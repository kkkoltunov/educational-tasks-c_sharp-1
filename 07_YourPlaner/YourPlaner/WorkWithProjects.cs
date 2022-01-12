using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;

namespace YourPlaner
{
    partial class Program
    {
        /// <summary>
        /// Меню для работы с проектами.
        /// </summary>
        static void WorkWithProjects()
        {
            int numberComand;

            Console.Clear();

            do
            {
                // Вывод вспомогательного текста на экран.
                WorkWithProjectsText();

                if (!int.TryParse(Console.ReadLine(), out numberComand) || numberComand < 0 || numberComand > 4)
                {
                    IncorrectCountPeoplesText();
                }
                else
                {
                    switch (numberComand)
                    {
                        // Выход из меню.
                        case 0:
                            Console.Clear();
                            return;
                        // Создание проекта.
                        case 1:
                            CreateProject();
                            break;
                        // Получение информации о проектах.
                        case 2:
                            InfoAboutProjects();
                            break;
                        // Изменение названия проекта.
                        case 3:
                            ChageNameOfTheProject();
                            break;
                        // Удаление проекта.
                        case 4:
                            RemoveProject();
                            break;
                    }
                }
            } while (true);
        }

        /// <summary>
        /// Изменение названия проекта.
        /// </summary>
        static void ChageNameOfTheProject()
        {
            int numberOfTheProject;
            string newNameOfTheProject;
            string oldNameOfTheProject;

            Console.Clear();

            // Проверка количества проектов.
            if (projects.Count == 0)
            {
                IncorrectCountProjectsText();
                return;
            }

            // Вывод информации о проектах.
            InfoAboutProjects();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер проекта по списку, имя которого хотите изменить: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTheProject) || numberOfTheProject < 1 || (numberOfTheProject > projects.Count));

            // Сохранение старого названия проекта.
            oldNameOfTheProject = projects[numberOfTheProject - 1].Name;

            Console.Clear();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите новое название проекта: ");
                newNameOfTheProject = Console.ReadLine();
            } while (newNameOfTheProject.Length < 2 || newNameOfTheProject.Length > 20);

            Console.Clear();

            // Изменение названия проекта.
            projects[numberOfTheProject - 1].Name = newNameOfTheProject;

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Название проекта \"{oldNameOfTheProject}\" изменено на \"{newNameOfTheProject}\".");
            Console.ResetColor();

        }

        /// <summary>
        /// Удаление проекта.
        /// </summary>
        static void RemoveProject()
        {
            Console.Clear();

            int numberOfTheProject;
            string nameOfTheDeleteProject;

            // Проверка количества проектов.
            if (projects.Count == 0)
            {
                IncorrectCountProjectsText();
                return;
            }

            // Вывод информации о проектах.
            InfoAboutProjects();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер проекта по списку, который хотите удалить: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTheProject) || numberOfTheProject < 1 || (numberOfTheProject > projects.Count));

            Console.Clear();

            // Сохранение названия удаляемого проекта.
            nameOfTheDeleteProject = projects[numberOfTheProject - 1].Name;

            // Удаление проекта.
            projects.Remove(projects[numberOfTheProject - 1]);

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Проект с именем \"{nameOfTheDeleteProject}\" успешно удален!");
            Console.ResetColor();
        }

        /// <summary>
        /// Создание проекта.
        /// </summary>
        static void CreateProject()
        {
            string nameOfTheProject;
            int maxCountTasks;

            Console.Clear();

            // Проверка количества исполнителей.
            if (peoples.Count == 0)
            {
                IncorrectCountPeoplesInProjectText();
                return;
            }

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Укажите имя проекта [от 2 до 20 символов]: ");
                nameOfTheProject = Console.ReadLine();
                Console.Clear();
            } while (nameOfTheProject.Length < 2 || nameOfTheProject.Length > 20);

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Укажите количество задач для проекта [от 3 до 25]: ");
            } while (!int.TryParse(Console.ReadLine(), out maxCountTasks) || maxCountTasks < 3 || maxCountTasks > 25);

            // Создание проекта.
            projects.Add(new Project(nameOfTheProject, maxCountTasks));

            Console.Clear();

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Проект успешно создан!");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.WriteLine(projects[projects.Count - 1]);
        }

        /// <summary>
        /// Вывод информации о существующих проектах.
        /// </summary>
        static void InfoAboutProjects()
        {
            Console.Clear();

            if (projects.Count == 0)
            {
                IncorrectCountProjectsText();
                return;
            }

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("============================================== Список проектов ==============================================");
            Console.ResetColor();
            Console.Write(Environment.NewLine);

            // Вывод информации с соответствующим отступом.
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Номер:".PadRight(10) +
                " Название:".PadRight(24) +
                " Количество задач:".PadRight(25) +
                " Максимальное количество задач:".PadRight(35));
            Console.ResetColor();

            // Цикл по списку проектов.
            for (int i = 0; i < projects.Count; i++)
            {
                Console.WriteLine($"{(i + 1).ToString().PadRight(10)}" +
                    $" {projects[i].Name.PadRight(24)}" +
                    $"{projects[i].ActualCountTasks().ToString().PadRight(25)}" +
                    $"{projects[i].MaxCountTasks.ToString().PadRight(35)}");
            }

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==============================================================================================================");
            Console.ResetColor();

        }
    }
}
