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
    public class MyMatrix
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

        public MyMatrix(int lowerSizeLimit = 2, int upperSizeLimit = 4, int lowerValueLimit = 0, int upperValueLimit = 9)
        {
            MakeRandomMatrix(lowerSizeLimit, upperSizeLimit, lowerValueLimit, upperValueLimit);
        }

        public bool AddRow(int[] values, int count)
        {
            try
            {
                if (count != this.ColumnsCount)
                {
                    return false;
                }

                int[][] temp = Values;

                Values = new int[RowsCount + 1][];

                for (var i = 0; i < RowsCount; i++)
                {
                    Values[i] = new int[ColumnsCount];

                    for (var j = 0; j < ColumnsCount; j++)
                    {
                        Values[i][j] = temp[i][j];
                    }
                }
                Values[RowsCount] = new int[ColumnsCount];
                for (var j = 0; j < ColumnsCount; j++)
                {
                    Values[RowsCount][j] = values[j];
                }
                RowsCount += 1;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddColumn(int[] values, int count)
        {
            try
            {
                if (count != this.RowsCount - 1)
                {
                    return false;
                }

                int[][] temp = Values;

                Values = new int[RowsCount][];

                for (var i = 0; i < RowsCount - 1; i++)
                {
                    Values[i] = new int[ColumnsCount + 1];

                    for (var j = 0; j < ColumnsCount; j++)
                    {
                        Values[i][j] = temp[i][j];
                    }
                    Values[i][ColumnsCount] = values[i];
                }

                Values[RowsCount - 1] = new int[ColumnsCount + 1];
                for (var j = 0; j < ColumnsCount; j++)
                {
                    Values[RowsCount - 1][j] = temp[RowsCount - 1][j];
                }
              
                ColumnsCount += 1;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MyMatrix(int rows, int columns)
        {
            RowsCount = rows;
            ColumnsCount = columns;
            Values = new int[rows][];

            for (var i = 0; i < rows; i++)
            {
                Values[i] = new int[columns];
            }
        }

        public MyMatrix(int rows, int columns, IList<int[]> values)
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