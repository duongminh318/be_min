using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession7
{
    public static class StringExtensions
    {
        public static string ToUpperCaseFirstLetter(this string input, bool isUpcase)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            if (isUpcase)
            {
                return char.ToUpper(input[0]) + input.Substring(1);
            }
            return input;
        }
    }
}
