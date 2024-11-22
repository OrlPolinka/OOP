using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using lab8;

namespace lab8
{
    public static class String
    {
        public static string str {  get; set; }

        public static void RemovePunctuation()
        {
            str = Regex.Replace(str, $"[!?.,;:]", "");
            Console.WriteLine(str);
        }

        public static void RemoveSpace()
        {
            str = Regex.Replace(str, $" ", "");
            Console.WriteLine(str);
        }

        public static void ToUpperLetter()
        {
            str = str.ToUpper();
            Console.WriteLine(str);
        }

        public static bool ContainsExample(string input)
        {
            return input.Contains("Строка", StringComparison.OrdinalIgnoreCase);
        }

        public static void ToLowerLetter()
        {
            str = str.ToLower();
            Console.WriteLine(str);
        }

        public static string AddString(string input, string newStr)
        {
            return input + newStr;
        }
    }
}
