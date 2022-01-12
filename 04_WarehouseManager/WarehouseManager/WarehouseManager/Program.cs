using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace WarehouseManager
{
    partial class Program
    {
        static void Main()
        {
            // Переменные.

            int countConatainers;
            double feeContainers;
            int numberComand;

            // Инициализация пустого склада.

            Warehouse warehouse = new Warehouse(0);

            Console.Clear();

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Овощной склад ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Приветствую! Я помощник на данном складе, поэтому хочу рассказать тебе немного о функционале склада!");

            do
            {
                StartText();
            } while (!int.TryParse(Console.ReadLine(), out numberComand) || numberComand < 1 || numberComand > 2);

            Console.Write(Environment.NewLine);

            // Ввод данных вручную.

            if (numberComand == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Мы предоставляем тебе территорию для размещения своих контейнеров. В самом начале, ты должен указать их количество.");
                Console.WriteLine("На следующем шаге тебе будет предоставлена возможность установить фиксированную плату за хранение каждого контейнера.");
                Console.ResetColor();
                Console.Write(Environment.NewLine);

                do
                {
                    Console.Write("Введите желаемое количество мест для контейнеров на складе (от 1 до 10000): ");
                } while (!int.TryParse(Console.ReadLine(), out countConatainers) || countConatainers < 1 || countConatainers >= 10000);

                warehouse = new Warehouse(countConatainers);
                Console.Write(Environment.NewLine);

                do
                {
                    Console.Write("Введите желаемую стоимость за хранение контейнера на складе (от 0.01 до 10000): ");
                } while (!double.TryParse(Console.ReadLine(), out feeContainers) || feeContainers < 0.01 || feeContainers > 10000);

                warehouse.FeeContainers = feeContainers;

                Console.Clear();

                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Склад успешно организован! Стоимость за хранение контейнеров: {warehouse.FeeContainers:f2}$," +
                    $" количество мест для контейнеров: {warehouse.CountConatainers}.");
                Console.ResetColor();
            }

            // Ввод данных из файла.

            if (numberComand == 2)
            {
                Console.Clear();

                // Вспомогательный текст.

                WarehouseInputText();
                
                // Метод для создания склада.

                FileInputWarehouse(ref warehouse);

                // Метод для заполнения склада контейнерами и ящиками.

                FileInputContainers(ref warehouse);

                // Метод для действий с контейнерами.

                FileInputMoves(ref warehouse);
            }

            // Ввод команды пользователем с клавиатуры.

            ComandMenuUser(ref warehouse);
        }

        /// <summary>
        /// Метод для выбора нужной операции для действий со складом.
        /// </summary>
        /// <param name="warehouse">Объект склада</param>
        static void ComandMenuUser(ref Warehouse warehouse)
        {
            int numberComand;

            do
            {
                ComandTextMenu();

                Console.Write("Введите номер желаемой команды: ");

                if (!int.TryParse(Console.ReadLine(), out numberComand) || (numberComand < 0 || numberComand > 6))
                {
                    Console.Write(Environment.NewLine);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Некорректный ввод, пожалуйста, повторите попытку!");
                    Console.ResetColor();
                }
                else
                {
                    switch (numberComand)
                    {
                        case 0:
                            ProgramExit();
                            break;
                        case 1:
                            AddContainer(ref warehouse);
                            break;
                        case 2:
                            DeleteContainer(ref warehouse);
                            break;
                        case 3:
                            InfoContainer(ref warehouse);
                            break;
                        case 4:
                            BoxAdd(ref warehouse);
                            break;
                        case 5:
                            InfoToFile(ref warehouse);
                            break;
                        case 6:
                            Console.Clear();
                            break;
                    }
                }
            } while (true);
        }

        /// <summary>
        /// Выход из программы, с возможностью создания нового склада.
        /// </summary>
        static void ProgramExit()
        {
            string input = "";

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите \"0\", если хотите выйти из программы, или \"1\" для создания нового склада: ");
                input = Console.ReadLine();
            } while (input != "0" && input != "1");

            if (input == "0")
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("До скорых встреч!");
                Environment.Exit(0);
            }
            if (input == "1")
            {
                Main();
            }
        }


        /// <summary>
        /// Метод, в котором происходит создание контейнера с тегом, и заполнение его ящиками.
        /// </summary>
        /// <param name="warehouse">Объект склада</param>
        static void AddContainer(ref Warehouse warehouse)
        {
            string idContainer;
            int countBoxes;
            double weightBox;
            double feeBox;
            int i = 1;

            Console.Clear();

            do
            {
                Console.Write("Введите тег для контейнера (от 1 до 8 символов): ");
                idContainer = Console.ReadLine();
            } while (idContainer.Length < 1 || idContainer.Length > 8);

            // Создание контейнера с тегом.

            warehouse.SetContainerInfo(idContainer);

            // Вывод информации о всех контейнерах на складе.

            warehouse.PrintContainers();

            Console.Write(Environment.NewLine);

            do
            {
                Console.Write("Введите количество ящиков в контейнере (от 1 до 10000): ");
            } while (!int.TryParse(Console.ReadLine(), out countBoxes) || countBoxes < 1 || countBoxes > 10000);

            do
            {
                Console.Write(Environment.NewLine);

                do
                {
                    Console.Write($"Введите вес {i} ящика (от 0.01 до 1000): ");
                } while (!double.TryParse(Console.ReadLine(), out weightBox) || weightBox < 0.1 || weightBox > 1000);

                do
                {
                    Console.Write("Введите цену за киллограм (от 0.01 до 10000): ");
                } while (!double.TryParse(Console.ReadLine(), out feeBox) || feeBox < 0.1 || feeBox > 10000);

                // Создание ящика в контейнере.

                warehouse.Box(weightBox, feeBox, out bool flag);

                if (flag == true)
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("Контейнер заполнен!");
                    break;
                }

                i++;
                countBoxes--;
            } while (countBoxes != 0);

            // Проверка на корректность содержимого контейнера.

            warehouse.Check();
        }

        /// <summary>
        /// Метод, в котором происходит удаление контейнеров.
        /// </summary>
        /// <param name="warehouse">Объект склада</param>
        static void DeleteContainer(ref Warehouse warehouse)
        {
            int numberOfContainer;

            Console.Clear();

            // Вывод информации о контейнерах на экран.

            warehouse.PrintContainers();

            if (warehouse.GetContainers != 0)
            {
                do
                {
                    Console.Write(Environment.NewLine);
                    Console.Write($"Введите номер контейнера (из предоставленного списка), который вы хотите удалить: ");
                } while (!int.TryParse(Console.ReadLine(), out numberOfContainer) || numberOfContainer > warehouse.GetContainers || numberOfContainer < 1);

                // Удаление контейнера.

                warehouse.DeleteContainer(numberOfContainer);

                Console.Clear();

                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Контейнер успешно удален со склада!");
                Console.ResetColor();

                warehouse.PrintContainers();
            }
        }


        /// <summary>
        /// Метод для получения информации о контейнере и его содержимом.
        /// </summary>
        /// <param name="warehouse">Объект склада</param>
        static void InfoContainer(ref Warehouse warehouse)
        {
            int numberOfContainer;

            Console.Clear();
            warehouse.PrintContainers();

            if (warehouse.GetContainers != 0)
            {
                do
                {
                    Console.Write(Environment.NewLine);
                    Console.Write("Введите номер контейнера, информацию о ящиках которого вы хотите получить: ");
                } while (!int.TryParse(Console.ReadLine(), out numberOfContainer) || numberOfContainer > warehouse.GetContainers || numberOfContainer < 1);

                // Получение информации о ящиках в указанном контейнере и вывод ее на экран.

                warehouse.BoxInfo(numberOfContainer);
            }
        }

        /// <summary>
        /// Метод для добавления ящиков в контейнер.
        /// </summary>
        /// <param name="warehouse">Объект склада</param>
        static void BoxAdd(ref Warehouse warehouse)
        {
            int numberOfContainer;
            int countBoxes;
            double weightBox;
            double feeBox;

            Console.Clear();

            warehouse.PrintContainers();

            if (warehouse.GetContainers != 0)
            {
                do
                {
                    Console.Write(Environment.NewLine);
                    Console.Write($"Введите номер контейнера (из предоставленного списка), в который вы хотите добавить ящики: ");
                } while (!int.TryParse(Console.ReadLine(), out numberOfContainer) || numberOfContainer > warehouse.GetContainers || numberOfContainer < 1);

                int i = warehouse.BoxInContainer(numberOfContainer) + 1;

                Console.Write(Environment.NewLine);

                do
                {
                    Console.Write("Введите число ящиков, которые вы хотите добавить: ");
                } while (!int.TryParse(Console.ReadLine(), out countBoxes) || countBoxes < 1);

                do
                {
                    Console.Write(Environment.NewLine);

                    do
                    {
                        Console.Write($"Введите вес {i} ящика: ");
                    } while (!double.TryParse(Console.ReadLine(), out weightBox) || weightBox < 0.1);

                    do
                    {
                        Console.Write("Введите цену за киллограм: ");
                    } while (!double.TryParse(Console.ReadLine(), out feeBox) || feeBox < 0.1);

                    warehouse.BoxAdd(weightBox, feeBox, out bool flag, numberOfContainer);

                    if (flag == true)
                    {
                        Console.Write(Environment.NewLine);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Контейнер заполнен!");
                        Console.ResetColor();
                        break;
                    }

                    i++;
                    countBoxes--;
                } while (countBoxes != 0);

                // Проверка контейнера на содержимое.

                warehouse.Check();

                // Вывод информации о контейнерах.

                warehouse.PrintContainers();
            }
        }


        /// <summary>
        /// Вывод ифнормации о контейнерах и их содержимом в файл.
        /// </summary>
        /// <param name="warehouse">Объект склада</param>
        static void InfoToFile(ref Warehouse warehouse)
        {
            Console.Clear();

            // Список, в который добавляется вся информация о контейнерах.

            List<string> infoContainers = new List<string>();

            string pathToOutput;

            do
            {
                Console.Write("Введите полный путь до файла, в который Вы хотите вывести информацию: ");
                pathToOutput = Console.ReadLine();
            } while (!File.Exists(pathToOutput));

            try
            {
                // Метод, в которм добавляется вся информация о контейнерах в список.

                warehouse.PrintContainersToFile(infoContainers);
                
                // Переопредление файла.

                StreamWriter sw = new StreamWriter(pathToOutput, false);
                sw.Close();
                
                // Запись в файл всех строк из списка.

                File.AppendAllLines(pathToOutput, infoContainers);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Environment.NewLine);
                Console.WriteLine("Запись информации о контейнерах в файл успешно произведена!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"К сожалению, произошла ошибка: {ex.Message}");
                Console.ResetColor();
                Console.Write(Environment.NewLine);
                Console.WriteLine("Для продолжения работы, нажмите любую клавишу!");
                Console.ReadKey();
                Console.Clear();
                Main();
            }
        }
    }
}
