using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    partial class Program
    {
        // Текст, который выводится при запуске программы.

        static void StartText()
        {
            Console.WriteLine("Приветствую в консольном приложении - \"Файловый менеджер\"!");
            Console.WriteLine("Если в процессе выполнения программы возникают вопросы - напишите команду \"HELP\".");
            Console.WriteLine("Для того, чтобы завершить работу консольного приложения - напишите \"EXIT\".");
            Console.Write(Environment.NewLine);
            Console.WriteLine("На данном этапе, Вам нужно выбрать диск, с которого мы начнем работу!");
        }

        // Текст, который выводится при смене диска.

        static void ProcessText()
        {
            Console.WriteLine("Вы вернулись в меню выбора диска.");
            Console.WriteLine("Если у вас остались вопросы - напишите команду \"HELP\"");
            Console.WriteLine("Для того, чтобы завершить работу консольного приложения - напишите \"EXIT\"");
        }

        // Текст, который выводится при вызове команды "help".

        static void HelpText()
        {
            Console.WriteLine("Список доступных команд:");
            Console.Write(Environment.NewLine);
            Console.WriteLine("\"cd\" - смена диска.");
            Console.WriteLine("\"cd -\" - возврат к предыдущей директории.");
            Console.WriteLine("\"dir\" - вывод списка файлов и подпапок из указанной папки.");
            Console.WriteLine("\"encoding\" - список возможных кодировок, с которыми работает файловый менеджер.");
            Console.WriteLine("\"rf название файла.расширение кодировка\" - вывод содержимого текстового файла в указанной кодировке (3 параметра).");
            Console.WriteLine("\"del название файла.расширение\" - удаление файла (2 параметра).");
            Console.WriteLine("\"mv\" - перемещение файла");
            Console.WriteLine("\"cp\" - копирование файла");
            Console.WriteLine("\"ct\" - конкатенация содержимого нескольих файлов и вывод результата в консоль.");
            Console.WriteLine("\"cr\" - создание файла и запись текста в него в кодировке UTF-8");
            Console.WriteLine("\"cr кодировка\" - создание файла и запись текста в него в указанной кодировке.");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Для использования команды \"del название файла.расширение\" и команды \"rf название файла.расширение кодировка\" нужно находится в директории с данными файлом.");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Для перехода в другую директорию нужно ввести ее название и ничего более.");
            Console.WriteLine("Для вывода содержимого текствого файла в консоль в кодировке UTF-8, достаточно ввести его название.");
            Console.WriteLine("При вводе следующих команд \"ct\", \"cp\", \"mv\", \"cr\", \"cr кодировка\" будет открыто дополнительное меню с дальнейшими действиями. ");
            Console.WriteLine("Важное замечание: используя команды, вы не можете ставить пробелов больше, чем указано в самих командах, иначе получите ошибку!");
            Console.WriteLine("В приложении гарантируется коректная работа с файлами расширения \"txt\". С другими файлами могут возникать ошибки.");
            Console.WriteLine("Запрещается проводить операции с файлами запущенного проекта! Дальнейшая работоспособность приложения не гарантируется!");
            Console.WriteLine("Не рекомендуется переходить по скрытым папкам и файлам. Также важно учитывать, что при укзаании полного пути до файла регистр ВАЖЕН!");
            Console.Write(Environment.NewLine);
        }

        // Текст, который выводится в методе ChosenDisk().

        static void HelpTextChosenDiskFirst()
        {
            Console.WriteLine("Примечание: в данном приложении можно работать только с жестким диском компьютера или съемным устройством хранения.");
            Console.WriteLine("Для того, чтобы выбрать том(диск) и попасть в его корневой каталог введите:");
            Console.WriteLine("Пример для Windows: \"Имя диска(тома):\\\"");
            Console.WriteLine("Пример для Unix-подобных систем: \"/../..\"");
            Console.Write(Environment.NewLine);
        }

        // Текст, который выводится при вызове команды "help" в методе ChosenDisk().

        static void HelpTextChosenDiskSecond()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("Зачем нужен нужен выбор этого диска? Все просто...");
            Console.WriteLine("Данный файловый менеджер является эмулятором командной строки, поэтому, Вам предлагается выбрать диск.");
            Console.WriteLine("Безусловно, в процессе работы приложения, Вы сможете изменить диск.");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Примечание: если все параметры установлены по умолчанию, то при открытии консоли в Windows");
            Console.WriteLine("диск и начальный путь уже будет указан, поэтому Вам предоставляется возможность выбора! :)");
        }

        // Кодировки, с которыми работает программа.

        static void UseCoding()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("Данное приложение поддерживает следующие кодировки:");
            Console.WriteLine("\"UTF-32\", \"UTF-8\", \"UTF-7\", \"ASCII\", \"Unicode\".");
            Console.WriteLine("По умолчанию используется коидровка \"UTF-8\".");
            Console.Write(Environment.NewLine);
        }

        // Проверка на наличие недопустимых символов, во введенной пользователем строке.

        static bool CheckInput(string strInput)
        {
            bool check = false;

            // Массив с недопустимыми символами.

            char[] input = { '<', '>', '|', '?', '*', '/', '\\', ':', '\"', '\'' };

            // Сравнение строки с массивом.

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < strInput.Length; j++)
                {
                    if (input[i] == strInput[j])
                    {
                        check = true;
                    }
                }
            }

            return check;
        }
    }
}
