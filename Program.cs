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


            Console.WriteLine(" 1 : Read file and concatenate");
            Console.WriteLine(" 2 : Read file and show json");
            string value = Console.ReadLine();
            switch(value)
            {
                case "1":
                    read.step1();
                    break;
                case "2":
                    read.step2();
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }
    }
}
