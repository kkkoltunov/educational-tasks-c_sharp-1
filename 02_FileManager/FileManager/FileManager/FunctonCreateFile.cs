using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileManager
{
    partial class Program
    {
        // Создание файла в указанной кодировке пользователем.

        static void FileCreateEncoding(string[] splitInput)
        {
            // Переменная для выполнения повторного ввода.

            bool flagCreateEncoding = false;

            // Проверка на коректность введенных данных.

            if (splitInput.Length == 2)
            {
                // Проверка на коректность введенных данных.

                if (splitInput[1] == "unicode" || splitInput[1] == "ascii" || splitInput[1] == "utf-32" || splitInput[1] == "utf-8" || splitInput[1] == "utf-7")
                {
                    do
                    {
                        Console.Write(Environment.NewLine);
                        Console.WriteLine("Если захотите прервать операцию создания файла - введите \"stop\". Примечание: \"stop\" может быть названием Вашего файла.");
                        Console.WriteLine("Все файлы создаются с расширением \".txt\", поэтому его указывать не нужно.");
                        Console.Write("Введите желаемое название файла: ");

                        // Ввод названия файла с клавиатуры.

                        string input = Console.ReadLine();

                        // Проверка на наличие запрещенных символов в названии файла.

                        bool check = CheckInput(input);

                        // Создание полного пути.

                        string nameFile = $"{Path.DirectorySeparatorChar}" + input + ".txt";

                        if (check == false)
                        {
                            Console.Write("Введите путь, по которому хотите создать файл:");

                            string strCreate = Console.ReadLine();

                            // Создание полного пути.

                            string filePath = strCreate + nameFile;

                            // Завершение выполнения команды.

                            if (strCreate == "stop")
                            {
                                flagCreateEncoding = true;
                                Console.Write(Environment.NewLine);
                            }
                            else
                            {
                                // Проверка коректности введенных пользователем путей, создание файла и его заполнение с клавиатуры.

                                try
                                {
                                    using (File.Create(filePath))
                                    {
                                        Console.Write(Environment.NewLine);
                                        Console.WriteLine("Создание файла прошло успешно! Давайте его чем-нибудь заполним. Для того, чтобы завершить заполнение введите //end//.");
                                        Console.WriteLine("Примечание: \"//end//\" должно быть введено в конце Вашего текста с новой строки!");
                                    }
                                }
                                catch (Exception exception)
                                {
                                    flagCreateEncoding = true;
                                    Console.Write(Environment.NewLine);
                                    Console.WriteLine(exception.Message);
                                    Console.Write(Environment.NewLine);
                                }

                                if (flagCreateEncoding == false)
                                {
                                    string inputFile = "";

                                    // Лист для текста, который вводится с клавиатуры.

                                    List<string> fileText = new List<string>();

                                    // Запись текста в указанной кодировке.

                                    switch (splitInput[1])
                                    {
                                        case "unicode":
                                            do
                                            {
                                                inputFile = Console.ReadLine();

                                                if (inputFile != "//end//")
                                                {
                                                    fileText.Add(inputFile);
                                                }

                                            } while (inputFile != "//end//");

                                            try
                                            {
                                                File.WriteAllLines(filePath, fileText, Encoding.Unicode);
                                            }
                                            catch (Exception exception)
                                            {
                                                Console.Write(Environment.NewLine);
                                                Console.WriteLine(exception.Message);
                                                Console.Write(Environment.NewLine);
                                            }

                                            flagCreateEncoding = true;
                                            break;

                                        case "utf-7":
                                            do
                                            {
                                                inputFile = Console.ReadLine();

                                                if (inputFile != "//end//")
                                                {
                                                    fileText.Add(inputFile);
                                                }

                                            } while (inputFile != "//end//");

                                            try
                                            {
                                                File.WriteAllLines(filePath, fileText, Encoding.UTF7);
                                            }
                                            catch (Exception exception)
                                            {
                                                Console.Write(Environment.NewLine);
                                                Console.WriteLine(exception.Message);
                                                Console.Write(Environment.NewLine);
                                            }

                                            flagCreateEncoding = true;
                                            break;

                                        case "ascii":
                                            do
                                            {
                                                inputFile = Console.ReadLine();

                                                if (inputFile != "//end//")
                                                {
                                                    fileText.Add(inputFile);
                                                }

                                            } while (inputFile != "//end//");

                                            try
                                            {
                                                File.WriteAllLines(filePath, fileText, Encoding.ASCII);
                                            }
                                            catch (Exception exception)
                                            {
                                                Console.Write(Environment.NewLine);
                                                Console.WriteLine(exception.Message);
                                                Console.Write(Environment.NewLine);
                                            }

                                            flagCreateEncoding = true;
                                            break;

                                        case "utf-32":
                                            do
                                            {
                                                inputFile = Console.ReadLine();

                                                if (inputFile != "//end//")
                                                {
                                                    fileText.Add(inputFile);
                                                }

                                            } while (inputFile != "//end//");

                                            try
                                            {
                                                File.WriteAllLines(filePath, fileText, Encoding.UTF32);
                                            }
                                            catch (Exception exception)
                                            {
                                                Console.Write(Environment.NewLine);
                                                Console.WriteLine(exception.Message);
                                                Console.Write(Environment.NewLine);
                                            }

                                            flagCreateEncoding = true;
                                            break;

                                        case "utf-8":
                                            do
                                            {
                                                inputFile = Console.ReadLine();

                                                if (inputFile != "//end//")
                                                {
                                                    fileText.Add(inputFile);
                                                }

                                            } while (inputFile != "//end//");

                                            try
                                            {
                                                File.WriteAllLines(filePath, fileText, Encoding.UTF8);
                                            }
                                            catch (Exception exception)
                                            {
                                                Console.Write(Environment.NewLine);
                                                Console.WriteLine(exception.Message);
                                                Console.Write(Environment.NewLine);
                                            }

                                            flagCreateEncoding = true;
                                            break;
                                    }

                                    Console.Write(Environment.NewLine);
                                }

                                flagCreateEncoding = true;
                            }
                        }
                        else
                        {
                            Console.Write(Environment.NewLine);
                            Console.WriteLine("Введены недопустимые символы!");
                            Console.WriteLine("Недопустимыми символами явлются: '<', '>', '|', '?', '*', '/', '\\', ':', '\"', '\''");
                            Console.Write(Environment.NewLine);
                        }
                    } while (flagCreateEncoding == false);
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

        // Создание файла в кодировке UTF-8.

        static void FileCreate()
        {
            // Переменная для выполнения повторного ввода.

            bool flagCreate = false;

            do
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("Если захотите прервать операцию создания файла - введите \"stop\". Примечание: \"stop\" может быть названием Вашего файла.");
                Console.WriteLine("Все файлы создаются с расширением \".txt\", поэтому его указывать не нужно.");

                Console.Write("Введите желаемое название файла: ");

                // Ввод названия файла с клавиатуры.

                string input = Console.ReadLine();

                // Проверка на наличие запрещенных символов в названии файла.

                bool check = CheckInput(input);

                string nameFile = $"{Path.DirectorySeparatorChar}" + input + ".txt";

                if (check == false)
                {
                    Console.Write("Введите путь, по которому хотите создать файл: ");

                    // Ввод пути с клавиатуры.

                    string strCreate = Console.ReadLine();

                    // Формирование пути для нового файла.

                    string filePath = strCreate + nameFile;

                    // Завершение выполнения команды.

                    if (strCreate == "stop")
                    {
                        flagCreate = true;
                        Console.Write(Environment.NewLine);
                    }

                    // Создание файла по указанному пути.

                    else
                    {
                        try
                        {
                            using (File.Create(filePath))
                            {
                                Console.Write(Environment.NewLine);
                                Console.WriteLine("Создание файла прошло успешно! Давайте его чем-нибудь заполним. Для того, чтобы завершить заполнение введите //end//.");
                                Console.WriteLine("Примечание: \"//end//\" должно быть введено в конце Вашего текста с новой строки!");
                            }
                        }
                        catch (Exception exception)
                        {
                            flagCreate = true;
                            Console.Write(Environment.NewLine);
                            Console.WriteLine(exception.Message);
                            Console.Write(Environment.NewLine);
                        }

                        if (flagCreate == false)
                        {
                            string inputFile = "";

                            List<string> fileText = new List<string>();

                            // Заполнение файла пользователем с клавиатуры.

                            do
                            {
                                inputFile = Console.ReadLine();

                                if (inputFile != "//end//")
                                {
                                    fileText.Add(inputFile);
                                }

                            } while (inputFile != "//end//");

                            try
                            {
                                File.WriteAllLines(filePath, fileText, Encoding.UTF8);
                            }
                            catch (Exception exception)
                            {
                                Console.Write(Environment.NewLine);
                                Console.WriteLine(exception.Message);
                                Console.Write(Environment.NewLine);
                            }

                            flagCreate = true;

                            Console.Write(Environment.NewLine);
                        }

                        flagCreate = true;
                    }
                }
                else
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("Введены недопустимые символы!");
                    Console.WriteLine("Недопустимыми символами явлются: '<', '>', '|', '?', '*', '/', '\\', ':', '\"', '\''");
                    Console.Write(Environment.NewLine);
                }
            } while (flagCreate == false);
        }
    }
}
