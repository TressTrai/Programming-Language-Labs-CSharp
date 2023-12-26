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
        // Создание строкового списка
        private static List<string> CreateList(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("Строка - элемент списка");
            Console.Write("Пустой энтер - прекращение ввода");

            return ReadFromUser.StringList("");

        }
        
        // Вывод списка
        private static void PrintList<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        // Замена первого вхождения списка другим списком
        private static List<T> ReplaceFirstOccurrence<T>(List<T> L, List<T> L1, List<T> L2)
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
                if (found) // Если переменная осталась true после цикла проверки вхождения, значит, последовательность L1 найдена
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                L.RemoveRange(index, L1.Count); // Удаляем подпоследовательность
                L.InsertRange(index, L2); // Вставляем подпоследовательность
            }
            return L;
        }

        // Создание связанного списка
        private static LinkedList<string> CreateLinkedList(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("Строка - элемент списка");
            Console.Write("Пустой энтер - прекращение ввода");

            return ReadFromUser.StringLinkedList("");

        }

        // Сортировка связанного списка
        static LinkedList<T> SortLinkedList<T>(LinkedList<T> list)
        {
            List<T> tempList = new List<T>(list); // Преобразуем в обычный список
            tempList.Sort(); 
            return new LinkedList<T>(tempList);
        }

        // Вывод связанного списка
        private static void PrintLinkedList<T>(LinkedList<T> list)
        {
            foreach (var el in list)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }

        // Вывод множества
        private static void OutPutHashSetGames(string msg, HashSet<string> set)
        {
            Console.WriteLine(msg);
            if (set.Count != 0)
            {
                foreach (var el in set)
                {
                    Console.WriteLine(el);
                }
            }
            else
            {
                Console.WriteLine("Таких игр нет!");
            }
        }

        // Заполнение текстового файла текстом
        private static void FillTxtFilesByText(string filePath)
        {
            Console.WriteLine("\nНапишите строки файла.");
            Console.WriteLine("Пустая строка - выход");

            try
            {
                string temp;
                StreamWriter writer = new StreamWriter(File.Open(filePath, FileMode.Create));
                while ((temp = Console.ReadLine()) != "") // Если будет пустая строчка то выйдет из цикла
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

        // Проверка на наличие нужных букв
        private static bool CheckConsonantal(string filePath, HashSet<char> letters)
        {
            try
            {
                string line;
                char temp;
                StreamReader reader = new StreamReader(File.Open(filePath, FileMode.Open));
                while ((line = reader.ReadLine()) != null) // По строчно считываем
                {
                    foreach (char c in line) // Проверяем каждый символ в строке
                    {
                        temp = Char.ToUpper(c); // Подгоняем под стандарты (ну, чтобы, не парится маленькая буква или большая)
                        if (letters.Contains(temp)) // Если есть, то убираем, по моему логично
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
                Console.WriteLine(ex);
                return false;
            }

        }

        // Поиск максимального значения в словаре
        private static void FindMaxValue(Dictionary<string, int> dict)
        {

            int max = int.MinValue;

            foreach (var el in dict)
            {
                if (el.Value > max)
                {
                    max = el.Value;
                }
            }

            Console.WriteLine($"Участники, набравшие макс количество баллов: ");

            foreach (var el in dict)
            {
                if (el.Value == max) // Если набрано максимальное количество, то выводим
                {
                    Console.WriteLine("     " + el.Key);
                }
            }
            
        }

        // Чтение из файла в словарь
        private static Dictionary<string, int> ReadInfoFromContest(string filePath)
        {
            Dictionary<string, int> participants = new Dictionary<string, int>();

            try
            {
                string line;
                string[] SplitLine;
                string name;
                int scores, score1, score2, score3;
                int n;
                StreamReader reader = new StreamReader(File.Open(filePath, FileMode.Open));

                bool success_n = int.TryParse(reader.ReadLine(), out n);

                if (!success_n)
                {
                    Console.WriteLine("Не удалось сконвертировать в число");
                    reader.Close();
                    return null;
                }

                if (n > 250 || n < 1)
                {
                    Console.WriteLine("Некорректное число участников");
                    reader.Close();
                    return null;
                }

                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();

                    if (line == null)
                    {
                        Console.WriteLine("Недостаточно данных об участниках");
                        reader.Close();
                        return null;
                    }

                    SplitLine = line.Split(" ");

                    if (SplitLine.Length != 5)
                    {
                        Console.WriteLine("Некорректное число элементов в строке");
                        reader.Close();
                        return null;
                    }

                    if (SplitLine[0].Length > 20)
                    {
                        Console.WriteLine("Фамилия слишком длинная");
                        reader.Close();
                        return null;
                    }

                    if (SplitLine[1].Length > 15)
                    {
                        Console.WriteLine("Имя слишком длинное");
                        reader.Close();
                        return null;
                    }

                    name = SplitLine[0] + " " + SplitLine[1];

                    bool success_s1 = int.TryParse(SplitLine[2], out score1);
                    bool success_s2 = int.TryParse(SplitLine[3], out score2);
                    bool success_s3 = int.TryParse(SplitLine[4], out score3);

                    if (!(success_s1 &&  success_s2 && success_s3))
                    {
                        Console.WriteLine("Не удалось конвертировать баллы в числа");
                        reader.Close();
                        return null;
                    }

                    if (score1 > 25 || score2 > 25 || score3 > 25 || score1 < 0 || score2 < 0 || score3 < 0)
                    {
                        Console.WriteLine("Тут явно кто-то считерил, что-то не так с баллами");
                        reader.Close();
                        return null;
                    }

                    scores = score1 + score2 + score3;
                    participants.Add(name, scores);
                }
                reader.Close();
                return participants;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при обработке данных файла: " + ex);
                return null;
            }
        }

        // Вывод первого задания
        public static void Task1()
        {
            Console.WriteLine("\n------------------------------ Задание 1 ------------------------------");
            
            // Создание списков
            List<string> L = CreateList("Список L");
            List<string> L1 = CreateList("Список L1");
            List<string> L2 = CreateList("Список L2");

            // Вывод данных списков
            Console.Write("Начальный список L: ");
            PrintList(L);

            Console.Write("Список вхождения L1: ");
            PrintList(L1);

            Console.Write("Список замены L2: ");
            PrintList(L2);

            // Замена первого вхождения 
            L = ReplaceFirstOccurrence(L, L1, L2);

            // Вывод конечного списка
            Console.Write("Изменненный список L: ");
            PrintList(L);

            Console.WriteLine("-----------------------------------------------------------------------");
        }

        // Вывод второго задания
        public static void Task2()
        {
            Console.WriteLine("\n------------------------------ Задание 2 ------------------------------");
            LinkedList<string> linky = CreateLinkedList("Связанный список");

            Console.WriteLine("Изначальный список: ");
            PrintLinkedList(linky);

            linky = SortLinkedList(linky);

            Console.WriteLine("Отсортированный список: ");
            PrintLinkedList(linky);
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        // Вывод третьего задания
        public static void Task3()
        {
            Console.WriteLine("\n------------------------------ Задание 3 ------------------------------");
            // Общее множество игр
            HashSet<string> games = new HashSet<string> { "Valorant", "Minecraft", "Genshin Impact", "Factorio", "Stardew Valley", "Starbound", "Terraria", "Doom", "PustozerskVR", "NyaganVR", "KrotuvaGame" };

            // Студенты группы
            HashSet<string> student1 = new HashSet<string> { "Valorant", "Genshin Impact" };
            HashSet<string> student2 = new HashSet<string> { "Minecraft", "Factorio","Terraria", "Doom","KrotuvaGame" };
            HashSet<string> student3 = new HashSet<string> { "Valorant", "Minecraft", "Genshin Impact", "PustozerskVR", "NyaganVR", "KrotuvaGame" };
            HashSet<string> student4 = new HashSet<string> { "Minecraft"};

            // Игры в которые все играют
            HashSet<string> LoveGame = new HashSet<string> (student1);
            LoveGame.IntersectWith(student2);
            LoveGame.IntersectWith(student3);
            LoveGame.IntersectWith(student4);
            OutPutHashSetGames("Любимые игры группы: ", LoveGame);

            Console.WriteLine();

            // Игры в которые никто не играет
            HashSet<string> HateGame = new HashSet<string>(games);
            HateGame.ExceptWith(student1);
            HateGame.ExceptWith(student2);
            HateGame.ExceptWith(student3);
            HateGame.ExceptWith(student4);
            OutPutHashSetGames("Непопулярные игры группы: ", HateGame);

            Console.WriteLine();

            // Игры кто хоть кто-то играет, но не все
            HashSet<string> SoSoGame = new HashSet<string>(games);
            SoSoGame.ExceptWith(HateGame);
            SoSoGame.ExceptWith(LoveGame);
            OutPutHashSetGames("Относительно популярные игры группы: ", SoSoGame);

            Console.WriteLine("-----------------------------------------------------------------------");
        }

        // Вывод четвертого задания
        public static void Task4()
        {
            Console.WriteLine("\n------------------------------ Задание 4 ------------------------------");

            HashSet<char> consonantalDullLetters = new HashSet<char>("КСПТФХЧШЩЦ"); // Множество глухих согласных букв
            string filename = "Task4.txt"; 
            FillTxtFilesByText(filename); // Заполняем файл текстом

            if (!CheckConsonantal(filename, consonantalDullLetters))
                return;

            if (consonantalDullLetters.Count == 0) // Если не осталось букв, значит они все использованы
            {
                Console.WriteLine("\nВсе глухие согласные задействованы");
            } 
            else
            {
                Console.WriteLine("Глухие согласные, которые не входят в слова: ");
                foreach (var el in consonantalDullLetters) // Выводим эту красоту
                {
                    Console.Write(el);
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        // Вывод пятого задания
        public static void Task5()
        {
            Console.WriteLine("\n------------------------------ Задание 5 ------------------------------");
            Dictionary<string, int> participants = ReadInfoFromContest("Task5.txt");

            if (participants != null)
                FindMaxValue(participants);

            Console.WriteLine("-----------------------------------------------------------------------");
        }
    }

}

