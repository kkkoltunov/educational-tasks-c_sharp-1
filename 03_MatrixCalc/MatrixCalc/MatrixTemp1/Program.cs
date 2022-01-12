using System;

namespace MatrixTemp1
{
    class Program
    {
        static double[][] MatrixCreate(int rows, int cols)
        {
            double[][] result = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                result[i] = new double[cols]; 
            }

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    result[i][j] = Convert.ToDouble(Console.ReadLine());
                }
                Console.WriteLine();
            }

            return result;
        }

        static double[][] MatrixDecompose(double[][] matrix, out int toggle)
        {
            double[][] result = matrix;

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

                    toggle = -toggle;
                }

                if (Math.Abs(result[j][j]) < 1.0E-20)
                {
                    return null;
                }

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
            double[][] lum = MatrixDecompose(matrix, out toggle);

            if (lum == null)
            {
                throw new ArgumentException("Невозможно вычислить дискриминант, скорее всего он равен 0.");
            }

            double result = toggle;

            for (int i = 0; i < lum.Length; i++)
            {
                result *= lum[i][i];
            }

            return result;
        }
        static void Main(string[] args)
        {
            int rows = 3; // строка
            int cols = 3; // столбец

            double[][] matrix = MatrixCreate(rows, cols);

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }

            double det = Math.Round(MatrixDeterminant(matrix));

            Console.WriteLine();
            Console.WriteLine(det);
        }
    }
}
