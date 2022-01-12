using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;

namespace YourPlaner
{
    partial class Program
    {
        /// <summary>
        /// Объект задачи типа Epic.
        /// </summary>
        static Epic epicTask;

        /// <summary>
        /// Меню выбора проекта.
        /// </summary>
        static void WorkWithProjectEpicTasks()
        {
            // Очистка консоли.
            Console.Clear();

            int numberOfTheProject;

            // Вывод информации о существующих проектах на экран.
            InfoAboutProjects();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер проекта по списку, с которым хотите продолжить работать дальше: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTheProject) || numberOfTheProject < 1 || (numberOfTheProject > projects.Count));

            // Метод для выбора задачи типа Epic.
            if (SelectEpicTask(projects[numberOfTheProject - 1]))
            {
                // Метод для работы с задачей типа Epic.
                ComandMenuEpicProjects(projects[numberOfTheProject - 1]);
            }
        }

        /// <summary>
        /// Выбор задачи тпиа Epic для дальнейшей работы с объектом.
        /// </summary>
        /// <param name="project">Объект проекта.</param>
        /// <returns>True, если объект успешно выбран, False - иначе.</returns>
        static bool SelectEpicTask(Project project)
        {
            int numberOfTask;

            Console.Clear();

            // Проверка существования задач типа Epic.
            if (!project.ExsistEpicTasks())
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("В данном проекте отсутствуют задачи типа \"Epic\"!");
                Console.ResetColor();
                return false;
            }

            // Вывод на экран списка задач типа Epic.
            project.PrintEpicTasks();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер задачи по списку, с которой хотите продолжить работать дальше: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTask) || numberOfTask < 1 || (numberOfTask > project.CountEpicTasks()));

            // Получение объекта под указанным номером задания по списку.
            epicTask = project.GetEpicTask(numberOfTask - 1);

            Console.Clear();

            return true;
        }

        /// <summary>
        /// Меню для работы с выбранной задачей типа Epic.
        /// </summary>
        /// <param name="project">Объект проекта.</param>
        static void ComandMenuEpicProjects(Project project)
        {
            int numberComand;

            Console.Clear();

            do
            {
                // Вывод вспомогательного текста на экран.
                WorkWithEpicTasksText();

                if (!int.TryParse(Console.ReadLine(), out numberComand) || numberComand < 0 || numberComand > 8)
                {
                    IncorrectInputText();
                }
                else
                {
                    // Выбор метода для выполнения.
                    switch (numberComand)
                    {
                        // Выход из меню.
                        case 0:
                            Console.Clear();
                            return;
                        // Создание подзадачи.
                        case 1:
                            CreateEpicUnderTasks();
                            break;
                        // Удаление подзадачи.
                        case 2:
                            RemoveEpicUnderTask();
                            break;
                        // Назанчение исполнителя подзадачи.
                        case 3:
                            SetPeoplesOnTheUnderTask();
                            break;
                        // Изменение исполнителя подзадачи.
                        case 4:
                            ChangePeoplesOnTheUnderTask();
                            break;
                        // Удаление исполнителя подзадачи.
                        case 5:
                            RemovePeoplesOnTheUnderTask();
                            break;
                        // Изменение статуса подзадачи.
                        case 6:
                            ChangeStatusOfTheUnderTask();
                            break;
                        // Группировка задач по их статусу.
                        case 7:
                            GroupUnderTaskForStatus();
                            break;
                        // Подробная информация обо всех задачах.
                        case 8:
                            InfoAboutUnderTasks();
                            break;
                    }
                }
            } while (true);
        }

        /// <summary>
        /// Создание подзадачи.
        /// </summary>
        /// <param name="epicTask"></param>
        static void CreateEpicUnderTasks()
        {
            int numberComand;
            int numberOfTheTask = 0;
            string nameOfTheTask = "";

            Console.Clear();
            do
            {
                // Вывод вспомогательного текста на экран.
                CreateUnderTasksForEpicsText();
                if (!int.TryParse(Console.ReadLine(), out numberComand) || numberComand < 0 || numberComand > 2)
                {
                    // Сообщение об ошибке при вводе команды.
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
                        // Тип задачи - "Story".
                        case 1:
                            numberOfTheTask = 1;
                            break;
                        // Тип азадчи - "Task".
                        case 2:
                            numberOfTheTask = 2;
                            break;
                    }
                    Console.Clear();
                    do
                    {
                        Console.Write(Environment.NewLine);
                        Console.Write("Укажите имя задачи [от 2 до 15 символов]: ");
                        nameOfTheTask = Console.ReadLine();
                    } while (nameOfTheTask.Length < 2 || nameOfTheTask.Length > 15);
                    epicTask.CreateTasks(nameOfTheTask, numberOfTheTask);
                    CreateTaskSuccsesText(nameOfTheTask);
                }
            } while (true);
        }

        /// <summary>
        /// Удаление подзадачи из списка.
        /// </summary>
        static void RemoveEpicUnderTask()
        {
            int numberOfTask;
            string nameOfTheTask;

            Console.Clear();

            // Проверка актуального количества подздадач.
            if (epicTask.CountTasksInEpic() == 0)
            {
                IncorrectCountTasksInEpicCountText();
                return;
            }

            // Информация о подзадачах.
            epicTask.InfoAboutTasksInEpic();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер задачи по списку, которую вы хотите удалить: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTask) || numberOfTask < 1 || (numberOfTask > epicTask.CountTasksInEpic()));

            Console.Clear();

            // Получение названия подзадачи.
            nameOfTheTask = epicTask.NameTasksInEpic(numberOfTask - 1);

            // Удаление подзадачи.
            epicTask.RemoveTasks(numberOfTask - 1);

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Задача \"{nameOfTheTask}\" успешно удалена!");
            Console.ResetColor();
        }

        /// <summary>
        /// Назначение исполнителей подзадачи.
        /// </summary>
        static void SetPeoplesOnTheUnderTask()
        {
            int numberOfTask;

            Console.Clear();

            // Проверка актуального количества подздадач.
            if (epicTask.CountTasksInEpic() == 0)
            {
                IncorrectCountTasksInEpicCountText();
                return;
            }

            // Информация о подзадачах.
            epicTask.InfoAboutTasksInEpic();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер задачи по списку, на которую вы хотите назначить человека: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTask) || numberOfTask < 1 || (numberOfTask > epicTask.CountTasksInEpic()));

            Console.Clear();

            // Проверка возможности назначения исполнителя подзадачи.
            if (epicTask.FlagCountPeopleOnTheTasks(numberOfTask - 1))
            {
                // Назначение исполнителя задачи.
                SetPeopleOnTheTask(numberOfTask);
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Невозможно назначить человека на данную задачу!");
                Console.Write(Environment.NewLine);
                Console.WriteLine("Задачам типа \"Task\" можно назначить только одного исполнителя!");
                Console.ResetColor();
            }
        }


        /// <summary>
        /// Вспомогтаельный метод для назначения исполнителя выбранной подздачи.
        /// </summary>
        /// <param name="numberOfTask">Номер подзадачи.</param>
        static void SetPeopleOnTheTask(int numberOfTask)
        {
            int numberOfHuman;
            bool flagPersonOnTheTask;

            // Вывод списка пользователей на экран.
            InfoAboutPeople();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер человека по списку, которого хотите назначить на данную задачу: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfHuman) || numberOfHuman < 1 || (numberOfHuman > peoples.Count));

            Console.Clear();

            // Назначение исполнителя задачи.
            flagPersonOnTheTask = epicTask.ManagePeoples(peoples[numberOfHuman - 1], numberOfTask - 1);

            // Проверка выполнения операции назначения исполнителя.
            if (flagPersonOnTheTask)
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Пользователь с именем \"{peoples[numberOfHuman - 1].Name}\" успешно назачен на задачу \"{epicTask.NameTasksInEpic(numberOfTask - 1)}\"!");
                Console.ResetColor();
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Пользователь \"{peoples[numberOfHuman - 1].Name}\" является исполнителем задачи \"{epicTask.NameTasksInEpic(numberOfTask - 1)}\"!");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Замена исполнителя задачи.
        /// </summary>
        static void ChangePeoplesOnTheUnderTask()
        {
            int numberOfTask;

            Console.Clear();

            // Проверка актуального количества подздадач.
            if (epicTask.CountTasksInEpic() == 0)
            {
                IncorrectCountTasksInEpicCountText();
                return;
            }

            // Информация о подзадачах.
            epicTask.InfoAboutTasksInEpic();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер задачи по списку, исполнителя на которой вы хотите заменить: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTask) || numberOfTask < 1 || (numberOfTask > epicTask.CountTasksInEpic()));

            Console.Clear();

            // Проверка типа задачи и возможности заменить исполнителя.
            if (epicTask.FlagIsStory(numberOfTask - 1))
            {
                ChangeStoryUser(numberOfTask);
            }
            else if (epicTask.FlagIsTask(numberOfTask - 1))
            {
                ChangeTaskUser(numberOfTask);
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Исполнитель задачи отсутствует!");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Вспомогательный метод для замены исполнителя подзадачи типа Task.
        /// </summary>
        /// <param name="numberOfTask">Номер подзадачи.</param>
        static void ChangeTaskUser(int numberOfTask)
        {
            int numberOfHumanChange;

            // Удаление исполнителя задачи.
            epicTask.RemoveAllPeoples(numberOfTask - 1);

            // Вывод информации о пользователях.
            InfoAboutPeople();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер человека по списку, которого хотите поставить на данную задачу: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfHumanChange) || numberOfHumanChange < 1 || (numberOfHumanChange > peoples.Count));

            Console.Clear();

            // Замена исполнителя.
            epicTask.ManagePeoples(peoples[numberOfHumanChange - 1], numberOfTask - 1);

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Пользователь успешно назначен на выполнение данной задачи!");
            Console.ResetColor();
        }

        /// <summary>
        /// Вспомогательный метод для замены исполнителя подзадачи типа Story.
        /// </summary>
        /// <param name="numberOfTask">Номер подзадачи.</param>
        static void ChangeStoryUser(int numberOfTask)
        {
            int numberOfHuman;
            int numberOfHumanChange;

            // Вывод списка исполнителей задачи.
            epicTask.PrintInfoAboutPeoplesStory(numberOfTask - 1);

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер человека по списку, которого хотите заменить: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfHuman) || numberOfHuman < 1 || (numberOfHuman > peoples.Count));

            Console.Clear();
            
            // Вывод списка пользователей.
            InfoAboutPeople();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер человека по списку, которого хотите поставить на данную задачу: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfHumanChange) || numberOfHumanChange < 1 || (numberOfHumanChange > peoples.Count));

            Console.Clear();

            // Проверка заменяемого исполнителя.
            if (numberOfHuman == numberOfHumanChange)
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Данный человек является исполнителем задачи!");
                Console.ResetColor();
            }
            else
            {
                // Замена исполнителя.
                epicTask.ChangePeoples(peoples[numberOfHuman - 1], peoples[numberOfHumanChange - 1], numberOfTask - 1);

                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Пользователь \"{peoples[numberOfHuman - 1].Name}\" успешно заменен на пользователя \"{peoples[numberOfHumanChange - 1].Name}\"!");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Удаление исполнителей подзадачи.
        /// </summary>
        static void RemovePeoplesOnTheUnderTask()
        {
            int numberOfTask;

            Console.Clear();

            // Проверка актуального количества подздадач.
            if (epicTask.CountTasksInEpic() == 0)
            {
                IncorrectCountTasksInEpicCountText();
                return;
            }

            // Вывод информации о подзадачах.
            epicTask.InfoAboutTasksInEpic();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер задачи по списку, с которой вы хотите удалить исполнителя: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTask) || numberOfTask < 1 || (numberOfTask > epicTask.CountTasksInEpic()));

            Console.Clear();

            // Проверка типа задачи и возможности ее удаления.
            if (epicTask.FlagIsStory(numberOfTask - 1))
            {
                RemovePeopleOnTheStory(numberOfTask);
            }
            else if (epicTask.FlagIsTask(numberOfTask - 1))
            {
                epicTask.RemoveAllPeoples(numberOfTask - 1);
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Исполнитель задачи отсутствует!");
                Console.ResetColor();
                return;
            }

            Console.Clear();

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Исполнитель успешно удален!");
            Console.ResetColor();
        }

        /// <summary>
        /// Удаление исполнителя подзадачи типа Story.
        /// </summary>
        /// <param name="numberOfTask"></param>
        static void RemovePeopleOnTheStory(int numberOfTask)
        {
            int numberOfHuman;

            // Вывод исполнителей задачи.
            epicTask.PrintInfoAboutPeoplesStory(numberOfTask - 1);

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер человека по списку, которого хотите удалить: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfHuman) || numberOfHuman < 1 || (numberOfHuman > peoples.Count));

            // Удаление исполнителя.
            epicTask.RemovePeoples(peoples[numberOfHuman - 1], numberOfTask - 1);
        }

        /// <summary>
        /// Изменение статуса подзадачи.
        /// </summary>
        static void ChangeStatusOfTheUnderTask()
        {
            bool flagChange;

            Console.Clear();

            // Проверка актуального количества подздадач.
            if (epicTask.CountTasksInEpic() == 0)
            {
                IncorrectCountTasksInEpicCountText();
                return;
            }

            // Вывод информации о подзадачах.
            epicTask.InfoAboutTasksInEpic();

            flagChange = ChangeStatusOnTheTask();

            Console.Clear();

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
        /// Изменение статуса подзадачи.
        /// </summary>
        /// <returns>True, если изменение произошло успешно, False - иначе.</returns>
        static bool ChangeStatusOnTheTask()
        {
            int numberOfTask;
            int numberOfTheStatus;
            bool flagChange;

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер задачи по списку, статус которой вы хотите изменить: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTask) || numberOfTask < 1 || (numberOfTask > epicTask.CountTasksInEpic()));

            Console.Clear();

            do
            {
                Console.Clear();
                ChangeStatusText();
            } while (!int.TryParse(Console.ReadLine(), out numberOfTheStatus) || numberOfTheStatus < 1 || numberOfTheStatus > 3);

            // Изменение статуса подзадачи.
            flagChange = epicTask.ChangeStatusOfTheTask(numberOfTask - 1, numberOfTheStatus);

            return flagChange;
        }

        /// <summary>
        /// Группировка задач по статусу.
        /// </summary>
        static void GroupUnderTaskForStatus()
        {
            Console.Clear();

            // Проверка актуального количества подздадач.
            if (epicTask.CountTasksInEpic() == 0)
            {
                IncorrectCountTasksInEpicCountText();
                return;
            }

            // Вывод отстортированных задач на экран.
            epicTask.PrintInfoAboutTasksGroupStatus();
        }

        /// <summary>
        /// Получение детальной информации о подзадачах.
        /// </summary>
        static void InfoAboutUnderTasks()
        {
            int numberOfTheTask;

            Console.Clear();

            // Проверка актуального количества подздадач.
            if (epicTask.CountTasksInEpic() == 0)
            {
                IncorrectCountTasksInEpicCountText();
                return;
            }

            // Вывод списка подзадач на экран.
            epicTask.InfoAboutTasksInEpic();

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер задачи по списку, подробную информацию о которой хотите получить: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfTheTask) || numberOfTheTask < 1 || numberOfTheTask > epicTask.CountTasksInEpic());

            // Вывод подробной информации по выбранной задаче.
            PrintDetailInfoAboutTask(epicTask, numberOfTheTask - 1);
        }

        /// <summary>
        /// Вывод детальной информации о задаче (дата создания, список исполнителей).
        /// </summary>
        /// <param name="epicTask"></param>
        /// <param name="numberOfTheTask"></param>
        static void PrintDetailInfoAboutTask(Epic epicTask, int numberOfTheTask)
        {
            Console.Clear();

            epicTask.DetailInfoAboutTask(numberOfTheTask);
        }
    }
}
