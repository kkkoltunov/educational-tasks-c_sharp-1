using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileManager
{
    partial class Program
    {
        // Команда "rf"

        static void FilePrint(string way, string[] splitInput)
        {
            // Проверка на коректность введенных данных.

            if (splitInput.Length == 3)
            {
                // Проверка на коректность введенных данных.

                if (splitInput[2] == "unicode" || splitInput[2] == "ascii" || splitInput[2] == "utf-32" || splitInput[2] == "utf-8" || splitInput[2] == "utf-7")
                {
                    // Проверка файла на существование и вывод его содержимого в консоль.

                    if (File.Exists(way + splitInput[1]))
                    {
                        string[] file = new string[0];

                        // Вывод по кодировке указанной пользователем.

                        switch (splitInput[2])
                        {
                            case "unicode":
                                try
                                {
                                    file = File.ReadAllLines(way + splitInput[1], Encoding.Unicode);
                                }
                                catch (Exception exception)
                                {
                                    Console.Write(Environment.NewLine);
                                    Console.WriteLine(exception.Message);
                                    Console.Write(Environment.NewLine);
                                }
                                break;
                            case "ascii":
                                try
                                {
                                    file = File.ReadAllLines(way + splitInput[1], Encoding.ASCII);
                                }
                                catch (Exception exception)
                                {
                                    Console.Write(Environment.NewLine);
                                    Console.WriteLine(exception.Message);
                                    Console.Write(Environment.NewLine);
                                }
                                break;
                            case "utf-32":
                                try
                                {
                                    file = File.ReadAllLines(way + splitInput[1], Encoding.UTF32);
                                }
                                catch (Exception exception)
                                {
                                    Console.Write(Environment.NewLine);
                                    Console.WriteLine(exception.Message);
                                    Console.Write(Environment.NewLine);
                                }
                                break;
                            case "utf-8":
                                try
                                {
                                    file = File.ReadAllLines(way + splitInput[1], Encoding.UTF8);
                                }
                                catch (Exception exception)
                                {
                                    Console.Write(Environment.NewLine);
                                    Console.WriteLine(exception.Message);
                                    Console.Write(Environment.NewLine);
                                }
                                break;
                            case "utf-7":
                                try
                                {
                                    file = File.ReadAllLines(way + splitInput[1], Encoding.UTF7);
                                }
                                catch (Exception exception)
                                {
                                    Console.Write(Environment.NewLine);
                                    Console.WriteLine(exception.Message);
                                    Console.Write(Environment.NewLine);
                                }
                                break;
                        }

                        // Проверка файла на пустоту, и вывод его содержимого в консоль.

                        if (file.Length != 0)
                        {

                            Console.WriteLine("------------------------------START------------------------------");
                            Console.Write(Environment.NewLine);

                            foreach (var str in file)
                            {
                                Console.WriteLine(str);
                            }

                            Console.Write(Environment.NewLine);
                            Console.WriteLine("-------------------------------END-------------------------------");
                            Console.Write(Environment.NewLine);
                        }
                        else
                        {
                            Console.Write(Environment.NewLine);
                            Console.WriteLine("К сожалению, файл пустой!");
                            Console.Write(Environment.NewLine);
                        }
                    }
                    else
                    {
                        Console.Write(Environment.NewLine);
                        Console.WriteLine("Ошибка! Возможно вы неправильно указали путь!");
                        Console.Write(Environment.NewLine);
                    }
                }
                else
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("Ошибка! Возможно, кодировка указана некоректно!");
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

        // Вывод текста из файла в UTF-8.

        static void FileRead(string activeWay)
        {
            try
            {
                string[] file = File.ReadAllLines(activeWay, Encoding.UTF8);

                // Проверка файла на пустоту, и вывод его содержимого в консоль.

                if (file.Length != 0)
                {
                    Console.WriteLine("------------------------------START------------------------------");
                    Console.Write(Environment.NewLine);

                    foreach (var str in file)
                    {
                        Console.WriteLine(str);
                    }

                    Console.Write(Environment.NewLine);
                    Console.WriteLine("-------------------------------END-------------------------------");
                    Console.Write(Environment.NewLine);
                }
                else
                {
                    Console.Write(Environment.NewLine);
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
        }
    }
}
