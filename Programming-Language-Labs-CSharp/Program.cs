﻿using Programming_Language_Labs_CSharp;

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
            Console.WriteLine("\n------------------------ Лабораторная работа №7 ------------------------");
            Console.WriteLine("1. Составить программу, которая в списке L заменяет первое вхождение списка L1 (если такое есть) на список L2.");
            Console.WriteLine("2. Сортировка элементов списка по возрастанию;");
            Console.WriteLine("3. Есть перечень компьютерных игр. Студенты группы играют в какие-либо из этих игр. Известно для каждого студента, в какие игры он играет. Определить:\r\n• в какие игры из перечня играют все студенты группы;\r\n• в какие игры из перечня играют некоторые студенты группы;\r\n• в какие игры из перечня не играет ни один из студентов группы?");
            
            Console.WriteLine("4. Файл содержит текст на русском языке. Напечатать в алфавитном порядке все глухие согласные буквы, которые не входят хотя бы в одно слово.");
            Console.WriteLine("5. Максимальное количество баллов по олимпе по информатике");
            Console.WriteLine("0. Выход");
            Console.WriteLine("------------------------------------------------------------------------\n");

            userSwitch = ReadFromUser.IntDiap("Выберите пункт задания:", 0, 8);

            switch (userSwitch)
            {
                case 1:
                    // 1 задание
                    // Решить задачу, используя класс List
                    // Составить программу, которая в списке L заменяет первое вхождение списка L1 (если такое есть) на список L2
                    FileFunction.Task1(binaryFilePath);
                    break;
                case 2:
                    // 2 задание
                    // Решить задачу, используя класс LinkedList
                    // Сортировка элементов списка по возрастанию.
                    FileFunction.Task2(binaryFilePath);
                    break;
                case 3:
                    // 3 задание
                    // Решить задачу, используя класс HashSet
                    // Есть перечень компьютерных игр. Студенты группы играют в какие-либо из этих игр. Известно для каждого студента, в какие игры он играет. Определить:
                    // • в какие игры из перечня играют все студенты группы;
                    // • в какие игры из перечня играют некоторые студенты группы;
                    // • в какие игры из перечня не играет ни один из студентов группы?
                    FileFunction.Task3(filePath3);
                    break;
                case 4:
                    // 4 задание
                    // Решить задачу, используя класс HashSet. Дан текстовый файл. Обработать содержимое файла с использованием HashSe
                    // Файл содержит текст на русском языке. Напечатать в алфавитном порядке все глухие согласные буквы, которые не входят хотя бы в одно слово
                    FileFunction.Task4(txtFilePath);
                    break;
                case 5:
                    // 5 задание 
                    // Решить задачу, используя класс Dictionary (или класс SortedList)
                    // Решить текстовую задачу с использованием словаря (входные данные читать из текстового файла)

                    //На городской олимпиаде по информатике участникам было предложено
                    //выполнить 3 задания, каждое из которых оценивалось по 25 - балльной шкале.
                    //Известно, что общее количество участников первого тура олимпиады не
                    //превосходит 250 человек.На вход программы подаются сведения о результатах
                    //олимпиады.В первой строке вводится количество участников N.Далее следуют
                    //N строк, имеющих следующий формат:
                    //< Фамилия > < Имя > < Баллы >
                    //Здесь < Фамилия > – строка, состоящая не более чем из 20 символов; < Имя > –
                    //строка, состоящая не более чем из 15 символов; < Баллы > – строка, содержащая
                    //три целых числа, разделенных пробелом, соответствующих баллам,
                    //полученным участником за каждое задание первого тура. При этом<Фамилия>
                    //и<Имя>, < Имя > и < Баллы > разделены одним пробелом. Примеры входных
                    //строк:
                    //  Петрова Ольга 25 18 16
                    //  Калиниченко Иван 14 19 15
                    //Напишите программу, которая будет выводить на экран фамилию и имя
                    //участника, набравшего максимальное количество баллов.Если среди
                    //остальных участников есть ученики, набравшие такое же количество баллов,
                    //то их фамилии и имена также следует вывести.При этом имена и фамилии
                    //можно выводить в произвольном порядке
                    FileFunction.Task5(txtFilePath);
                    break;
                case 0:
                    Console.WriteLine("Выход...");
                    break;
            }
        }
        
    }
}