using Programming_Language_Labs_CSharp;

internal class Program
{
    private const string binaryFilePath = "task.bin";
    private const string filePath3 = "task3.bin";
    private const string txtFilePath = "task.txt";
    private const string txtFilePathOutput = "task6_Output.txt";

    internal static void Main(string[] args)
    {

        int userSwitch = 1;

        // Создание и заполнени Бинарного файла
        FileFunction.FillBinaryFile(binaryFilePath);
        FileFunction.OutputBinaryFile(binaryFilePath);

        // Основное тело программы
        while (userSwitch != 0)
        {
            Console.WriteLine("\n------------------------ Лабораторная работа №6 ------------------------");
            Console.WriteLine("Бинарные файлы");
            Console.WriteLine("1. Вычислить произведение нечетных отрицательных компонент файла.");
            Console.WriteLine("2. В матрице из файла поменять местами в каждом столбце \nминимальный и максимальный элементы.");
            Console.WriteLine("3. Найти число пассажиров, имеющих более двух единиц багажа и \nчисло пассажиров,количество единиц багажа которых превосходит среднее число единиц багажа.");
            Console.WriteLine("\nТекстовые файлы");
            Console.WriteLine("4. В файле найти сумму квадратов элементов.");
            Console.WriteLine("5. Вычислить произведение элементов.");
            Console.WriteLine("6. Переписать в другой файл строки, имеющие заданную длину m");

            Console.WriteLine("\nДополнительные функции");
            Console.WriteLine("7. Пересоздать бинарный файл.");
            Console.WriteLine("8. Вывод содержимого бинарного файла");
            Console.WriteLine("0. Выход");
            Console.WriteLine("------------------------------------------------------------------------\n");

            userSwitch = ReadFromUser.IntDiap("Выберите пункт задания:", 0, 8);

            switch (userSwitch)
            {
                case 1:
                    // 1 задние
                    // Бинарные файлы, содержащие числовые данные (исходный файл заполнить случайными данными, заполнение организовать отдельным методом)
                    // Вычислить произведение нечетных отрицательных компонент файла.
                    FileFunction.Task1(binaryFilePath);
                    break;
                case 2:
                    // 2 задание
                    // Бинарные файлы, содержащие числовые данные (исходный файл заполнить случайными данными, заполнение организовать отдельным методом)
                    // Скопировать элементы заданного файла в квадратную матрицу размером n×n(если элементов файла недостает, заполнить оставшиеся элементы матрицы нулями).Поменять местами в каждом столбце минимальный и максимальный элементы.
                    FileFunction.Task2(binaryFilePath);
                    break;
                case 3:
                    // 3 задание
                    // Бинарные файлы, содержащие величины типа struct (заполнение исходного файла организовать отдельным методом) - сериализация
                    // Информация о багаже пассажира описывается массивом, где каждый элемент содержит название единицы багажа(чемодан, сумка, коробка и т.д.) и ее массу.
                    // Дан файл, содержащий сведения о багаже нескольких пассажиров. Найти число пассажиров, имеющих более двух единиц багажа и число пассажиров, количество единиц багажа которых превосходит среднее число единиц багажа.
                    FileFunction.Task3(filePath3);
                    break;
                case 4:
                    // 4 задание
                    // Решить задачу с использованием структуры «текстовый файл» (в файле хранятся целые числа по одному в строке)
                    // В файле найти сумму квадратов элементов
                    FileFunction.Task4(txtFilePath);
                    break;
                case 5:
                    // 5 задание 
                    // Решить задачу с использованием структуры «текстовый файл» (в файле хранятся целые числа по несколько в строке)
                    // Вычислить произведение элементов
                    FileFunction.Task5(txtFilePath);
                    break;
                case 6:
                    // 6 задание 
                    // Решить задачу с использованием структуры «текстовый файл» (в файле хранится текст)
                    // Переписать в другой файл строки, имеющие заданную длину m.
                    FileFunction.Task6(txtFilePath, txtFilePathOutput);
                    break;

                case 7:
                    FileFunction.FillBinaryFile(binaryFilePath);
                    break;
                case 8:
                    FileFunction.OutputBinaryFile(binaryFilePath);
                    break;
                case 0:
                    Console.WriteLine("Выход...");
                    break;
            }
        }
        
    }
}