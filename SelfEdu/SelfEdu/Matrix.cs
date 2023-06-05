using System;
using System.Linq;

namespace SelfEdu
{
    class Matrix
    {
        private int col;
        private int row;
        private double[,]? data;
        private double[,]? resulMatrix;

        public void Read()
        {
            var colRow = Console.ReadLine().Split();
            col = int.Parse(colRow[0]);
            row = int.Parse(colRow[1]);
            data = new double[col, row];

            for(int i = 0; i < col; i++)
            {
                var elemMatriInput = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for(int j = 0; j < row; j++)
                {
                    data[i, j] = elemMatriInput[j];
                }
            }
        }

        public void Write()
        {
            if (resulMatrix.Length == 0)
            {
                for (int i = 0; i < col; i++)
                {
                    for (int j = 0; j < row; j++)
                    {
                        Console.Write("{0}{1}", data[i, j], j == (data.Length - 1) ? "" : " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < resulMatrix.RowCountMatrix(); i++)
                {
                    for (int j = 0; j < resulMatrix.ColCountMatrix(); j++)
                    {
                        Console.Write("{0}{1}", resulMatrix[i, j], j == (resulMatrix.Length - 1) ? "" : " ");
                    }
                    Console.WriteLine();
                }
            }
        }
        public double[,] MultiplyMatrix(Matrix b)
        {
            if (data.RowCountMatrix() != b.data.ColCountMatrix())
                throw new Exception("Кол-во строк не равно кол-ву столбцов второй матрицы!");
            resulMatrix = new double[data.RowCountMatrix(), b.data.ColCountMatrix()];
            for(int i = 0; i < data.RowCountMatrix(); i++)
            {
                for(int j = 0; j < b.data.ColCountMatrix(); j++)
                {
                    resulMatrix[i, j] = 0;
                    for(int k = 0; k < data.ColCountMatrix(); k++)
                    {
                        resulMatrix[i, j] += data[i, k] * b.data[k, j];
                    }
                }
            }
            return resulMatrix;
        }
    }

    static class MatrixExist
    {
        public static int ColCountMatrix(this double[,]? matrix)
        {
            return matrix.GetUpperBound(1) + 1;
        }

        public static int RowCountMatrix(this double[,]? matrix)
        {
            return matrix.GetUpperBound(0) + 1;
        }
    }
}