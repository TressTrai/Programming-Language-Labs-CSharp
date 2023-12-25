using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Language_Labs_CSharp
{
    internal class FileFunction
    {
        private static List<string> CreateList(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("Начинайте вводить строки для формирования списка ниже...");
            Console.WriteLine("Когда ввод нужно будет закончить - отправьте пустую строку.");

            return ReadFromUser.StringList("Введите список");

        }

        private static void PrintStringList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i] + " ");
            }
        }

        static List<T> ReplaceFirstOccurrence<T>(List<T> L, List<T> L1, List<T> L2)
        {
            int index = -1;
            for (int i = 0; i <= L.Count - L1.Count; i++)
            {
                bool found = true;
                for (int j = 0; j < L1.Count; j++)
                {
                    if (!(L[i + j].Equals(L1[j])))
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                L.RemoveRange(index, L1.Count);
                L.InsertRange(index, L2);
            }
            return L;
        }



        public static void Task1()
        {
            Console.WriteLine("\n------------------------------ Задание 1 ------------------------------");
            List<string> L = CreateList("Список L");
            List<string> L1 = CreateList("Список L1");
            List<string> L2 = CreateList("Список L2");

            L = ReplaceFirstOccurrence(L, L1, L2);

            PrintStringList(L);

            Console.WriteLine("-----------------------------------------------------------------------");
        }
        public static void Task2()
        {
            Console.WriteLine("\n------------------------------ Задание 2 ------------------------------");

            Console.WriteLine("-----------------------------------------------------------------------");
        }
        public static void Task3()
        {
            Console.WriteLine("\n------------------------------ Задание 3 ------------------------------");

            Console.WriteLine("-----------------------------------------------------------------------");
        }
        public static void Task4()
        {
            Console.WriteLine("\n------------------------------ Задание 4 ------------------------------");

            Console.WriteLine("-----------------------------------------------------------------------");
        }
        public static void Task5()
        {
            Console.WriteLine("\n------------------------------ Задание 5 ------------------------------");

            Console.WriteLine("-----------------------------------------------------------------------");
        }
    }

}

