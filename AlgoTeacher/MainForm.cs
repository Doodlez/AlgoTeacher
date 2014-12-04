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
            MyTask testTask = new MyTask("Умножение матриц", typeof(MatrixMultiplyForm));

            TaskCollection tasks = new TaskCollection(testTask);

            TaskComboBox.Properties.Items.Add(tasks[0]);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (TaskComboBox.Properties.Items.Count != 0)
            {
                MyTask selectedTask = (MyTask) TaskComboBox.EditValue;
                //selectedTask.ShowForm();

                if (selectedTask.Name == "Умножение матриц")
                {
                    IntroForm = new IntroForm("Доброго времени суток, дружище! Не желаешь ли научиться перемножать матрицы?", selectedTask, this);

                    this.Visible = false;
                    IntroForm.Show();
                }
            }
        }
    }
}
