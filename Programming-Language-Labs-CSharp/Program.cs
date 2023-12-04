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
        // Тесты конструкторов
        Console.WriteLine("Конструктор по умолчанию");
        Money money1 = new Money();
        Console.WriteLine(money1.ToString());

        Console.WriteLine("\nКонструктор с сеттером по копейкам");
        Money money2 = new Money(1, 201);
        Console.WriteLine(money2.ToString());

        Console.WriteLine();

        // Ввод 
        uint user_rub = ReadFromUser.UInt("Ввод рублей");
        byte user_kop = ReadFromUser.Byte("Ввод копеек");

        Money user_money = new Money(user_rub, user_kop);
        Console.WriteLine($"Переменная user_money = {user_money.ToString()}");


        // Проверка методов
        Console.WriteLine("\nПроверка метода добавляющий копейки");
        uint user_add_kop = ReadFromUser.UInt(" Добавление копеек");
        user_money.AddKopeeks(user_add_kop);
        Console.WriteLine(user_money.ToString());


        Console.WriteLine("\nПроверка ++");
        user_money++;
        Console.WriteLine(user_money.ToString());

        Console.WriteLine("\nПроверка --");
        user_money--;
        Console.WriteLine(user_money.ToString());

        Console.WriteLine("\nРубли uint (явно)");
        uint temp_uint = (uint)user_money;
        Console.WriteLine(temp_uint);

        Console.WriteLine("\nКопейки double (неявно)");
        double temp_double = user_money;
        Console.WriteLine(temp_double);

        Console.WriteLine("\nMoney + Число");
        Console.WriteLine($"user_money = {user_money.ToString()}");
        uint user_add_rub_1 = ReadFromUser.UInt(" Добавление числа");
        Console.WriteLine($"user_money + Число = {(user_money + user_add_rub_1).ToString()}");

        Console.WriteLine("\nЧисло + Money");
        Console.WriteLine($"user_money = {user_money.ToString()}");
        uint user_add_rub_2 = ReadFromUser.UInt(" Добавление числа");
        Console.WriteLine($"Число + user_money = {(user_add_rub_2 + user_money).ToString()}");

        Console.WriteLine("\nMoney - Число");
        Console.WriteLine($"user_money = {user_money.ToString()}");
        uint user_sub_rub_1 = ReadFromUser.UInt(" Вычитание числа");
        Console.WriteLine($"user_money - Число = {(user_money - user_sub_rub_1).ToString()}");

        Console.WriteLine("\nЧисло - Money");
        Console.WriteLine($"user_money = {user_money.ToString()}");
        uint user_sub_rub_2 = ReadFromUser.UInt(" Вычитание из числа");
        Console.WriteLine($"Число - user_money = {(user_sub_rub_2 - user_money).ToString()}");


    }
}
