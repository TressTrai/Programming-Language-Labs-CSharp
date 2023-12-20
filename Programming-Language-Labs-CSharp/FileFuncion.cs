﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Language_Labs_CSharp
{
    internal class FileFuncion
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
                        // Читаем данные из файла
                        while (fileStream.Position < fileStream.Length)
                        {
                            int value = reader.ReadInt32();
                            Console.WriteLine($"Прочитано значение: {value}");
                        }
                    }
                }

                Console.WriteLine("Чтение бинарного файла завершено.");
            }
            else
            {
                Console.WriteLine("Файл не существует.");
            }
        }

        public static void CalculateProductOfNegativeOddNumbers(string filePath)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                int product = 1;
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int value = reader.ReadInt32();
                    if (value < 0 && value % 2 != 0)
                    {
                        product *= value;
                    }
                }
                Console.WriteLine("Произведение нечетных отрицательных чисел из файла: " + product);
            }
        }

        public static bool FillMatrix(string filePath)
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
                Console.WriteLine("Содержимое матрицы:");
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
        public static int[,] ChangeMaxMinElInColumn(int[,] matrix, int n)
        {
            int column = 0;
            int iMax = 0;
            int maxValue = 0;
            int iMin = 0;
            int minValue = 1000000;
            int[,] newMatrix = matrix;

            // Перебор столбцов матрицы
            for (int j = 0; j < n; j++)
            {
                maxValue = 0;
                minValue = 1000000000;

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
        public static void PrintMatrix(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(string.Concat(Enumerable.Repeat(" ", 4 - matrix[i, j].ToString().Length)) + matrix[i, j]);
                }
                Console.Write("\n");
            }
        }

        // Заполнение бинароного файлa багажа
        public static bool FillBinaryFileLaggage(string filePath)
        {
            Luggage[] luggages = new Luggage[5];

            luggages[0] = new Luggage("Машинка", 2000);
            luggages[1] = new Luggage("Кукла", 1500);
            luggages[2] = new Luggage("Мяч", 500);
            luggages[3] = new Luggage("Паровозик", 3000);
            luggages[4] = new Luggage("Валорант", 1);

            Console.WriteLine("Сведения о всех игрушках: ");
            foreach (Luggage luggage in luggages)
            {
                Console.WriteLine(luggage.ToString());
            }
            Console.WriteLine();

            try
            {
                // Создание BinaryWriter для записи в бинарный файл
                BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create));

                // Создание BinaryFormatter для сериализации массива игрушек
                BinaryFormatter formatter = new BinaryFormatter();

                // Сериализация массива и запись в файл
                formatter.Serialize(writer.BaseStream, luggages);

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
        public static void AppropriateLuggage(string filePath)
        {
            try
            {
                // Создание BinaryReader для чтения из бинарного файла
                BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open));

                // Создание BinaryFormatter для десериализации данных
                BinaryFormatter formatter = new BinaryFormatter();

                // Десериализация массива игрушек из файла
                Luggage[]? luggages = formatter.Deserialize(reader.BaseStream) as Luggage[];
                reader.Close();

                // Переменные для формирования списка подходящих игрушек и подсчета их количества
                string listLuggage = "";
                int count = 0;

                // Найти число пассажиров, имеющих более двух единиц багажа и число пассажиров, количество единиц багажа которых превосходит среднее число единиц багажа.
                foreach (Luggage luggage in luggages)
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


    }

}

