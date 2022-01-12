using System;
using System.Collections.Generic;
using System.Text;

namespace SellersAndBuyers
{
    [Serializable]
    public class Client
    {
        /// <summary>
        /// ID клиента.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Имя клиента.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия клиента.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество клиента.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Номер телефона клиента.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Адрес клиента.
        /// </summary>
        public string HomeAddress { get; set; }

        /// <summary>
        /// Электронная почта клиента.
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// Пароль клиента.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Список заказов клиента.
        /// </summary>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <param name="name">Имя.</param>
        /// <param name="surname">Фамилия.</param>
        /// <param name="patronymic">Отчество.</param>
        /// <param name="phoneNumber">Номер телефона.</param>
        /// <param name="homeAdress">Домашний адрес.</param>
        /// <param name="email">Электронная почта.</param>
        /// <param name="password">Пароль.</param>
        public Client(int id, string name, string surname, string patronymic, string phoneNumber, string homeAdress, string email, string password)
        {
            ID = id;
            Name = name;
            Surname = name;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            HomeAddress = homeAdress;
            EMail = email;
            Password = password;
            Orders = new List<Order>();
        }
    }
}
