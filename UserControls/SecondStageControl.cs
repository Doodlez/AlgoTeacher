using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControls
{
    public partial class SecondStageControl : DevExpress.XtraEditors.XtraUserControl
    {
        public delegate void AnswerClickedHandler(object sender, EventArgs e);
        public event AnswerClickedHandler AnswerClicked;

        private delegate void SetTextCallback(string text1);
        private delegate void SetCleanCallback();

        public SecondStageControl()
        {
            InitializeComponent();
        }

        public bool AnswerButtonEnabled
        {
            get { return AnswerButton.Enabled; }
            set { AnswerButton.Enabled = value;}
        }

        public string GetRowsAnswer()
        {
            return RowsTextEdit.Text;
        }

        public string GetColumnsAnswer()
        {
            return ColumnsTextEdit.Text;
        }

        public void CleanRows()
        {
            if (RowsTextEdit.InvokeRequired)
            {
                var d = new SetCleanCallback(CleanRows);
                Invoke(d);
            }
            else
            {
                RowsTextEdit.Text = string.Empty;
            } 
        }

        public void CleanColumns()
        {
            if (ColumnsTextEdit.InvokeRequired)
            {
                var d = new SetCleanCallback(CleanColumns);
                Invoke(d);
            }
            else
            {
                ColumnsTextEdit.Text = string.Empty;
            }
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            if (RowsTextEdit.Text.Length == 0)
            {
                MessageBox.Show("Введите число строк матрицы");
            }
            else if (ColumnsTextEdit.Text.Length == 0)
            {
                MessageBox.Show("Введите число столбцов матрицы");
            }
            else
            {
                OnAnswerClicked(sender, e);
            }
        }
        protected virtual void OnAnswerClicked(object sender, EventArgs e)
        {
            // If an event has no subscribers registerd, it will
            // evaluate to null. The test checks that the value is not
            // null, ensuring that there are subsribers before
            // calling the event itself.
            if (AnswerClicked != null)
            {
                AnswerClicked(sender, e);  
            }
        }
    }
}
