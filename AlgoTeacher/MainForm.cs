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
                //selectTask.ShowForm();

                if (selectedTask.Name == "Умножение матриц")
                {
                    var introForm = new IntroForm("Доброго времени суток, дружище! Не желаешь ли научиться перемножать матрицы?");
                    this.Hide();
                    introForm.ShowDialog();

                    InformationForm infoForm;

                    switch ( introForm.DialogResult )
                    {
                        case DialogResult.OK:
                            infoForm = new InformationForm("Две матрицы A и B размерами mxn и pxq можно перемножить только при том условии, что число столбцов первой матрицы равно числу строк второй, т.е. когда n = p");
                            infoForm.Show();
                            break;

                        case DialogResult.No:
                            selectedTask.ShowForm();
                            //infoForm = new InformationForm("Ну раз ты понял, как это решается, попробуй решить следующий пример...");
                            //infoForm.Show();
                            break;

                        case DialogResult.Cancel:
                            //MessageBox.Show("Здесь будет комплекс показательныз задач");
                            this.Show();
                            break;
                    }
                }
            }
        }
    }
}
