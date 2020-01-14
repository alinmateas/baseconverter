using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp3
{
    class Program
    {

        static void Main(string[] args)
        {
            //int x = baseConvert(21,2);
            //Console.WriteLine(x);
            //floatAssign(0.375f, 2);
            //long x = Convert_b_10("1110", 2, 0);
            //Console.WriteLine(x);
            //Console.ReadKey();
            float fnumber = 14.375f;

            int inumber = baseConvert_1_10_b((int)fnumber, 2);

            floatAssign(getDecimal(fnumber), 2);

            

        }

        private static float getDecimal(float fnumber)
        {
            int multiplier = 1000;
            double double_value = fnumber;
            int double_result = (int)((double_value - (int)double_value) * multiplier);
            return (float)double_result/1000;
        }

        public static int baseConvert_1_10_b(int nr, int baza)
        {
            if (nr == 0)
            {
                return nr;
            }
           
            return nr % baza + 10 * baseConvert_1_10_b(nr / baza, baza);
            
        }

        public static void floatAssign(float x, int baza)
        {
            float z=0;
            z = baseConvert_1_10_b(14, 2);
            Console.WriteLine(z);
            while (x != 1)
            {
                x = x * baza;
                z = z * 10 + (int)(x);
                if (x > 1) { x = x - (int)(x); }  // VERIFICARE CAZURI SPECIALE
            }

            Console.WriteLine((float)z/1000);
            Console.ReadKey();
        }


        private static long Convert_b_10(string numar, int baza, int i)
        {
            if (numar.Length == 0) return 0;
            
            int putere = (int)Math.Pow(baza, i);

            return GetDigitValue(numar[numar.Length-1]) * putere + Convert_b_10(numar.Substring(0,numar.Length-1), baza, i+=1);
        }


        private static long GetDigitValue(char v)
        {
            if (v >= '0' && v <= '9')
                return v - '0';
            else if (v >= 'A' && v <= 'F')
                return v - 'A' + 10;
            else
                return 0;
        }


        private static string Convert_10_16_b(int n, int baza)
        {
            int rest;
            int cifra;
            Stack<int> stack = new Stack<int>();
            while (n > 0)
            {
                rest = n % baza;
                stack.Push(rest);
                n = n / baza;
            }

            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                cifra = stack.Pop();
                sb.Append((char)('A' + (cifra - 10)));
                //sb.Append(cifra.ToString("X"));
            }

            return sb.ToString();
        }


    }
}
