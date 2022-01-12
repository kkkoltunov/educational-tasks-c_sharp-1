using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;

namespace YourPlaner
{
    partial class Program
    {
        /// <summary>
        /// Меню для работы с пользователями.
        /// </summary>
        static void WorkWithPeople()
        {
            int numberComand;

            Console.Clear();

            do
            {
                // Вывод вспомогательного текста на экран.
                WorkWithPeoplesText();

                if (!int.TryParse(Console.ReadLine(), out numberComand) || numberComand < 0 || numberComand > 3)
                {
                    IncorrectInputText();
                }
                else
                {
                    switch (numberComand)
                    {
                        // Выход из меню.
                        case 0:
                            Console.Clear();
                            return;
                        // Добавление пользователя.
                        case 1:
                            AddPeople();
                            break;
                        // Удаление пользователя.
                        case 2:
                            RemovePeople();
                            break;
                        // Получение информации о пользователях.
                        case 3:
                            InfoAboutPeople();
                            break;
                    }
                }
            } while (true);
        }

        /// <summary>
        /// Добавление пользователя.
        /// </summary>
        static void AddPeople()
        {            
            string nameOfThePerson = "";

            Console.Clear();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Укажите имя пользователя [от 2 до 12 символов]: ");
                nameOfThePerson = Console.ReadLine();
                peoples.Add(new Person(nameOfThePerson));
            } while (nameOfThePerson.Length < 2 || nameOfThePerson.Length > 12);

            Console.Clear();

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Пользователь с именем \"{peoples[peoples.Count - 1].Name}\" успешно добавлен!");
            Console.ResetColor();
        }

        /// <summary>
        /// Удаление пользователя из списка.
        /// </summary>
        static void RemovePeople()
        {
            int numberOfHuman;

            Console.Clear();

            // Проверка количества исполнителей задачи.
            if (peoples.Count == 0)
            {
                IncorrectCountPeoplesText();
            }
            else
            {
                // Вывод на экран списка пользователей.
                AllPeoplesPrint();

                do
                {
                    Console.Write(Environment.NewLine);
                    Console.Write("Введите номер человека по списку, которого хотите удалить: ");
                } while (!int.TryParse(Console.ReadLine(), out numberOfHuman) || numberOfHuman < 1 || (numberOfHuman > peoples.Count));

                Console.Clear();

                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Пользователь с именем \"{peoples[numberOfHuman - 1].Name}\" успешно удален!");
                Console.ResetColor();

                // Удаление пользователя с роли исполнителя задач.
                for (int i = 0; i < projects.Count; i++)
                {
                    projects[i].RemovePeopleOnTheTask(peoples[numberOfHuman - 1]);
                }

                // Удаление выбранного пользователя.
                peoples.Remove(peoples[numberOfHuman - 1]);
            }
        }

        /// <summary>
        /// Получение информации о пользователях.
        /// </summary>
        static void InfoAboutPeople()
        {
            Console.Clear();

            // Проверка количества пользователей.
            if (peoples.Count == 0)
            {
                IncorrectCountPeoplesText();
            }
            else
            {
                // Вывод на экран всех пользователей.
                AllPeoplesPrint();
            }
        }

        /// <summary>
        /// Вывод на экран списка всех пользователей.
        /// </summary>
        static void AllPeoplesPrint()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("============================================ Список пользователей ============================================");
            Console.ResetColor();
            Console.Write(Environment.NewLine);

            // Цикл по списку пользователей.
            for (int i = 0; i < peoples.Count; i++)
            {
                Console.WriteLine($"{i + 1} пользователь: {peoples[i].Name}");
            }

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==============================================================================================================");
            Console.ResetColor();
        }
    }
}
