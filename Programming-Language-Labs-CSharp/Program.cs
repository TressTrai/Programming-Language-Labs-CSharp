using Programming_Language_Labs_CSharp;
using System;
using System.Data;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

internal class Program
{
    internal static void Main(string[] args)
    {
        uint ReadIntFromUser(string msg)
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
                if (isParsed && result > 0)
                {
                    // Введено корректное положительное число
                    break;
                }
                else
                {
                    Console.WriteLine("   Ошибка! Введите корректное значение [1; 4294967295]");
                }
            } while (true);


            Console.WriteLine();
            return result;
        }

        byte ReadByteFromUser(string msg)
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

            Console.WriteLine();
            return result;
        }

        //Console.Write("Вызов Money(): ");
        //Money money1 = new Money();
        //Console.Write(money1.ToString());//выводится объект класса Money

        //Console.Write("Вызов Money(234, 202): ");
        //Money am1 = new Money(234, 202);
        //Console.Write(am1.ToString());
        //Console.WriteLine();

        
        uint user_rub = ReadIntFromUser("Ввод рублей");

        byte user_kop = ReadByteFromUser("Ввод копеек");

        Money user_money = new Money(user_rub, user_kop);
        Console.WriteLine($"Переменная user_money = {user_money.ToString()}");

        uint user_add_kop = ReadIntFromUser("Добавление копеек");

        user_money.AddKopeeks(user_add_kop);

        Console.WriteLine($"Итоговая сумма: {user_money.ToString()}");
    }
}
