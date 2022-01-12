using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager
{
    partial class Program
    {
        // Меню программы.

        static void ComandTextMenu()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Доступные для выполнения операции:");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[1] Добавление контейнера на склад.");
            Console.WriteLine("[2] Удаление контейнера со склада.");
            Console.WriteLine("[3] Получение информации о содержимом склада.");
            Console.WriteLine("[4] Добавления ящиков в контейнер.");
            Console.WriteLine("[5] Вывод информации о текущем состоянии склада в файл.");
            Console.WriteLine("[6] Очистка экрана.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("[0] Выход из программы.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
        }

        // Текст в самом начале выполнения программы.

        static void StartText()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("Полезная информация при работе с программой:");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("При работе с файлами рекомендуется использовать файлы с расширением *txt (UTF8), для остальных файлов корректная работа не гарантируется!");
            Console.WriteLine("Считвание информации из файла происходит по ключевым словам и значениям, поэтому сторонняя информация в файле будет проигнорирована.");
            Console.WriteLine("Если вы хотите воспользоваться файлом для ввода действий с контейнерами, то стоить заметить, что в данном случае заполнять контейнер не нужно!");
            Console.WriteLine("В данной функции при создании контейнера вы просто резервируете место под него, а в основной программе нужно будет его заполнить.");
            Console.WriteLine("Только после заполнения контейнера ящиками будет вынесено решение: добавлять контейнер на склад или нет.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Возможно два варианта организации склада, выберете один из них:");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[1] Ввод данных вручную.");
            Console.WriteLine("[2] Ввод данных из файла.");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Введите номер желаемой команды: ");
        }

        // Текст при вводе данных о контейнере с файла.

        static void WarehouseInputText()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Овощной склад ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Мы предоставляем тебе территорию для размещения своих контейнеров. В самом начале, ты должен указать их количество.");
            Console.WriteLine("Следующим параметром, который тебе нужно указать - это фиксированная плата за хранение каждого контейнера.");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Файл с информацией о складе должен содержать две строки.");
            Console.ResetColor();
            Console.WriteLine("В первой строке должно находится значение вместимости (от 1 до 10000) склада в виде \"Size = *value*\".");
            Console.WriteLine("Во второй строке должно находится значение платы (от 0.01 до 10000) за хранение контейнера на складе в виде \"Price = *value*\".");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Пример:");
            Console.ResetColor();
            Console.WriteLine("Size = 123");
            Console.WriteLine("Price = 32,12");
            Console.WriteLine();
        }

        // Текст при вводе информации о контейнерах и их содержимом с файла.

        static void ContainersInputText()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Овощной склад ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("На данном этапе вам нужно передать информацию о всех контейнерах, которые будут помещены на склад.");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Файл с информацией о контейнерах (для каждого n-ого контейнера) должен быть сформирован по следующей структуре:");
            Console.ResetColor();
            Console.WriteLine("При добавлении каждого нового контейнера вводится ключевое слово \"Container *tag*\".");
            Console.WriteLine("Далее вводится команда \"Boxes = *value*\". Value от 1 до 1000 - это количество ящиков в контейнере.");
            Console.WriteLine("С новой строки вводим вес ящиков (от 0.01 до 1000), а на следующей стоимость овощей за килограмм (от 0.01 до 10000).");
            Console.WriteLine("Ввод веса ящиков и стоимость овощей за киллограм продолжается до того момента, пока не будут заполнена информация обо всех ящиках.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Пример:");
            Console.ResetColor();
            Console.WriteLine("Container 123");
            Console.WriteLine("Boxes = 2");
            Console.WriteLine("12");
            Console.WriteLine("2");
            Console.WriteLine("20");
            Console.WriteLine("1");
            Console.WriteLine("Container 231");
            Console.WriteLine("Boxes = 1");
            Console.WriteLine("3");
            Console.WriteLine("10");
        }

        // Текст при вводе действий с контейнерами с файла.

        static void MovesInputText()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Овощной склад ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("На данном этапе вам нужно передать информацию о всех действиях с контейнерами, которые вы хотите произвести.");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Если вы не хотите использовать файлы на данном этапе, вы можете пропустить данное действие, введя цифру \"0\" в консоль.");
            Console.WriteLine("На следующем шаге вы получите полный доступ к складу и его контейнерам и сможете выполнить операции с ними!");
            Console.WriteLine("Если вы захотите добавить контейнер на данном шаге, то под него будет зарезервировано место на складе, но содержимое вы заполните позже.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Данные в файле должны быть сформированы в следующем формате:");
            Console.ResetColor();
            Console.WriteLine("Ключевые команды - создать контейнер \"CreateContainer *tag*\" и удалить существующий \"DeleteContainer *value*\"");
            Console.WriteLine("Длина тега должна быть от 1 до 8 символов. При удалении контейнера нужно указать его номер от 1 до n.");
            Console.WriteLine("Каждая команда пишется с новой строки в файле.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Пример:");
            Console.ResetColor();
            Console.WriteLine("CreateContainer MyContainer");
            Console.WriteLine("DeleteContainer 1");
        }
    }
}
