using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Language_Labs_CSharp
{
    internal class ReadFromUser
    {
        public static uint UInt(string msg)
        {
            Console.WriteLine($"{msg}");
            uint result;

            do
            {
                Console.Write("   Введите положительное число: ");
                string input = Console.ReadLine();

                // Пытаемся преобразовать введенное значение в int
                bool isParsed = uint.TryParse(input, out result);

                // Проверяем, что введено положительное число
                if (isParsed)
                {
                    // Введено корректное положительное число
                    break;
                }
                else
                {
                    Console.WriteLine("   Ошибка! Введите корректное значение [0; 4294967295]");
                }
            } while (true);

            return result;
        }

        public static byte Byte(string msg)
        {
            Console.WriteLine($"{msg}");
            byte result;

            do
            {
                Console.Write("   Введите положительное число: ");
                string input = Console.ReadLine();

                // Пытаемся преобразовать введенное значение в byte
                bool isParsed = byte.TryParse(input, out result);

                // Проверяем, что введено положительное число от 0 до 255
                if (isParsed)
                {
                    // Введено корректное значение для byte
                    break;
                }
                else
                {
                    Console.WriteLine("   Ошибка! Введите корректное значение [0; 255]");
                }
            } while (true);

            return result;
        }

        public static int Int(string msg)
        {
            Console.WriteLine($"{msg}");
            int result;

            do
            {
                Console.Write("     Введите целочисленное число: ");
                string input = Console.ReadLine();

                // Пытаемся преобразовать введенное значение в int
                bool isParsed = int.TryParse(input, out result);

                // Проверяем, что введено положительное число
                if (isParsed)
                {
                    // Введено корректное положительное число
                    break;
                }
                else
                {
                    Console.WriteLine("   Ошибка! Введите корректное значение");
                }
            } while (true);

            return result;
        }

        public static int IntDiap(string msg, int min, int max)
        {
            Console.WriteLine($"{msg}");
            int result;

            do
            {
                Console.Write($"   Введите число от {min} до {max}: ");
                string input = Console.ReadLine();

                // Пытаемся преобразовать введенное значение в int
                bool isParsed = int.TryParse(input, out result);

                // Проверяем, что введено положительное число
                if (isParsed)
                {
                    if (result >= min && result <= max)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("   Ошибка! Введите число в заданном диапозоне!");
                    }
                }
                else
                {
                    Console.WriteLine("   Ошибка! Введите число!");
                }
            } while (true);

            return result;
        }

        public static List<string> StringList(string msg)
        {

            Console.WriteLine($"{msg}");
            List<string> result = new List<string>();

            do
            {
                string line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    if (result.Count == 0)
                        continue;
                    else
                        break;
                }

                result.Add(line);

            } while (true);

            return result;
        }

    }
}
