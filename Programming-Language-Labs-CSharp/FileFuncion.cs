using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Language_Labs_CSharp
{
    internal class FileFuncion
    {
        public static void CreateBinaryFile(string filePath)
        {
            // Создаем и открываем файловый поток для записи в бинарный файл
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                Console.WriteLine("Бинарный файл создан");
            }

        }

        public static void FillBinaryFile(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Append))
            {
                // Создаем объект BinaryWriter для записи данных в бинарный файл
                using (BinaryWriter writer = new BinaryWriter(fileStream))
                {
                    // Записываем рандомные значения в файл
                    Random random = new Random();
                    for (int i = 0; i < 10; i++)
                    {
                        int randomNumber = random.Next(-1000, 1000);
                        writer.Write(randomNumber);
                    }
                }
            }
        }

        public static void ReadBinaryFile(string filePath)
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
    }
}

