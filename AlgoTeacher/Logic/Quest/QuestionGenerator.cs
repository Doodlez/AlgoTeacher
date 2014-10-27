using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTeacher.Logic.Quest
{
    public class QuestionGenerator
    {
        public static string MatrixMultQuestion(int x, int y)
        {
            var random = new Random();
            var questionNumber = 1 + random.Next() % 5;

            switch ( questionNumber )
            {
                case 1:
                    return "Чему будет равен элемент матрицы с координатами (" + x + ", " + y + ")?";
                case 2:
                    return "Как вы думаете, что будет находиться в матрице по адресу (" + x + ", " + y + ")?";
                case 3:
                    return "Впишите получившийся результат в ячейку (" + x + ", " + y + ") матрицы).";
                case 4:
                    return "Что у вас получилось в ячейке матрицы по адресу (" + x + ", " + y + ")?";
                default:
                    return "Введите ваш ответ по адресу (" + x + ", " + y + "), пожалуйста.";
            }
        }
    }
}
