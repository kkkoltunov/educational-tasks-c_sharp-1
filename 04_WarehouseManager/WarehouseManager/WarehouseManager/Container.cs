using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager
{
    class Container
    {
        // Рандом.

        Random random = new Random();

        // Поля.

        int weightAllBox;

        string idContainer;

        double weight = 0;

        double price = 0;

        double damageContainer;

        // Список контейнеров в контейнере.

        List<Box> boxes = new List<Box>();

        // Свойство для установки случайного повреждения/получения информации о повреждении.

        public double DamageContainer
        {
            get
            {
                return damageContainer;
            }
            set
            {
                damageContainer = random.NextDouble();

                if (damageContainer > 0.5)
                {
                    damageContainer -= 0.5;
                }
            }
        }

        // Свойство установки веса всех ящиков для конкретного контейнера.

        public int WeightAllBox
        {
            get
            {
                return weightAllBox;
            }
            set
            {
                weightAllBox = random.Next(50, 1001);
            }
        }

        // Совйство для установки/получения тега контейнера.

        public string IdContainer
        {
            get
            {
                return idContainer;
            }
            set
            {
                idContainer = value;
            }
        }

        // Конструктор.

        public Container(string id)
        {
            IdContainer = id;
            WeightAllBox = weightAllBox;
            DamageContainer = damageContainer;
        }

        // Свойство для добавление ящиков на склад.

        public void SetBoxInfo(double weightBox, double feeBox)
        {
            boxes.Add(new Box(weightBox, feeBox));
        }

        // Свойство для получения актуальной стоимости ящиков.

        public double GetPriceBoxes
        {
            get
            {
                price = 0;

                for (int i = 0; i < boxes.Count; i++)
                {
                    price += (boxes[i].FeeBox * boxes[i].WeightBox);
                }

                return price;
            }
        }

        // Свойство для получения общего веса ящиков.

        public double GetWeightBoxes
        {
            get
            {
                weight = 0;

                for (int i = 0; i < boxes.Count; i++)
                {
                    weight += boxes[i].WeightBox;
                }

                return weight;
            }
        }

        // Метод для подсчета количества ящиков в контейнере на данный момент.

        public int BoxNow()
        {
            return boxes.Count;
        }

        // Метод для вывода информация о ящиках в контейнере.

        public void PrintBoxes()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"===================================== Информация о ящиках в текущем контейнере =====================================");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Номер:".PadRight(10) + 
                " Вес (кг):".PadRight(15) + 
                " Стоимость за кг ($):".PadRight(20) + 
                " Общая стоимость ящика ($):");
            Console.ResetColor();

            for (int i = 0; i < boxes.Count; i++)
            {
                Console.WriteLine($"{(i + 1).ToString().PadRight(10)} " +
                    $"{boxes[i].WeightBox.ToString("f3").PadRight(14)} " +
                    $"{boxes[i].FeeBox.ToString("f8").PadRight(20)} " +
                    $"{(boxes[i].WeightBox * boxes[i].FeeBox):f8}");
            }

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=====================================================================================================================");
            Console.ResetColor();
        }

        // Метод для записи информации о ящиках и контейнерах в список.

        public void PrintBoxesToFile(List<string> boxInfo)
        {
            boxInfo.Add($"===================================== Информация о ящиках в текущем контейнере =====================================");
            boxInfo.Add("");
            boxInfo.Add("Номер:".PadRight(10) + 
                " Вес (кг):".PadRight(15) + 
                " Стоимость за кг ($):".PadRight(20) + 
                " Общая стоимость ящика ($):");

            for (int i = 0; i < boxes.Count; i++)
            {
                boxInfo.Add($"{(i + 1).ToString().PadRight(10)} " +
                    $"{boxes[i].WeightBox.ToString("f3").PadRight(14)} " +
                    $"{boxes[i].FeeBox.ToString("f8").PadRight(20)} " +
                    $"{(boxes[i].WeightBox * boxes[i].FeeBox):f8}");
            }

            boxInfo.Add("");
            boxInfo.Add("=====================================================================================================================");
        }
    }
}
