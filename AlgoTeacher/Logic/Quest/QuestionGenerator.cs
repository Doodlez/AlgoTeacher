using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AlgoTeacher.Logic.Quest
{
    public class QuestionGenerator
    {
        public static string MatrixMultQuestion(int x, int y, string language)
        {
            const string address = @"..\..\Questions\";
            string[] questions = File.ReadAllLines(address + language + @"\matrix_mult\matrix_questions.txt", Encoding.Default);

            var random = new Random();
            var questionNumber = 1 + random.Next() % 5;

            switch ( questionNumber )
            {
                case 1:
                    return String.Format(questions[0], x, y);
                case 2:
                    return String.Format(questions[1], x, y);
                case 3:
                    return String.Format(questions[2], x, y);
                case 4:
                    return String.Format(questions[3], x, y);
                default:
                    return String.Format(questions[4], x, y);
            }
        }

        public static string TransportTaskQuestion(string language)
        {
            const string address = @"..\..\Questions\";
            string[] questions = File.ReadAllLines(address + language + @"\transport_task\transport_questions.txt", Encoding.Default);

            var random = new Random();
            var questionNumber = 1 + random.Next() % 5;

            switch ( questionNumber )
            {
                case 1:
                    return String.Format(questions[0]);
                case 2:
                    return String.Format(questions[1]);
                case 3:
                    return String.Format(questions[2]);
                case 4:
                    return String.Format(questions[3]);
                default:
                    return String.Format(questions[4]);
            }
        }
    }
}
