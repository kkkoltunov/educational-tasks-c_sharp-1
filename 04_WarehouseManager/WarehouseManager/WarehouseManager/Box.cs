using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager
{
    class Box
    {
        // Поля.

        double weightBox;
        double feeBox;

        // Конструктор.

        public Box(double weightBox, double feeBox)
        {
            WeightBox = weightBox;
            FeeBox = feeBox;
        }

        // Свойство для получения/установки веса коробки.

        public double WeightBox
        {
            get
            {
                return weightBox;
            }
            set
            {
                weightBox = value;
            }
        }

        // Свойство для получения/утсановки стоимости коробки.

        public double FeeBox
        {
            get
            {
                return feeBox;
            }
            set
            {
                feeBox = value;
            }
        }
    }
}
