using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileManager
{
    partial class Program
    {
        // Команда "dir".

        static void DirectoryInfo(string[] directories, string[] files)
        {
            Console.Write(Environment.NewLine);

            // Проверка на наличие подпапок.

            if (directories.Length != 0)
            {
                Console.WriteLine("Подкаталоги:");

                for (int i = 0; i < directories.Length; i++)
                {
                    Console.WriteLine(directories[i]);
                }
            }
            else
            {
                Console.WriteLine("Подкаталоги не найдены!");
            }

            Console.Write(Environment.NewLine);

            // Проверка на наличие файлов.

            if (files.Length != 0)
            {
                Console.WriteLine("Файлы:");

                for (int i = 0; i < files.Length; i++)
                {
                    Console.WriteLine(files[i]);
                }
            }
            else
            {
                Console.WriteLine("Файлы не найдены!");
            }

            Console.Write(Environment.NewLine);
        }

        // Команда "cd -".

        static string ChangeDirectory(string way, string currentDirect)
        {
            // Проверка на нахождение в корневой директории.

            if (way != currentDirect)
            {
                // Массив из текущего пути.

                string[] tempruaryWay = way.Split(Path.DirectorySeparatorChar);

                way = "";

                // Очищение крацнего элемента массива.

                tempruaryWay[tempruaryWay.Length - 2] = null;

                // Комбинирование нового пути без последней директории.

                for (int i = 0; i < tempruaryWay.Length - 2; i++)
                {
                    way += tempruaryWay[i] + $"{Path.DirectorySeparatorChar}";
                }
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("Вы находитесь в корневой директории!");
            }

            Console.Write(Environment.NewLine);

            return way;
        }

        // Команда "cp".

        static void CopyFile()
        {
            // Переменная для выполнения повторного ввода.

            bool flagCopy = false;

            Console.Write(Environment.NewLine);
            Console.WriteLine("Если захотите прервать операция копирования - введите \"stop\". При вводе названия файла, обязательно укажите его расширение!");
            Console.WriteLine("Важно: обязательно указывайте расширение файла (.txt).");

            do
            {
                Console.Write("Введите путь до файла, который нужно скопировать: ");
                string strCopy = Console.ReadLine();

                // Завершение выполнения команды.

                if (strCopy == "stop")
                {
                    flagCopy = true;
                    Console.Write(Environment.NewLine);
                }

                // Проверка файла на существование и запрос пути, по которому нужно произвести копирование.

                else if (File.Exists(strCopy))
                {
                    Console.Write("Введите путь, куда нужно скопировать файл: ");
                    string strCopyTo = Console.ReadLine();

                    // Завершение выполнения команды.

                    if (strCopyTo == "stop")
                    {
                        flagCopy = true;
                        Console.Write(Environment.NewLine);
                    }

                    // Проверка указанного пути и копирование файла.

                    else if (Directory.Exists(strCopyTo))
                    {
                        string[] name = strCopy.Split(Path.DirectorySeparatorChar);

                        try
                        {
                            File.Copy(strCopy, Path.Combine(strCopyTo, name[name.Length - 1]), true);

                            Console.Write(Environment.NewLine);
                            Console.WriteLine("Копирование успешно произведено!");
                            Console.Write(Environment.NewLine);
                        }
                        catch (Exception exeption)
                        {
                            Console.Write(Environment.NewLine);
                            Console.WriteLine(exeption.Message);
                            Console.Write(Environment.NewLine);
                        }

                        flagCopy = true;
                    }
                    else if (strCopyTo != "stop")
                    {
                        Console.Write(Environment.NewLine);
                        Console.WriteLine("Путь, по которому нужно произвести копирование - неверный!");
                        Console.Write(Environment.NewLine);
                    }
                }
                else if (strCopy != "stop")
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("Путь до файла, который нужно скопировать введен некоректно.");
                    Console.Write(Environment.NewLine);
                }
            } while (flagCopy == false);
        }

        // Команда "mv".

        static void FileMove()
        {
            // Переменная для выполнения повторного ввода.

            bool flagMove = false;

            Console.Write(Environment.NewLine);
            Console.WriteLine("Если захотите прервать операцию перемещения файла - введите \"stop\"");

            do
            {
                Console.Write("Введите путь до файла, который нужно переместить: ");
                string strMove = Console.ReadLine();

                // Завершение выполнения команды.

                if (strMove == "stop")
                {
                    flagMove = true;
                    Console.Write(Environment.NewLine);
                }

                // Проверка файла на существование и запрос пути, по которому нужно произвести перенос файла.

                else if (File.Exists(strMove))
                {
                    Console.Write("Введите путь, куда нужно перенести файл: ");
                    string strMoveTo = Console.ReadLine();

                    // Завершение выполнения команды.

                    if (strMoveTo == "stop")
                    {
                        flagMove = true;
                    }

                    // Проверка указанной директории на сущестование и перемещние файла.

                    if (Directory.Exists(strMoveTo))
                    {
                        string[] name = strMove.Split(Path.DirectorySeparatorChar);

                        try
                        {
                            File.Copy(strMove, Path.Combine(strMoveTo, name[name.Length - 1]), true);
                            File.Delete(strMove);

                            Console.Write(Environment.NewLine);
                            Console.WriteLine("Перемещение успешно произведено!");
                            Console.Write(Environment.NewLine);
                        }
                        catch (Exception exception)
                        {
                            Console.Write(Environment.NewLine);
                            Console.WriteLine(exception.Message);
                            Console.Write(Environment.NewLine);
                        }

                        flagMove = true;
                    }
                    else if (strMoveTo != "stop")
                    {
                        Console.Write(Environment.NewLine);
                        Console.WriteLine("Путь, по которому нужно произвести копирование - неверный!");
                    }
                }
                else if (strMove != "stop")
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("Путь до файла, который нужно скопировать введен некоректно");
                    Console.Write(Environment.NewLine);
                }
            } while (flagMove == false);
        }

        // Команда "del".

        static void FileDelete(string way, string[] splitInput)
        {
            // Проверка на коректность введенных данных.

            if (splitInput.Length == 2)
            {
                // Проверка файла на существование и его удаление.

                if (File.Exists(way + splitInput[1]))
                {
                    try
                    {
                        File.Delete(way + splitInput[1]);

                        Console.Write(Environment.NewLine);
                        Console.WriteLine("Удаление прошло успешно!");
                        Console.Write(Environment.NewLine);
                    }
                    catch (Exception exception)
                    {
                        Console.Write(Environment.NewLine);
                        Console.WriteLine(exception.Message);
                        Console.Write(Environment.NewLine);
                    }
                }
                else
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("Операция удаление не может быть произведена!");
                    Console.Write(Environment.NewLine);
                }
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("Ошибка при вводе команды!");
                Console.Write(Environment.NewLine);
            }
        }

        // Команда "ct".

        static void FileConcatenation()
        {
            // Переменная для выполнения повторного ввода.

            bool flagConcat = false;

            do
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("За одно выполнение команды конкатенировать можно не более 10 файлов.");
                Console.WriteLine("Если пути до файла, введенные вами будут некорректными, то файл будет создан пустым!");
                Console.WriteLine("Примечание: командой \"stop\" можно воспользовать только при вводе пути для сохранения файла.");
                Console.Write("Введите путь, по которому будет сохранен файл: ");

                // Ввод пути с консоли.

                string inputPath = Console.ReadLine();

                // Завершение выполнения команды.

                if (inputPath == "stop")
                {
                    flagConcat = true;
                    Console.Write(Environment.NewLine);
                }

                // Проверка на существование директории.

                else if (Directory.Exists(inputPath))
                {
                    bool check = true;
                    string filePath = "";

                    // Ввод названия файла и проверка введенных данных на коректность.

                    do
                    {
                        Console.Write("Введите желаемое название результирующего файла: ");

                        string nameFile = Console.ReadLine();

                        check = CheckInput(nameFile);

                        filePath = inputPath + $"{Path.DirectorySeparatorChar}" + nameFile + ".txt";

                        if (check == true)
                        {
                            Console.Write(Environment.NewLine);
                            Console.WriteLine("Некоректный ввод!");
                            Console.Write(Environment.NewLine);
                        }

                    } while (check == true);

                    if (check == false)
                    {
                        Console.Write("Введите желаемое количество файлов для конкатенации: ");

                        // Ввод количества файлов и проверка на коректность.

                        if (!int.TryParse(Console.ReadLine(), out int count) || (count <= 1 || count > 10))
                        {
                            Console.Write(Environment.NewLine);
                            Console.WriteLine("Некорректный ввод.");
                        }
                        else
                        {
                            // Создание списка для записи в него текста из файлов.

                            List<string> allText = new List<string>();

                            string file = "";

                            // Цикл, в котором происходит запись текста в список.

                            for (int i = 1; i <= count; i++)
                            {
                                Console.Write($"Введите путь до {i}-го файла:");

                                string inputWay = Console.ReadLine();

                                if (inputWay == "stop")
                                {
                                    flagConcat = true;
                                    break;
                                }

                                // Проверка файла на существование.

                                if (File.Exists(inputWay))
                                {
                                    try
                                    {
                                        file = File.ReadAllText(inputWay, Encoding.UTF8);
                                    }
                                    catch (Exception exception)
                                    {
                                        Console.WriteLine(exception.Message);
                                        flagConcat = true;
                                        break;
                                    }

                                    // Добавление в список текста из файла.

                                    allText.Add(file);
                                }
                                else
                                {
                                    Console.Write(Environment.NewLine);
                                    Console.WriteLine("Ошибка! Возможно путь введен некоректно!");
                                    Console.Write(Environment.NewLine);
                                }
                            }

                            // Создание результирующего файла.

                            try
                            {
                                using (File.Create(filePath))
                                {
                                    Console.Write(Environment.NewLine);
                                    Console.WriteLine("Создание файла прошло успешно!");
                                    Console.Write(Environment.NewLine);
                                }
                            }
                            catch (Exception exception)
                            {
                                flagConcat = true;
                                Console.Write(Environment.NewLine);
                                Console.WriteLine(exception.Message);
                                Console.Write(Environment.NewLine);
                            }

                            // Запись текста в указанный файл и чтение текста из этого файла.

                            if (flagConcat == false)
                            {
                                try
                                {
                                    File.WriteAllLines(filePath, allText);

                                    try
                                    {
                                        string[] fileRead = File.ReadAllLines(filePath, Encoding.UTF8);

                                        // Проверка файла на пустоту, и вывод его содержимого в консоль.

                                        if (fileRead.Length != 0)
                                        {
                                            Console.WriteLine("------------------------------START------------------------------");
                                            Console.Write(Environment.NewLine);

                                            foreach (var str in fileRead)
                                            {
                                                Console.WriteLine(str);
                                            }

                                            Console.Write(Environment.NewLine);
                                            Console.WriteLine("-------------------------------END-------------------------------");
                                            Console.Write(Environment.NewLine);
                                        }
                                        else
                                        {
                                            Console.WriteLine("К сожалению, файл пустой!");
                                            Console.Write(Environment.NewLine);
                                        }
                                    }
                                    catch (Exception exception)
                                    {
                                        Console.Write(Environment.NewLine);
                                        Console.WriteLine(exception.Message);
                                        Console.Write(Environment.NewLine);
                                    }

                                    flagConcat = true;
                                }
                                catch (Exception exception)
                                {
                                    Console.Write(Environment.NewLine);
                                    Console.WriteLine(exception.Message);
                                    Console.Write(Environment.NewLine);
                                }

                                flagConcat = true;
                            }

                            flagConcat = true;
                        }
                    }
                    else
                    {
                        Console.Write(Environment.NewLine);
                        Console.WriteLine("Введены недопустимые символы!");
                        Console.WriteLine("Недопустимыми символами явлются: '<', '>', '|', '?', '*', '/', '\\', ':', '\"', '\''");
                        Console.Write(Environment.NewLine);
                    }
                }
                else
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("Путь введен некорректно. Названия файла не должно быть в пути.");
                }
            } while (flagConcat == false);
        }
    }
}
