using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace matesoBeezupTest
{
    public class ReadFile
    {

        String Path = null;
        public ReadFile()
        {
            Path = ConfigurationManager.AppSettings["FilePath"];
        }

        public void step1()
        {
            if(Path != null)
            {
                using (var reader = new StreamReader(Path))
                using (var csv = new CsvReader(reader))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        int colC = 0;
                        int colD = 0;

                        bool booleanColC = int.TryParse(csv.GetField("columnC"), out colC);
                        bool booleanColD = int.TryParse(csv.GetField("columnD"), out colD);

                        if(booleanColC && booleanColD)
                        {
                            int sum = colC + colD;

                            if (sum > 100)
                            {
                                Console.WriteLine("" + csv.GetField("columnA") + " " + csv.GetField("columnB"));
                            }
                        }                     
                    }
                }
            }
        }

        public List<Values> step2()
        {
            List<Values> vals = new List<Values>();
            if (Path != null)
            {
                using (var reader = new StreamReader(Path))
                using (var csv = new CsvReader(reader))
                {
                    int count = 0;
                    csv.Read();
                    csv.ReadHeader();

                    
                    while (csv.Read())
                    {
                        int colC = 0;
                        int colD = 0;

                        bool booleanColC = int.TryParse(csv.GetField("columnC"), out colC);
                        bool booleanColD = int.TryParse(csv.GetField("columnD"), out colD);

                        if (booleanColC && booleanColD)
                        {
                            int sum = colC + colD;

                            Values values = new Values();

                            if (sum > 100)
                            {
                                values.lineNumber = count;
                                values.sumCD = sum;
                                values.type = "ok";
                                values.concatAB = csv.GetField("columnA") + " " + csv.GetField("columnB");
                            }
                            else
                            {
                                values.lineNumber = count;
                                values.sumCD = sum;
                                values.type = "error";
                                values.errorMessage = "sum is less than 100";
                            }

                            vals.Add(values);
                        }
                    }

                    /*
                    JsonSerializerSettings jsonSerializer = new JsonSerializerSettings();
                    jsonSerializer.NullValueHandling = NullValueHandling.Ignore;
                    Console.WriteLine(JsonConvert.SerializeObject(vals, jsonSerializer));
                    */
                }
            }
            return vals;
        }

        public void step3(string type)
        {
            switch(type)
            {
                case "json":
                    JsonSerialize(step2());
                    break;
                case "text":
                    TextSerialize(step2());
                    break;
                case "xml":
                    XMLSerialize(step2());
                    break;
            }
        }

        private void JsonSerialize(List<Values> vals)
        {
            JsonSerializerSettings jsonSerializer = new JsonSerializerSettings();
            jsonSerializer.NullValueHandling = NullValueHandling.Ignore;
            Console.WriteLine(JsonConvert.SerializeObject(vals, jsonSerializer));
        }

        private void TextSerialize(List<Values> vals)
        {
            foreach(Values values in vals)
            {
                Console.WriteLine(values.ToString());
            }
        }

        private void XMLSerialize(List<Values> vals)
        {
            XmlSerializer xMLSerialize = new XmlSerializer(typeof(List<Values>));
            xMLSerialize.Serialize(Console.Out, vals);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
