using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoTeacher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            int[][] values1 = { new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 } };
            int[][] values2 = { new[] { 9, 8, 7 }, new[] { 6, 5, 4 }, new[] { 3, 2, 1 } };

            var matrix1 = new Matrix(3, 3, values1);
            var matrix2 = new Matrix(3, 3, values2);

            //var result = Matrix.MatrixMult();

            //var b = Matrix.GetRandomCoords(4, 6);

            var a = 1;
        }
    }
}
