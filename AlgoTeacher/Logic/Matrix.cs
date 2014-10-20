using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTeacher
{
    public class Matrix
    {
        public int Rows
        {
            get;
            set;
        }

        public int Columns
        {
            get;
            set;
        }

        public int[][] Values
        {
            get;
            set;
        }

        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Values = new int[rows][];

            for (var i = 0; i < rows; i++)
            {
                Values[i] = new int[columns];
                for (var j = 0; j < columns; j++)
                {
                    Values[i][j] = 0;
                }
            }
        }

        public static Matrix MatrixMult(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Columns != matrix2.Rows)
                return null;

            var resultMatrix = new Matrix(matrix1.Rows, matrix2.Columns);
            for (var i = 0; i < matrix1.Rows; i++)
            {
                for (var j = 0; j < matrix2.Columns; j++)
                {
                    for (var k = 0; k < matrix1.Columns; k++)
                    {
                        resultMatrix.Values[i][j] += matrix1.Values[i][k] * matrix2.Values[k][j];
                    }
                }
            }

            return resultMatrix;
        }
    }
}