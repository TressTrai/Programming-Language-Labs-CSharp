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
        //Console.Write("Вызов Money(): ");
        //Money money1 = new Money();
        //Console.Write(money1.ToString());//выводится объект класса Money

        //Console.Write("Вызов Money(234, 202): ");
        //Money am1 = new Money(234, 202);
        //Console.Write(am1.ToString());
        //Console.WriteLine();

        
        uint user_rub = ReadFromUser.UInt("Ввод рублей");

        byte user_kop = ReadFromUser.Byte("Ввод копеек");

        Money user_money = new Money(user_rub, user_kop);
        Console.WriteLine($"Переменная user_money = {user_money.ToString()}");

        uint user_add_kop = ReadFromUser.UInt("Добавление копеек");

        //user_money.AddKopeeks(user_add_kop);

        Console.WriteLine($"Итоговая сумма: {user_money.ToString()}");

        Console.WriteLine((user_money - 10000).ToString());
        Console.WriteLine((10000 - user_money).ToString());
    }
}
