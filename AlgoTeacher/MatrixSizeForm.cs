using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AlgoTeacher
{
    public partial class MatrixSizeForm : DevExpress.XtraEditors.XtraForm
    {
        public MatrixSizeForm()
        {
            InitializeComponent();
        }

        private void MatrixSizeForm_Load(object sender, EventArgs e)
        {
            for (var i = 1; i <= 10; i++)
            {
                comboBoxRows1.Properties.Items.Add(i);
                comboBoxRows2.Properties.Items.Add(i);
                comboBoxColumns1.Properties.Items.Add(i);
                comboBoxColumns2.Properties.Items.Add(i);
            }
        }

        private void ReadyButton_Click(object sender, EventArgs e)
        {
            var rows1 = (int) comboBoxRows1.EditValue;
            var rows2 = (int) comboBoxRows2.EditValue;
            var columns1 = (int) comboBoxColumns1.EditValue;
            var columns2 = (int) comboBoxColumns2.EditValue;

            if (columns2 != rows1)
            {
                MessageBox.Show("Число столбцов первой матрицы должно соответствовать числу строк второй!");
            }
        }
    }
}