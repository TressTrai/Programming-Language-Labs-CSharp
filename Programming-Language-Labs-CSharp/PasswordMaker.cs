using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Programming_Language_Labs_CSharp
{
    internal class PasswordMaker : StringMaker
    {
        private string login;

        // Конструктор по умолчанию
        public PasswordMaker()
        {
            login = RandomLogin();
        }

        // Конструктор с параметрами
        public PasswordMaker(string userLogin, string userPassword) : base(userPassword)
        {
            login = userLogin;
        }

        // Проверка сложности пароля
        public void CheckComplexity()
        {
            int count = base.ToString().Split('!').Length - 1;

            if (count < 3) {
                Console.WriteLine($"Твой пароль слишком прост: {base.ToString()}, знаков восклицания: {count}");
                AddThreeExclamation();
                Console.WriteLine($"Ваш новый пароль: {base.ToString()}");
            }
            else
            {
                Console.WriteLine("Твой пароль очень сложный");
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
                Console.WriteLine("Строка без кириллицы.");
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
