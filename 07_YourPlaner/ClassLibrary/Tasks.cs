using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Tasks : IAssignable // Реализация интерфейса.
    {
        /// <summary>
        /// Свойство для установки и получения даты создания задачи.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Свойство для установки и получения названия задачи.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Свойство для установки и получения статуса задачи.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Список исполнителей задачи.
        /// </summary>
        List<Person> peoplesOnTheTask = new List<Person>();

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="name">Название задачи.</param>
        public Tasks(string name)
        {
            Name = name;
            Date = DateTime.Now;
            Status = "Открытая задача";
        }

        /// <summary>
        /// Добавление исполнителя задачи.
        /// </summary>
        /// <param name="person">Объект типа Person.</param>
        public void AddPerson(Person person)
        {
            peoplesOnTheTask.Add(person);
        }

        /// <summary>
        /// Получения имени исполнителя.
        /// </summary>
        /// <param name="numberOfTheHuman">Номер исполнителя по списку.</param>
        /// <returns></returns>
        public string PersonName(int numberOfTheHuman)
        {
            return peoplesOnTheTask[numberOfTheHuman].Name;
        }

        /// <summary>
        /// Удаление исполнителя задачи.
        /// </summary>
        /// <param name="person">Объект типа Person, который нужно удалить из списка.</param>
        public void RemovePerson(Person person)
        {
            if (peoplesOnTheTask.Contains(person))
            {
                peoplesOnTheTask.Remove(person);
            }
        }

        /// <summary>
        /// Очистка списка исполнителей.
        /// </summary>
        public void RemoveAllPeoples()
        {
            peoplesOnTheTask.Clear();
        }

        /// <summary>
        /// Информация о исполнителе.
        /// </summary>
        /// <returns>Строка с информацией.</returns>
        public string InfoAboutPerson()
        {
            string info = "";

            if (peoplesOnTheTask.Count == 1)
            {
                info = peoplesOnTheTask[0].Name;
            }

            return info;
        }

        /// <summary>
        /// Количество исполнителей задачи.
        /// </summary>
        /// <returns>Количество исполнителей.</returns>
        public int CountPeoplesOnTheTask()
        {
            return peoplesOnTheTask.Count;
        }

        /// <summary>
        /// Проверка человека в списке исполнителей задачи.
        /// </summary>
        /// <param name="person">Объект типа Person.</param>
        /// <returns>True, если пользователь является исполнителем задачи, False - иначе.</returns>
        public bool PeopleOnTheTask(Person person)
        {
            return peoplesOnTheTask.Contains(person);
        }

        /// <summary>
        /// Возврат списка исполнителей задачи.
        /// </summary>
        /// <returns>Список объектов типа Person.</returns>
        public List<Person> InfoAboutPersons()
        {
            return peoplesOnTheTask;
        }

        /// <summary>
        /// Замена исполнителя задачи.
        /// </summary>
        /// <param name="person">Объект типа Person, который нужно заменить.</param>
        /// <param name="personChange">Объект типа Person, на который нужно заменить.</param>
        public void PersonChange(Person person, Person personChange)
        {
            if (peoplesOnTheTask.Contains(person))
            {
                peoplesOnTheTask.Remove(person);
                peoplesOnTheTask.Add(personChange);
            }
        }
    }
}
