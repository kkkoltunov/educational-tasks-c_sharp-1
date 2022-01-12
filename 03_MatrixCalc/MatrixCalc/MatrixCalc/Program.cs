using System;

namespace MatrixCalc
{
    partial class Program
    {
        static bool flagStart = true;
        static void Main()
        {
            if (flagStart == true)
            {
                Console.WriteLine("Приветствую Вас в матричном калькуляторе! Настоятельно рекомендую ознакомиться с пунктом [9], а также открыть консоль на весь экран!");
                flagStart = false;
            }

            // Текст приветствия.

            TextWelcom();

            // Текущий номер команды.

            int numberComand;

            // Флаг нахождения в команде.

            bool flagInputComand = false;

            try
            {
                do
                {
                    Console.Write(Environment.NewLine);
                    Console.Write("Введите номер желаемой команды: ");
                    if (!int.TryParse(Console.ReadLine(), out numberComand) || (numberComand < 0 || numberComand > 9))
                    {
                        Console.Write(Environment.NewLine);
                        Console.WriteLine("Некорректный ввод, пожалуйста, повторите попытку!");
                    }

                    else
                    {
                        switch (numberComand)
                        {
                            case 0:
                                ProgramExit();
                                break;
                            case 1:
                                MatrixTrace();
                                break;
                            case 2:
                                MatrixTransposed();
                                break;
                            case 3:
                                MatrixMultNum();
                                break;
                            case 4:
                                MatrixDeterminant();
                                break;
                            case 5:
                                MatrixSum();
                                break;
                            case 6:
                                MatrixSubstraction();
                                break;
                            case 7:
                                MatrixMult();
                                break;
                            case 8:
                                MatrixGayss();
                                break;
                            case 9:
                                TextHelp();
                                break;
                        }
                    }

                } while (flagInputComand == false);
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
        
        // Выход из программы.

        static void ProgramExit()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("До скорых встреч!");
            Environment.Exit(0);
        }

        // Вывод матрицы на экран.

        static void MatrixPrint(int[,] arrayMatrix)
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("Исходная матрица:");
            Console.Write(Environment.NewLine);

            for (int i = 0; i < arrayMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < arrayMatrix.GetLength(1); j++)
                {
                    Console.Write($"{arrayMatrix[i, j].ToString().PadLeft(10)}");
                }
                Console.WriteLine();
            }
        }
    }
}
