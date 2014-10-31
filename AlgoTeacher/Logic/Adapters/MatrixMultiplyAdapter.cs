using SpreadsheetGear;
using SpreadsheetGear.Windows.Forms;

namespace AlgoTeacher.Logic.Adapters
{
    class MatrixMultiplyAdapter
    {
        private readonly WorkbookView _workbookView;
        private readonly IWorkbook _workbook;
        private readonly IWorksheet _worksheet;
        private readonly IRange _cells;

        private int _rows1;
        private int _columns1;
        private int _rows2;
        private int _columns2;

        public MatrixMultiplyAdapter(WorkbookView workbookView, int rows1, int columns1, int rows2, int columns2)
        {
            if (workbookView != null)
            {
                workbookView.GetLock();
            }

            _workbookView = workbookView;
            _workbook = _workbookView.ActiveWorkbook;
            _worksheet = _workbook.Worksheets[0];
            _cells = _worksheet.Cells;

            _rows1 = rows1;
            _columns1 = columns1;
            _rows2 = rows2;
            _columns2 = columns2;

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

            var values = new int[rows][];
            for (var i = 0; i < rows; i++)
            {
                values[i] = new int[columns];
            }

            for ( var i = startRowCell; i <= startRowCell + rows - 1; i++ )
            {
                for ( var j = startColumnCell; j <= startColumnCell + columns - 1; j++ )
                {
                    values[i - startRowCell][j - startColumnCell] = int.Parse(_cells[i, j].Value.ToString());
                }
            }

            if ( _workbookView != null )
            {
                _workbookView.ReleaseLock();
            }

            return values;
        }

        public void MakeBordersForMatrix(int startRow, int startColumn, int rows, int cols)
        {
            if ( _workbookView != null )
            {
                _workbookView.GetLock();
            }

            _cells[startRow, startColumn, startRow + rows - 1, startColumn + cols - 1].Borders.LineStyle = LineStyle.Double;

            if ( _workbookView != null )
            {
                _workbookView.ReleaseLock();
            }
        }

        public void FillResultCell(int row, int col, string value)
        {
            const int resultStartPositionRow = 0;
            var resultStartPositionColumns = _columns1 + _columns2 + 2;

            if (_workbookView != null)
            {
                _workbookView.GetLock();
            }
            _cells[resultStartPositionRow + row, resultStartPositionColumns + col].Value = value;

            if (_workbookView != null)
            {
                _workbookView.ReleaseLock();
            }
        }
    }
}
