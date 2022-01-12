using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixCalc
{
    partial class Program
    {
        // Доступные операции матричного калькулятора.

        static void TextWelcom()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Доступные операций для выполнения с одной матрицей:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[1] Нахождение следа матрицы.");
            Console.WriteLine("[2] Транспонирование матрицы.");
            Console.WriteLine("[3] Умножение матрицы на число.");
            Console.WriteLine("[4] Нахождение определителя матрицы.");
            Console.ResetColor();
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Доступные операций для выполнения с двумя матрицами:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[5] Сумма двух матриц.");
            Console.WriteLine("[6] Разность двух матриц.");
            Console.WriteLine("[7] Произведение двух матриц.");
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Решение СЛАУ:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[8] Решение СЛАУ методом Гаусса.");
            Console.Write(Environment.NewLine);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("[9] Тонкости в работе с программой.");
            Console.Write(Environment.NewLine);
            Console.WriteLine("[0] Выход из программы.");
            Console.ResetColor();
        }

        // Доступный ввод данных для одной матрицы.

        static void TextOneMatrixInput()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("На данном этапе Вам нужно выбрать подходящий вариант ввода данных:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(Environment.NewLine);
            Console.WriteLine("[1] Генерация матрицы случайным образом по введенным Вами данными.");
            Console.WriteLine("[2] Считывание данных о матрице из файла.");
            Console.WriteLine("[3] Ввод данных вручную с клавиатуры.");
            Console.Write(Environment.NewLine);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("[0] Выход из программы.");
            Console.ResetColor();
        }

        // Доступный ввод данных для двух матриц.
        static void TextTwoMatrixInput()
        {
            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("На данном этапе Вам нужно выбрать подходящий вариант ввода данных:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(Environment.NewLine);
            Console.WriteLine("[1] Генерация матриц случайным образом по введенным Вами данными.");
            Console.WriteLine("[2] Считывание данных о матрицах из файла.");
            Console.WriteLine("[3] Ввод данных вручную с клавиатуры.");
            Console.Write(Environment.NewLine);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("[0] Выход из программы.");
            Console.ResetColor();
        }

        // Текст для команды "Тонкости работы с программой".

        static void TextHelp()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("В программе установлены ограничения на ввод данных с клавиатуры и на генерацию данных случайным образом.");
            Console.WriteLine(" - Если Вам нужно выполнить операции с данными, которые больше установленных лимитов, используйте ввод данных с помощью файла!");
            Console.WriteLine(" - Матричный калькулятор работает с целочисленным типом данных, но в решении СЛАУ используется вещественный тип.");
            Console.WriteLine(" - В программе гарантируется \"красивый\" вывод матрицы только если длина ее чисел не превосходит 9 символов!");
            Console.WriteLine(" - Ведущие нули не учитываются при вводе с клавиатуры.");
            Console.WriteLine(" - Корректная работы программы гарантируется при вводе с клавиатуры и файла, если размер матрицы до 10х10 и ее элементы в диапазоне [-1000, 1000].");
            Console.WriteLine("Примечание: ограничения установлены согласно QnA.");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Удачи в работе!");
        }
    }
}
