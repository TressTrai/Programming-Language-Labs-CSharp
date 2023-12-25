using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Programming_Language_Labs_CSharp
{
    internal class FileFunction
    {
        public static void FillBinaryFile(string filePath)
        {
            Console.WriteLine("Создание бинарного файла...");

            uint quantity = ReadFromUser.UInt("Введите количество элементов: ");
            uint diapozon = ReadFromUser.UInt("\nВведите диапозон элементов: ");

            try
            {
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(filePath, FileMode.Create));
                Random random = new Random();
                for (int i = 0; i < quantity; i++)
                {
                    int number = random.Next(-(int)diapozon, (int)diapozon);
                    binaryWriter.Write(number);
                }
                binaryWriter.Close();

                Console.WriteLine("Создан бинарный файл!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void OutputBinaryFile(string filePath)
        {
            int temp = 0;

            Console.Write("\nБинарный файл: ");

            try
            {
                BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open));
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    temp = reader.ReadInt32();
                    Console.Write($"{temp} ");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }

        private static void CalculateProductOfNegativeOddNumbers(string filePath)
        {
            try
            {
                BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open));
                int product = 1;
                Console.Write("Произведение нечетных отрицательных чисел: ");
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int value = reader.ReadInt32();
                    if (value < 0 && value % 2 != 0)
                    {
                        product *= value;
                        Console.Write(value + " * ");
                    }
                }
                Console.WriteLine("1 = " + product);
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static bool FillMatrix(string filePath)
        {
            int n = ReadFromUser.Int("Введите размерность матрицы nxn: ");
            int index = 0;
            int[,] matrix = new int[n, n];

            try
            {
                // Открытие и чтение данных из исходного бинарного файла
                BinaryReader reader = new BinaryReader(File.OpenRead(filePath));

                // Заполнение матрицы данными из файла
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    if (index >= n * n)
                        break;
                    int number = reader.ReadInt32();
                    matrix[index / n, index % n] = number;
                    index++;
                }
                reader.Close();

                // Вывод содержимого матрицы
                Console.WriteLine("\nСодержимое матрицы:");
                PrintMatrix(matrix, n);

                Console.WriteLine("\nСодержимое измененной матрицы:");
                PrintMatrix(ChangeMaxMinElInColumn(matrix, n), n);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Поменять местами в каждом столбце минимальный и максимальный элементы.
        private static int[,] ChangeMaxMinElInColumn(int[,] matrix, int n)
        {
            int iMax;
            int maxValue;
            int iMin;
            int minValue;
            int[,] newMatrix = matrix;

            // Перебор столбцов матрицы
            for (int j = 0; j < n; j++)
            {
                maxValue = -1000000;
                minValue = 1000000;

                iMax = 0;
                iMin = 0;

                // Перебор элементов в столбце
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        iMin = i;
                        minValue = matrix[i, j];
                    }

                    if (matrix[i, j] > maxValue)
                    {
                        iMax = i;
                        maxValue = matrix[i, j];
                    }
                }

                matrix[iMin, j] = maxValue;
                matrix[iMax, j] = minValue;

            }
            return newMatrix;
        }

        // Более менее красивый вывод матрицы
        private static void PrintMatrix(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(string.Concat(Enumerable.Repeat(" ", 6 - matrix[i, j].ToString().Length)) + matrix[i, j]);
                }
                Console.Write("\n");
            }
        }

        // Заполнение бинароного файлa багажа
        private static Passenger[] FillBinaryFilePassangers(string filePath)
        {
            Passenger[] passengers = new Passenger[5];

            passengers[0] = new Passenger("Аня", new List<(string, int)>() { ("Соквояж", 3), ("Походный рюкзак", 6) });
            passengers[1] = new Passenger("Даня", new List<(string, int)>() { ("Сумка от ноутбука", 1), ("Сумочка Гуччи", 1), ("Соквояж Долче Кабан", 5), ("Пенал Адидас", 2)});
            passengers[2] = new Passenger("Маша", new List<(string, int)>() { ("Сумочка Биркин", 10), ("Чемодан Луис Витон", 1), ("Кошелек Прада", 0) });
            passengers[3] = new Passenger("Лена", new List<(string, int)>() { ("Рюкзак 1", 200), ("Рюкзак 2", 100), ("Рюкзак 3", 5), ("Рюкзак 4", 100), ("Чемодан Машин", 2) });
            passengers[4] = new Passenger("Миша", new List<(string, int)>() { ("Пакеты в пакете", 2), ("Чехол с гитарой", 10)});

            BinaryPassangersOutput(passengers);

            if (!PassangersToBinary(filePath, passengers))
            {
                return null;
            }

            Passenger[] passangersFromFile = BinaryToPassangers(filePath);

            if (passangersFromFile == null)
            {
                return null;
            }

            BinaryPassangersOutput(passangersFromFile);
            return passangersFromFile;
        }

        private static bool PassangersToBinary(string filePath, Passenger[] passengers)
        {
            try
            {
                BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create));
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(writer.BaseStream, passengers);
                writer.Close();

                Console.WriteLine();
                Console.WriteLine("Файл со сведениями о багаже сохранён по пути: " + Path.GetFullPath(filePath));
                Console.WriteLine();
                return true;
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке в случае исключения
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private static Passenger[] BinaryToPassangers(string filePath)
        {
            try
            {
                BinaryWriter reader = new BinaryWriter(File.Open(filePath, FileMode.Open));
                BinaryFormatter formatter = new BinaryFormatter();
                Passenger[] persons = (Passenger[])formatter.Deserialize(reader.BaseStream);
                reader.Close();
                Console.WriteLine();
                Console.WriteLine("Файл со сведениями о багаже был считан с: " + Path.GetFullPath(filePath));
                Console.WriteLine();
                return persons;
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке в случае исключения
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private static void BinaryPassangersOutput(Passenger[] passengers)
        {
            Console.WriteLine("\nСписок пассажиров:");
            foreach (Passenger passenger in passengers)
            {
                Console.WriteLine($"\n{passenger}");
            }
            Console.WriteLine();
        }

        // Поиск и вывод списка подходящих пассажиров
        private static void AppropriatePassangers(string filePath, Passenger[] passengers)
        {
            int luggageCount = 0;
            int moreThan2 = 0;

            foreach (Passenger passanger in passengers)
            {
                int k = 0;
                foreach ((string item, int quantity) in passanger.Luggage)
                {
                    k += 1;
                }
                if (k > 2)
                {
                    moreThan2++;

                }
                luggageCount += k;
            }
            if (moreThan2 != 0)

                Console.WriteLine($"Количество пассажиров, имеющих более двух единиц багажа: {moreThan2}");
            else
            {
                Console.WriteLine("Нет пассажиров, имеющих более двух единиц багажа");
            }

            Console.WriteLine();

            float median = ((float)luggageCount) / passengers.Length;
            int moreThanMedian = 0;
            foreach (Passenger passanger in passengers)
            {
                int k = 0;
                foreach ((string item, int quantity) in passanger.Luggage)
                {
                    k += 1;
                }
                if (k > median)
                {
                    moreThanMedian++;

                }

            }

            if (moreThan2 != 0)

                Console.WriteLine($"Количество пассажиров, имеющих количество багажа больше среднего ({median}): {moreThanMedian}");
            else
            {
                Console.WriteLine("Нет пассажиров, имеющих количество багажа больше среднего");
            }

        }

        public static void FillTxtFileOneOnLine(string filePath, int quantity, int diapozon)
        {
            try
            {
                StreamWriter writer = new StreamWriter(File.Open(filePath, FileMode.Create));
                Random random = new Random();
                for (int i = 0; i < quantity; i++)
                {
                    int number = random.Next(-diapozon, diapozon);
                    writer.Write(number);
                    writer.WriteLine("");
                }
                writer.Close();

                Console.WriteLine("Создан текстовый файл, по пути: " + Path.GetFullPath(filePath));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SumSquare(string filePath)
        {
            int result = 0;
            string line;
            int el;

            try
            {
                StreamReader reader = new StreamReader(File.Open(filePath, FileMode.Open));
                while ((line = reader.ReadLine()) != null)
                {
                    int.TryParse(line, out el);
                    result += (el * el);
                }
                reader.Close();
                Console.WriteLine($"Сумма квадратов элементов: {result}");
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void FillTxtFilesSeveralOnLine(string filePath, int quantity, int diapozon)
        {
            try
            {
                StreamWriter writer = new StreamWriter(File.Open(filePath, FileMode.Create));
                Random random = new Random();
                Random random2 = new Random();
                for (int i = 0; i < quantity; i++)
                {
                    int number = random.Next(-diapozon, diapozon);
                    writer.Write(number + " ");
                    if (random2.Next(1, 5) == 2)
                    {
                        writer.WriteLine();
                    }
                }
                writer.Close();

                Console.WriteLine("Создан текстовый файл, по пути: " + Path.GetFullPath(filePath));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Multiply(string filePath)
        {
            int result = 1;
            string line;
            int el;

            try
            {
                StreamReader reader = new StreamReader(File.Open(filePath, FileMode.Open));
                while ((line = reader.ReadLine()) != null)
                {
                    foreach (string str in line.Split(' '))
                    {
                        if (int.TryParse(str, out el))
                        {
                            result *= el;
                        }
                    }
                }
                reader.Close();
                Console.WriteLine($"Произведение элементов: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        public static void FillTxtFilesByText(string filePath)
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

        private static void DublicateFile(string filePath, string filePathOutput)
        {
            int strLength = ReadFromUser.Int("Введите длину строки: ");
            try
            {
                string temp;
                StreamReader reader = new StreamReader(File.Open(filePath, FileMode.Open));
                StreamWriter writer = new StreamWriter(File.Open(filePathOutput, FileMode.Create));
                while ((temp = reader.ReadLine()) != "")
                {
                    if (temp == null)
                    {
                        break;
                    }
                    if (temp.Length == strLength)
                    {
                        writer.WriteLine(temp);
                    }

                }
                Console.WriteLine($"Результат находится в: {Path.GetFullPath(filePathOutput)}");
                writer.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        public static void Task1(string filePath)
        {
            Console.WriteLine("\n------------------------------ Задание 1 ------------------------------");
            CalculateProductOfNegativeOddNumbers(filePath);
            Console.WriteLine("-----------------------------------------------------------------------");
        }
        public static void Task2(string filePath)
        {
            Console.WriteLine("\n------------------------------ Задание 2 ------------------------------");
            FillMatrix(filePath);
            Console.WriteLine("-----------------------------------------------------------------------");
        }
        public static void Task3(string filePath)
        {
            Console.WriteLine("\n------------------------------ Задание 3 ------------------------------");
            AppropriatePassangers(filePath, FillBinaryFilePassangers(filePath));
            Console.WriteLine("-----------------------------------------------------------------------");
        }
        public static void Task4(string filePath)
        {
            Console.WriteLine("\n------------------------------ Задание 4 ------------------------------");
            FillTxtFileOneOnLine(filePath, 10, 10);
            SumSquare(filePath);
            Console.WriteLine("-----------------------------------------------------------------------");
        }
        public static void Task5(string filePath)
        {
            Console.WriteLine("\n------------------------------ Задание 5 ------------------------------");
            FillTxtFilesSeveralOnLine(filePath, 10, 10);
            Multiply(filePath);
            Console.WriteLine("-----------------------------------------------------------------------");
        }
        public static void Task6(string filePath, string filePathOutput)
        {
            Console.WriteLine("\n------------------------------ Задание 6 ------------------------------");
            FillTxtFilesByText(filePath);
            DublicateFile(filePath, filePathOutput);
            Console.WriteLine("-----------------------------------------------------------------------");
        }
    }

}

