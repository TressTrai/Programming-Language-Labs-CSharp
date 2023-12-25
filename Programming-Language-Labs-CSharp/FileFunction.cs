using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Language_Labs_CSharp
{
    internal class FileFunction
    {
        public static void FillBinaryFile(string filePath, int quantity, int diapozon)
        {
            try
            {
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(filePath, FileMode.Create));
                Random random = new Random();
                for (int i = 0; i < quantity; i++)
                {
                    int number = random.Next(-diapozon, diapozon);
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
            // Проверяем, существует ли файл
            if (File.Exists(filePath))
            {
                // Создаем и открываем файловый поток для чтения из бинарного файла
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    // Создаем объект BinaryReader для чтения данных из бинарного файла
                    using (BinaryReader reader = new BinaryReader(fileStream))
                    {

                        Console.Write("Бинарный файл: ");
                        // Читаем данные из файла
                        while (fileStream.Position < fileStream.Length)
                        {
                            int value = reader.ReadInt32();
                            Console.Write($"{value} ");
                        }
                    }
                }

                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Файл не существует.");
            }
        }

        private static void CalculateProductOfNegativeOddNumbers(string filePath)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
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
                Console.WriteLine();
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
        private static bool FillBinaryFileLaggage(string filePath)
        {
            Passenger[] passengers = new Passenger[5];

            passengers[0] = new Passenger("Аня", new List<(string, int)>() { ("Соквояж", 3) });
            passengers[1] = new Passenger("Аня", new List<(string, int)>() { ("Соквояж", 3) });
            passengers[2] = new Passenger("Аня", new List<(string, int)>() { ("Соквояж", 3) });
            passengers[3] = new Passenger("Аня", new List<(string, int)>() { ("Соквояж", 3) });
            passengers[4] = new Passenger("Аня", new List<(string, int)>() { ("Соквояж", 3) });

            Console.WriteLine("Сведения о всех игрушках: ");
            foreach (Passenger passenger in passengers)
            {
                Console.WriteLine(passenger.ToString());
            }
            Console.WriteLine();

            try
            {
                // Создание BinaryWriter для записи в бинарный файл
                BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create));

                // Создание BinaryFormatter для сериализации массива игрушек
                BinaryFormatter formatter = new BinaryFormatter();

                // Сериализация массива и запись в файл
                formatter.Serialize(writer.BaseStream, passengers);

                writer.Flush();
                writer.Close();

                Console.WriteLine();
                Console.WriteLine("Файл со сведениями о багаже сохранён по пути:\n" + Path.GetFullPath(filePath));
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

        // Поиск и вывод списка подходящих игрушек
        private static void AppropriateLuggage(string filePath)
        {
            try
            {
                // Создание BinaryReader для чтения из бинарного файла
                BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open));

                // Создание BinaryFormatter для десериализации данных
                BinaryFormatter formatter = new BinaryFormatter();

                // Десериализация массива игрушек из файла
                Passenger[]? passengers = formatter.Deserialize(reader.BaseStream) as Passenger[];
                reader.Close();

                // Переменные для формирования списка подходящих игрушек и подсчета их количества
                string listLuggage = "";
                int count = 0;

                // Найти число пассажиров, имеющих более двух единиц багажа и число пассажиров, количество единиц багажа которых превосходит среднее число единиц багажа.
                foreach (Passenger passenger in passengers)
                {
                    
                }

                Console.WriteLine("Список подходящих пассажиров: \n" + listLuggage);
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке в случае исключения
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

            Console.WriteLine("-----------------------------------------------------------------------");
        }
        public static void Task4(string filePath)
        {
            Console.WriteLine("\n------------------------------ Задание 4 ------------------------------");

            Console.WriteLine("-----------------------------------------------------------------------");
        }
        public static void Task5(string filePath)
        {
            Console.WriteLine("\n------------------------------ Задание 5 ------------------------------");

            Console.WriteLine("-----------------------------------------------------------------------");
        }
        public static void Task6(string filePath)
        {
            Console.WriteLine("\n------------------------------ Задание 6 ------------------------------");

            Console.WriteLine("-----------------------------------------------------------------------");
        }
    }

}

