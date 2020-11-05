using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace TODOlite
{
    static class decryppter
    {
        public static string GetContent(string input)
        {
            //Example 1 !2
            if(input.Contains("!")){
                if(input.IndexOf("!1") >= 0) return input.Replace("!1","");
                if(input.IndexOf("!2") >= 0) return input.Replace("!2","");
                if(input.IndexOf("!3") >= 0) return input.Replace("!3","");
            }
            return input;
        }
        public static int GetPriority(string input)
        {
            //Example 1 !2
            if (input.Contains("!"))
            {
                if (input.LastIndexOf("!") >= 0)
                {
                    var lastIndex = input.LastIndexOf("!");
                    if(input.Substring(lastIndex + 1).Count() > 0)
                    {
                        var priorityString = input.Substring(lastIndex + 1,1);
                        _ = int.TryParse(priorityString, out int output);
                        return output;
                    }
                }

            }
            return 0;
        }

    }
}
