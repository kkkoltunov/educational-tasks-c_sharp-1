using System;
using System.Data;

namespace Gauss_Jordan_Method
{
    class Maths
    {
        /// <summary>
        /// Метод Гаусса-Жордана (Обратная матрица)
        /// </summary>
        /// <param name="Matrix">Начальная матрица</param>
        /// <returns></returns>
        public static double[,] GaussJordan(double[,] Matrix)
        {
            int n = Matrix.GetLength(0); //Размерность начальной матрицы

            double[,] xirtaM = new double[n, n]; //Единичная матрица (искомая обратная матрица)
            for (int i = 0; i < n; i++)
                xirtaM[i, i] = 1;

            double[,] Matrix_Big = new double[n, 2 * n]; //Общая матрица, получаемая скреплением Начальной матрицы и единичной
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matrix_Big[i, j] = Matrix[i, j];
                    Matrix_Big[i, j + n] = xirtaM[i, j];
                }

            //Прямой ход (Зануление нижнего левого угла)
            for (int k = 0; k < n; k++) //k-номер строки
            {
                for (int i = 0; i < 2 * n; i++) //i-номер столбца
                    Matrix_Big[k, i] = Matrix_Big[k, i] / Matrix[k, k]; //Деление k-строки на первый член !=0 для преобразования его в единицу
                for (int i = k + 1; i < n; i++) //i-номер следующей строки после k
                {
                    double K = Matrix_Big[i, k] / Matrix_Big[k, k]; //Коэффициент
                    for (int j = 0; j < 2 * n; j++) //j-номер столбца следующей строки после k
                        Matrix_Big[i, j] = Matrix_Big[i, j] - Matrix_Big[k, j] * K; //Зануление элементов матрицы ниже первого члена, преобразованного в единицу
                }
                for (int i = 0; i < n; i++) //Обновление, внесение изменений в начальную матрицу
                    for (int j = 0; j < n; j++)
                        Matrix[i, j] = Matrix_Big[i, j];
            }

            //Обратный ход (Зануление верхнего правого угла)
            for (int k = n - 1; k > -1; k--) //k-номер строки
            {
                for (int i = 2 * n - 1; i > -1; i--) //i-номер столбца
                    Matrix_Big[k, i] = Matrix_Big[k, i] / Matrix[k, k];
                for (int i = k - 1; i > -1; i--) //i-номер следующей строки после k
                {
                    double K = Matrix_Big[i, k] / Matrix_Big[k, k];
                    for (int j = 2 * n - 1; j > -1; j--) //j-номер столбца следующей строки после k
                        Matrix_Big[i, j] = Matrix_Big[i, j] - Matrix_Big[k, j] * K;
                }
            }

            //Отделяем от общей матрицы
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    xirtaM[i, j] = Matrix_Big[i, j + n];

            return xirtaM;
        }

        static void Main()
        {
            int rows = 3;
            int cols = 3;
            double[,] matrix = new double[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                }
                Console.WriteLine();
            }

            matrix = GaussJordan(matrix);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}