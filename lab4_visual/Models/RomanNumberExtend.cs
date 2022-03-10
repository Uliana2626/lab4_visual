using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_visual.Models
{
    class RomanNumberExtend : RomanNumber
    {
        private static short[] Tens = new short[]
        { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };


        private static string[] Romes = new string[]
        { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        public RomanNumberExtend(string number) : base(ToUShort(number)) { }
        private static ushort ToUShort(string x)
        {
            short t = 0;
            string t2 = x;
            for (int i = 0; i < Romes.Length;)
            {
                if (t2.Contains(Romes[i]))
                {
                    int t1 = t2.IndexOf(Romes[i][0]);
                    t2 = t2.Remove(t1, Romes[i].Length);
                    t += Tens[i];
                }
                else
                {
                    ++i;
                }
            }
            return ((ushort)t);
        }
    }
}
