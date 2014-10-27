using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTeacher.Logic;
using AlgoTeacher.Logic.Quest;

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
        }

        public Matrix(int rows, int columns, IList<int[]> values)
        {
            Rows = rows;
            Columns = columns;
            Values = new int[rows + 1][];

            for (var i = 1; i <= rows; i++)
            {
                Values[i] = new int[columns + 1];
                for (var j = 1; j <= columns; j++)
                {
                    Values[i][j] = values[i - 1][j - 1];
                }
            }
        }
    }
}