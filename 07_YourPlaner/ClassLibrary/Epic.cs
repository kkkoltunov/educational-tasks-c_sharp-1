using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Epic : Tasks
    {
        /// <summary>
        /// Список подзадач.
        /// </summary>
        List<Tasks> tasks = new List<Tasks>();

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="name">Название подзадачи.</param>
        public Epic(string name) : base(name) { }

        /// <summary>
        /// Получение количества подзадач.
        /// </summary>
        /// <returns>Число подзадач.</returns>
        public int CountTasks()
        {
            return tasks.Count;
        }

        /// <summary>
        /// Получение типа подзадачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер подзадачи.</param>
        /// <returns>Строка с информацией.</returns>
        public string TypeOfTheTaskInEpic(int numberOfTheTask)
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

            return type;
        }

        /// <summary>
        /// Получение статуса подзадачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер подзадачи.</param>
        /// <returns>Строка с информацией.</returns>
        public string StatusTaskInEpic(int numberOfTheTask)
        {
            return tasks[numberOfTheTask].Status;
        }

        /// <summary>
        /// Получение даты создания подзадачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер подзадачи.</param>
        /// <returns>Строка с информацией.</returns>
        public string DateTaskInEpic(int numberOfTheTask)
        {
            return tasks[numberOfTheTask].Date.ToString();
        }

        /// <summary>
        /// Получение количества исполнителей подзадачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        /// <returns>Число исполнителей.</returns>
        public int CountPeoplesOnTheEpicTask(int numberOfTheTask)
        {
            return tasks[numberOfTheTask].CountPeoplesOnTheTask();
        }

        /// <summary>
        /// Получения списка исполнителей подзадачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер задачи.</param>
        /// <returns>Лист исполнителей типа Person.</returns>
        public List<Person> NamePeoplesOnTheTask(int numberOfTheTask)
        {
            return tasks[numberOfTheTask].InfoAboutPersons();
        }

        /// <summary>
        /// Создание подзадачи.
        /// </summary>
        /// <param name="name">Название подзадачи.</param>
        /// <param name="numberOfTask">Номер подзадачи.</param>
        public void CreateTasks(string name, int numberOfTask)
        {
            switch (numberOfTask)
            {
                case 1:
                    tasks.Add(new Story(name));
                    break;
                case 2:
                    tasks.Add(new Task(name));
                    break;
            }
        }

        /// <summary>
        /// Создание подзадачи по типу.
        /// </summary>
        /// <param name="typeOfTheTask">Тип подзадачи.</param>
        /// <param name="name">Название подзадачи.</param>
        public void AddTasks(string typeOfTheTask, string name)
        {
            switch (typeOfTheTask)
            {
                case "Story":
                    tasks.Add(new Story(name));
                    break;
                case "Task":
                    tasks.Add(new Task(name));
                    break;
            }
        }

        /// <summary>
        /// Количество подзадач в Epic.
        /// </summary>
        /// <returns></returns>
        public int CountTasksInEpic()
        {
            return tasks.Count;
        }

        /// <summary>
        /// Установка даты создания подзадачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер подзадачи.</param>
        /// <param name="dateTime">Дата создания подзадачи.</param>
        public void SetDateForTask(int numberOfTheTask, DateTime dateTime)
        {
            tasks[numberOfTheTask].Date = dateTime;
        }

        /// <summary>
        /// Установка статуса подзадачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер подзадачи.</param>
        /// <param name="status">Статус подзадачи.</param>
        public void SetStatusForTask(int numberOfTheTask, string status)
        {
            tasks[numberOfTheTask].Status = status;
        }

        /// <summary>
        /// Удаление подзадачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер подзадачи.</param>
        public void RemoveTasks(int numberOfTheTask)
        {
            tasks.Remove(tasks[numberOfTheTask]);
        }

        /// <summary>
        /// Флаг количества исполнителей подзадачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер подзадачи.</param>
        /// <returns>True, если 0 исполнителей, False - иначе.</returns>
        public bool FlagCountPeopleOnTheTasks(int numberOfTheTask)
        {
            bool flag = false;

            if (tasks[numberOfTheTask] is Task)
            {
                Task task = (Task)tasks[numberOfTheTask];
                flag = task.FlagCountPeoples;
            }
            if (tasks[numberOfTheTask] is Story)
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// Назначение исолнителей подзадачи.
        /// </summary>
        /// <param name="person">Объект типа Person.</param>
        /// <param name="numberOfTheTask">Номер подзадачи.</param>
        /// <returns>True, если исполнитель назначен, False - иначе.</returns>
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
        /// Изменение исполнителя подзадачи.
        /// </summary>
        /// <param name="person">Объект типа Person, который нужно заменить.</param>
        /// <param name="personChange">Объект типа Person, на который нужно заменить.</param>
        /// <param name="numberOfTheTask">Номер подзадачи.</param>
        public void ChangePeoples(Person person, Person personChange, int numberOfTheTask)
        {
            tasks[numberOfTheTask].PersonChange(person, personChange);
        }

        /// <summary>
        /// Удаление исполнителей подзадачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер подзадачи.</param>
        public void RemoveAllPeoples(int numberOfTheTask)
        {
            tasks[numberOfTheTask].RemoveAllPeoples();
        }

        /// <summary>
        /// Удаление исполнителя подзадачи.
        /// </summary>
        /// <param name="person">Объект типа Person.</param>
        /// <param name="numberOfTheTask">Номер подзадачи.</param>
        public void RemovePeoples(Person person, int numberOfTheTask)
        {
            tasks[numberOfTheTask].RemovePerson(person);
        }

        /// <summary>
        /// Удаление исполнителя задачи, после его удаления из списка пользователей.
        /// </summary>
        /// <param name="person">Объект типа Person.</param>
        public void RemoveDeleteUser(Person person)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                tasks[i].RemovePerson(person);
            }
        }

        /// <summary>
        /// Изменение статуса подзадачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер подзадачи.</param>
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
        /// Проверка типа подзадачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер подзадачи.</param>
        /// <returns>True, если задача типа Task, False - иначе.</returns>
        public bool FlagIsTask(int numberOfTheTask)
        {
            return tasks[numberOfTheTask] is Task && tasks[numberOfTheTask].CountPeoplesOnTheTask() > 0;
        }

        /// <summary>
        /// Проверка типа подзадачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер подзадачи.</param>
        /// <returns>True, если задача типа Story, False - иначе.</returns>
        public bool FlagIsStory(int numberOfTheTask)
        {
            return tasks[numberOfTheTask] is Story && tasks[numberOfTheTask].CountPeoplesOnTheTask() > 0;
        }

        /// <summary>
        /// Возвращение названия подзадачи.
        /// </summary>
        /// <param name="numberOfTheTask">Номер подзадачи.</param>
        /// <returns>Строка с информацией.</returns>
        public string NameTasksInEpic(int numberOfTheTask)
        {
            return tasks[numberOfTheTask].Name;
        }

        /// <summary>
        /// Информация о исполнителях подзадач.
        /// </summary>
        /// <param name="numberOfTheTask">Номер подзадачи.</param>
        /// <returns>Строка с информацией.</returns>
        public string InfoAboutPeoplesInEpic(int numberOfTheTask)
        {
            string info = "";

            if (tasks[numberOfTheTask].CountPeoplesOnTheTask() == 0)
            {
                info = "Отсутствуют";
            }
            else if (tasks[numberOfTheTask].CountPeoplesOnTheTask() == 1)
            {
                info = tasks[numberOfTheTask].InfoAboutPerson();
            }
            else
            {
                info = tasks[numberOfTheTask].CountPeoplesOnTheTask().ToString();
            }

            return info;
        }

        /// <summary>
        /// Вывод списка подзадач на экран.
        /// </summary>
        public void InfoAboutTasksInEpic()
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

            // Цикл по задачам.
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{(i + 1).ToString().PadRight(12)}" +
                    $" {tasks[i].Name.PadRight(19)}" +
                    $"{TypeOfTheTaskInEpic(i).PadRight(18)}" +
                    $"{tasks[i].Status.PadRight(26)}" +
                    $"{InfoAboutPeoplesInEpic(i).PadRight(16)}");
            }

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==============================================================================================================");
            Console.ResetColor();
        }

        /// <summary>
        /// Вывод инормации об исполнителях задач типа Story.
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

            // Цикл по исполнителям.
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
        /// Вывод группированных по статусу задач на экран.
        /// </summary>
        public void PrintInfoAboutTasksGroupStatus()
        {
            int count = 1;

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=============================================== Список задач ===============================================");
            Console.ResetColor();
            Console.Write(Environment.NewLine);

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
                        $"{TypeOfTheTaskInEpic(i).PadRight(18)}" +
                        $"{tasks[i].Status.PadRight(26)}" +
                        $"{InfoAboutPeoplesInEpic(i).PadRight(16)}");
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
                    $"{TypeOfTheTaskInEpic(i).PadRight(18)}" +
                    $"{tasks[i].Status.PadRight(26)}" +
                    $"{InfoAboutPeoplesInEpic(i).PadRight(16)}");
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
                    $"{TypeOfTheTaskInEpic(i).PadRight(18)}" +
                    $"{tasks[i].Status.PadRight(26)}" +
                    $"{InfoAboutPeoplesInEpic(i).PadRight(16)}");
                }
            }
        }

        /// <summary>
        /// Вывод детальной информации о задаче на экран.
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

            // Информация о подзадаче.
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

            // Цикл по исполнителям задачи.
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
    }
}
