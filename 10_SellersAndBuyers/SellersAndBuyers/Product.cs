using System;

namespace SellersAndBuyers
{
    [Serializable]
    public class Product
    {
        /// <summary>
        /// Марка машины.
        /// </summary>
        public string CarBrand { get; set; }

        /// <summary>
        /// Тип топлива.
        /// </summary>
        public string FuelType { get; set; }

        /// <summary>
        /// Тип кузова.
        /// </summary>
        public string BodyType { get; set; }

        /// <summary>
        /// Количество на складе.
        /// </summary>
        public uint Count { get; set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="carBrand">Марка машины.</param>
        /// <param name="fuelType">Тип топлива.</param>
        /// <param name="bodyType">Тип кузова.</param>
        /// <param name="count">Количество на складе.</param>
        /// <param name="price">Стоимость.</param>
        public Product(string carBrand, string fuelType, string bodyType, uint count, decimal price)
        {
            CarBrand = carBrand;
            FuelType = fuelType;
            BodyType = bodyType;
            Count = count;
            Price = price;
        }
    }
}
