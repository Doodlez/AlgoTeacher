using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoTeacher.Interface;
using AlgoTeacher.Logic;

namespace AlgoTeacher
{
    public partial class MainForm : Form
    {
        public IntroForm IntroForm;
        public InformationForm InformationForm;
        public MyTask MyTask;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string introText = "Доброго времени суток, дружище!\r\nНе желаешь ли научиться перемножать матрицы?";
            List<string> helpsText = new List<string>();
            helpsText.Add("Итак, две матрицы A и B размера PxQ и MxN соответственно\r\nможно перемножить тогда и только тогда,\r\nкогда число столбцов первой матрицы совпадает с числом строк второй,\r\nт.е. Q = M.\r\nКаждый элемент итоговой матрицы C будет состоять\r\nиз сумм произведения элементов матриц\r\ncоответствующей строки матрицы A и столбца матрицы B.");
            helpsText.Add("Давай рассмотрим это поподробнее - ...");
            helpsText.Add("Пример");

            TaskHelp testHelp = new TaskHelp("test", helpsText);
            MyTask testTask = new MyTask("Умножение матриц", typeof(MatrixMultiplyForm), introText, testHelp);

            TaskCollection tasks = new TaskCollection(testTask);

            TaskComboBox.Properties.Items.Add(tasks[0]);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (TaskComboBox.Properties.Items.Count != 0)
            {
                MyTask selectedTask = (MyTask) TaskComboBox.EditValue;
                selectedTask.ShowIntro();

                //if (selectedTask.Name == "Умножение матриц")
                //{
                //    //IntroForm = new IntroForm("Доброго времени суток, дружище! Не желаешь ли научиться перемножать матрицы?", selectedTask, this);

                //    this.Visible = false;
                //    IntroForm.Show();
                //}
            }
        }
    }
}
