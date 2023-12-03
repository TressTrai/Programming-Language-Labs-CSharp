using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Language_Labs_CSharp
{
    internal class StringMaker
    {
        private string baseField;

        // Конструктор по умолчанию
        public StringMaker()
        {
            baseField = "Default";
        }

        // Конструктор копирования
        public StringMaker(StringMaker other)
        {
            baseField = other.baseField;
        }

        // Метод для добавления трех восклицательных знаков в начало строки
        public void AddThreeExclamation()
        {
            baseField = "!!!" + baseField;
        }

        // Перегрузка метода ToString
        public override string ToString()
        {
            return $"Name: {baseField}";
        }
    } //password
}
