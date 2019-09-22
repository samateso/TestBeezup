using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matesoBeezupTest
{
    public class Values
    {
        public int lineNumber { get; set; }
        public string type { get; set; }
        public string concatAB { get; set; }
        public int? sumCD { get; set; }
        public string errorMessage { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("lineNumber : " + lineNumber);
            stringBuilder.AppendLine("type : " + type);
            if(concatAB != null)
            {
                stringBuilder.AppendLine("concatAB : " + concatAB);
            }
            if(sumCD != null)
            {
                stringBuilder.AppendLine("sumCD : " + sumCD);
            }
            if(errorMessage != null)
            {
                stringBuilder.AppendLine("errorMessage : " + errorMessage);
            }
            return stringBuilder.ToString();
        }
    }
}
