using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Person
    {
        /// <summary>
        /// Автореализуемое свойство для установки или получения имени пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        public Person(string name)
        {
            Name = name;
        }
    }
}
