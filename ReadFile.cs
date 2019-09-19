﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
