using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class Story : Tasks
    {
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="name">Название задачи.</param>
        public Story(string name) : base(name) { }
    }
}
