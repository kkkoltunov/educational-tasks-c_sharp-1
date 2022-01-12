using System;
using System.Collections.Generic;

namespace SellersAndBuyers
{
    [Serializable]
    public class Order
    {
        /// <summary>
        /// Заказанные клиентом продукты.
        /// </summary>
        public Dictionary<Product, uint> ProductsOrdered { get; set; }

        /// <summary>
        /// Номер заказа.
        /// </summary>
        public uint Number { get; set; }

        /// <summary>
        /// Дата оформления заказа.
        /// </summary>
        public DateTime TimeOrdered { get; set; }

        /// <summary>
        /// Статус заказа.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Клиент.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Оплата заказа.
        /// </summary>
        public bool Paid { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="productOrdered"><Список заказанных товаров./param>
        /// <param name="timeOrdered">Дата заказа.</param>
        /// <param name="client">Клиент.</param>
        /// <param name="numberOrder">Номер заказа.</param>
        public Order(Dictionary<Product, uint> productOrdered, DateTime timeOrdered, Client client, uint numberOrder)
        {
            ProductsOrdered = productOrdered;
            Number = 1000 + numberOrder;
            TimeOrdered = timeOrdered;
            Status = Status.New;
            Client = client;
            Paid = false;
        }

        /// <summary>
        /// Рассчет стоимости заказа.
        /// </summary>
        /// <returns>Стоимость заказа типа decimal.</returns>
        public decimal Cost()
        {
            decimal cost = 0;

            foreach (KeyValuePair<Product, uint> product in ProductsOrdered)
            {
                cost += product.Key.Price * product.Value;
            }

            return cost;
        }

        /// <summary>
        /// Информация о заказанных товарах.
        /// </summary>
        /// <returns></returns>
        public string InfoAboutOrderedProducts()
        {
            string info = "";

            foreach (KeyValuePair<Product, uint> product in ProductsOrdered)
            {
                info += $"|{product.Key.CarBrand}/{product.Key.BodyType}/{product.Value}| ";
            }

            return info;
        }

        /// <summary>
        /// Переопредленный метод для вывода информации об экземпляре класса.
        /// </summary>
        /// <returns>Строка с данными.</returns>
        public override string ToString()
        {
            string status = "";

            if (Status == Status.New)
                status += "Новый";
            if (Status == Status.Processed)
                status += "Обработан";
            if (Status == Status.Shipped)
                status += "Отгружен";
            if (Status == Status.Completed)
                status += "Исполнен";
            if (Paid)
                status += " / Оплачен";
            else
                status += " / Не оплачен";
            return $"{Number};{status};{TimeOrdered};{InfoAboutOrderedProducts()};{Cost()};{Client.EMail}";
        }
    }
}
