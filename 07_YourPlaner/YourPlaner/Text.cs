using System;
using System.Collections.Generic;
using System.Text;

namespace YourPlaner
{
    partial class Program
    {
        /// <summary>
        /// Стартовое меню.
        /// </summary>
        static void StartText()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Доступные для выполнения операции:");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[1] Работа с проектами.");
            Console.WriteLine("[2] Работа с пользователями.");
            Console.WriteLine("[3] Работа с задачами в проекте.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("[0] Выход из программы.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.Write("Выберите номер желаемой операции: ");
        }

        /// <summary>
        /// Меню при работе с пользователями.
        /// </summary>
        static void WorkWithPeoplesText()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Доступные для выполнения операции:");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[1] Добавить пользователя.");
            Console.WriteLine("[2] Удалить пользователя.");
            Console.WriteLine("[3] Просмотреть список пользователей.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("[0] Назад.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.Write("Выберите номер желаемой операции: ");
        }

        /// <summary>
        /// Меню при создании различных типов задач.
        /// </summary>
        static void CreateTasksText()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Выберите тип задачи:");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[1] \"Story\" - задача, средняя по объему работы (много исполнителей).");
            Console.WriteLine("[2] \"Task\" - задача, маленькая по объему работы (1 исполнитель).");
            Console.WriteLine("[3] \"Bug\" - задача, описывающая проблему в проекте (1 исполнитель).");
            Console.WriteLine("[4] \"Epic\" - большая задача, включает в себя несколько меньших подзадач.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("[0] Назад.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.Write("Выберите номер желаемой операции: ");
        }

        /// <summary>
        /// Меню при работе с проектами.
        /// </summary>
        static void WorkWithProjectsText()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Доступные для выполнения операции:");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[1] Создать проект.");
            Console.WriteLine("[2] Просмотреть список существующих проектов.");
            Console.WriteLine("[3] Изменить название проекта.");
            Console.WriteLine("[4] Удалить проект.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("[0] Назад.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.Write("Выберите номер желаемой операции: ");
        }

        /// <summary>
        /// Меню при работе со всеми типами задач.
        /// </summary>
        static void WorkWithTasksInProjectText()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Доступные для выполнения операции:");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[1] Добавить задачу в проект.");
            Console.WriteLine("[2] Удалить задачу.");
            Console.WriteLine("[3] Назначить исполнителей задачи.");
            Console.WriteLine("[4] Изменить исполнителя задачи.");
            Console.WriteLine("[5] Удалить исполнителя задачи.");
            Console.WriteLine("[6] Изменить статус задачи.");
            Console.WriteLine("[7] Группировка задач по статусу.");
            Console.WriteLine("[8] Получить информацию о существующих задачах.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("[0] Назад.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.Write("Выберите номер желаемой операции: ");
        }

        /// <summary>
        /// Меню при создании подзадач задачи Epic.
        /// </summary>
        static void CreateUnderTasksForEpicsText()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Выберите тип задачи:");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[1] \"Story\" - задача, средняя по объему работы (много исполнителей).");
            Console.WriteLine("[2] \"Task\" - задача, маленькая по объему работы (1 исполнитель).");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("[0] Назад.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.Write("Выберите номер желаемой операции: ");
        }

        /// <summary>
        /// Меню при выборе типа задач для работы.
        /// </summary>
        static void SelectTypeOfTheTasksText()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Выберите тип задачи, с которыми хотите продолжить работу:");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[1] Создание всех типов задач.");
            Console.WriteLine("[2] Работа с задачами типа \"Epic\", которые включают в себя другие подзадачи.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("[0] Назад.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.Write("Выберите тип задачи: ");
        }

        /// <summary>
        /// Меню при изменении статуса задачи.
        /// </summary>
        static void ChangeStatusText()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Выберите статус, который вы хотите установить:");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[1] \"Открытая задача\".");
            Console.WriteLine("[2] \"Задача в работе\".");
            Console.WriteLine("[3] \"Завершенная задача\".");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("[0] Назад.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.Write("Выберите тип задачи: ");
        }

        /// <summary>
        /// Меню при работе с подзадачами задачи Epic.
        /// </summary>
        static void WorkWithEpicTasksText()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Доступные для выполнения операции:");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[1] Добавить подзадачу.");
            Console.WriteLine("[2] Удалить подзадачу.");
            Console.WriteLine("[3] Назначить исполнителей подзадачи.");
            Console.WriteLine("[4] Изменить исполнителя подзадачи.");
            Console.WriteLine("[5] Удалить исполнителя подзадачи.");
            Console.WriteLine("[6] Изменить статус подзадачи.");
            Console.WriteLine("[7] Группировка подзадач по статусу.");
            Console.WriteLine("[8] Получить информацию о существующих подзадачах.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("[0] Назад.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.Write("Выберите номер желаемой операции: ");
        }

        /// <summary>
        /// Текст при некорректном вводе пункта меню.
        /// </summary>
        static void IncorrectInputText()
        {
            Console.Clear();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Некорректный ввод, пожалуйста, повторите попытку!");
            Console.ResetColor();
        }

        /// <summary>
        /// Текст об успешном создании задачи.
        /// </summary>
        /// <param name="nameOfTheTask">Номер задачи.</param>
        static void CreateTaskSuccsesText(string nameOfTheTask)
        {
            Console.Clear();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Подзадача \"{nameOfTheTask}\" успешно создана!");
            Console.ResetColor();
        }

        /// <summary>
        /// Текст об ошибке в связи с отсутствием подзадач.
        /// </summary>
        static void IncorrectCountTasksInEpicCountText()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Подзадачи отсутствуют!");
            Console.ResetColor();
        }

        /// <summary>
        /// Текст об ошибке в связи с отсутствием пользователей.
        /// </summary>
        static void IncorrectCountPeoplesText()
        {
            Console.Clear();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Пользователи отсутствуют!");
            Console.ResetColor();
        }

        /// <summary>
        /// Текст об ошибке в связи с отсутствием проектов.
        /// </summary>
        static void IncorrectCountProjectsText()
        {
            Console.Clear();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Проекты отсутствуют!");
            Console.ResetColor();
        }

        /// <summary>
        /// Текст об ошибке в связи с отсутствием пользователей.
        /// </summary>
        static void IncorrectCountPeoplesInProjectText()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Для создания проекта добавьте хотя бы одного пользователя!");
            Console.ResetColor();
        }

        /// <summary>
        /// Текст об ошибке в связи с созданием максимального количества задач.
        /// </summary>
        static void MaxCountTasksCreateText()
        {
            Console.Clear();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("В данном проекте создано максимальное число задач!");
            Console.ResetColor();
        }

        /// <summary>
        /// Текст об ошибке в связи с отсутствием задач.
        /// </summary>
        static void IncorrectCountTasksCreatedText()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Задачи отсутствуют!");
            Console.ResetColor();
        }

        /// <summary>
        /// Ошибка в связи с тем, что задача типа Epic.
        /// </summary>
        static void TaskIsEpicText()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Для работы с задачами типа \"Epic\" воспользуйтесь специальным пунктом меню!");
            Console.Write(Environment.NewLine);
            Console.WriteLine("[Работа с задачами в проекте] -> [Большие задачи, которые включают в себя другие подзадачи].");
            Console.ResetColor();
        }

        /// <summary>
        /// Ошибка в связи с отсутствием исполнителя задачи.
        /// </summary>
        static void PeopleNotExsistText()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Исполнитель задачи отсутствует!");
            Console.ResetColor();
        }

        /// <summary>
        /// Текст об успешном удалении пользователя.
        /// </summary>
        static void PeopleSuccsessfulDeleteText()
        {
            Console.Clear();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Исполнитель успешно удален!");
            Console.ResetColor();
        }

        /// <summary>
        /// Текст ошибки в связи с отсутсвтием проектов.
        /// </summary>
        static void ProjectsNotExsistText()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Проекты отсутствуют!");
            Console.ResetColor();
        }
    }
}
