using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WarehouseManager
{
    partial class Program
    {
        static void FileInputWarehouse(ref Warehouse warehouse)
        {
            int countConatainers;
            double feeContainers;
            string pathWarehouse = "";
            string[] warehouseArray = new string[0];

            do
            {
                Console.Write("Введите путь до файла с информацией о характеристиках склада: ");
                pathWarehouse = Console.ReadLine();
            } while (!File.Exists(pathWarehouse));

            try
            {
                // Считывание информации из файла.

                warehouseArray = File.ReadAllLines(pathWarehouse, Encoding.UTF8);

                // Проверка на корректность введенных данных.

                if (warehouseArray.Length == 2)
                {
                    if (warehouseArray[0].StartsWith("Size = ") && warehouseArray[1].StartsWith("Price = "))
                    {
                        // Удаление ключевых слов.

                        warehouseArray[0] = warehouseArray[0].Remove(0, 7);
                        warehouseArray[1] = warehouseArray[1].Remove(0, 8);

                        if (int.TryParse(warehouseArray[0], out countConatainers) && double.TryParse(warehouseArray[1], out feeContainers) && (countConatainers >= 1 && countConatainers <= 10000) && (feeContainers >= 0.01 && feeContainers <= 10000))
                        {
                            // Создание нового склада.

                            warehouse = new Warehouse(countConatainers);
                            warehouse.FeeContainers = feeContainers;

                            Console.Write(Environment.NewLine);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Склад успешно организован! Стоимость хранения контейнеров: {warehouse.FeeContainers:f2}$," +
                                $" количество мест для контейнеров: {warehouse.CountConatainers}.");
                            Console.ResetColor();
                            Console.Write(Environment.NewLine);
                            Console.WriteLine("Для продолжения работы, нажмите любую клавишу!");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            throw new ArgumentException("Ошибка ввода! Некорректно введено число контейнеров или цена за храненение контейнеров!");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Ошибка ввода! Некорректно введены ключевые слова!");
                    }
                }
                else
                {
                    throw new ArgumentException("Ошибка ввода! Количество строк должно быть равно 2!");
                }
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

        static void FileInputContainers(ref Warehouse warehouse)
        {
            // Переменные.

            string pathContainers;
            string[] containersArray;
            int countString = 0;
            int countBoxes = 0;
            double weightBox;
            double feeBox;
            string idContainer;

            // Вспомогательный текст.

            ContainersInputText();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите путь до файла с информацией о характеристиках контейнера: ");
                pathContainers = Console.ReadLine();
            } while (!File.Exists(pathContainers));

            try
            {
                containersArray = File.ReadAllLines(pathContainers, Encoding.UTF8);

                // Подсчет количества строк, начинающихся с ключевого слова.

                for (int i = 0; i < containersArray.Length; i++)
                {
                    if (containersArray[i].StartsWith("Container "))
                    {
                        countString++;
                    }
                }

                // Проверка на корректность ввода.

                if (countString <= warehouse.CountConatainers)
                {
                    for (int i = 0; i < containersArray.Length;)
                    {
                        if (containersArray[i].StartsWith("Container "))
                        {
                            // Удаление ключевого слова и создание контейнера с тегом.

                            containersArray[i] = containersArray[i].Remove(0, 10);

                            idContainer = containersArray[i];

                            if (idContainer.Length >= 1 && idContainer.Length <= 8)
                            {
                                warehouse.SetContainerInfo(idContainer);
                            }
                            else
                            {
                                warehouse.SetContainerInfo("DefaultTag");
                            }

                            // Вывод информации на экран.

                            warehouse.PrintContainers();
                            i++;

                            if (containersArray[i].StartsWith("Boxes = "))
                            {
                                containersArray[i] = containersArray[i].Remove(0, 8);

                                // Считывание информации из файла о ящиках в контейнере.

                                if (int.TryParse(containersArray[i], out countBoxes) && countBoxes >= 1 && countBoxes <= 1000)
                                {
                                    i++;

                                    do
                                    {
                                        Console.Write(Environment.NewLine);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Производим заполнение контейнера ящиками ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.ResetColor();

                                        if (double.TryParse(containersArray[i], out weightBox) && weightBox >= 0.01 && weightBox <= 1000)
                                        {
                                            i++;
                                        }
                                        else
                                        {
                                            throw new ArgumentException("Вес ящика введен некорректно!");
                                        }

                                        if (double.TryParse(containersArray[i], out feeBox) && feeBox >= 0.01 && feeBox <= 10000)
                                        {
                                            i++;
                                        }
                                        else
                                        {
                                            throw new ArgumentException("Цена за киллограм овощей в ящике введена некорректно!");
                                        }

                                        warehouse.Box(weightBox, feeBox, out bool flag);

                                        if (flag == true)
                                        {
                                            Console.Write(Environment.NewLine);
                                            Console.WriteLine("Контейнер заполнен!");
                                            break;
                                        }

                                        countBoxes--;
                                    } while (countBoxes != 0);

                                    warehouse.Check();
                                }
                                else
                                {
                                    throw new ArgumentException("Количество ящиков введено некорректно!");
                                }
                            }
                            else
                            {
                                throw new ArgumentException("Количество ящиков введено некорректно!");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Некорректный ввод!");
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Количество контейнеров в файле, не соответсвует количечству мест под контейнеры!");
                }
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

            // Вывод информации о контейнерах на экран.

            warehouse.PrintContainers();

            Console.Write(Environment.NewLine);
            Console.WriteLine("Для продолжения работы, нажмите любую клавишу!");
            Console.ReadKey();
            Console.Clear();
        }

        static void FileInputMoves(ref Warehouse warehouse)
        {
            // Переменные.

            string idContainer;
            string pathActions;
            string[] actionsArray;
            int lenghtCount = 0;
            int numberOfContainer;
            int deleteContainers = 0;
            int deleteID = 0;

            // Вспомогательный текст.

            MovesInputText();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите путь до файла с информацией о характеристиках контейнера: ");
                pathActions = Console.ReadLine();
                if (pathActions == "0")
                {
                    break;
                }
            } while (!File.Exists(pathActions));

            if (pathActions != "0")
            {
                try
                {
                    actionsArray = File.ReadAllLines(pathActions, Encoding.UTF8);

                    if (actionsArray.Length >= 1)
                    {
                        // Подсчет ключевых слов.

                        for (int i = 0; i < actionsArray.Length; i++)
                        {
                            if (actionsArray[i].StartsWith("CreateContainer") || actionsArray[i].StartsWith("DeleteContainer "))
                            {
                                lenghtCount++;
                            }

                            if (actionsArray[i].StartsWith("DeleteContainer "))
                            {
                                deleteContainers++;
                            }
                        }

                        // Проверка корректности ввода.

                        if (lenghtCount == actionsArray.Length)
                        {
                            for (int i = 0; i < actionsArray.Length; i++)
                            {
                                // Создание контейнеров с тегом.

                                if (actionsArray[i].StartsWith("CreateContainer"))
                                {
                                    actionsArray[i] = actionsArray[i].Remove(0, 16);

                                    idContainer = actionsArray[i];

                                    if (idContainer.Length >= 1 && idContainer.Length <= 8)
                                    {
                                        warehouse.SetContainerInfo(idContainer);
                                    }
                                    else
                                    {
                                        idContainer = "DefaultTag";
                                    }

                                    warehouse.SetContainerInfo(idContainer);
                                }

                                // Удаление контейнеров.

                                if (actionsArray[i].StartsWith("DeleteContainer "))
                                {
                                    do
                                    {
                                        actionsArray[i] = actionsArray[i].Remove(0, 16);

                                        if (warehouse.GetContainers != 0)
                                        {
                                            if (int.TryParse(actionsArray[i], out numberOfContainer) && ((numberOfContainer - deleteID) <= warehouse.GetContainers && numberOfContainer >= 1))
                                            {
                                                warehouse.DeleteContainer(numberOfContainer - deleteID);
                                            }
                                        }
                                        else
                                        {
                                            throw new ArgumentException("Некорректный ввод! Невозможно удалить указанные контейнеры!");
                                        }

                                        deleteContainers--;
                                        deleteID++;
                                        i++;
                                    } while (deleteContainers != 0);
                                }
                            }

                            Console.Write(Environment.NewLine);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Все действия, описанные в файле, были успешно произведены!");
                            Console.ResetColor();
                        }
                        else
                        {
                            throw new ArgumentException("Некорректный ввод! В строке отсутствует команда для выполнения!");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Файл пустой!");
                    }
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
}
