using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class Bug : Tasks
    {
        /// <summary>
        /// Свойство, возвращающее True, если количество задач равно 0, Else - иначе.
        /// </summary>
        public bool FlagCountPeoples
        {
            get
            {
                return CountPeoplesOnTheTask() == 0;
            }
        }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="name">Название задачи.</param>
        public Bug(string name) : base(name) { }
    }
}
