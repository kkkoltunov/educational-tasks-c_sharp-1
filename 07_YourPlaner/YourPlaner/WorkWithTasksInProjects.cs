using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;

namespace YourPlaner
{
    partial class Program
    {
        /// <summary>
        /// Меню для работы с заданиями.
        /// </summary>
        static void WorkWithProjectAllTasks()
        {
            Console.Clear();

            int numberOfTheProject;

            // Информация о проектах.
            InfoAboutProjects();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер проекта по списку, с которым хотите продолжить работать дальше: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTheProject) || numberOfTheProject < 1 || (numberOfTheProject > projects.Count));

            // Выбор нужного проекта.
            ComandMenuAllProjects(projects[numberOfTheProject - 1]);
        }

        /// <summary>
        /// Меню для работы с проектами.
        /// </summary>
        /// <param name="project"></param>
        static void ComandMenuAllProjects(Project project)
        {
            int numberComand;

            Console.Clear();

            do
            {
                // Вспомогательный текст.
                WorkWithTasksInProjectText();

                if (!int.TryParse(Console.ReadLine(), out numberComand) || numberComand < 0 || numberComand > 8)
                {
                    Console.Clear();
                    Console.Write(Environment.NewLine);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Некорректный ввод, пожалуйста, повторите попытку!");
                    Console.ResetColor();
                }
                else
                {
                    switch (numberComand)
                    {
                        // Выход из меню.
                        case 0:
                            Console.Clear();
                            return;
                        // Создание задачи.
                        case 1:
                            CreateTasks(project);
                            break;
                        // Удаление задачи.
                        case 2:
                            RemoveTask(project);
                            break;
                        // Назначение исполнителей задачи.
                        case 3:
                            SetPeoplesOnTheTask(project);
                            break;
                        // Изменение исполнителя задачи.
                        case 4:
                            ChangePeoplesOnTheTask(project);
                            break;
                        // Удаление исполнителя задачи.
                        case 5:
                            RemovePeoplesOnTheTask(project);
                            break;
                        // Изменение статуса задачи.
                        case 6:
                            ChangeStatusOfTheTask(project);
                            break;
                        // Группировка задач по статусам.
                        case 7:
                            GroupTaskForStatus(project);
                            break;
                        // Информация обо всех задачах в проекте.
                        case 8:
                            InfoAboutTasks(project);
                            break;
                    }
                }
            } while (true);
        }

        /// <summary>
        /// Создание задачи.
        /// </summary>
        /// <param name="project">Объект проекта.</param>
        static void CreateTasks(Project project)
        {
            int numberComand;
            string nameOfTheTask;

            Console.Clear();

            do
            {
                // Вспомогательный текст.
                CreateTasksText();

                if (!int.TryParse(Console.ReadLine(), out numberComand) || numberComand < 0 || numberComand > 4)
                {
                    IncorrectInputText();
                }
                else
                {
                    // Выход из меню.
                    if (numberComand == 0)
                    {
                        Console.Clear();
                        return;
                    }

                    Console.Clear();

                    do
                    {
                        Console.Write(Environment.NewLine);
                        Console.Write("Укажите имя задачи [от 2 до 15 символов]: ");
                        nameOfTheTask = Console.ReadLine();
                        Console.Clear();
                    } while (nameOfTheTask.Length < 2 || nameOfTheTask.Length > 15);

                    // Проверка количества созданных проектов.
                    if (project.ActualCountTasks() == project.MaxCountTasks)
                    {
                        MaxCountTasksCreateText();
                        return;
                    }

                    // Создание задачи нужного типа.
                    project.AddTasks(nameOfTheTask, numberComand);

                    Console.Clear();

                    Console.Write(Environment.NewLine);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Задача \"{nameOfTheTask}\" успешно создана!");
                    Console.ResetColor();
                }
            } while (true);
        }

        /// <summary>
        /// Удаление задачи.
        /// </summary>
        /// <param name="project">Объект проекта.</param>
        static void RemoveTask(Project project)
        {
            int numberOfTask;
            string nameOfTheTask;

            Console.Clear();

            // Проверка количества созданных задач.
            if (project.ActualCountTasks() == 0)
            {
                IncorrectCountTasksCreatedText();
                return;
            }

            // Вывод информации о задачах на экран.
            project.PrintTasksWithoutEpics();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер задачи по списку, которую вы хотите удалить: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTask) || numberOfTask < 1 || (numberOfTask > project.ActualCountTasks()));

            Console.Clear();

            // Сохранение названия задачи.
            nameOfTheTask = project.NameTasks(numberOfTask - 1);

            // Удаление задачи.
            project.RemoveTasks(numberOfTask - 1);

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Задача \"{nameOfTheTask}\" успешно удалена!");
            Console.ResetColor();
        }

        /// <summary>
        /// Назначение исполнителей задачи.
        /// </summary>
        /// <param name="project">Объект проекта.</param>
        static void SetPeoplesOnTheTask(Project project)
        {
            int numberOfTask;
            Console.Clear();

            // Проверка количества созданных задач.
            if (project.ActualCountTasks() == 0)
            {
                IncorrectCountTasksCreatedText();
                return;
            }

            // Вывод информации о задачах на экран.
            project.PrintTasksWithoutEpics();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер задачи по списку, на которую вы хотите назначить человека: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTask) || numberOfTask < 1 || (numberOfTask > project.ActualCountTasks()));

            Console.Clear();

            // Проверка типа задачи, выход из меню, в случае, если задача типа Epic.
            if (project.FlagIskEpic(numberOfTask - 1))
            {
                TaskIsEpicText();
                return;
            }

            // Проверка возможности назначить исполнителя задачи.
            if (project.FlagCountPeopleOnTheTasks(numberOfTask - 1))
            {
                // Назначение исполнителя задачи.
                SetPeopleOnTheSelectTask(project, numberOfTask);
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Невозможно назначить человека на данную задачу!");
                Console.Write(Environment.NewLine);
                Console.WriteLine("Задачам типа \"Task\" и \"Bug\" можно назначить только одного исполнителя!");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Назначение исполнителя на выбранную задачу.
        /// </summary>
        /// <param name="project">Объект проекта.</param>
        /// <param name="numberOfTask">Номер задачи.</param>
        static void SetPeopleOnTheSelectTask(Project project, int numberOfTask)
        {
            int numberOfHuman;
            bool flagPersonOnTheTask;

            // Вывод информации о пользователях.
            InfoAboutPeople();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер человека по списку, которого хотите назначить на данную задачу: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfHuman) || numberOfHuman < 1 || (numberOfHuman > peoples.Count));

            Console.Clear();

            // Назначения исполнителя на выбранную задачу.
            flagPersonOnTheTask = project.ManagePeoples(peoples[numberOfHuman - 1], numberOfTask - 1);

            // Проверка проведения операции назначения исполнителя.
            if (flagPersonOnTheTask)
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Пользователь с именем \"{peoples[numberOfHuman - 1].Name}\" успешно назачен на задачу \"{project.NameTasks(numberOfTask - 1)}\"!");
                Console.ResetColor();
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Пользователь \"{peoples[numberOfHuman - 1].Name}\" является исполнителем задачи \"{project.NameTasks(numberOfTask - 1)}\"!");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Изменение исполнителя задачи.
        /// </summary>
        /// <param name="project">Объект проекта.</param>
        static void ChangePeoplesOnTheTask(Project project)
        {
            int numberOfTask;

            Console.Clear();

            // Проверка количества созданных задач.
            if (project.ActualCountTasks() == 0)
            {
                IncorrectCountTasksCreatedText();
                return;
            }

            // Вывод информации о задачах на экран.
            project.PrintTasksWithoutEpics();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер задачи по списку, исполнителя на которой вы хотите заменить: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTask) || numberOfTask < 1 || (numberOfTask > project.ActualCountTasks()));

            Console.Clear();

            // Проверка типа задачи, выход из меню, в случае, если задача типа Epic.
            if (project.FlagIskEpic(numberOfTask - 1))
            {
                TaskIsEpicText();
                return;
            }

            // Проверка возможности назначить исполнителя задачи.
            if (project.FlagIsStory(numberOfTask - 1))
            {
                SetPeopleOnTheStory(project, numberOfTask);
            }
            else if (project.FlagIsTask(numberOfTask - 1) || project.FlagIsBug(numberOfTask - 1))
            {
                SetPeoplesOnTheTaskAndBug(project, numberOfTask);
            }
            else
            {
                PeopleNotExsistText();
            }
        }

        /// <summary>
        /// Изменение исполнителей для задачи типа Story.
        /// </summary>
        /// <param name="project">Объект проекта.</param>
        /// <param name="numberOfTask">Номер задачи.</param>
        static void SetPeopleOnTheStory(Project project, int numberOfTask)
        {
            int numberOfHuman;
            int numberOfHumanChange;

            // Вывод списка исполнителей задачи на экран.
            project.PrintInfoAboutPeoplesStory(numberOfTask - 1);

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер человека по списку, которого хотите заменить: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfHuman) || numberOfHuman < 1 || (numberOfHuman > peoples.Count));

            Console.Clear();

            // Вывод списка исполнителей на экран.
            InfoAboutPeople();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер человека по списку, которого хотите поставить на данную задачу: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfHumanChange) || numberOfHumanChange < 1 || (numberOfHumanChange > peoples.Count));

            Console.Clear();

            // Проверка изменяемого исполнителя.
            if (numberOfHuman == numberOfHumanChange)
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Данный человек является исполнителем задачи!");
                Console.ResetColor();
            }
            else
            {
                // Изменение исполнителя.
                project.ChangePeoples(peoples[numberOfHuman - 1], peoples[numberOfHumanChange - 1], numberOfTask - 1);

                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Пользователь \"{peoples[numberOfHuman - 1].Name}\" успешно заменен на пользователя \"{peoples[numberOfHumanChange - 1].Name}\"!");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Назначение исполнителей на задачу типа Bug или Task.
        /// </summary>
        /// <param name="project">Объект проекта.</param>
        /// <param name="numberOfTask">Номер задачи.</param>
        static void SetPeoplesOnTheTaskAndBug(Project project, int numberOfTask)
        {
            int numberOfHumanChange;

            // Удаление всех исполнителей задачи.
            project.RemoveAllPeoples(numberOfTask - 1);

            // Информация обо всех пользователях.
            InfoAboutPeople();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер человека по списку, которого хотите поставить на данную задачу: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfHumanChange) || numberOfHumanChange < 1 || (numberOfHumanChange > peoples.Count));

            Console.Clear();

            // Назачение исполнителя.
            project.ManagePeoples(peoples[numberOfHumanChange - 1], numberOfTask - 1);

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Пользователь успешно назначен на выполнение данной задачи!");
            Console.ResetColor();
        }

        /// <summary>
        /// Удаление исполнителя задачи.
        /// </summary>
        /// <param name="project">Объект проекта.</param>
        static void RemovePeoplesOnTheTask(Project project)
        {
            int numberOfTask;

            Console.Clear();

            // Проверка количества созданных задач.
            if (project.ActualCountTasks() == 0)
            {
                IncorrectCountTasksCreatedText();
                return;
            }

            // Вывод информации о задачах на экран.
            project.PrintTasksWithoutEpics();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер задачи по списку, с которой вы хотите удалить исполнителя: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTask) || numberOfTask < 1 || (numberOfTask > project.ActualCountTasks()));

            Console.Clear();

            // Проверка типа задачи, выход из меню, в случае, если задача типа Epic.
            if (project.FlagIskEpic(numberOfTask - 1))
            {
                TaskIsEpicText();
                return;
            }

            // Проверка возможности удаление исполнителя.
            if (project.FlagIsStory(numberOfTask - 1))
            {
                RemovePeopleOnTheStoryTask(project, numberOfTask);
            }
            else if (project.FlagIsTask(numberOfTask - 1) || project.FlagIsBug(numberOfTask - 1))
            {
                project.RemoveAllPeoples(numberOfTask - 1);
            }
            else
            {
                // Текст с ошибкой при удалении исполнителя задачи.
                PeopleNotExsistText();
                return;
            }

            // Тект об успешном далении исполнителя задачи.
            PeopleSuccsessfulDeleteText();
        }

        /// <summary>
        /// Удаление исполнителя задачи типа Story.
        /// </summary>
        /// <param name="project">Объект проекта.</param>
        /// <param name="numberOfTask">Номер задания.</param>
        static void RemovePeopleOnTheStoryTask(Project project, int numberOfTask)
        {
            int numberOfHuman;

            // Вывод на экран информации об исполнителях задачи.
            project.PrintInfoAboutPeoplesStory(numberOfTask - 1);

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер человека по списку, которого хотите удалить: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfHuman) || numberOfHuman < 1 || (numberOfHuman > peoples.Count));

            // Удаление выбранного исполнителя.
            project.RemovePeoples(peoples[numberOfHuman - 1], numberOfTask - 1);
        }

        /// <summary>
        /// Изменение статуса задачи.
        /// </summary>
        /// <param name="project">Объект проекта.</param>
        static void ChangeStatusOfTheTask(Project project)
        {
            int numberOfTask;
            int numberOfTheStatus;

            Console.Clear();

            // Проверка количества созданных задач.
            if (project.ActualCountTasks() == 0)
            {
                IncorrectCountTasksCreatedText();
                return;
            }

            // Вывод информации о задачах на экран.
            project.PrintTasksWithoutEpics();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер задачи по списку, статус которой вы хотите изменить: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTask) || numberOfTask < 1 || (numberOfTask > project.ActualCountTasks()));

            Console.Clear();

            // Выбор статуса.
            do
            {
                Console.Clear();
                ChangeStatusText();
            } while (!int.TryParse(Console.ReadLine(), out numberOfTheStatus) || numberOfTheStatus < 1 || numberOfTheStatus > 3);

            // Изменение статуса.
            bool flagChange = project.ChangeStatusOfTheTask(numberOfTask - 1, numberOfTheStatus);

            Console.Clear();

            // Проверка выполнения операции.
            if (flagChange)
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Cтатус успешно изменен!");
                Console.ResetColor();
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Данный статус уже установлен для этой задачи!");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Группировка задач по статусу.
        /// </summary>
        /// <param name="project">Объект проекта.</param>
        static void GroupTaskForStatus(Project project)
        {
            Console.Clear();

            // Проверка количества созданных задач.
            if (project.ActualCountTasks() == 0)
            {
                IncorrectCountTasksCreatedText();
                return;
            }

            // Вывод на экран отсортированного списка задач.
            project.PrintInfoAboutTasksGroupStatus();
        }


        /// <summary>
        /// Информация о задачах.
        /// </summary>
        /// <param name="project">Объект проекта.</param>
        static void InfoAboutTasks(Project project)
        {
            int numberOfTheTask;

            Console.Clear();

            // Проверка количества созданных задач.
            if (project.ActualCountTasks() == 0)
            {
                IncorrectCountTasksCreatedText();
                return;
            }

            // Вывод информации о задачах на экран.
            project.PrintTasksWithoutEpics();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер задачи по списку, подробную информацию о которой хотите получить: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTheTask) || numberOfTheTask < 1 || numberOfTheTask > project.ActualCountTasks());

            // Вывод подробной информации о задаче на экран.
            PrintDetailInfoAboutTask(project, numberOfTheTask - 1);
        }

        /// <summary>
        /// Вывод подробной информации на экран.
        /// </summary>
        /// <param name="project">Объект проекта.</param>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        static void PrintDetailInfoAboutTask(Project project, int numberOfTheTask)
        {
            Console.Clear();

            project.DetailInfoAboutTask(numberOfTheTask);
        }
    }
}
