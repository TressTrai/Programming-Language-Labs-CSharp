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

        private static void PrintList<T>(List<T> list)
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

        private static LinkedList<string> CreateLinkedList(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("Начинайте вводить строки для формирования списка ниже...");
            Console.WriteLine("Когда ввод нужно будет закончить - отправьте пустую строку.");

            return ReadFromUser.StringLinkedList("Введите список");

        }

        static LinkedList<string> SortLinkedList(LinkedList<string> list)
        {
            List<string> tempList = new List<string>(list);
            tempList.Sort();
            return new LinkedList<string>(tempList);
        }

        private static void PrintLinkedList<T>(LinkedList<T> list)
        {
            foreach (var el in list)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }

        private static void fillHashSetGames()
        {
            Console.WriteLine("\nНапишите названия компьютерных игр. Чтобы закончить напишите пустую строку.\n\n");
            HashSet<string> games = new HashSet<string> { "Valorant", "Minecraft", "Genshin Impact", "Factorio", "Stardew Valley", "Starbound", "Terraria", "Doom", "PustozerskVR", "NyaganVR", "KrotuvaGame" };


            Console.WriteLine("\nНапишите предпочтения каждого студента в одной строке, разделяя игры с помощью \";\". \nЧтобы закончить напишите пустую строку.\n\n");
            HashSet<HashSet<string>> studentChoices = new HashSet<HashSet<string>> { };
        }

        // Заполнение текстового файла текстом
        private static void FillTxtFilesByText(string filePath)
        {
            Console.WriteLine("\nНапишите строки файла. Чтобы закончить напишите пустую строку.\nВведите содержание файла.\n");

            try
            {
                string temp;
                StreamWriter writer = new StreamWriter(File.Open(filePath, FileMode.Create));
                while ((temp = Console.ReadLine()) != "")
                {
                    writer.WriteLine(temp);
                }
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }


        private static bool CheckLetters(string filePath, HashSet<char> letters)
        {
            try
            {
                string line;
                char temp;
                StreamReader reader = new StreamReader(File.Open(filePath, FileMode.Open));
                while ((line = reader.ReadLine()) != null)
                {
                    foreach (char c in line)
                    {
                        temp = Char.ToUpper(c);
                        if (letters.Contains(temp))
                        {
                            letters.Remove(temp);
                        }
                    }
                }
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при обработке данных файла: " + ex);
                return false;
            }

        }

        public static void Task1()
        {
            Console.WriteLine("\n------------------------------ Задание 1 ------------------------------");
            List<string> L = CreateList("Список L");
            List<string> L1 = CreateList("Список L1");
            List<string> L2 = CreateList("Список L2");

            L = ReplaceFirstOccurrence(L, L1, L2);

            PrintList(L);

            Console.WriteLine("-----------------------------------------------------------------------");
        }
        public static void Task2()
        {
            Console.WriteLine("\n------------------------------ Задание 2 ------------------------------");
            LinkedList<string> linky = CreateLinkedList("Связанный список");
            linky = SortLinkedList(linky);
            PrintLinkedList(linky);
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

            HashSet<char> letters = new HashSet<char>("КСПТФХЧШЩЦ");
            string filename = "File4.txt";
            FillTxtFilesByText(filename);
            if (!CheckLetters(filename, letters))
                return;
            if (letters.Count == 0)
            {
                Console.WriteLine("\nВсе глухие согласные входят хотя бы в одно слово");
                return;
            }

            Console.WriteLine("\nГлухие согласные, которые не входят в слова: ");
            foreach (var let in letters)
            {
                Console.Write($"{let} ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------");
        }
        public static void Task5()
        {
            Console.WriteLine("\n------------------------------ Задание 5 ------------------------------");

            Console.WriteLine("-----------------------------------------------------------------------");
        }
    }

}

