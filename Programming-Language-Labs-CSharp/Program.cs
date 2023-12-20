﻿using Programming_Language_Labs_CSharp;

internal class Program
{
    private const string filePath = "task.bin";

    internal static void Main(string[] args)
    {
        FileFuncion.FillBinaryFile(filePath, 10, 1000);
        FileFuncion.OutputBinaryFile(filePath);

        // 1 задние
        // Бинарные файлы, содержащие числовые данные (исходный файл заполнить случайными данными, заполнение организовать отдельным методом)
        // Вычислить произведение нечетных отрицательных компонент файла.
        FileFuncion.CalculateProductOfNegativeOddNumbers(filePath);

        // 2 задание
        // Бинарные файлы, содержащие числовые данные (исходный файл заполнить случайными данными, заполнение организовать отдельным методом)
        // Скопировать элементы заданного файла в квадратную матрицу размером n×n(если элементов файла недостает, заполнить оставшиеся элементы матрицы нулями).Поменять местами в каждом столбце минимальный и максимальный элементы.
        FileFuncion.FillMatrix(filePath);

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