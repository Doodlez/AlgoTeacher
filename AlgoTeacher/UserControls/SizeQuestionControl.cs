using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
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

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            var good = true;
            if (RowsTextEdit.Text.Length == 0)
            {
                RowsTextEdit.Properties.BorderStyle = BorderStyles.Flat;
                RowsTextEdit.Properties.Appearance.BorderColor = Color.Red;
                good = false;
            }
            
            if (ColumnsTextEdit.Text.Length == 0)
            {
                ColumnsTextEdit.Properties.BorderStyle = BorderStyles.Flat;
                ColumnsTextEdit.Properties.Appearance.BorderColor = Color.Red;
                good = false;
            }

            if (good)
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

        public override void SetFocus()
        {
            RowsTextEdit.Focus();
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

        private void RowsTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (RowsTextEdit.Text.Length != 0)
            {
                RowsTextEdit.Properties.BorderStyle = BorderStyles.NoBorder;
                RowsTextEdit.Properties.Appearance.BorderColor = Color.Empty;
            }
        }

        private void ColumnsTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ColumnsTextEdit.Text.Length != 0)
            {
                ColumnsTextEdit.Properties.BorderStyle = BorderStyles.NoBorder;
                ColumnsTextEdit.Properties.Appearance.BorderColor = Color.Empty;
            }
        }
    }
}
