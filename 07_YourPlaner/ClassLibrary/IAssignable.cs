using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Интерфейс, позволяющий назначать, удалять исполнителей задачи.
    /// </summary>
    interface IAssignable
    {
        /// <summary>
        /// Список исполнителей задачи.
        /// </summary>
        static List<Person> people = new List<Person>();

        /// <summary>
        /// Метод для добавления человека в список исполнителей задачи.
        /// </summary>
        /// <param name="person">Пользователь.</param>
        void AddPerson(Person person);

        /// <summary>
        /// Метод для удаления человека из списка исполнителей задачи.
        /// </summary>
        /// <param name="person">Пользователь.</param>
        void RemovePerson(Person person);

        /// <summary>
        /// Очистка всего списка пользователей.
        /// </summary>
        void RemoveAllPeoples();
    }
}
