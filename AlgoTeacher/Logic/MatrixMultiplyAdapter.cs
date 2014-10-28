using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpreadsheetGear;
using SpreadsheetGear.Windows.Forms;

namespace AlgoTeacher.Logic
{
    class MatrixMultiplyAdapter
    {
        private readonly WorkbookView _workbookView;
        private readonly IWorkbook _workbook;
        private readonly IWorksheet _worksheet;
        private readonly IRange _cells;

        public MatrixMultiplyAdapter(WorkbookView workbookView)
        {
            if (workbookView != null)
            {
                workbookView.GetLock();
            }

            _workbookView = workbookView;
            _workbook = _workbookView.ActiveWorkbook;
            _worksheet = _workbook.Worksheets[0];
            _cells = _worksheet.Cells;

            if (workbookView != null)
            {
                workbookView.ReleaseLock();
            }
        }

        public int[][] ReadInitialMatrixValues(int startRowCell, int startColumnCell, int rows, int columns)
        {
            if (_workbookView != null)
            {
                _workbookView.GetLock();
            }

            var values = new int[rows + 1][];
            for (var i = 1; i <= rows; i++)
            {
                values[i] = new int[columns + 1];
            }

            for ( var i = startRowCell; i <= startRowCell + rows - 1; i++ )
            {
                for ( var j = startColumnCell; j <= startColumnCell + columns - 1; j++ )
                {
                    values[i][j] = (int) _cells[i, j].Value;
                }
            }

            if ( _workbookView != null )
            {
                _workbookView.ReleaseLock();
            }

            return values;
        }

        public void MakeBordersForInitialMatrixes(int rows1, int cols1, int rows2, int cols2)
        {
            if ( _workbookView != null )
            {
                _workbookView.GetLock();
            }

            _cells[0, 0, rows1 - 1, cols1 - 1].Borders.LineStyle = LineStyle.Double;
            _cells[0, cols1 + 1, rows2 - 1, cols1 + cols2].Borders.LineStyle = LineStyle.Double;

            if ( _workbookView != null )
            {
                _workbookView.ReleaseLock();
            }
        }
    }
}
