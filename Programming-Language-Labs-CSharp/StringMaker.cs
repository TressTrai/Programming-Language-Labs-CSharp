using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Language_Labs_CSharp
{
    internal class StringMaker
    {
        private string data;

        // Конструктор по умолчанию
        public StringMaker()
        {
            data = "qwerty";
        }

        // Конструктор для строки
        public StringMaker(string other)
        {
            data = other;
        }

        // Конструктор копирования
        public StringMaker(StringMaker other)
        {
            data = other.data;
        }

        // Метод для добавления трех восклицательных знаков в начало строки
        protected void AddThreeExclamation()
        {
            data = "!!!" + data;
        }

        // Перегрузка метода ToString
        public override string ToString()
        {
            return $"{data}";
        }
    }
}
