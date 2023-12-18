using Programming_Language_Labs_CSharp;

internal class Program
{
    private const string filePath = "task.bin";

    static void CreateBinaryFile()
    {
        // Создаем и открываем файловый поток для записи в бинарный файл
        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        {
            Console.WriteLine("Бинарный файл создан");
        }

    }

    static void FillBinaryFile(int quantity, int diapozon)
    {
        using (FileStream fileStream = new FileStream(filePath, FileMode.Append))
        {
            // Создаем объект BinaryWriter для записи данных в бинарный файл
            using (BinaryWriter writer = new BinaryWriter(fileStream))
            {
                // Записываем рандомные значения в файл
                Random random = new Random();
                for (int i = 0; i < quantity; i++)
                {
                    int randomNumber = random.Next(-diapozon, diapozon);
                    writer.Write(randomNumber);
                }
            }
        }
    }

    static void OutputBinaryFile()
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
                        Console.Write($"{value} ");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Чтение бинарного файла завершено.");
        }
        else
        {
            Console.WriteLine("Файл не существует.");
        }
    }

    static void CalculateProductOfNegativeOddNumbers()
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





    internal static void Main(string[] args)
    {
        // 1 задние
        // Бинарные файлы, содержащие числовые данные (исходный файл заполнить случайными данными, заполнение организовать отдельным методом)
        // Вычислить произведение нечетных отрицательных компонент файла.
        CreateBinaryFile();
        FillBinaryFile(10, 1000);
        OutputBinaryFile();
        CalculateProductOfNegativeOddNumbers();

        // 2 задание
        // Бинарные файлы, содержащие числовые данные (исходный файл заполнить случайными данными, заполнение организовать отдельным методом)
        // Скопировать элементы заданного файла в квадратную матрицу размером n×n(если элементов файла недостает, заполнить оставшиеся элементы матрицы нулями).Поменять местами в каждом столбце минимальный и максимальный элементы.

        // 3 задание
        // Бинарные файлы, содержащие величины типа struct (заполнение исходного файла организовать отдельным методом) - сериализация
        // Информация о багаже пассажира описывается массивом, где каждый элемент содержит название единицы багажа(чемодан, сумка, коробка и т.д.) и ее массу.
        // Дан файл, содержащий сведения о багаже нескольких пассажиров. Найти число пассажиров, имеющих более двух единиц багажа и число пассажиров, количество единиц багажа которых превосходит среднее число единиц багажа.

        // 4 задание
        // Решить задачу с использованием структуры «текстовый файл» (в файле хранятся целые числа по одному в строке)
        // В файле найти сумму квадратов элементов

        // 5 задание 
        // Решить задачу с использованием структуры «текстовый файл» (в файле хранятся целые числа по несколько в строке)
        // Вычислить произведение элементов

        // 6 задание 
        // Решить задачу с использованием структуры «текстовый файл» (в файле хранится текст)
        // Переписать в другой файл строки, имеющие заданную длину m.
    }
}