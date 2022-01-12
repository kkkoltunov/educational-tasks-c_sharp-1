using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    // Дополнительным функционалом является реализация эмулятора консольной строки(у меня нет меню и каких-то шаблонов, полный простор для ваших действий), но тут уже на ваш суд.

    partial class Program
    {
        // Булевская переменная, для того, чтобы приветствие выводилось только при первом запуске программы.

        public static bool flagStart = false;

        // Основной блок программы, в котором происходит вызов различных методов.

        static void Main(string[] args)
        {
            // Переменная меняющая свое значение в зависимости от исполнения команды или ее не исполнения.

            bool flagComand = false;

            // Вызов метода, который выводит текст.

            if (flagStart == false)
            {
                StartText();
                flagStart = true;
            }
            else
            {
                ProcessText();
            }

            // Получение стартовой директории от пользователя.

            string way = ChosenDisk();

            // Стартовая директория.

            string currentDirect = way;

            Console.WriteLine("Отлично! Теперь можно начать работу с файловым менеджером :)");
            Console.Write(Environment.NewLine);

            // Вспомогательный текст.

            HelpText();

            Console.WriteLine("Если в процессе выполнения программы возникают вопросы - напишите команду \"HELP\".");
            Console.WriteLine("В \"HELP\" собран список команд, и возможные подсказки на различных этапах работы приложения.");
            Console.WriteLine("Рекомендуется открыть консоль на весь экран.");
            Console.Write(Environment.NewLine);

            do
            {
                // Вывод в консоль актуального пути + символа (как в консоли Windows).

                Console.Write(way + ">");

                // Ввод пользлователя с клавиатуры.

                string strInput = Console.ReadLine().Trim();

                // Получение информации и о файлах и директориях на текущем пути.

                string[] directories = Directory.GetDirectories(way);
                string[] files = Directory.GetFiles(way);

                // Ввод пользователя с клавиатуры.

                string strInputFirst = strInput;

                // Проверка на наличие запрещенных символов при вводе с клавиатуры.

                bool check = CheckInput(strInput);

                if (check == false)
                {
                    string activeWay = way + strInput;

                    for (int i = 0; i < directories.Length; i++)
                    {
                        if (activeWay.ToLower() == directories[i].ToString().ToLower())
                        {
                            strInput = directories[i].ToString();
                        }
                    }

                    // Разбиение вводимой пользователем строки.

                    string[] splitInput = strInput.ToLower().Split(' ');

                    // Перемещение по директориям.

                    if (Directory.Exists(strInput) && (!strInputFirst.Trim().StartsWith("/") && !strInput.Trim().StartsWith(" ") && !strInputFirst.Trim().StartsWith("\\")))
                    {
                        flagComand = true;
                        way = strInput + $"{Path.DirectorySeparatorChar}";
                        Console.Write(Environment.NewLine);
                    }

                    // Вывод текста из файла на экран в кодировке UTF-8.

                    if (File.Exists(activeWay))
                    {
                        flagComand = true;
                        FileRead(activeWay);
                    }

                    // Информация о файлах и подпапках в текущей папке.

                    if (strInput == "dir")
                    {
                        flagComand = true;
                        DirectoryInfo(directories, files);
                    }

                    // Смена диска.

                    if (strInput == "cd")
                    {
                        flagComand = true;
                        way = "";
                        Console.Clear();
                        Main(args);
                    }

                    // Возврат на директорию назад.

                    if (strInput == "cd -")
                    {
                        flagComand = true;
                        way = ChangeDirectory(way, currentDirect);
                    }

                    // Коипрование файлов.

                    if (strInput == "cp")
                    {
                        flagComand = true;
                        CopyFile();
                    }

                    // Перемещение файлов.

                    if (strInput == "mv")
                    {
                        flagComand = true;
                        FileMove();
                    }

                    // Удаление файлов.

                    if (splitInput[0] == "del")
                    {
                        flagComand = true;
                        FileDelete(way, splitInput);
                    }

                    // Вывод текста из файла на экран в указанной пользователем кодировке.

                    if (splitInput[0] == "rf")
                    {
                        flagComand = true;
                        FilePrint(way, splitInput);
                    }

                    // Конкатенаия содержимого нескольких файлов.

                    if (strInput == "ct")
                    {
                        flagComand = true;
                        FileConcatenation();
                    }

                    // Создание файла в кодировке UTF-8.

                    if (strInput == "cr")
                    {
                        flagComand = true;
                        FileCreate();
                    }

                    // Создание файла в выбранной пользователем кодировке.

                    else if (splitInput[0] == "cr" && splitInput[1] != null)
                    {
                        flagComand = true;
                        FileCreateEncoding(splitInput);
                    }

                    //  Возможные кодировки, с которыми работает приложение.

                    if (strInput == "encoding")
                    {
                        flagComand = true;
                        UseCoding();
                    }

                    // Список доступных команд.

                    if (strInput == "help")
                    {
                        flagComand = true;
                        Console.Write(Environment.NewLine);
                        HelpText();
                    }

                    // Завершение работы приложения.

                    if (strInput == "exit")
                    {
                        flagComand = true;
                        Console.Write(Environment.NewLine);
                        Console.WriteLine("До скорых встреч!");
                        Environment.Exit(0);
                    }

                    // Некорректный ввод в консоль.

                    if (flagComand == false)
                    {
                        Console.Write(Environment.NewLine);
                        Console.WriteLine($"\"{strInput}\" не является командой, исполняемой программой или пакетным файлом.");
                        Console.Write(Environment.NewLine);
                    }

                    flagComand = false;
                }
                else
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("Введены недопустимые символы!");
                    Console.WriteLine("Недопустимыми символами явлются: '<', '>', '|', '?', '*', '/', '\\', ':', '\"', '\''");
                    Console.Write(Environment.NewLine);
                }

            } while (true);
        }
    }
}
