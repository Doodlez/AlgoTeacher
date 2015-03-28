using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControls
{
    public partial class MatrixGridView : DataGridView
    {
        public MatrixGridView()
        {
            InitializeComponent();

        }

        public MatrixGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void AddValues(int[][] values, int rowCount, int colCount)
        {
            this.DataSource = new DataTable();
            List<int[]> rowlist = new List<int[]>();
            for (int i = 0; i < rowCount; i++)
            {
                rowlist.Add(values[i]);
            }
            
            DataTable tab = new DataTable();
            for (int i = 0; i < colCount; i++)
            {
                DataColumn col = new DataColumn();
                tab.Columns.Add(col);
            }

            foreach (var el in rowlist)
            {
                DataRow row = tab.NewRow();
                for (int i = 0; i < tab.Columns.Count; i++)
                {
                    row[i] = el[i];
                }
                tab.Rows.Add(row);
            }

            this.DataSource = tab;

            // Resize
            this.Size = new Size(colCount * 50, rowCount * 50);
            foreach (DataGridViewColumn col in this.Columns)
            {
                col.Width = 50;
            }
        }
    }
}
