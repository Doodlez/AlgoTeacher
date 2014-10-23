using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoTeacher.User_Controls;
using DevExpress.XtraEditors;

namespace AlgoTeacher
{
    public partial class MatrixMultiplyForm : DevExpress.XtraEditors.XtraForm 
    {
        public MatrixMultiplyForm()
        {
            InitializeComponent();
            QuestionControl.AnswerClickedHandler answerClickHandler = new QuestionControl.AnswerClickedHandler(AnswerButton_Clicked);
            questionControl.AnswerClicked += answerClickHandler;

            QuestionControl.CalculateClickedHandler calculateClickHandler = new QuestionControl.CalculateClickedHandler(CalculateButton_Clicked);
            questionControl.CalculateClicked += calculateClickHandler;
        }
        private void MatrixMultiplyForm_Load(object sender, EventArgs e)
        {

        }
        public void CalculateButton_Clicked(object sender, EventArgs e)
        {
            // Действия при нажатии посчитать
            MessageBox.Show("Hi");
        }

        public void AnswerButton_Clicked(object sender, EventArgs e)
        {
            // Действия при нажатии ответ
        }

        private void MatrixMultiplyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}