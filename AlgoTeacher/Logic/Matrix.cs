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
            Values = new int[rows][];

            for (var i = 0; i < rows; i++)
            {
                Values[i] = new int[columns];
                for (var j = 0; j < columns; j++)
                {
                    Values[i][j] = 2;
                }
            }
        }
    }
}