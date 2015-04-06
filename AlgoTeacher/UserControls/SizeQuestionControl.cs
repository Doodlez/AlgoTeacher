using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace UserControls
{
    // TODO: В качестве параметров передавать строки для подписи ввода (строки-столбцы, ограничения)
    public partial class SizeQuestionControl : QuestionControlBase
    {
        private delegate void SetCleanCallback();

        public SizeQuestionControl()
        {
            InitializeComponent();
        }

        //public bool AnswerButtonEnabled
        //{
        //    get { return AnswerButton.Enabled; }
        //    set { AnswerButton.Enabled = value;}
        //}

        //public string GetRowsAnswer()
        //{
        //    return RowsTextEdit.Text;
        //}

        //public string GetColumnsAnswer()
        //{
        //    return ColumnsTextEdit.Text;
        //}

        //public void CleanRows()
        //{
        //    if (RowsTextEdit.InvokeRequired)
        //    {
        //        var d = new SetCleanCallback(CleanRows);
        //        Invoke(d);
        //    }
        //    else
        //    {
        //        RowsTextEdit.Text = string.Empty;
        //    } 
        //}

        //public void CleanColumns()
        //{
        //    if (ColumnsTextEdit.InvokeRequired)
        //    {
        //        var d = new SetCleanCallback(CleanColumns);
        //        Invoke(d);
        //    }
        //    else
        //    {
        //        ColumnsTextEdit.Text = string.Empty;
        //    }
        //}

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
                checkAnswer(sender, e);
            }
        }

        public override void ClearControl()
        {
            if (RowsTextEdit.InvokeRequired || ColumnsTextEdit.InvokeRequired)
            {
                var d = new SetCleanCallback(ClearControl);
                Invoke(d);
            }
            else
            {
                RowsTextEdit.Text = string.Empty;
                ColumnsTextEdit.Text = string.Empty;
            } 
        }

        // проверка вида "строка, столбец"!!!
        protected override void checkAnswer(object sender, EventArgs e)
        {
            if (string.Concat(RowsTextEdit.Text, ", ", ColumnsTextEdit.Text) == this.expectAnswer)
            {
                this.OnGoodAnswered(sender, e);
            }
            else
            {
                this.OnBadAnswered(sender, e);
            }
        }
    }
}
