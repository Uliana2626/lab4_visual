using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_visual.Models
{
    public class RomanNumber : ICloneable, IComparable
    {
        private ushort ten;
        public RomanNumber(ushort n) //Конструктор получает число n, которое должен представлять объект класса
        {
            if (n <= 0 || n > 3999)
                throw new RomanNumberException("The number must be from 0 to 3999");
            else ten = n;
        }

        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2) //Сложение римских чисел
        {
            ushort add;
            add = (ushort)(n1.ten + n2.ten);
            if (add > 3999) throw new RomanNumberException("Result > 3999");
            else
            {
                RomanNumber rez = new(add);
                return rez;
            }
        }

        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2) //Вычитание римских чисел
        {
            short sub;
            sub = (short)(n1.ten - n2.ten);
            if (sub <= 0) throw new RomanNumberException("Result <= 0");
            else
            {
                RomanNumber rez = new((ushort)sub);
                return rez;
            }
        }

        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2) //Умножение римских чисел
        {
            ushort mul;
            mul = (ushort)(n1.ten * n2.ten);
            if (mul > 3999) throw new RomanNumberException("Result > 3999");
            else
            {
                RomanNumber rez = new(mul);
                return rez;
            }
        }

        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2) //Целочисленное деление римских чисел
        {
            ushort div;
            div = (ushort)(n1.ten / n2.ten);
            if (div <= 0) throw new RomanNumberException("Result <= 0");
            else
            {
                RomanNumber rez = new(div);
                return rez;
            }
        }

        public override string ToString() //Возвращает строковое представление римского числа
        {
            short[] number = new short[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] numeral = new string[]
                { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            StringBuilder roman = new();
            short n = (short)ten;

            for (int i = 0; i < 13; i++)
            {
                while (n >= number[i])
                {
                    n -= number[i];
                    roman.Append(numeral[i]);
                }
            }
            return roman.ToString();
        }

        public object Clone() //Реализация интерфейса IClonable
        {
            return new RomanNumber(ten);
            //throw new RomanNumberException("");
        }

        public int CompareTo(object? obj) //Реализация интерфейса IComparable
        {
            if (obj is RomanNumber romanNumber) return ((short)ten).CompareTo((short)romanNumber.ten);
            else throw new RomanNumberException("Error");
        }
    }
}
