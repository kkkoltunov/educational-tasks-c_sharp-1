using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager
{
    class Warehouse
    {
        Random random = new Random();

        // Поля.

        int countConatainers;

        double feeContainers;

        // Список контейнеров.

        List<Container> containers = new List<Container>();

        // Свойство получение/установки количества контейнеров.

        public int CountConatainers
        {
            get
            {
                return countConatainers;
            }
            set
            {
                countConatainers = value;
            }
        }

        // Свойство для получение/установки стоимости хранения контейнеров.

        public double FeeContainers
        {
            get
            {
                return feeContainers;
            }
            set
            {
                feeContainers = value;
            }
        }

        // Конструктор.

        public Warehouse(int count)
        {
            CountConatainers = count;
        }

        // Свойство для получения актуального количества контейнеров.

        public int GetContainers
        {
            get
            {
                return containers.Count;
            }
        }

        // Создание контейнера с указанным пользователем тегом.

        public void SetContainerInfo(string id)
        {
            if (countConatainers != containers.Count)
            {
                containers.Add(new Container(id));
            }
            else
            {
                containers.RemoveAt(0);
                containers.Add(new Container(id));
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Произведено удаление первого контейнера и помещение нового!");
                Console.ResetColor();
            }
        }

        // Метод для получения содержимого контейнера.

        public void BoxInfo(int numberOfConatainer)
        {
            if (containers[numberOfConatainer - 1].BoxNow() != 0)
            {
                containers[numberOfConatainer - 1].PrintBoxes();
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("Контейнер пуст!");
            }
        }

        // Метод для аписи информации о контейнерах в файл.

        public void BoxInfoToFile(int numberOfConatainer, List<string> boxInfo)
        {
            if (containers[numberOfConatainer].BoxNow() != 0)
            {
                containers[numberOfConatainer].PrintBoxesToFile(boxInfo);
            }
            else
            {
                boxInfo.Add("");
                boxInfo.Add("Контейнер пуст!");
                boxInfo.Add("");
            }
        }

        // Метод для создания корробок в контейнере.

        public void Box(double weight, double fee, out bool flag)
        {
            flag = false;

            if (containers[containers.Count - 1].WeightAllBox >= containers[containers.Count - 1].GetWeightBoxes + weight)
            {
                containers[containers.Count - 1].SetBoxInfo(weight, fee);
                containers[containers.Count - 1].PrintBoxes();
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Максимальный объем данного контейнера: {containers[containers.Count - 1].WeightAllBox} кг," +
                    $" текущий объем: {containers[containers.Count - 1].GetWeightBoxes} кг. Ящик не помещен, так как вес ящика {weight} кг!");
                Console.ResetColor();
            }

            if (containers[containers.Count - 1].WeightAllBox == containers[containers.Count - 1].GetWeightBoxes)
            {
                flag = true;
            }
        }

        // Метод для добавления коробок в контейнер(доп.функционал).

        public void BoxAdd(double weight, double fee, out bool flag, int numberOfContainer)
        {
            flag = false;

            if (containers[numberOfContainer - 1].WeightAllBox >= containers[numberOfContainer - 1].GetWeightBoxes + weight)
            {
                containers[numberOfContainer - 1].SetBoxInfo(weight, fee);
                containers[numberOfContainer - 1].PrintBoxes();
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Максимальный объем данного контейнера: {containers[numberOfContainer - 1].WeightAllBox} кг," +
                    $" текущий объем: {containers[numberOfContainer - 1].GetWeightBoxes} кг. Ящик не помещен, так как вес ящика {weight} кг!");
                Console.ResetColor();
            }

            if (containers[numberOfContainer - 1].WeightAllBox == containers[numberOfContainer - 1].GetWeightBoxes)
            {
                flag = true;
            }
        }

        // Метод для проверки стоимости содержимого контейнера.

        public void Check()
        {
            if ((containers[containers.Count - 1].GetPriceBoxes * (1 - (containers[containers.Count - 1].DamageContainer)) < feeContainers))
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Контейнер не помещен на склад! Стоимость содержимого - {(containers[containers.Count - 1].GetPriceBoxes * (1 - containers[containers.Count - 1].DamageContainer)):f8}$, что ниже фиксированной платы за хранение!");
                Console.ResetColor();
                containers.RemoveAt(containers.Count - 1);
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Контейнер успешно зарегестрирован на нашем складе!");
                Console.ResetColor();
            }
        }

        // Метод для проверки количества коробок в контейнере.

        public int BoxInContainer(int numberOfContainer)
        {
            return containers[numberOfContainer - 1].BoxNow();
        }

        // Метод для удаления контейнера из списка.

        public void DeleteContainer(int numContainer)
        {
            containers.RemoveAt(numContainer - 1);
        }

        // Метод для вывода на экран информации о контейнерах.

        public void PrintContainers()
        {
            if (containers.Count != 0)
            {
                Console.Write(Environment.NewLine);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"======================================== Информация о контейнерах на складе =========================================");
                Console.ResetColor();

                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Номер:".PadRight(10) + 
                    " Тег:".PadRight(10) + 
                    "  Макс. вес ящиков (кг):".PadRight(22) + 
                    " Текущий вес ящиков (кг):".PadRight(24) + 
                    " Общая стоимость контейнера ($):".ToString().PadRight(31) + 
                    " Повреждение (%):");

                Console.ResetColor();

                for (int i = 0; i < containers.Count; i++)
                {
                    Console.WriteLine($"{(i + 1).ToString().PadRight(10)} " +
                        $"{containers[i].IdContainer.ToString().PadRight(10)} " +
                        $"{containers[i].WeightAllBox.ToString().PadRight(22)} " +
                        $"{containers[i].GetWeightBoxes.ToString("f3").PadRight(24)} " +
                        $"{containers[i].GetPriceBoxes.ToString("f8").PadRight(31)} " +
                        $"{(containers[i].DamageContainer * 100):f3}");
                }

                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=====================================================================================================================");
                Console.ResetColor();
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("Склад пуст! :(");
            }
        }

        // Метод для добавления данных о контейнера их содержмом в список.

        public void PrintContainersToFile(List<string> infoContainers)
        {
            List<string> infoBox = new List<string>();

            infoContainers.Add($"======================================== Информация о контейнерах на складе =========================================");
            infoContainers.Add("");

            if (containers.Count != 0)
            {
                for (int i = 0; i < containers.Count; i++)
                {
                    infoContainers.Add($"============================================ Информация о {i + 1} контейнере =============================================");
                    infoContainers.Add("");
                    infoContainers.Add("Номер:".PadRight(10) + 
                        " Тег:".PadRight(10) + 
                        "  Макс. вес ящиков (кг):".PadRight(22) + 
                        " Текущий вес ящиков (кг):".PadRight(24) + 
                        " Общая стоимость контейнера ($):".ToString().PadRight(31) + 
                        " Повреждение (%):");

                    infoContainers.Add($"{(i + 1).ToString().PadRight(10)} " +
                        $"{containers[i].IdContainer.ToString().PadRight(10)} " +
                        $"{containers[i].WeightAllBox.ToString().PadRight(22)} " +
                        $"{containers[i].GetWeightBoxes.ToString("f3").PadRight(24)} " +
                        $"{containers[i].GetPriceBoxes.ToString("f8").PadRight(31)} " +
                        $"{(containers[i].DamageContainer * 100):f3}");

                    infoContainers.Add("");
                    BoxInfoToFile(i, infoBox);
                    infoContainers.AddRange(infoBox);
                    infoContainers.Add("");
                    infoBox.Clear();
                }
            }
            else
            {
                infoContainers.Add("");
                infoContainers.Add("Склад пуст! :(");
                infoBox.Clear();
            }
        }
    }
}
