//Разработать класс с одним строковым полем. Создать конструктор
//копирования.Разработать метод, приписывающий к полю в начало три
//знака восклицания. Перегрузить метод ToString() для формирования
//строки из полей класса. Реализовать дочерний класс (его содержание
//предложить самостоятельно и описать в решении: какой содержательный
//смысл имеют поля; реализовать конструкторы; предложить и реализовать
//2-3 метода). Протестировать все конструкторы и другие методы базового и
//дочернего классов.
using Programming_Language_Labs_CSharp;

internal class Program
{
    internal static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать на регистрацию на сайт https://TressTrai.com !!!");
        Console.WriteLine("Он правда еще не открылся, но форму регистрации надо сейчас отработать :)");
        Console.WriteLine("Правила:");
        Console.WriteLine("1) В логине никакой кирилицы, карается сменой логина");
        Console.WriteLine("2) Мы заботимся о сложности ваших паролей, поэтому в пароли необходимо использовать как минимум три знака восклицания, карается добавлением знаков восклицания в ваш пароль");
        Console.WriteLine("Удачи :)\n");

        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Класс StringMaker | Проверка конструктора по умолчанию");
        var string1 = new StringMaker();
        Console.WriteLine(string1.ToString());
        Console.WriteLine("----------------------------------------------------------\n");



        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Класс StringMaker | Проверка метода добавления \"!!!\"");
        var string2 = new StringMaker("Привет!!!");
        Console.WriteLine($"До метода: {string2.ToString()}");
        string2.AddThreeExclamation();
        Console.WriteLine($"После метода: {string2.ToString()}");
        Console.WriteLine("----------------------------------------------------------\n");



        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Класс StringMaker | Проверка конструктора копирования");
        var string3 = new StringMaker(string2);
        Console.WriteLine(string2.ToString());
        Console.WriteLine("----------------------------------------------------------\n");



        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Класс Register | Проверка конструктора по умолчанию");
        var user1 = new Register();
        Console.WriteLine(user1.ToString());
        Console.WriteLine("----------------------------------------------------------\n");



        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Класс Register | Проверка конструктора c параметрами");
        var user2 = new Register("ТрессТраи", "йцукен123456");
        Console.WriteLine(user2.ToString());
        Console.WriteLine("----------------------------------------------------------\n");



        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Класс Register | Проверка метода проверки сложности пароля");

        Console.WriteLine();

        var user3 = new Register("Юзер1", "gdkje234hlHehwIhqw3j12");
        Console.WriteLine(user3.ToString());
        user3.CheckComplexity();

        Console.WriteLine();

        var user32 = new Register("Юзер2", "qwerty!!!");
        Console.WriteLine(user32.ToString());
        user32.CheckComplexity();

        Console.WriteLine();

        var user33 = new Register("Юзер3", "!qwerty!");
        Console.WriteLine(user33.ToString());
        user33.CheckComplexity();

        Console.WriteLine();

        var user34 = new Register("Юзер4", "");
        Console.WriteLine(user34.ToString());
        user34.CheckComplexity();
        Console.WriteLine("----------------------------------------------------------\n");



        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Класс Register | Проверка метода нового логина");
        var user4 = new Register("ТрессТраи", "**********");
        Console.WriteLine(user4.RandomLogin());
        Console.WriteLine("----------------------------------------------------------\n");


        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Класс Register | Проверка метода проверки логина на разрешимые символы");
        var user5 = new Register("ТрессТраи", "**********");
        Console.WriteLine($"До метода:\n{user5.ToString()}\n");
        user5.CheckAllowChar();
        Console.WriteLine($"\nПосле метода:\n{user5.ToString()}");

        var user6 = new Register("TressTrai", "**********");
        Console.WriteLine($"До метода:\n{user6.ToString()}\n");
        user6.CheckAllowChar();
        Console.WriteLine($"\nПосле метода:\n{user6.ToString()}");

        Console.WriteLine("----------------------------------------------------------\n");

    }
}
