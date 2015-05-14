using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AlgoTeacher.Logic;
using AlgoTeacher.Logic.Quest;

namespace AlgoTeacher
{
    public class Matrix
    {
        public int RowsCount
        {
            get;
            set;
        }

        public int ColumnsCount
        {
            get;
            set;
        }

        public int[][] Values
        {
            get;
            set;
        }

        public Matrix(int lowerSizeLimit = 2, int upperSizeLimit = 4, int lowerValueLimit = 0, int upperValueLimit = 9)
        {
            MakeRandomMatrix(lowerSizeLimit, upperSizeLimit, lowerValueLimit, upperValueLimit);
        }

        public Matrix(int rows, int columns)
        {
            RowsCount = rows;
            ColumnsCount = columns;
            Values = new int[rows][];

            for (var i = 0; i < rows; i++)
            {
                Values[i] = new int[columns];
            }
        }

        public Matrix(int rows, int columns, IList<int[]> values)
        {
            RowsCount = rows;
            ColumnsCount = columns;
            Values = new int[rows][];

            for (var i = 0; i < rows; i++)
            {
                Values[i] = new int[columns];
                for (var j = 0; j < columns; j++)
                {
                    Values[i][j] = values[i][j];
                }
            }
        }

        private void MakeRandomMatrix(int lowerSizeLimit = 2, int upperSizeLimit = 4, int lowerValueLimit = 0, int upperValueLimit = 9)
        {
            var random = new Random();

            RowsCount = random.Next(lowerSizeLimit, upperSizeLimit + 1);
            Thread.Sleep(100);
            ColumnsCount = random.Next(lowerSizeLimit, upperSizeLimit + 1);

            Values = new int[RowsCount][];

            for (var i = 0; i < RowsCount; i++)
            {
                Values[i] = new int[ColumnsCount];
                for (var j = 0; j < ColumnsCount; j++)
                {
                    Values[i][j] = random.Next(lowerValueLimit, upperValueLimit + 1);
                }
            }
        }
    }
}