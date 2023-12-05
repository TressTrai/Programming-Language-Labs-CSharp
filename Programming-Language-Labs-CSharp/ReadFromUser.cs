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
                    Console.WriteLine("   Ошибка! Введите корректное значение [1; 255]");
                }
            } while (true);

            return result;
        }

    }
}
