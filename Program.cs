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
            string value = Console.ReadLine();
            switch(value)
            {
                case "1":
                    read.step1();
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }
    }
}
