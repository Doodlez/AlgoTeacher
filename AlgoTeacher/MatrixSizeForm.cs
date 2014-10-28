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
        public int Rows1;
        public int Columns1;
        public int Rows2;
        public int Columns2;

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
            Rows1 = (int) comboBoxRows1.EditValue;
            Rows2 = (int) comboBoxRows2.EditValue;
            Columns1 = (int) comboBoxColumns1.EditValue;
            Columns2 = (int) comboBoxColumns2.EditValue;

            if (Rows2 != Columns1)
            {
                MessageBox.Show("Число столбцов первой матрицы должно соответствовать числу строк второй!");
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}