using System;

namespace MatrixCalc
{
    partial class Program
    {
        static double[][] MatrixCreate(int rows, int cols)
        {
            // Создаем матрицу, полностью инициализированную значениями 0.0.

            double[][] result = new double[rows][];
            for (int i = 0; i < rows; i++)
            {
                result[i] = new double[cols];
            }

            // Заполнение элементов матрицы с клавиатуры.

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    Console.Write($"Введите {j + 1} элемент {i + 1} строки матрицы: ");

                    string tempInput = Console.ReadLine();

                    string[] tempInputSplit = tempInput.Split(' ');

                    if (tempInputSplit.Length != 1)
                    {
                        throw new ArgumentException("Введено неверное число!");
                    }

                    double.TryParse(tempInputSplit[0], out result[i][j]);
                }
                Console.WriteLine();
            }

            return result;
        }

        // LUP разложение матрицы.

        static double[][] MatrixDecompose(double[][] matrix, out int[] perm, out int toggle)
        {
            double[][] result = matrix;

            perm = new int[matrix.Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                perm[i] = i;
            }

            // Знак (+/-).

            toggle = 1;

            // Основной цикл по столбцу j.

            for (int j = 0; j < matrix.Length - 1; j++)
            {
                // Поиск наибольшего значения в столбце j.

                double colMax = Math.Abs(result[j][j]); 

                int pRow = j;

                for (int i = j + 1; i < matrix.Length; i++)
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

                    // Меняем информацию о перестановке.

                    int tmp = perm[pRow];

                    perm[pRow] = perm[j];

                    perm[j] = tmp;

                    // Переключатель перестановки строк (+/-).

                    toggle = -toggle; 
                }

                // Проверка значения.

                if (Math.Abs(result[j][j]) < 1.0E-20)
                    return null;

                // Перестановка элементов матрицы.

                for (int i = j + 1; i < matrix.Length; i++)
                {
                    result[i][j] /= result[j][j];

                    for (int k = j + 1; k < matrix.Length; k++)
                    {
                        result[i][k] -= result[i][j] * result[j][k];
                    }
                }
            }

            // Возврат переставленной матрицы LU.

            return result;
        }

        // Решение LUP * X = b.

        static double[] HelperSolve(double[][] luMatrix, double[] b)
        {
            double[] x = new double[luMatrix.Length];

            // Инициалщиация столбца свободных коэффициентов.

            b.CopyTo(x, 0);

            // Прямая подстановка в нижней части матрицы LU.

            for (int i = 1; i < luMatrix.Length; i++)
            {
                double sum = x[i];

                for (int j = 0; j < i; j++)
                {
                    sum -= luMatrix[i][j] * x[j];
                }

                x[i] = sum;
            }

            x[luMatrix.Length - 1] /= luMatrix[luMatrix.Length - 1][luMatrix.Length - 1];

            // Обратная подстановка в верхней части матрицы LU.

            for (int i = luMatrix.Length - 2; i >= 0; i--)
            {
                double sum = x[i];

                for (int j = i + 1; j < luMatrix.Length; j++)
                {
                    sum -= luMatrix[i][j] * x[j];
                }

                x[i] = sum / luMatrix[i][i];
            }
            return x;
        }

        // Решение A * X = b.

        static double[] SystemSolve(double[][] A, double[] b)
        {
            int[] perm;

            int toggle;

            // Получение LU матрицы.

            double[][] luMatrix = MatrixDecompose(A, out perm, out toggle);

            // Проверка на возможность решения.

            if (luMatrix == null)
            {
                throw new ArgumentException("Невозможно найти решение системы. Причины: присутствую свободные коэффициенты, нет общего решения.");
            }

            double[] bp = new double[b.Length];

            // Замена элементов матрицы.

            for (int i = 0; i < A.Length; i++)
            {
                bp[i] = b[perm[i]];
            }

            // Решение измененной матрицы.

            double[] x = HelperSolve(luMatrix, bp);

            return x;
        }

        // Ввод значений.

        static void GayssInput()
        {
            // Строки матрицы.

            int rows;
            
            // Столбцы матрицы.

            int cols;

            // Массив столбца свободных членов.

            double[] system = new double[0];

            // Переменная для проверки корректности вывода.

            double tempNum;

            // Замечание для пользователя.

            Console.Write(Environment.NewLine);
            Console.WriteLine("Обратите внимание! Для выполнения данной операция матрица должна быть квадратной!");
            Console.Write(Environment.NewLine);
            do
            {
                Console.Write("Введите количество строк матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out rows) || rows < 1 || rows > 30);

            do
            {
                Console.Write("Введите количество столбцов матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out cols) || cols < 1 || cols > 30 || cols != rows);

            Console.WriteLine();
            Console.WriteLine("Сначала Вам нужно ввести элементы основной матрицы системы, а затем столбец свободных членов.");
            Console.WriteLine();

            double[][] matrix = MatrixCreate(rows, cols);

            // Создание столбца свободных членов.

            double[] b = new double[cols];

            // Ввод данных с клавиатуры.

            for (int i = 0; i < b.Length; i++)
            {
                Console.Write($"Введите {i + 1} элемент столбца свободных членов: ");
                string tempInput = Console.ReadLine();

                string[] tempInputSplit = tempInput.Split(' ');

                if (tempInputSplit.Length != 1)
                {
                    throw new ArgumentException("Введено неверное число!");
                }

                double.TryParse(tempInputSplit[0], out b[i]);
            }

            // Вывод результата ввода.

            Console.WriteLine();
            Console.WriteLine("Исходная матрица со столбцом свободных членов:");
            Console.WriteLine();

            try
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        Console.Write($"{matrix[i][j].ToString().PadLeft(10)}");
                    }

                    Console.Write($"{b[i].ToString().PadLeft(10)}");
                    Console.WriteLine();
                }
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

            // Решение системы.

            try
            {
                system = SystemSolve(matrix, b);
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

            try
            {
                for (int i = 0; i < system.Length; i++)
                {
                    string temp = system[i].ToString();

                    if (double.TryParse(temp, out tempNum))
                    {
                        throw new ArgumentException("Невозможно найти решение системы. Причины: присутствую свободные коэффициенты, нет общего решения.");
                    }
                }
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

            // Вывод результата на экран.

            Console.WriteLine();
            Console.WriteLine("Результат вычисления:");
            Console.WriteLine();

            try
            {
                for (int i = 0; i < system.Length; i++)
                {
                    Console.WriteLine($"X{i + 1} = {system[i]:f2}");
                }
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
    }
}
