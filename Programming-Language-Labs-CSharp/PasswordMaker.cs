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
        private string derivedField;

        // Конструктор по умолчанию
        public PasswordMaker()
        {
            derivedField = " ";
        }

        // Конструктор с параметрами
        public PasswordMaker(string derivedValue, string baseValue) : base(baseValue)
        {
            derivedField = derivedValue;
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


        public override string ToString()
        {
            return $"Логин: {derivedField}" + "\n" + $"Пароль: {base.ToString()}" ;
        }
    }
}
