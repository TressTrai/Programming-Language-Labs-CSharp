using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Programming_Language_Labs_CSharp
{
    internal class Register : StringMaker
    {
        private string login;

        // Конструктор по умолчанию
        public Register()
        {
            login = RandomLogin();
        }

        // Конструктор с параметрами
        public Register(string userLogin, string userPassword) : base(userPassword)
        {
            login = userLogin;
        }

        // Проверка сложности пароля
        public void CheckComplexity()
        {
            int count = base.ToString().Split('!').Length - 1;

            if (count < 3) {
                Console.WriteLine($"Ваш пароль слишком прост");
                Console.WriteLine($"Знаков восклицания: {count} < 3");
                Console.WriteLine($"Генерация нового пароля...");
                AddThreeExclamation();
                Console.WriteLine($"Ваш новый пароль: {base.ToString()}");
            }
            else
            {
                Console.WriteLine("Ваш пароль очень сложный");
            }
        }

        public void CheckAllowChar()
        {
            string cyrylic = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
            if (login.IndexOfAny(cyrylic.ToCharArray()) != -1)
            {
                Console.WriteLine("В логине содержаться элементы кирилицы!");
                login = RandomLogin();
                Console.WriteLine($"Ваш новый логин: {login}");
            }

            else
                Console.WriteLine("Ваш логин подходит!");
        }

        public string RandomLogin()
        {
            Random random = new Random();
            int id = random.Next(1000, 9999);
            return "user" + id.ToString();
        }

        public override string ToString()
        {
            return $"Логин: {login}" + "\n" + $"Пароль: {base.ToString()}" ;
        }
    }
}
