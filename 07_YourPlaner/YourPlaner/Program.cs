using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;
using System.IO;

namespace YourPlaner
{
    partial class Program
    {
        /// <summary>
        /// Список проектов.
        /// </summary>
        static List<Project> projects = new List<Project>();

        /// <summary>
        /// Список пользователей.
        /// </summary>
        static List<Person> peoples = new List<Person>();

        static void Main(string[] args)
        {
            Console.WriteLine("Приветствую в консольном приложении \"YourPlanner\"!");

            // Установка настроек.
            try
            {
                UploadSettings();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Произошла неизвестная ошибка при настройки приложения!" +
                    $"\n\nОшибка: {ex}" +
                    $"\n\nДля корректной работы приложения очистите файл в корневой папке \"setting.txt\"!");
            }

            // Командное меню приложения.
            ComandMenu();
        }

        /// <summary>
        /// Командное меню приложения.
        /// </summary>
        static void ComandMenu()
        {
            int numberComand;

            do
            {
                // Вспомогательный текст.
                StartText();

                if (!int.TryParse(Console.ReadLine(), out numberComand) || numberComand < 0 || numberComand > 3)
                {
                    IncorrectInputText();
                }
                else
                {
                    Console.Clear();

                    switch (numberComand)
                    {
                        // Выход из программы.
                        case 0:
                            ProgramExit();
                            break;
                        // Работа с проектами.
                        case 1:
                            WorkWithProjects();
                            break;
                        // Работа с пользователями.
                        case 2:
                            WorkWithPeople();
                            break;
                        // Выбор категории задач для работы.
                        case 3:
                            SelectTypeOfTheTasks();
                            break;
                    }
                }
            } while (true);
        }

        /// <summary>
        /// Выбор категории задач для работы.
        /// </summary>
        static void SelectTypeOfTheTasks()
        {
            int numberComand;

            // Проверка существования проектов.
            if (projects.Count == 0)
            {
                ProjectsNotExsistText();
                return;
            }

            do
            {
                // Вывод вспомогательного текста.
                SelectTypeOfTheTasksText();

                if (!int.TryParse(Console.ReadLine(), out numberComand) || numberComand < 0 || numberComand > 2)
                {
                    IncorrectInputText();
                }
                else
                {
                    Console.Clear();

                    switch (numberComand)
                    {
                        // Выход из меню.
                        case 0:
                            Console.Clear();
                            return;
                        // Работа с задачами всех типов.
                        case 1:
                            WorkWithProjectAllTasks();
                            break;
                        // Работа с подзадачами задачи типа Epic.
                        case 2:
                            WorkWithProjectEpicTasks();
                            break;
                    }
                }
            } while (true);
        }

        /// <summary>
        /// Установка сохраненных настроек.
        /// </summary>
        static void UploadSettings()
        {
            string[] arraySettings = File.ReadAllLines($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}settings.txt", Encoding.UTF8);

            if (arraySettings.Length < 4)
            {
                return;
            }

            int.TryParse(arraySettings[0], out int countOfTheProjects);

            int i = 2;

            while (arraySettings[i] != "e")
            {
                peoples.Add(new Person(arraySettings[i++]));
            }

            if (arraySettings[i] == "e")
            {
                i++;
            }

            SettingsProjects(arraySettings, ref i, countOfTheProjects);
        }

        /// <summary>
        /// Установка настроек для проектов.
        /// </summary>
        /// <param name="arraySettings">Массив с данными.</param>
        /// <param name="i">Итератор массива</param>
        /// <param name="countOfTheProjects">Количество проектов.</param>
        static void SettingsProjects(string[] arraySettings, ref int i, int countOfTheProjects)
        {
            // Цикл по количеству проектов.
            for (int j = 0; j < countOfTheProjects; j++)
            {
                // Номер задачи в проекте.
                int counterTasks = 0;

                while (arraySettings[i++] != "p")
                {
                    // Название проекта.
                    string name = arraySettings[i++];

                    // Максимальное количество задач.
                    int.TryParse(arraySettings[i++], out int maxCountTasks);

                    // Создание проекта.
                    projects.Add(new Project(name, maxCountTasks));

                    // Количество задач в проекте.
                    int.TryParse(arraySettings[i++], out int actualCountTasks);

                    // Количество задач типа Epic.
                    int.TryParse(arraySettings[i++], out int maxCountEpicTasks);

                    // Цикл по количеству задач.
                    for (int k = 0; k < actualCountTasks; k++)
                    {
                        // Проверка типа задач и создание их экземпляров.
                        if (arraySettings[i] == "Story" || arraySettings[i] == "Bug" || arraySettings[i] == "Task")
                        {
                            SettingsAllTasks(arraySettings, ref i, ref k, ref counterTasks);
                        }
                        else if (arraySettings[i] == "Epic")
                        {
                            SettingsEpicTasks(arraySettings, ref i, ref counterTasks);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Настройка всех типов задач.
        /// </summary>
        /// <param name="arraySettings">Массив с данными.</param>
        /// <param name="i">Итератор массива.</param>
        /// <param name="k">Номер задачи.</param>
        /// <param name="counterTasks">Количество задач.</param>
        static void SettingsAllTasks(string[] arraySettings, ref int i, ref int k, ref int counterTasks)
        {
            // Создание задачи с именем и типом задачи.
            projects[projects.Count - 1].CreateTasks(arraySettings[i++], arraySettings[i++]);

            // Установка даты создания задачи.
            projects[projects.Count - 1].SetDateForTask(counterTasks, DateTime.Parse(arraySettings[i++]));

            // Установка статуса задачи.
            projects[projects.Count - 1].SetStatusForTask(counterTasks, arraySettings[i++]);

            // Количество исполнителей задачи.
            int.TryParse(arraySettings[i++], out int countPeoples);

            // Цикл по количеству исполнителей задачи.
            for (int x = 0; x < countPeoples; x++)
            {
                // Назначение исполнителей задачи.
                projects[projects.Count - 1].ManagePeoples(peoples[FindPeopleForName(arraySettings[i++])], k);
            }

            counterTasks++;
        }

        /// <summary>
        /// Настройка задач типа Epic.
        /// </summary>
        /// <param name="arraySettings">Массив с данными.</param>
        /// <param name="i">Итератор массива.</param>
        /// <param name="counterTasks">Количество задач.</param>
        static void SettingsEpicTasks(string[] arraySettings, ref int i, ref int counterTasks)
        {
            // Создание задачи.
            projects[projects.Count - 1].CreateTasks(arraySettings[i++], arraySettings[i++]);

            // Установка даты создания задачи.
            projects[projects.Count - 1].SetDateForTask(counterTasks, DateTime.Parse(arraySettings[i++]));

            // Установка статуса задачи.
            projects[projects.Count - 1].SetStatusForTask(counterTasks, arraySettings[i++]);

            // Количество подзадач.
            int.TryParse(arraySettings[i++], out int countUnderTasks);

            // Получение объекта задачи типа Epic.
            projects[projects.Count - 1].FindEpicTasks();
            Epic epicTask = projects[projects.Count - 1].GetEpicTask(projects[projects.Count - 1].CountEpicTasks() - 1);

            // Цикл по количеству подзадач типа Epic.
            for (int x = 0; x < countUnderTasks; x++)
            {
                // Добавление подзадачи.
                epicTask.AddTasks(arraySettings[i++], arraySettings[i++]);

                // Установка даты создания подзадачи.
                epicTask.SetDateForTask(x, DateTime.Parse(arraySettings[i++]));

                // Установка статуса подзадачи.
                epicTask.SetStatusForTask(x, arraySettings[i++]);

                // Количество исполнителей подзадачи.
                int.TryParse(arraySettings[i++], out int countPeoples);

                // Цикл по количеству исполнителей.
                for (int g = 0; g < countPeoples; g++)
                {
                    // Назначение исполнителей.
                    epicTask.ManagePeoples(peoples[FindPeopleForName(arraySettings[i++])], x);
                }
            }

            counterTasks++;
        }

        /// <summary>
        /// Поиск номера объекта пользователя по его имени.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        /// <returns>Номер объекта в списке.</returns>
        static int FindPeopleForName(string name)
        {
            for (int i = 0; i < peoples.Count; i++)
            {
                if (peoples[i].Name == name)
                {
                    return i;
                }
            }

            return 0;
        }

        /// <summary>
        /// Выход из программы.
        /// </summary>
        static void ProgramExit()
        {
            try
            {
                string info = $"{projects.Count}";
                info += "\npeoples";

                // Сохранение данных всех пользователей.
                for (int i = 0; i < peoples.Count; i++)
                {
                    info += $"\n{peoples[i].Name}";
                }

                info += "\ne";

                // Сохранение данных со всех проектов.
                for (int i = 0; i < projects.Count; i++)
                {
                    info += projects[i].SaveAllInfoAboutProject();
                }

                // Запись информации в файл.
                StreamWriter streamWriter = new StreamWriter($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}settings.txt", false, Encoding.UTF8);
                streamWriter.WriteLine(info);
                streamWriter.Close();

                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("До скорых встреч!");
                Console.ResetColor();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Произошла неизвестная ошибка при сохранении настроек приложения!" +
                    $"\n\nОшибка: {ex}" +
                    $"\n\nДля корректной работы приложения очистите файл в корневой папке \"setting.txt\"!");
            }
        }
    }
}
