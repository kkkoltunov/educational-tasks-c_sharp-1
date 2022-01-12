using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileManager
{
    partial class Program
    {
        // Характеристика тома(диска).
        static void DiskInfo(DriveInfo[] allDrives)
        {
            double diskSpace = 0;

            foreach (DriveInfo disk in allDrives)
            {
                Console.WriteLine($"Том(диск) - {disk.Name}");

                Console.WriteLine($"    Тип тома(диска): {disk.DriveType}");

                if (disk.IsReady == true)
                {
                    Console.WriteLine($"    Файловая система: {disk.DriveFormat}");

                    if (disk.AvailableFreeSpace > Math.Pow(10, 9))
                    {
                        diskSpace = disk.AvailableFreeSpace / (double)(1024 * 1024 * 1024);
                        Console.WriteLine($"    Общий объем свободного места: {diskSpace:f2} ГБ");
                    }
                    else if (disk.AvailableFreeSpace > Math.Pow(10, 5))
                    {
                        diskSpace = disk.AvailableFreeSpace / (double)(1024 * 1024);
                        Console.WriteLine($"    Общий объем свободного места: {diskSpace:f2} МБ");
                    }
                    else
                    {
                        diskSpace = disk.AvailableFreeSpace;
                        Console.WriteLine($"    Общий объем свободного места: {diskSpace:f2} БАЙТ");
                    }

                    if (disk.TotalSize > Math.Pow(10, 9))
                    {
                        diskSpace = disk.TotalSize / (double)(1024 * 1024 * 1024);
                        Console.WriteLine($"    Общий размер места для хранения: {diskSpace:f2} ГБ");
                    }
                    else if (disk.TotalSize > Math.Pow(10, 5))
                    {
                        diskSpace = disk.TotalSize / (double)(1024 * 1024);
                        Console.WriteLine($"    Общий размер места для хранения: {diskSpace:f2} МБ");
                    }
                    else
                    {
                        diskSpace = disk.TotalSize;
                        Console.WriteLine($"    Общий размер места для хранения: {diskSpace:f2} БАЙТ");
                    }
                }

                Console.Write(Environment.NewLine);
            }
        }

        // Информация о томах(дисках).

        static void WorkDisk(ref DriveInfo[] allDrives, out string[] drivesPortable, out string[] drivesFix, out int count)
        {
            // Подсчет количества нефиксированных дисков.

            count = 0;

            for (int i = 0; i < allDrives.Length; i++)
            {
                if (allDrives[i].DriveType != DriveType.Fixed && allDrives[i].DriveType != DriveType.Removable)
                {
                    count++;
                }
            }

            // Создание массива из нефиксированных дисков.

            drivesPortable = new string[allDrives.Length];

            if (count != 0)
            {
                for (int i = 0; i < drivesPortable.Length; i++)
                {
                    if (allDrives[i].DriveType != DriveType.Fixed && allDrives[i].DriveType != DriveType.Removable)
                    {
                        drivesPortable[i] = allDrives[i].RootDirectory.ToString().ToLower();
                    }
                }
            }

            // Создание массива из фиксированных дисков.

            drivesFix = new string[allDrives.Length];

            for (int i = 0; i < allDrives.Length; i++)
            {
                if ((allDrives[i].DriveType == DriveType.Fixed) || (allDrives[i].DriveType == DriveType.Removable))
                {
                    drivesFix[i] = allDrives[i].RootDirectory.ToString().ToLower();
                }
            }
        }

        static string ChosenDisk()
        {
            // Строка, в которой формируется путь.

            string way = "";

            // Корректность ввода.

            bool flag = true;

            do
            {
                // Получение информации о томах(дисках).

                DriveInfo[] allDrives = DriveInfo.GetDrives();

                Console.Write(Environment.NewLine);

                // Вывод информации о томах(дисках).

                DiskInfo(allDrives);

                // Массив с данными нефиксированных томов(дисков).

                string[] drivesPortable = new string[allDrives.Length];

                // Массив с данными фиксированных томв(дисков).

                string[] drivesFix = new string[allDrives.Length];

                // Определение параметров диска.

                WorkDisk(ref allDrives, out drivesPortable, out drivesFix, out int count);

                // Переменная для вывода текста единоразово, после первого запуска метода.

                bool firstStart = false;

                do
                {
                    // Вывод пустой строки только при первом запуске.

                    if (firstStart == true)
                    {
                        Console.Write(Environment.NewLine);
                        firstStart = false;
                    }

                    firstStart = true;

                    // Вспомогательный текст.

                    HelpTextChosenDiskFirst();

                    // Ввод пользоватем с клавиатуры.

                    string inputDrive = Console.ReadLine().ToLower();

                    // Вызов вспомогательного текста.

                    if (inputDrive == "help")
                    {
                        HelpTextChosenDiskSecond();
                    }

                    // Выход из программы.

                    if (inputDrive == "exit")
                    {
                        Console.Write(Environment.NewLine);
                        Console.WriteLine("До скорых встреч!");
                        Environment.Exit(0);
                    }

                    // Проверка на коректность введенных данных.

                    for (int i = 0; i < drivesFix.Length; i++)
                    {
                        if (inputDrive == drivesFix[i])
                        {
                            Console.Clear();
                            way = allDrives[i].ToString();
                            flag = false;
                        }
                    }

                    // При попытке попасть в любой нефиксированный диск, будет 

                    if (count != 0)
                    {
                        for (int i = 0; i < drivesPortable.Length; i++)
                        {
                            if (inputDrive == drivesPortable[i])
                            {
                                Console.Write(Environment.NewLine);
                                Console.WriteLine("Данный диск не может быть использован, так как он не подключен!!!");
                            }
                        }
                    }

                    // Некоректный ввод.

                    if (inputDrive != "exit" && inputDrive != "help" && flag != false)
                    {
                        Console.Write(Environment.NewLine);
                        Console.WriteLine("Некорректный ввод!");
                    }
                } while (flag == true);

            } while (flag == true);

            return way;
        }
    }
}
