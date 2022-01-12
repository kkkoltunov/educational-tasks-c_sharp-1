using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClassLibrary
{
    public class Project
    {
        /// <summary>
        /// Список всех задач, кроме задач типа Epic.
        /// </summary>
        List<Tasks> tasks = new List<Tasks>();

        /// <summary>
        /// Список задач типа Epic.
        /// </summary>
        List<Epic> tasksEpic = new List<Epic>();

        /// <summary>
        /// Свойства для работы с именем.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Свойство для установки максимального количества задач.
        /// </summary>
        public int MaxCountTasks { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="name">Название проекта.</param>
        /// <param name="maxCountTasks">Максимальное количество задач.</param>
        public Project(string name, int maxCountTasks)
        {
            Name = name;
            MaxCountTasks = maxCountTasks;
        }

        /// <summary>
        /// Добавлвение задач в проект.
        /// </summary>
        /// <param name="name">Название задач.</param>
        /// <param name="numberOfTask">Тип задачи.</param>
        public void AddTasks(string name, int numberOfTask)
        {
            switch (numberOfTask)
            {
                case 1:
                    tasks.Add(new Story(name));
                    break;
                case 2:
                    tasks.Add(new Task(name));
                    break;
                case 3:
                    tasks.Add(new Bug(name));
                    break;
                case 4:
                    tasks.Add(new Epic(name));
                    break;
            }
        }

        /// <summary>
        /// Удаление задачи из проекта.
        /// </summary>
        /// <param name="numberOfTask">Номер задачи.</param>
        public void RemoveTasks(int numberOfTask)
        {
            tasks.Remove(tasks[numberOfTask]);
        }

        /// <summary>
        /// Назначения исполнителя задачи.
        /// </summary>
        /// <param name="person">Объект класса Person.</param>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        /// <returns></returns>
        public bool ManagePeoples(Person person, int numberOfTheTask)
        {
            if (tasks[numberOfTheTask].PeopleOnTheTask(person))
            {
                return false;
            }
            else
            {
                tasks[numberOfTheTask].AddPerson(person);

                return true;
            }
        }

        /// <summary>
        /// Удаление исполнителя задачи.
        /// </summary>
        /// <param name="person">Объект класса Person.</param>
        /// <param name="numberOfTheTask">Номер задания.</param>
        public void RemovePeoples(Person person, int numberOfTheTask)
        {
            tasks[numberOfTheTask].RemovePerson(person);
        }

        /// <summary>
        /// Очистка списка исполнителей задачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер задания.</param>
        public void RemoveAllPeoples(int numberOfTheTask)
        {
            tasks[numberOfTheTask].RemoveAllPeoples();
        }

        /// <summary>
        /// Замена исполнителя задачи.
        /// </summary>
        /// <param name="person">Объект типа Person, который нужно заменить.</param>
        /// <param name="personChange">Объект типа Person, на который нужно заменить.</param>
        /// <param name="numberOfTheTask">Номер задания.</param>
        public void ChangePeoples(Person person, Person personChange, int numberOfTheTask)
        {
            tasks[numberOfTheTask].PersonChange(person, personChange);
        }

        /// <summary>
        /// Количество заданий в проекте.
        /// </summary>
        /// <returns>Количество заданий.</returns>
        public int ActualCountTasks()
        {
            return tasks.Count;
        }
        
        /// <summary>
        /// Установка даты создания для задачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        /// <param name="dateTime">Дата.</param>
        public void SetDateForTask(int numberOfTheTask, DateTime dateTime)
        {
            tasks[numberOfTheTask].Date = dateTime;
        }

        /// <summary>
        /// Установка статуса для задачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        /// <param name="status">Статус задачи.</param>
        public void SetStatusForTask(int numberOfTheTask, string status)
        {
            tasks[numberOfTheTask].Status = status;
        }

        /// <summary>
        /// Создание задачи.
        /// </summary>
        /// <param name="typeOfTheTask">Номер задачи.</param>
        /// <param name="name">Название задачи.</param>
        public void CreateTasks(string typeOfTheTask, string name)
        {
            switch (typeOfTheTask)
            {
                case "Story":
                    tasks.Add(new Story(name));
                    break;
                case "Task":
                    tasks.Add(new Task(name));
                    break;
                case "Bug":
                    tasks.Add(new Bug(name));
                    break;
                case "Epic":
                    tasks.Add(new Epic(name));
                    break;
            }
        }

        /// <summary>
        /// Метод, возвращающий тип задачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        /// <returns>Тип задачи.</returns>
        public string TypeOfTheTask(int numberOfTheTask)
        {
            string type = "";

            if (tasks[numberOfTheTask] is Story)
            {
                type = "Story";
            }
            if (tasks[numberOfTheTask] is Task)
            {
                type = "Task";
            }
            if (tasks[numberOfTheTask] is Bug)
            {
                type = "Bug";
            }
            if (tasks[numberOfTheTask] is Epic)
            {
                type = "Epic";
            }

            return type;
        }

        /// <summary>
        /// Информация об исполнителях задачи.
        /// </summary>
        /// <param name="numberOfTheTask"></param>
        /// <returns></returns>
        public string InfoAboutPeoples(int numberOfTheTask)
        {
            string info = "";
            
            // Если исполнителей нет - "Отсутствуют".
            if (tasks[numberOfTheTask].CountPeoplesOnTheTask() == 0)
            {
                info = "Отсутствуют";
            }

            // Если исполнитель один - имя исполнителя.
            else if (tasks[numberOfTheTask].CountPeoplesOnTheTask() == 1)
            {
                info = tasks[numberOfTheTask].InfoAboutPerson();
            }

            // Если исполнителей много - количество исполнителей.
            else
            {
                info = tasks[numberOfTheTask].CountPeoplesOnTheTask().ToString();
            }

            return info;
        }

        /// <summary>
        /// Флаг количества исполнителей задачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        /// <returns>True - если исполнителей нет, False - иначе.</returns>
        public bool FlagCountPeopleOnTheTasks(int numberOfTheTask)
        {
            bool flag = false;

            if (tasks[numberOfTheTask] is Task)
            {
                Task task = (Task)tasks[numberOfTheTask];
                flag = task.FlagCountPeoples;
            }
            if (tasks[numberOfTheTask] is Bug)
            {
                Bug bug = (Bug)tasks[numberOfTheTask];
                flag = bug.FlagCountPeoples;
            }
            if (tasks[numberOfTheTask] is Story)
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// Проверка типа задачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        /// <returns>True, если задача типа Story, False - иначе.</returns>
        public bool FlagIsStory(int numberOfTheTask)
        {
            return tasks[numberOfTheTask] is Story && tasks[numberOfTheTask].CountPeoplesOnTheTask() > 0;
        }

        /// <summary>
        /// Проверка типа задачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        /// <returns>True, если задача типа Task, False - иначе.</returns>
        public bool FlagIsTask(int numberOfTheTask)
        {
            return tasks[numberOfTheTask] is Task && tasks[numberOfTheTask].CountPeoplesOnTheTask() > 0;
        }

        /// <summary>
        /// Проверка типа задачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        /// <returns>True, если задача типа Bug, False - иначе.</returns>
        public bool FlagIsBug(int numberOfTheTask)
        {
            return tasks[numberOfTheTask] is Bug && tasks[numberOfTheTask].CountPeoplesOnTheTask() > 0;
        }

        /// <summary>
        /// Проверка типа задачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        /// <returns>True, если задача типа Epic, False - иначе.</returns>
        public bool FlagIskEpic(int numberOfTheTask)
        {
            return tasks[numberOfTheTask] is Epic;
        }

        /// <summary>
        /// Метод для получения задачи типа Epic.
        /// </summary>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        /// <returns></returns>
        public Epic GetEpicTask(int numberOfTheTask)
        {
            return tasksEpic[numberOfTheTask];
        }

        /// <summary>
        /// Проверка существования в списке задач, зачи типа Epic.
        /// </summary>
        /// <returns>True, если нашлась задача типа Epic, False - иначе.</returns>
        public bool ExsistEpicTasks()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i] is Epic)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Подсчет задач типа Epic.
        /// </summary>
        /// <returns>Количество задач типа Epic.</returns>
        public int CountEpicTasks()
        {
            int count = 0;

            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i] is Epic)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Получение название задачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        /// <returns>Название задачи.</returns>
        public string NameTasks(int numberOfTheTask)
        {
            return tasks[numberOfTheTask].Name;
        }

        /// <summary>
        /// Изменение статуса задачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        /// <param name="numberOfTheStatus">Номер статуса.</param>
        /// <returns>True, если статус изменен, False - иначе.</returns>
        public bool ChangeStatusOfTheTask(int numberOfTheTask, int numberOfTheStatus)
        {
            string status = "";

            if (numberOfTheStatus == 1)
            {
                status = "Открытая задача";
            }
            else if (numberOfTheStatus == 2)
            {
                status = "Задача в работе";
            }
            else if (numberOfTheStatus == 3)
            {
                status = "Завершенная задача";
            }

            if (tasks[numberOfTheTask].Status == status)
            {
                return false;
            }
            else
            {
                tasks[numberOfTheTask].Status = status;

                return true;
            }
        }

        /// <summary>
        /// Удаление исполнителя задачи, после его удаления из списка пользователей.
        /// </summary>
        /// <param name="person">Объект типа Person.</param>
        public void RemovePeopleOnTheTask(Person person)
        {
            try
            {
                FindEpicTasks();

                for (int i = 0; i < tasks.Count; i++)
                {
                    tasks[i].RemovePerson(person);
                }

                for (int i = 0; i < tasksEpic.Count; i++)
                {
                    tasksEpic[i].RemoveDeleteUser(person);
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Произошла неизвестная ошибка при удалении исполнителей задачи!" +
                    $"\n\nОшибка: {ex}");
            }
        }

        /// <summary>
        /// Обновление списка задач типа Epic.
        /// </summary>
        public void FindEpicTasks()
        {
            tasksEpic = new List<Epic>();

            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i] is Epic)
                {
                    tasksEpic.Add((Epic)tasks[i]);
                }
            }
        }

        /// <summary>
        /// Вывод на экран информации о задачах типа Epic.
        /// </summary>
        public void PrintEpicTasks()
        {
            // Метод, который обновляет список задач типа Epic.
            FindEpicTasks();

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=============================================== Список задач ===============================================");
            Console.ResetColor();
            Console.Write(Environment.NewLine);

            // Вывод текста на экран с соответствующим отступом.
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Номер:".PadRight(12) +
                " Название:".PadRight(19) +
                " Количество подзадач:".PadRight(26) +
                " Статус задачи:".PadRight(26) +
                " Дата создания:".PadRight(16));
            Console.ResetColor();

            // Цикл по задачам типа Epic.
            for (int i = 0; i < tasksEpic.Count; i++)
            {
                Console.WriteLine($"{(i + 1).ToString().PadRight(12)}" +
                    $" {tasksEpic[i].Name.PadRight(19)}" +
                    $"{tasksEpic[i].CountTasksInEpic().ToString().PadRight(26)}" +
                    $"{tasksEpic[i].Status.PadRight(26)}" +
                    $"{tasksEpic[i].Date.ToString().PadRight(16)}");
            }

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==============================================================================================================");
            Console.ResetColor();
        }

        /// <summary>
        /// Вывод на экран информации о всех задачах.
        /// </summary>
        public void PrintTasksWithoutEpics()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=============================================== Список задач ===============================================");
            Console.ResetColor();
            Console.Write(Environment.NewLine);

            // Вывод текста на экран с соответствующим отступом.
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Номер:".PadRight(12) +
                " Название:".PadRight(19) +
                " Тип задачи:".PadRight(18) +
                " Статус задачи:".PadRight(26) +
                " Исполнители:".PadRight(16));
            Console.ResetColor();

            // Цикл по всем задачам.
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{(i + 1).ToString().PadRight(12)}" +
                    $" {tasks[i].Name.PadRight(19)}" +
                    $"{TypeOfTheTask(i).PadRight(18)}" +
                    $"{tasks[i].Status.PadRight(26)}" +
                    $"{InfoAboutPeoples(i).PadRight(16)}");
            }

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==============================================================================================================");
            Console.ResetColor();
        }

        /// <summary>
        /// Вывод информации на экран об отсортированных задачах по статусу.
        /// </summary>
        public void PrintInfoAboutTasksGroupStatus()
        {
            // Счетчик номера задач.
            int count = 1;

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=============================================== Список задач ===============================================");
            Console.ResetColor();
            Console.Write(Environment.NewLine);

            // Вывод текста на экран с соответствующим отступом.
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Номер:".PadRight(12) +
                " Название:".PadRight(19) +
                " Тип задачи:".PadRight(18) +
                " Статус задачи:".PadRight(26) +
                " Исполнители:".PadRight(16));
            Console.ResetColor();

            // Метод, который выводит на экран задачи со статусом - "Открытая задача".
            PrintOpenTasks(ref count);

            // Метод, который выводит на экран задачи со статусом - "Задача в работе".
            PrintWorkTasks(ref count);

            // Метод, который выводит на экран задачи со статусом - "Завершенная задача".
            PrintCloseTasks(ref count);

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==============================================================================================================");
            Console.ResetColor();
        }

        /// <summary>
        /// Метод, который выводит на экран задачи со статусом - "Открытая задача".
        /// </summary>
        /// <param name="count">Счетчик по списку.</param>
        public void PrintOpenTasks(ref int count)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Status == "Открытая задача")
                {
                    Console.WriteLine($"{(count++).ToString().PadRight(12)}" +
                        $" {tasks[i].Name.PadRight(19)}" +
                        $"{TypeOfTheTask(i).PadRight(18)}" +
                        $"{tasks[i].Status.PadRight(26)}" +
                        $"{InfoAboutPeoples(i).PadRight(16)}");
                }
            }
        }

        /// <summary>
        /// Метод, который выводит на экран задачи со статусом - "Задача в работе".
        /// </summary>
        /// <param name="count">Счетчик по списку.</param>
        public void PrintWorkTasks(ref int count)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Status == "Задача в работе")
                {
                    Console.WriteLine($"{(count++).ToString().PadRight(12)}" +
                    $" {tasks[i].Name.PadRight(19)}" +
                    $"{TypeOfTheTask(i).PadRight(18)}" +
                    $"{tasks[i].Status.PadRight(26)}" +
                    $"{InfoAboutPeoples(i).PadRight(16)}");
                }
            }
        }

        /// <summary>
        /// Метод, который выводит на экран задачи со статусом - "Завершенная задача".
        /// </summary>
        /// <param name="count">Счетчик по списку.</param>
        public void PrintCloseTasks(ref int count)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Status == "Завершенная задача")
                {
                    Console.WriteLine($"{(count++).ToString().PadRight(12)}" +
                    $" {tasks[i].Name.PadRight(19)}" +
                    $"{TypeOfTheTask(i).PadRight(18)}" +
                    $"{tasks[i].Status.PadRight(26)}" +
                    $"{InfoAboutPeoples(i).PadRight(16)}");
                }
            }
        }


        /// <summary>
        /// Вывод на экран спика исполнителей задачи типа Story. 
        /// </summary>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        public void PrintInfoAboutPeoplesStory(int numberOfTheTask)
        {
            // Получение списка исполнителей задачи.
            List<Person> peoples = tasks[numberOfTheTask].InfoAboutPersons();

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("============================================ Список пользователей ============================================");
            Console.ResetColor();
            Console.Write(Environment.NewLine);

            // Цикл по списку людей.
            for (int i = 0; i < peoples.Count; i++)
            {
                Console.WriteLine($"{i + 1} пользователь: {peoples[i].Name}.");
            }

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==============================================================================================================");
            Console.ResetColor();
        }

        /// <summary>
        /// Вывод на экран детальной информации о задачи (дата создания, исполнители).
        /// </summary>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        public void DetailInfoAboutTask(int numberOfTheTask)
        {
            // Получение списка исполнителей задачи.
            List<Person> peoples = tasks[numberOfTheTask].InfoAboutPersons();

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("============================================= Информация о задаче =============================================");
            Console.ResetColor();
            Console.Write(Environment.NewLine);

            // Информация о задаче.
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Название задачи: ");
            Console.ResetColor();
            Console.WriteLine($"\"{tasks[numberOfTheTask].Name}\".{Environment.NewLine}");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Дата создания: ");
            Console.ResetColor();
            Console.WriteLine($"\"{tasks[numberOfTheTask].Date}\".{Environment.NewLine}");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Исполнители: ");
            Console.ResetColor();

            // Информация об исполнителях.
            for (int i = 0; i < peoples.Count; i++)
            {
                if (i == 0)
                    Console.Write(Environment.NewLine);
                Console.WriteLine($"{i + 1}. {peoples[i].Name}");
            }
            if (peoples.Count == 0)
            {
                Console.WriteLine("отсутствуют.");
            }

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==============================================================================================================");
            Console.ResetColor();
        }

        /// <summary>
        /// Сохранение всей информации о проекте и его задачах.
        /// </summary>
        /// <returns>Строка с информацией.</returns>
        public string SaveAllInfoAboutProject()
        {
            string info = "\ns";

            int epicCounter = 0;
            
            // Метод для обновления списка задач типа Epic.
            FindEpicTasks();

            // Метод возвращающий информацию о проекте (Название, задачи и т.д.).
            info += InfoAboutProject();

            for (int i = 0; i < tasks.Count; i++)
            {
                // Задачи типа Epic.
                if (tasks[i] is Epic)
                {
                    info += $"\n{TypeOfTheTask(i)}";

                    info += SaveInfoAboutEpicTasks(ref epicCounter);

                    epicCounter++;
                }

                // Задачи типа Story, Task, Bug.
                if (tasks[i] is Story || tasks[i] is Task || tasks[i] is Bug)
                {
                    info += SaveInfoAboutAllTasks(i);
                }
            }

            // Метка завершения проекта.
            info += "\np";

            return info;
        }

        /// <summary>
        /// Сохранение информации о задачах типа Epic, и их подзадачах.
        /// </summary>
        /// <param name="epicCounter">Счётчик номера задачи.</param>
        /// <returns>Строка с информацией.</returns>
        public string SaveInfoAboutEpicTasks(ref int epicCounter)
        {
            string info = $"\n{tasksEpic[epicCounter].Name}";
            info += $"\n{tasksEpic[epicCounter].Date}";
            info += $"\n{tasksEpic[epicCounter].Status}";
            info += $"\n{tasksEpic[epicCounter].CountTasks()}";

            // Подзадачи.
            for (int j = 0; j < tasksEpic[epicCounter].CountTasks(); j++)
            {
                info += $"\n{tasksEpic[epicCounter].TypeOfTheTaskInEpic(j)}";
                info += $"\n{tasksEpic[epicCounter].NameTasksInEpic(j)}";
                info += $"\n{tasksEpic[epicCounter].DateTaskInEpic(j)}";
                info += $"\n{tasksEpic[epicCounter].StatusTaskInEpic(j)}";
                info += $"\n{tasksEpic[epicCounter].CountPeoplesOnTheEpicTask(j)}";

                // Получение списка исполнителей задачи.
                List<Person> peoples = tasksEpic[epicCounter].NamePeoplesOnTheTask(j);

                // Исполнители подзадачи.
                for (int k = 0; k < peoples.Count; k++)
                {
                    info += $"\n{peoples[k].Name}";
                }
            }

            return info;
        }

        /// <summary>
        /// Сохранение информации обо всех задачах, кроме Epic.
        /// </summary>
        /// <param name="counterTask">Номер задачи./param>
        /// <returns>Строка с информацией.</returns>
        public string SaveInfoAboutAllTasks(int counterTask)
        {
            string info = $"\n{TypeOfTheTask(counterTask)}";
            info += $"\n{tasks[counterTask].Name}";
            info += $"\n{tasks[counterTask].Date}";
            info += $"\n{tasks[counterTask].Status}";
            info += $"\n{tasks[counterTask].CountPeoplesOnTheTask()}";

            for (int j = 0; j < tasks[counterTask].CountPeoplesOnTheTask(); j++)
            {
                info += $"\n{tasks[counterTask].PersonName(j)}";
            }

            return info;
        }

        /// <summary>
        /// Информация о проекте (название, максимальное количество задач, количество задач, количество задач типа Epic). 
        /// </summary>
        /// <returns>Строка с информацией.</returns>
        public string InfoAboutProject()
        {
            string info = $"\n{Name}";
            info += $"\n{MaxCountTasks}";
            info += $"\n{tasks.Count}";
            info += $"\n{tasksEpic.Count}";

            return info;
        }

        /// <summary>
        /// Информация о проекте (название и количество задач).
        /// </summary>
        /// <returns>Строка с информацией.</returns>
        public override string ToString()
        {
            return $"Название проекта - \"{Name}\". " +
                $"\nМаксимальное количество задач на проект - {MaxCountTasks}.";
        }
    }
}
