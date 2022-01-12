using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixCalc
{
    partial class Program
    {
        // Сумма двух матриц.

        static void MatrixSum()
        {
            // Массив двух матриц.

            int[,] arrayMatrixFirst = new int[0, 0];
            int[,] arrayMatrixSecond = new int[0, 0];

            // Вспомогательный текст.

            TextTwoMatrixInput();

            // Полезное замечание для пользователя.

            Console.Write(Environment.NewLine);
            Console.WriteLine("Обратите внимание! Для выполнения данной операции количество строк и стоблцов в матрицах должно совпадать!");

            // Получение номера команды от пользователя.

            int numberComand = MatrixInputComand();

            // Выход из программы.

            if (numberComand == 0)
            {
                ProgramExit();
            }

            // Генерация данных случайным образом по введенным данным от пользователя.

            else if (numberComand == 1)
            {
                TwoMatrixInputRandom(out arrayMatrixFirst, out arrayMatrixSecond);
            }

            // Чтение данных из файла.

            else if (numberComand == 2)
            {
                try
                {
                    TwoMatrixInputFile(out arrayMatrixFirst, out arrayMatrixSecond);
                }
                catch (Exception ex)
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine($"К сожалению произошла ошибка: {ex.Message}");
                    Console.Write(Environment.NewLine);
                    Console.Write("Для продолжения нажмите любую клавишу!");
                    Console.ReadKey();
                    Console.Clear();

                    Main();
                }
            }

            // Ввод данных с клавиатуры.

            else if (numberComand == 3)
            {
                try
                {
                    TwoMatrixInputUser(out arrayMatrixFirst, out arrayMatrixSecond);
                }
                catch (Exception ex)
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine($"К сожалению произошла ошибка: {ex.Message}");
                    Console.Write(Environment.NewLine);
                    Console.Write("Для продолжения нажмите любую клавишу!");
                    Console.ReadKey();
                    Console.Clear();

                    Main();
                }
            }

            // Вывод на экран сгенерированных матриц.

            MatrixPrint(arrayMatrixFirst);

            MatrixPrint(arrayMatrixSecond);

            Console.Write(Environment.NewLine);
            Console.WriteLine("Результат сложения матриц:");
            Console.Write(Environment.NewLine);

            // Вывод результата сложения на экран.

            for (int i = 0; i < arrayMatrixFirst.GetLength(0); i++)
            {
                for (int j = 0; j < arrayMatrixFirst.GetLength(1); j++)
                {
                    Console.Write($"{(arrayMatrixFirst[i, j] + arrayMatrixSecond[i, j]).ToString().PadLeft(10)}");
                }
                Console.WriteLine();
            }

            Console.Write(Environment.NewLine);
            Console.Write("Для продолжения нажмите любую клавишу!");
            Console.ReadKey();
            Console.Clear();

            Main();
        }

        // Вычитание двух матриц.

        static void MatrixSubstraction()
        {
            // Массив двух матриц.

            int[,] arrayMatrixFirst = new int[0, 0];
            int[,] arrayMatrixSecond = new int[0, 0];

            // Вспомогательный текст.

            TextTwoMatrixInput();

            // Полезное замечание для пользователя.

            Console.Write(Environment.NewLine);
            Console.WriteLine("Обратите внимание! Для выполнения данной операции количество строк и стоблцов в матрицах должны совпадать!");

            int numberComand = MatrixInputComand();

            if (numberComand == 0)
            {
                ProgramExit();
            }
            else if (numberComand == 1)
            {
                TwoMatrixInputRandom(out arrayMatrixFirst, out arrayMatrixSecond);
            }
            else if (numberComand == 2)
            {
                try
                {
                    TwoMatrixInputFile(out arrayMatrixFirst, out arrayMatrixSecond);
                }
                catch (Exception ex)
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine($"К сожалению произошла ошибка: {ex.Message}");
                    Console.Write(Environment.NewLine);
                    Console.Write("Для продолжения нажмите любую клавишу!");
                    Console.ReadKey();
                    Console.Clear();

                    Main();
                }
            }
            else if (numberComand == 3)
            {
                try
                {
                    TwoMatrixInputUser(out arrayMatrixFirst, out arrayMatrixSecond);
                }
                catch (Exception ex)
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine($"К сожалению произошла ошибка: {ex.Message}");
                    Console.Write(Environment.NewLine);
                    Console.Write("Для продолжения нажмите любую клавишу!");
                    Console.ReadKey();
                    Console.Clear();

                    Main();
                }
            }

            // Вывод на экран сгенерированных матриц.

            MatrixPrint(arrayMatrixFirst);

            MatrixPrint(arrayMatrixSecond);

            Console.Write(Environment.NewLine);
            Console.WriteLine("Результат вычитания матриц:");
            Console.Write(Environment.NewLine);

            // Вывод результата вычитания.

            for (int i = 0; i < arrayMatrixFirst.GetLength(0); i++)
            {
                for (int j = 0; j < arrayMatrixFirst.GetLength(1); j++)
                {
                    Console.Write($"{(arrayMatrixFirst[i, j] - arrayMatrixSecond[i, j]).ToString().PadLeft(10)}");
                }
                Console.WriteLine();
            }

            Console.Write(Environment.NewLine);
            Console.Write("Для продолжения нажмите любую клавишу!");
            Console.ReadKey();
            Console.Clear();

            Main();
        }

        // Перемножение двух матриц.

        static void MatrixMult()
        {
            // Массив двух матриц.

            int[,] arrayMatrixFirst = new int[0, 0];
            int[,] arrayMatrixSecond = new int[0, 0];

            // Вспомогательный текст.

            TextTwoMatrixInput();

            // Полезное замечание для пользователя.

            Console.Write(Environment.NewLine);
            Console.WriteLine("Обратите внимание! Для выполнения данной операции количество столбцов первой матрицы и количество строк второй матрицы должны совпадать!");

            int numberComand = MatrixInputComand();

            if (numberComand == 0)
            {
                ProgramExit();
            }
            else if (numberComand == 1)
            {
                TwoMatrixInputRandomMult(out arrayMatrixFirst, out arrayMatrixSecond);
            }
            else if (numberComand == 2)
            {
                try
                {
                    TwoMatrixInputFileMult(out arrayMatrixFirst, out arrayMatrixSecond);
                }
                catch (Exception ex)
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine($"К сожалению произошла ошибка: {ex.Message}");
                    Console.Write(Environment.NewLine);
                    Console.Write("Для продолжения нажмите любую клавишу!");
                    Console.ReadKey();
                    Console.Clear();

                    Main();
                }
            }
            else if (numberComand == 3)
            {
                try
                {
                    TwoMatrixInputUserMult(out arrayMatrixFirst, out arrayMatrixSecond);
                }
                catch (Exception ex)
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine($"К сожалению произошла ошибка: {ex.Message}");
                    Console.Write(Environment.NewLine);
                    Console.Write("Для продолжения нажмите любую клавишу!");
                    Console.ReadKey();
                    Console.Clear();

                    Main();
                }
            }

            // Вывод на экран сгенерированных матриц.

            MatrixPrint(arrayMatrixFirst);

            MatrixPrint(arrayMatrixSecond);

            // Перемножение матриц.

            int[,] arrayMatrixResult = new int[arrayMatrixFirst.GetLength(0), arrayMatrixSecond.GetLength(1)];

            for (int i = 0; i < arrayMatrixFirst.GetLength(0); i++)
            {
                for (int j = 0; j < arrayMatrixSecond.GetLength(1); j++)
                {
                    for (int k = 0; k < arrayMatrixSecond.GetLength(0); k++)
                    {
                        arrayMatrixResult[i, j] += arrayMatrixFirst[i, k] * arrayMatrixSecond[k, j];
                    }
                }
            }

            // Вывод результата.

            Console.Write(Environment.NewLine);
            Console.WriteLine("Результат перемножения матриц:");
            Console.Write(Environment.NewLine);

            for (int i = 0; i < arrayMatrixResult.GetLength(0); i++)
            {
                for (int j = 0; j < arrayMatrixResult.GetLength(1); j++)
                {
                    Console.Write($"{arrayMatrixResult[i, j].ToString().PadLeft(10)}");
                }
                Console.WriteLine();
            }

            Console.Write(Environment.NewLine);
            Console.Write("Для продолжения нажмите любую клавишу!");
            Console.ReadKey();
            Console.Clear();

            Main();
        }
    }
}
