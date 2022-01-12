using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MatrixCalc
{
    partial class Program
    {
        // Генерация данных матриц случайным образом по введенным пользователем данным.

        static void TwoMatrixInputRandom(out int[,] arrayMatrixFirst, out int[,] arrayMatrixSecond)
        {
            // Строки и столбцы первой матрицы.

            int stringMatrixFirst;
            int columnMatrixFirst;

            // Строки и столбцы второй матрицы.

            int stringMatrixSecond;
            int columnMatrixSecond;

            // Минимальное и максимальное значение для первой матрицы.

            int minRandomFirst;
            int maxRandomFirst;

            // Минимальное и максимальное значение для второй матрицы.

            int minRandomSecond;
            int maxRandomSecond;

            // Заполнение данных первой матрицы.

            Console.Write(Environment.NewLine);
            do
            {
                Console.Write("Введите количество строк первой матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out stringMatrixFirst) || stringMatrixFirst < 1 || stringMatrixFirst > 30);

            do
            {
                Console.Write("Введите количество столбцов первой матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out columnMatrixFirst) || columnMatrixFirst < 1 || columnMatrixFirst > 30);

            do
            {
                Console.Write("Введите значение, начиная с которого будут генерироваться числа в первой матрице. Диапазон ---> [-100; 100]: ");
            } while (!int.TryParse(Console.ReadLine(), out minRandomFirst) || minRandomFirst < -100 || minRandomFirst > 100);

            do
            {
                Console.Write("Введите значение, до которого будут генерироваться числа в первой матрице. Диапазон ---> [-100; 100]: ");
            } while (!int.TryParse(Console.ReadLine(), out maxRandomFirst) || maxRandomFirst < -100 || maxRandomFirst > 100 || maxRandomFirst < minRandomFirst);

            // Формурование матрицы ввода.

            arrayMatrixFirst = new int[stringMatrixFirst, columnMatrixFirst];

            for (int i = 0; i < stringMatrixFirst; i++)
            {
                for (int j = 0; j < columnMatrixFirst; j++)
                {
                    arrayMatrixFirst[i, j] = rnd.Next(minRandomFirst, maxRandomFirst);
                }
            }

            // Заполнение данных второй матрицы.

            Console.Write(Environment.NewLine);
            do
            {
                Console.Write("Введите количество строк второй матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out stringMatrixSecond) || stringMatrixSecond < 1 || stringMatrixSecond > 30 || stringMatrixFirst != stringMatrixSecond);

            do
            {
                Console.Write("Введите количество столбцов второй матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out columnMatrixSecond) || columnMatrixSecond < 1 || columnMatrixSecond > 30 || columnMatrixFirst != columnMatrixSecond);

            do
            {
                Console.Write("Введите значение, начиная с которого будут генерироваться числа во второй матрице. Диапазон ---> [-100; 100]: ");
            } while (!int.TryParse(Console.ReadLine(), out minRandomSecond) || minRandomSecond < -100 || minRandomSecond > 100);

            do
            {
                Console.Write("Введите значение, до которого будут генерироваться числа во второй матрице. Диапазон ---> [-100; 100]: ");
            } while (!int.TryParse(Console.ReadLine(), out maxRandomSecond) || maxRandomSecond < -100 || maxRandomSecond > 100 || maxRandomSecond < minRandomSecond);

            // Формурование матрицы ввода.

            arrayMatrixSecond = new int[stringMatrixSecond, columnMatrixSecond];

            for (int i = 0; i < stringMatrixSecond; i++)
            {
                for (int j = 0; j < columnMatrixSecond; j++)
                {
                    arrayMatrixSecond[i, j] = rnd.Next(minRandomSecond, maxRandomSecond);
                }
            }
        }

        // Генерация данных матриц случайным образом по введенным пользователем данным для операции умножения.

        static void TwoMatrixInputRandomMult(out int[,] arrayMatrixFirst, out int[,] arrayMatrixSecond)
        {
            // Строки и столбцы первой матрицы.

            int stringMatrixFirst;
            int columnMatrixFirst;

            // Строки и столбцы второй матрицы.

            int stringMatrixSecond;
            int columnMatrixSecond;

            // Минимальное и максимальное значение для первой матрицы.

            int minRandomFirst;
            int maxRandomFirst;

            // Минимальное и максимальное значение для второй матрицы.

            int minRandomSecond;
            int maxRandomSecond;

            // Заполнение данных первой матрицы.

            Console.Write(Environment.NewLine);
            do
            {
                Console.Write("Введите количество строк первой матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out stringMatrixFirst) || stringMatrixFirst < 1 || stringMatrixFirst > 30);

            do
            {
                Console.Write("Введите количество столбцов первой матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out columnMatrixFirst) || columnMatrixFirst < 1 || columnMatrixFirst > 30);

            do
            {
                Console.Write("Введите значение, начиная с которого будут генерироваться числа в первой матрице. Диапазон ---> [-100; 100]: ");
            } while (!int.TryParse(Console.ReadLine(), out minRandomFirst) || minRandomFirst < -100 || minRandomFirst > 100);

            do
            {
                Console.Write("Введите значение, до которого будут генерироваться числа в первой матрице. Диапазон ---> [-100; 100]: ");
            } while (!int.TryParse(Console.ReadLine(), out maxRandomFirst) || maxRandomFirst < -100 || maxRandomFirst > 100 || maxRandomFirst < minRandomFirst);

            // Формурование матрицы ввода.

            arrayMatrixFirst = new int[stringMatrixFirst, columnMatrixFirst];

            for (int i = 0; i < stringMatrixFirst; i++)
            {
                for (int j = 0; j < columnMatrixFirst; j++)
                {
                    arrayMatrixFirst[i, j] = rnd.Next(minRandomFirst, maxRandomFirst);
                }
            }

            // Заполнение данных второй матрицы.

            Console.Write(Environment.NewLine);
            do
            {
                Console.Write("Введите количество строк второй матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out stringMatrixSecond) || stringMatrixSecond < 1 || stringMatrixSecond > 30 || columnMatrixFirst != stringMatrixSecond);

            do
            {
                Console.Write("Введите количество столбцов второй матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out columnMatrixSecond) || columnMatrixSecond < 1 || columnMatrixSecond > 30);

            do
            {
                Console.Write("Введите значение, начиная с которого будут генерироваться числа во второй матрице. Диапазон ---> [-100; 100]: ");
            } while (!int.TryParse(Console.ReadLine(), out minRandomSecond) || minRandomSecond < -100 || minRandomSecond > 100);

            do
            {
                Console.Write("Введите значение, до которого будут генерироваться числа во второй матрице. Диапазон ---> [-100; 100]: ");
            } while (!int.TryParse(Console.ReadLine(), out maxRandomSecond) || maxRandomSecond < -100 || maxRandomSecond > 100 || maxRandomSecond < minRandomSecond);

            // Формурование матрицы ввода.

            arrayMatrixSecond = new int[stringMatrixSecond, columnMatrixSecond];

            for (int i = 0; i < stringMatrixSecond; i++)
            {
                for (int j = 0; j < columnMatrixSecond; j++)
                {
                    arrayMatrixSecond[i, j] = rnd.Next(minRandomSecond, maxRandomSecond);
                }
            }
        }

        // Чтение матриц из файла.

        static void TwoMatrixInputFile(out int[,] arrayMatrixFirst, out int[,] arrayMatrixSecond)
        {
            // Замечание для пользователя.

            Console.Write(Environment.NewLine);
            Console.WriteLine("Обратите внимание, что корректное чтение файла гарантируется только для расширения .txt!");
            Console.WriteLine("В одном файле - данные первой матрицы, во втором файле - данные второй матрицы.");
            Console.WriteLine("В файле вы должны ввести данные исходной матрицы, то есть столбцы и строки.");
            Console.WriteLine("Каждый элемент матрицы вводится через пробел, после матрицы не должно быть пустых строк.");
            Console.Write(Environment.NewLine);

            // Массив для записи данных из файла.

            string[] matrixFile;

            // Путь до файла.

            string inputFile;

            // Первая матрица.

            do
            {
                Console.Write("Укажите полный путь до первого файла, который нужно открыть: ");
                inputFile = Console.ReadLine();

                // Проверка файла на существование.

                if (File.Exists(inputFile))
                {
                    break;
                }

            } while (true);

            // Чтение данных из файла и их запись в массив.

            matrixFile = File.ReadAllLines(inputFile, Encoding.UTF8);

            // Разбиение первой строки по элементам.

            string[] firstLine = matrixFile[0].Split(' ');

            // Подсчет размерности для результирующего массивы

            int lenghtLineFirst = matrixFile.Length;
            int lenghtColumnFirst = firstLine.Length;

            // Формирование матрицы ввода.

            arrayMatrixFirst = new int[lenghtLineFirst, lenghtColumnFirst];

            for (int i = 0; i < matrixFile.Length; i++)
            {
                string temp = matrixFile[i];

                string[] tempMatrixLine = temp.Split(' ');

                if (tempMatrixLine.Length != lenghtColumnFirst)
                {
                    throw new ArgumentException("Введено некорректное количество элементов строки!");
                }

                for (int j = 0; j < tempMatrixLine.Length; j++)
                {
                    arrayMatrixFirst[i, j] = Convert.ToInt32(tempMatrixLine[j]);
                }
            }

            // Вторая матрица.

            do
            {
                Console.Write("Укажите полный путь до второго файла, который нужно открыть: ");
                inputFile = Console.ReadLine();

                // Проверка файла на существование.

                if (File.Exists(inputFile))
                {
                    break;
                }

            } while (true);

            // Чтение данных из файла и их запись в массив.

            matrixFile = File.ReadAllLines(inputFile, Encoding.UTF8);

            // Разбиение первой строки по элементам.

            firstLine = matrixFile[0].Split(' ');

            // Подсчет размерности для результирующего массивы

            int lenghtLineSecond = matrixFile.Length;
            int lenghtColumnSecond = firstLine.Length;

            if (lenghtLineFirst != lenghtLineSecond || lenghtColumnFirst != lenghtColumnSecond)
            {
                throw new ArgumentException("Количество строк и стоблцов в матрицах должно совпадать!");
            }

            // Формирование матрицы ввода.

            arrayMatrixSecond = new int[lenghtLineSecond, lenghtColumnSecond];

            for (int i = 0; i < matrixFile.Length; i++)
            {
                string temp = matrixFile[i];

                string[] tempMatrixLine = temp.Split(' ');

                if (tempMatrixLine.Length != lenghtColumnSecond)
                {
                    throw new ArgumentException("Введено некорректное количество элементов строки!");
                }

                for (int j = 0; j < tempMatrixLine.Length; j++)
                {
                    arrayMatrixSecond[i, j] = Convert.ToInt32(tempMatrixLine[j]);
                }
            }
        }

        // Чтение данных из файла для операции перемножения матриц.

        static void TwoMatrixInputFileMult(out int[,] arrayMatrixFirst, out int[,] arrayMatrixSecond)
        {
            // Замечание для пользователя.

            Console.Write(Environment.NewLine);
            Console.WriteLine("Обратите внимание, что корректное чтение файла гарантируется только для расширения .txt!");
            Console.WriteLine("В одном файле - данные первой матрицы, во втором файле - данные второй матрицы.");
            Console.WriteLine("В файле вы должны ввести данные исходной матрицы, то есть столбцы и строки.");
            Console.WriteLine("Каждый элемент матрицы вводится через пробел, после матрицы не должно быть пустых строк.");
            Console.Write(Environment.NewLine);

            // Массив для записи данных из файла.

            string[] matrixFile;

            // Путь до файла.

            string inputFile;

            // Первая матрица.

            do
            {
                Console.Write("Укажите полный путь до первого файла, который нужно открыть: ");
                inputFile = Console.ReadLine();

                // Проверка файла на существование.

                if (File.Exists(inputFile))
                {
                    break;
                }

            } while (true);

            // Чтение данных из файла и их запись в массив.

            matrixFile = File.ReadAllLines(inputFile, Encoding.UTF8);

            // Разбиение первой строки по элементам.

            string[] firstLine = matrixFile[0].Split(' ');

            // Подсчет размерности для результирующего массивы

            int lenghtLineFirst = matrixFile.Length;
            int lenghtColumnFirst = firstLine.Length;

            // Формирование матрицы ввода.

            arrayMatrixFirst = new int[lenghtLineFirst, lenghtColumnFirst];

            for (int i = 0; i < matrixFile.Length; i++)
            {
                string temp = matrixFile[i];

                string[] tempMatrixLine = temp.Split(' ');

                if (tempMatrixLine.Length != lenghtColumnFirst)
                {
                    throw new ArgumentException("Введено некорректное количество элементов строки!");
                }

                for (int j = 0; j < tempMatrixLine.Length; j++)
                {
                    arrayMatrixFirst[i, j] = Convert.ToInt32(tempMatrixLine[j]);
                }
            }

            // Вторая матрица.

            do
            {
                Console.Write("Укажите полный путь до второго файла, который нужно открыть: ");
                inputFile = Console.ReadLine();

                // Проверка файла на существование.

                if (File.Exists(inputFile))
                {
                    break;
                }

            } while (true);

            // Чтение данных из файла и их запись в массив.

            matrixFile = File.ReadAllLines(inputFile, Encoding.UTF8);

            // Разбиение первой строки по элементам.

            firstLine = matrixFile[0].Split(' ');

            // Подсчет размерности для результирующего массивы

            int lenghtLineSecond = matrixFile.Length;
            int lenghtColumnSecond = firstLine.Length;

            // Исключение.

            if (lenghtColumnFirst != lenghtLineSecond)
            {
                throw new ArgumentException("Количество строк и стоблцов в матрицах должно совпадать!");
            }

            // Формирование матрицы вывода.

            arrayMatrixSecond = new int[lenghtLineSecond, lenghtColumnSecond];

            for (int i = 0; i < matrixFile.Length; i++)
            {
                string temp = matrixFile[i];

                string[] tempMatrixLine = temp.Split(' ');

                if (tempMatrixLine.Length != lenghtColumnSecond)
                {
                    throw new ArgumentException("Введено некорректное количество элементов строки!");
                }

                for (int j = 0; j < tempMatrixLine.Length; j++)
                {
                    arrayMatrixSecond[i, j] = Convert.ToInt32(tempMatrixLine[j]);
                }
            }
        }

        // Ввод матриц с клавиатуры.

        static void TwoMatrixInputUser(out int[,] arrayMatrixFirst, out int[,] arrayMatrixSecond)
        {
            // Строки и столбцы первой матрицы.

            int stringMatrixFirst;
            int columnMatrixFirst;

            // Строки и столбцы второй матрицы.

            int stringMatrixSecond;
            int columnMatrixSecond;

            // Первая матрица.

            Console.Write(Environment.NewLine);
            do
            {
                Console.Write("Введите количество строк первой матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out stringMatrixFirst) || stringMatrixFirst < 1 || stringMatrixFirst > 30);

            do
            {
                Console.Write("Введите количество столбцов первой матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out columnMatrixFirst) || columnMatrixFirst < 1 || columnMatrixFirst > 30);

            // Формирование матрицы ввода.

            arrayMatrixFirst = new int[stringMatrixFirst, columnMatrixFirst];

            for (int i = 0; i < arrayMatrixFirst.GetLength(0); i++)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine($"Введите элементы {i + 1} строки: ");
                string temp = Console.ReadLine();

                string[] tempMatrixLine = temp.Split(' ');

                if (tempMatrixLine.Length != columnMatrixFirst)
                {
                    throw new ArgumentException("Введено некорректное количество элементов строки!");
                }

                for (int j = 0; j < arrayMatrixFirst.GetLength(1); j++)
                {
                    arrayMatrixFirst[i, j] = Convert.ToInt32(tempMatrixLine[j]);
                }
            }

            // Вторая матрица.

            Console.Write(Environment.NewLine);
            do
            {
                Console.Write("Введите количество строк второй матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out stringMatrixSecond) || stringMatrixSecond < 1 || stringMatrixSecond > 30 || stringMatrixFirst != stringMatrixSecond);

            do
            {
                Console.Write("Введите количество столбцов второй матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out columnMatrixSecond) || columnMatrixSecond < 1 || columnMatrixSecond > 30 || columnMatrixFirst != columnMatrixSecond);

            // Формирование матрицы ввода.

            arrayMatrixSecond = new int[stringMatrixSecond, columnMatrixSecond];

            for (int i = 0; i < arrayMatrixSecond.GetLength(0); i++)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine($"Введите элементы {i + 1} строки: ");
                string temp = Console.ReadLine();

                string[] tempMatrixLine = temp.Split(' ');

                if (tempMatrixLine.Length != columnMatrixSecond)
                {
                    throw new ArgumentException("Введено некорректное количество элементов строки!");
                }

                for (int j = 0; j < arrayMatrixSecond.GetLength(1); j++)
                {
                    arrayMatrixSecond[i, j] = Convert.ToInt32(tempMatrixLine[j]);
                }
            }
        }        

        // Ввод матриц с клавиатуры для операции перемножение матриц.

        static void TwoMatrixInputUserMult(out int[,] arrayMatrixFirst, out int[,] arrayMatrixSecond)
        {
            // Строки и столбцы первой матрицы.

            int stringMatrixFirst;
            int columnMatrixFirst;

            // Строки и столбцы второй матрицы.

            int stringMatrixSecond;
            int columnMatrixSecond;

            // Первая матрица.

            Console.Write(Environment.NewLine);
            do
            {
                Console.Write("Введите количество строк первой матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out stringMatrixFirst) || stringMatrixFirst < 1 || stringMatrixFirst > 30);

            do
            {
                Console.Write("Введите количество столбцов первой матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out columnMatrixFirst) || columnMatrixFirst < 1 || columnMatrixFirst > 30);

            // Формирование матрицы ввода.

            arrayMatrixFirst = new int[stringMatrixFirst, columnMatrixFirst];

            for (int i = 0; i < arrayMatrixFirst.GetLength(0); i++)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine($"Введите элементы {i + 1} строки: ");
                string temp = Console.ReadLine();

                string[] tempMatrixLine = temp.Split(' ');

                if (tempMatrixLine.Length != columnMatrixFirst)
                {
                    throw new ArgumentException("Введено некорректное количество элементов строки!");
                }

                for (int j = 0; j < arrayMatrixFirst.GetLength(1); j++)
                {
                    arrayMatrixFirst[i, j] = Convert.ToInt32(tempMatrixLine[j]);
                }
            }

            // Вторая матрица.

            Console.Write(Environment.NewLine);
            do
            {
                Console.Write("Введите количество строк второй матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out stringMatrixSecond) || stringMatrixSecond < 1 || stringMatrixSecond > 30 || columnMatrixFirst != stringMatrixSecond);

            do
            {
                Console.Write("Введите количество столбцов второй матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out columnMatrixSecond) || columnMatrixSecond < 1 || columnMatrixSecond > 30);

            // Формирование матрицы ввода.

            arrayMatrixSecond = new int[stringMatrixSecond, columnMatrixSecond];

            for (int i = 0; i < arrayMatrixSecond.GetLength(0); i++)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine($"Введите элементы {i + 1} строки: ");
                string temp = Console.ReadLine();

                string[] tempMatrixLine = temp.Split(' ');

                if (tempMatrixLine.Length != columnMatrixSecond)
                {
                    throw new ArgumentException("Введено некорректное количество элементов строки!");
                }

                for (int j = 0; j < arrayMatrixSecond.GetLength(1); j++)
                {
                    arrayMatrixSecond[i, j] = Convert.ToInt32(tempMatrixLine[j]);
                }
            }
        }
    }
}
