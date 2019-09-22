using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matesoBeezupTest
{
    class Program
    {
       
        static void Main(string[] args)
        {
            ReadFile read = new ReadFile();


            //Console.WriteLine(" 1 : Read file and concatenate");
            Console.WriteLine("Veuillez choisir un type de format de retour :");
            Console.WriteLine(" 1 : Format JSON");
            Console.WriteLine(" 2 : Format TEXTE");
            Console.WriteLine(" 3 : Format XML");
            //Console.WriteLine(" 2 : Read file and show json");
            string value = Console.ReadLine();
            switch(value)
            {
                case "1":
                    read.step3("json");
                    break;
                case "2":
                    read.step3("text");
                    //read.step2();
                    break;
                case "3":
                    read.step3("xml");
                    //read.step2();
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }
    }
}
