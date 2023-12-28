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
        // Создание и заполнение бинарного файла
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

                Console.WriteLine("Создан бинарный файл, по пути: " + Path.GetFullPath(filePath));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Вывод бинарного файла
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

        // Вычисление произведение нечетных отрицательных чисел с бинарного файла
        private static void CalculateProductOfNegativeOddNumbers(string filePath)
        {
            OutputBinaryFile(filePath);
            bool isPrint = false;
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
                        isPrint = true;
                    }
                }
                if (isPrint)
                {
                    Console.WriteLine("1 = " + product);
                } 
                else
                {
                    Console.WriteLine("0");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Заполнение матрицы и вывод
        private static void FillMatrix(string filePath)
        {
            OutputBinaryFile(filePath);

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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Поменять местами в каждом столбце минимальный и максимальный элементы
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

        // Матрица. Красивое.
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
            Passenger[] passengers = new Passenger[5]; // массив на 5 элементов

            passengers[0] = new Passenger("Аня", new List<(string, int)>() { ("Соквояж", 3), ("Походный рюкзак", 6) });
            passengers[1] = new Passenger("Даня", new List<(string, int)>() { ("Сумка от ноутбука", 1), ("Сумочка Гуччи", 1), ("Соквояж Долче Кабан", 5), ("Пенал Адидас", 2)});
            passengers[2] = new Passenger("Маша", new List<(string, int)>() { ("Сумочка Биркин", 10), ("Чемодан Луис Витон", 1), ("Кошелек Прада", 0) });
            passengers[3] = new Passenger("Лена", new List<(string, int)>() { ("Рюкзак 1", 200), ("Рюкзак 2", 100), ("Рюкзак 3", 5), ("Рюкзак 4", 100), ("Чемодан Машин", 2) });
            passengers[4] = new Passenger("Миша", new List<(string, int)>() { ("Пакеты в пакете", 2), ("Чехол с гитарой", 10)});

            BinaryPassangersOutput(passengers); // Вывод содержимого массива до записи в файл

            if (!PassangersToBinary(filePath, passengers)) // Пытаемся записать нашу структуру в бинарный файл
            {
                Passenger[] emptyArray = new Passenger[0]; 
                return emptyArray; // возвращаем пустой массив
            }

            Passenger[] passangersFromFile = BinaryToPassangers(filePath); // Считываем с файла и преобразуем в структуру

            if (passangersFromFile.Length == 0) // Проверяем что в массиве что-то есть
            {
                Passenger[] emptyArray = new Passenger[0];
                return emptyArray; // возвращаем пустой массив
            }

            BinaryPassangersOutput(passangersFromFile); // Вывод содержимого массива после считывания с файла
            return passangersFromFile;
        }

        // Запись пассажиров в бинарный файл
        private static bool PassangersToBinary(string filePath, Passenger[] passengers)
        {
            try
            {
                BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create));
                BinaryFormatter formatter = new BinaryFormatter();

                // Бинарно сериализуем массив пассажиров и записываем его в файл
                formatter.Serialize(writer.BaseStream, passengers);
                writer.Close();

                Console.WriteLine("\nФайл со сведениями о багаже сохранён по пути: " + Path.GetFullPath(filePath));
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

        // Чтение пассажиров из бинарного файла
        private static Passenger[] BinaryToPassangers(string filePath)
        {
            try
            {
                BinaryWriter reader = new BinaryWriter(File.Open(filePath, FileMode.Open));
                BinaryFormatter formatter = new BinaryFormatter();

                // Десериализируем из файла
                Passenger[] passengers = (Passenger[])formatter.Deserialize(reader.BaseStream);
                reader.Close();

                Console.WriteLine("\nФайл со сведениями о багаже был считан с: " + Path.GetFullPath(filePath));
                Console.WriteLine();
                return passengers;
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке в случае исключения
                Console.WriteLine(ex.Message);
                Passenger[] emptyArray = new Passenger[0];
                return emptyArray; // возвращаем пустой массив
            }
        }

        // Вывод пассажиров из бинарного файла
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
            int countBaggage = 0; // Сколько багажа всего
            int countMoreTwo = 0; // Число пассажиров у которых багажа больше чем два

            foreach (Passenger passanger in passengers)
            {
                if (passanger.Baggage.Count > 2)
                    countMoreTwo++;

                countBaggage += passanger.Baggage.Count;
            }

            Console.WriteLine($"Число пассажиров, имеющих более двух единиц багажа: {countMoreTwo}");

            float med = ((float)countBaggage) / passengers.Length; // Среднее число багажа на человека
            int moreMed = 0; // Число пассажиров у которых багажа больше чем среднее число
            foreach (Passenger passanger in passengers)
            {
                if (passanger.Baggage.Count > med)
                    moreMed++;
            }

            Console.WriteLine($"Число пассажиров, количество единиц багажа которых превосходит среднее число единиц багажа, составляющее {med}: {moreMed}");
        }

        // Заполнение текстового файла числа по одному в строку
        private static void FillTxtFileOneOnLine(string filePath)
        {
            Console.WriteLine("Создание текстового файла...");

            uint quantity = ReadFromUser.UInt("Введите количество элементов: ");
            uint diapozon = ReadFromUser.UInt("\nВведите диапозон элементов: ");

            try
            {
                StreamWriter writer = new StreamWriter(File.Open(filePath, FileMode.Create));
                Random random = new Random();
                for (int i = 0; i < quantity; i++)
                {
                    int number = random.Next(-(int)diapozon, (int)diapozon);
                    writer.WriteLine(number);
                }
                writer.Close();

                Console.WriteLine("Создан текстовый файл, по пути: " + Path.GetFullPath(filePath));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Элменты в квадрате, затем складываются 
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

        // Заполнение текстовго файла чисел по несколько в строку
        private static void FillTxtFilesSeveralOnLine(string filePath)
        {
            Console.WriteLine("Создание текстового файла...");

            uint quantity = ReadFromUser.UInt("Введите количество элементов: ");
            uint diapozon = ReadFromUser.UInt("\nВведите диапозон элементов: ");

            try
            {
                StreamWriter writer = new StreamWriter(File.Open(filePath, FileMode.Create));
                Random random = new Random();
                Random random2 = new Random();
                for (int i = 0; i < quantity; i++)
                {
                    int number = random.Next(-(int)diapozon, (int)diapozon);
                    writer.Write(number + " ");
                    if (random2.Next(1, 7) == 2)
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

        // Переумножение элементов
        private static void Multiply(string filePath)
        {
            int result = 1;
            string line;
            int el;
            bool isPrint = false;

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
                            isPrint = true;
                        }
                    }
                }
                reader.Close();
                if (!isPrint)
                    result = 0;
       
                Console.WriteLine($"Произведение элементов: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
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
                Console.WriteLine("Создан текстовый файл, по пути: " + Path.GetFullPath(filePath));
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        // Дублирование файла со строками определенной длины
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

        // Вывод первого задания
        public static void Task1(string filePath)
        {
            Console.WriteLine("\n------------------------------ Задание 1 ------------------------------");
            CalculateProductOfNegativeOddNumbers(filePath);
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        // Вывод второго задания
        public static void Task2(string filePath)
        {
            Console.WriteLine("\n------------------------------ Задание 2 ------------------------------");
            FillMatrix(filePath);
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        // Вывод третьего задания
        public static void Task3(string filePath)
        {
            Console.WriteLine("\n------------------------------ Задание 3 ------------------------------");
            AppropriatePassangers(filePath, FillBinaryFilePassangers(filePath));
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        // Вывод четвертого задания
        public static void Task4(string filePath)
        {
            Console.WriteLine("\n------------------------------ Задание 4 ------------------------------");
            FillTxtFileOneOnLine(filePath);
            SumSquare(filePath);
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        // Вывод пятого задания
        public static void Task5(string filePath)
        {
            Console.WriteLine("\n------------------------------ Задание 5 ------------------------------");
            FillTxtFilesSeveralOnLine(filePath);
            Multiply(filePath);
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        // Вывод шестого задания
        public static void Task6(string filePath, string filePathOutput)
        {
            Console.WriteLine("\n------------------------------ Задание 6 ------------------------------");
            FillTxtFilesByText(filePath);
            DublicateFile(filePath, filePathOutput);
            Console.WriteLine("-----------------------------------------------------------------------");
        }
    }

}

