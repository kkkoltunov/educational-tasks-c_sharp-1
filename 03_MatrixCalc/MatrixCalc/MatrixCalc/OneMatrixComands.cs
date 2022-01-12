using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixCalc
{
    partial class Program
    {
        // Поиск следа матрицы.

        static void MatrixTrace()
        {
            // Проверка матрицы (квадратная или нет).

            bool flagSquare = true;

            // Переменная для подсчета следа матрицы.

            int trace = 0;

            // Создание пустого массива.

            int[,] arrayMatrix = new int[0, 0];

            // Информация о возможностях ввода данных.

            TextOneMatrixInput();

            // Полезное замечание для пользователя.

            Console.Write(Environment.NewLine);
            Console.WriteLine("Обратите внимание! Для выполнения данной операция матрица должна быть квадратной!");

            // Получение номера команды от пользователя.

            int numberComand = MatrixInputComand();

            // Выход из программы.

            if (numberComand == 0)
            {
                ProgramExit();
            }

            // Генерация данных случайным образом.

            else if (numberComand == 1)
            {
                MatrixInputRandom(out arrayMatrix, flagSquare);
            }

            // Чтение данных из файла.

            else if (numberComand == 2)
            {
                try
                {
                    MatrixInputFile(out arrayMatrix, flagSquare);
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
                    MatrixInputUser(out arrayMatrix, flagSquare);
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

            // Вывод на экран сгенерированной матрицы.

            MatrixPrint(arrayMatrix);

            // Подсчет следа.

            for (int i = 0; i < arrayMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < arrayMatrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        trace += arrayMatrix[i, j];
                    }
                }
            }

            // Проверка результата подсчета.

            if (trace == 0)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("Данная матрица является бесследовой!");
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine($"След матрицы = {trace}");
            }

            Console.Write(Environment.NewLine);
            Console.Write("Для продолжения нажмите клавишу!");
            Console.ReadKey();
            Console.Clear();

            Main();
        }

        // Поиск транспонированной матрицы.

        static void MatrixTransposed()
        {
            // Проверка матрицы (квадратная или нет).

            bool flagSquare = false;

            // Создание пустого массива.

            int[,] arrayMatrix = new int[0, 0];

            // Информация о возможностях ввода данных.

            TextOneMatrixInput();

            // Получение номера команды от пользователя.

            int numberComand = MatrixInputComand();

            if (numberComand == 0)
            {
                ProgramExit();
            }
            else if (numberComand == 1)
            {
                MatrixInputRandom(out arrayMatrix, flagSquare);
            }
            else if (numberComand == 2)
            {
                try
                {
                    MatrixInputFile(out arrayMatrix, flagSquare);
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
                    MatrixInputUser(out arrayMatrix, flagSquare);
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

            // Вывод на экран сгенерированной матрицы.

            MatrixPrint(arrayMatrix);

            // Вывод транспонированной матрицы.

            Console.Write(Environment.NewLine);
            Console.WriteLine("Транспонированная матрица:");
            Console.Write(Environment.NewLine);

            for (int i = 0; i < arrayMatrix.GetLength(1); i++)
            {
                for (int j = 0; j < arrayMatrix.GetLength(0); j++)
                {
                    Console.Write($"{arrayMatrix[j, i].ToString().PadLeft(10)}");
                }
                Console.WriteLine();
            }

            Console.Write(Environment.NewLine);
            Console.Write("Для продолжения нажмите любую клавишу!");
            Console.ReadKey();
            Console.Clear();

            Main();
        }

        // Умножение матрицы на число.

        static void MatrixMultNum()
        {
            // Проверка матрицы (квадратная или нет).

            bool flagSquare = false;

            // Создание пустого массива.

            int[,] arrayMatrix = new int[0, 0];

            int number = 0;

            // Информация о возможностях ввода данных.

            TextOneMatrixInput();

            // Получение номера команды от пользователя.

            int numberComand = MatrixInputComand();

            if (numberComand == 0)
            {
                ProgramExit();
            }
            else if (numberComand == 1)
            {
                MatrixInputRandomMult(out arrayMatrix, out number, flagSquare);
            }
            else if (numberComand == 2)
            {
                try
                {
                    MatrixInputFileMult(out arrayMatrix, flagSquare, out number);
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
                    MatrixInputUserMult(out arrayMatrix, flagSquare, out number);
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

            // Вывод на экран сгенерированной матрицы.

            MatrixPrint(arrayMatrix);

            // Умножение матрица на число.

            Console.Write(Environment.NewLine);
            Console.WriteLine("Результирующая матрица:");
            Console.Write(Environment.NewLine);

            for (int i = 0; i < arrayMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < arrayMatrix.GetLength(1); j++)
                {
                    arrayMatrix[i, j] = arrayMatrix[i, j] * number;
                }
            }

            // Вывод матрицы умноженной на число.

            for (int i = 0; i < arrayMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < arrayMatrix.GetLength(1); j++)
                {
                    Console.Write($"{arrayMatrix[i, j].ToString().PadLeft(10)}");
                }
                Console.WriteLine();
            }

            Console.Write(Environment.NewLine);
            Console.Write("Для продолжения нажмите любую клавишу!");
            Console.ReadKey();
            Console.Clear();

            Main();
        }

        // Решение СЛАУ методом Гаусса.

        static void MatrixGayss()
        {
            try
            {
                GayssInput();
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

            Console.Write(Environment.NewLine);
            Console.Write("Для продолжения нажмите любую клавишу!");
            Console.ReadKey();
            Console.Clear();

            Main();
        }

        static void MatrixDeterminant()
        {
            // Проверка матрицы (квадратная или нет).

            bool flagSquare = true;

            // Создание пустого массива.

            int[,] arrayMatrix = new int[0, 0];

            // Определитель.

            double determinant = 0;

            // Информация о возможностях ввода данных.

            TextOneMatrixInput();

            // Полезное замечание для пользователя.

            Console.Write(Environment.NewLine);
            Console.WriteLine("Обратите внимание! Для выполнения данной операция матрица должна быть квадратной!");

            // Получение номера команды от пользователя.

            int numberComand = MatrixInputComand();

            if (numberComand == 0)
            {
                ProgramExit();
            }
            else if (numberComand == 1)
            {
                MatrixInputRandom(out arrayMatrix, flagSquare);
            }
            else if (numberComand == 2)
            {
                try
                {
                    MatrixInputFile(out arrayMatrix, flagSquare);
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
                    MatrixInputUser(out arrayMatrix, flagSquare);
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

            // Вывод на экран сгенерированной матрицы.

            MatrixPrint(arrayMatrix);

            // Создание двумерного массива, путем записывания данных из зубчатого.

            double[][] arrayMatrixResult = new double[arrayMatrix.GetLength(0)][];

            for (int i = 0; i < arrayMatrixResult.Length; i++)
            {
                arrayMatrixResult[i] = new double[arrayMatrix.GetLength(1)];

                for (int j = 0; j < arrayMatrixResult[i].Length; j++)
                {
                    arrayMatrixResult[i][j] = arrayMatrix[i, j];
                }
            }

            // Подсчет определителя.

            try
            {
                determinant = Math.Round(MatrixDeterminant(arrayMatrixResult));
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

            // Проверка результата подсчета.

            if (determinant == 0)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("Определитель равен 0!");
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine($"Определитель матрицы = {determinant}");
            }

            Console.Write(Environment.NewLine);
            Console.Write("Для продолжения нажмите любую клавишу!");
            Console.ReadKey();
            Console.Clear();

            Main();
        }

        // Нахождение верхнетреугольной матрицы.

        static double[][] MatrixDecompose(double[][] matrix, out int toggle)
        {
            double[][] result = matrix;

            // Знак (+/-).

            toggle = 1;

            // Основной цикл по столбцу j.

            for (int j = 0; j < matrix.Length - 1; ++j)
            {
                // Наибольшее значение в столбце j.

                double colMax = Math.Abs(result[j][j]);

                int pRow = j;

                for (int i = j + 1; i < matrix.Length; ++i)
                {
                    if (result[i][j] > colMax)
                    {
                        colMax = result[i][j];
                        pRow = i;
                    }
                }

                // Перестановка строк.

                if (pRow != j)
                {
                    double[] rowPtr = result[pRow];

                    result[pRow] = result[j];

                    result[j] = rowPtr;

                    // Переключатель перестановки строк (+/-).

                    toggle = -toggle;
                }

                // Проверка значения.

                if (Math.Abs(result[j][j]) < 1.0E-20)
                {
                    return null;
                }

                // Перестановка элементов матрицы.

                for (int i = j + 1; i < matrix.Length; ++i)
                {
                    result[i][j] /= result[j][j];

                    for (int k = j + 1; k < matrix.Length; ++k)
                    {
                        result[i][k] -= result[i][j] * result[j][k];
                    }
                }
            }

            return result;
        }

        static double MatrixDeterminant(double[][] matrix)
        {
            int toggle;

            // Получение верхнетреугольной матрицы.

            double[][] lum = MatrixDecompose(matrix, out toggle);

            // Проверка данных.

            if (lum == null)
            {
                throw new ArgumentException("Определитель равен 0.");
            }

            // Знак определителя.

            double result = toggle;

            // Перемножение элементов на главной диагонали.

            for (int i = 0; i < lum.Length; i++)
            {
                result *= lum[i][i];
            }

            return result;
        }
    }
}
