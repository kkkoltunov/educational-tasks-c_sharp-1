using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MatrixCalc
{
    partial class Program
    {
        // Объект класса Random.

        static Random rnd = new Random();

        // Ввод номера команды с клавиатуры.

        static int MatrixInputComand()
        {
            int numberComand;

            do
            {
                Console.Write(Environment.NewLine);
                Console.Write("Введите номер желаемой команды: ");
                if (!int.TryParse(Console.ReadLine(), out numberComand) || (numberComand < 0 || numberComand > 3))
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("Некорректный ввод, пожалуйста, повторите попытку!");
                }
                else
                {
                    break;
                }

            } while (true);

            return numberComand;
        }

        // Генерация данных случайнм образом по введенным пользователем данным.

        static void MatrixInputRandom(out int[,] arrayMatrix, bool flagSquare)
        {
            int stringMatrix;
            int columnMatrix;

            int minRandom;
            int maxRandom;

            Console.Write(Environment.NewLine);

            do
            {
                Console.Write("Введите количество строк матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out stringMatrix) || stringMatrix < 1 || stringMatrix > 30);

            do
            {
                Console.Write("Введите количество столбцов матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out columnMatrix) || columnMatrix < 1 || columnMatrix > 30 || (flagSquare == true && columnMatrix != stringMatrix));

            do
            {
                Console.Write("Введите значение, начиная с которого будут генерироваться числа в матрице. Диапазон ---> [-100; 100]: ");
            } while (!int.TryParse(Console.ReadLine(), out minRandom) || minRandom < -100 || minRandom > 100);

            do
            {
                Console.Write("Введите значение, до которого будут генерироваться числа в матрице. Диапазон ---> [-100; 100]: ");
            } while (!int.TryParse(Console.ReadLine(), out maxRandom) || maxRandom < -100 || maxRandom > 100 || maxRandom < minRandom);

            // Создание матрицы ввода.

            arrayMatrix = new int[stringMatrix, columnMatrix];

            for (int i = 0; i < stringMatrix; i++)
            {
                for (int j = 0; j < columnMatrix; j++)
                {
                    arrayMatrix[i, j] = rnd.Next(minRandom, maxRandom);
                }
            }
        }

        // Генерация данных случайнм образом по введенным пользователем данным для операции умножения матрицы на число.

        static void MatrixInputRandomMult(out int[,] arrayMatrix, out int number, bool flagSquare)
        {
            int stringMatrix;
            int columnMatrix;

            int minRandom;
            int maxRandom;

            Console.Write(Environment.NewLine);

            do
            {
                Console.Write("Введите количество строк матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out stringMatrix) || stringMatrix < 1 || stringMatrix > 30);

            do
            {
                Console.Write("Введите количество столбцов матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out columnMatrix) || columnMatrix < 1 || columnMatrix > 30 || (flagSquare == true && columnMatrix != stringMatrix));

            do
            {
                Console.Write("Введите значение, начиная с которого будут генерироваться числа в матрице. Диапазон ---> [-100; 100]: ");
            } while (!int.TryParse(Console.ReadLine(), out minRandom) || minRandom < -100 || minRandom > 100);

            do
            {
                Console.Write("Введите значение, до которого будут генерироваться числа в матрице. Диапазон ---> [-100; 100]: ");
            } while (!int.TryParse(Console.ReadLine(), out maxRandom) || maxRandom < -100 || maxRandom > 100 || maxRandom < minRandom);

            do
            {
                Console.Write("Введите число, на которое вы хотите умножить матрицу. Диапазон ---> [-99999; 99999]: ");
            } while (!int.TryParse(Console.ReadLine(), out number) || number < -99999 || number > 99999);

            // Создание матрицы ввода.

            arrayMatrix = new int[stringMatrix, columnMatrix];

            for (int i = 0; i < stringMatrix; i++)
            {
                for (int j = 0; j < columnMatrix; j++)
                {
                    arrayMatrix[i, j] = rnd.Next(minRandom, maxRandom);
                }
            }
        }

        // Чтение данных матрицы из файла.

        static void MatrixInputFile(out int[,] arrayMatrix, bool flagSquare)
        {
            // Замечание для пользователя.

            Console.Write(Environment.NewLine);
            Console.WriteLine("Обратите внимание, что корректное чтение файла гарантируется только для расширения .txt!");
            Console.WriteLine("В файле вы должны ввести данные исходной матрицы, то есть столбцы и строки.");
            Console.WriteLine("Каждый элемент матрицы вводится через пробел, после матрицы не должно быть пустых строк.");
            Console.Write(Environment.NewLine);

            // Массив для записи данных из файла.

            string[] matrixFile;

            // Путь до файла.

            string inputFile;

            do
            {
                Console.Write("Укажите полный путь до файла, который нужно открыть: ");
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

            int lenghtLine = matrixFile.Length;
            int lenghtColumn = firstLine.Length;

            // Исключение.

            if (flagSquare == true && lenghtColumn != lenghtLine)
            {
                throw new ArgumentException("Количество строк должно равняться количеству столбцов!");
            }

            // Формирование матрицы ввода.

            arrayMatrix = new int[lenghtLine, lenghtColumn];

            for (int i = 0; i < matrixFile.Length; i++)
            {
                string temp = matrixFile[i];

                string[] tempMatrixLine = temp.Split(' ');

                if (tempMatrixLine.Length != lenghtColumn)
                {
                    throw new ArgumentException("Введено некорректное количество элементов строки!");
                }

                for (int j = 0; j < tempMatrixLine.Length; j++)
                {
                    arrayMatrix[i, j] = Convert.ToInt32(tempMatrixLine[j]);
                }
            }
        }

        // Чтение данных матрицы из файла для операции умножения матрицы на число.

        static void MatrixInputFileMult(out int[,] arrayMatrix, bool flagSquare, out int number)
        {
            // Замечание для пользователя.

            Console.Write(Environment.NewLine);
            Console.WriteLine("Обратите внимание, что корректное чтение файла гарантируется только для расширения .txt!");
            Console.WriteLine("В файле вы должны ввести данные исходной матрицы, то есть столбцы и строки.");
            Console.WriteLine("Каждый элемент матрицы вводится через пробел, после матрицы не должно быть пустых строк.");
            Console.Write(Environment.NewLine);

            // Массив для записи данных из файла.

            string[] matrixFile;

            // Путь до файла.

            string inputFile;

            do
            {
                do
                {
                    Console.Write("Введите число, на которое вы хотите умножить матрицу. Диапазон ---> [-99999; 99999]: ");
                } while (!int.TryParse(Console.ReadLine(), out number) || number < -99999 || number > 99999);

                Console.Write("Укажите полный путь до файла, который нужно открыть: ");
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

            int lenghtLine = matrixFile.Length;
            int lenghtColumn = firstLine.Length;

            // Исключение.

            if (flagSquare == true && lenghtColumn != lenghtLine)
            {
                throw new ArgumentException("Количество строк должно равняться количеству столбцов!");
            }

            // Формирование матрицы ввода.

            arrayMatrix = new int[lenghtLine, lenghtColumn];

            for (int i = 0; i < matrixFile.Length; i++)
            {
                string temp = matrixFile[i];

                string[] tempMatrixLine = temp.Split(' ');

                if (tempMatrixLine.Length != lenghtColumn)
                {
                    throw new ArgumentException("Введено некорректное количество элементов строки!");
                }


                for (int j = 0; j < tempMatrixLine.Length; j++)
                {
                    arrayMatrix[i, j] = Convert.ToInt32(tempMatrixLine[j]);
                }
            }
        }

        // Ввод данных матрицы с клавиатуры.

        static void MatrixInputUser(out int[,] arrayMatrix, bool flagSquare)
        {
            int stringMatrix;
            int columnMatrix;

            Console.Write(Environment.NewLine);

            do
            {
                Console.Write("Введите количество строк матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out stringMatrix) || stringMatrix < 1 || stringMatrix > 30);

            do
            {
                Console.Write("Введите количество столбцов матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out columnMatrix) || columnMatrix < 1 || columnMatrix > 30 || (flagSquare == true && columnMatrix != stringMatrix));

            // Формирование матрицы ввода.

            arrayMatrix = new int[stringMatrix, columnMatrix];

            for (int i = 0; i < arrayMatrix.GetLength(0); i++)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine($"Введите элементы {i + 1} строки: ");
                string temp = Console.ReadLine();

                string[] tempMatrixLine = temp.Split(' ');

                if (tempMatrixLine.Length != columnMatrix)
                {
                    throw new ArgumentException("Введено некорректное количество элементов строки!");
                }

                for (int j = 0; j < arrayMatrix.GetLength(1); j++)
                {
                    arrayMatrix[i, j] = Convert.ToInt32(tempMatrixLine[j]);
                }
            }
        }

        // Ввод данных матрицы с клавиатуры для операции умножения матрицы на число.

        static void MatrixInputUserMult(out int[,] arrayMatrix, bool flagSquare, out int number)
        {
            int stringMatrix;
            int columnMatrix;

            Console.Write(Environment.NewLine);

            do
            {
                Console.Write("Введите количество строк матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out stringMatrix) || stringMatrix < 1 || stringMatrix > 30);

            do
            {
                Console.Write("Введите количество столбцов матрицы. Диапазон ---> [1; 30]: ");
            } while (!int.TryParse(Console.ReadLine(), out columnMatrix) || columnMatrix < 1 || columnMatrix > 30 || (flagSquare == true && columnMatrix != stringMatrix));

            do
            {
                Console.Write("Введите число, на которое вы хотите умножить матрицу. Диапазон ---> [-99999; 99999]: ");
            } while (!int.TryParse(Console.ReadLine(), out number) || number < -99999 || number > 99999);

            if (flagSquare == true && columnMatrix != stringMatrix)
            {
                throw new ArgumentException("Количество строк должно равняться количеству столбцов!");
            }

            // Формирование матрицы ввода.

            arrayMatrix = new int[stringMatrix, columnMatrix];

            for (int i = 0; i < arrayMatrix.GetLength(0); i++)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine($"Введите элементы {i + 1} строки: ");
                string temp = Console.ReadLine();

                string[] tempMatrixLine = temp.Split(' ');

                if (tempMatrixLine.Length != columnMatrix)
                {
                    throw new ArgumentException("Введено некорректное количество элементов строки!");
                }

                for (int j = 0; j < arrayMatrix.GetLength(1); j++)
                {
                    arrayMatrix[i, j] = Convert.ToInt32(tempMatrixLine[j]);
                }
            }
        }
    }
}
