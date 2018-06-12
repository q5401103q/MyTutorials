using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.International.Converters.PinYinConverter;

namespace ChineseCharacter_Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "變";
            Console.WriteLine("{0}共{1}画", str, GetStringStrokeNumber(str));

            Console.Read();
        }

        public static int GetStringStrokeNumber(string str)
        {
            int count = 0;
            char[] c = str.ToCharArray();
            foreach(char temp in c)
            {
                count += ChineseChar.GetStrokeNumber(temp);
            }
            return count;
        }
    }
}
