using System;
using System.Linq;
using System.Text;

namespace SumOfBigNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number1 = Console.ReadLine();
            string number2 = Console.ReadLine();

            if (number1.Length < number2.Length)
            {
                number1 = ResizeString(number1, number2.Length - number1.Length);
            }
            else if(number1.Length > number2.Length)
            {
                number2 = ResizeString(number2, number1.Length - number2.Length);
            }

            StringBuilder result = new StringBuilder(new string('0', number1.Length));
            byte sum = 0;

            for (int i = number1.Length - 1; i >= 0; i--)
            {
                sum = (byte)((Convert.ToByte(number1[i].ToString()) + Convert.ToByte(number2[i].ToString())) + sum);

                if (sum >= 10)
                {
                    sum = (byte)(sum % 10);
                    result[i] = Convert.ToChar(sum.ToString());
                    sum = 1;
                }
                else
                {
                    result[i] = Convert.ToChar(sum.ToString());
                    sum = 0;
                }
            }

            if (sum == 1)
            {
                result.Insert(0, '1');
            }

            Console.WriteLine(result.ToString());
        }

        static string ResizeString(string number, int newLength)
        {
            // return number.Insert(0, new string('0', newLength).ToCharArray().ToList());
            return number.Insert(0, new string('0', newLength));
        }

    }
}
