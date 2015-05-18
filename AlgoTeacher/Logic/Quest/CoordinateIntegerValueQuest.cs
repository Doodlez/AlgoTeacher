using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTeacher.Interface;

namespace AlgoTeacher.Logic.Quest
{
    class CoordinateIntegerValueQuest : IQuest
    {
        private readonly CoordinateIntegerValue _Answer;
        private readonly string _Question;
        private readonly string _Name;

        public CoordinateIntegerValueQuest(string name, string question, CoordinateIntegerValue answer)
        {
            _Name = name;
            _Question = question;
            _Answer = answer;
        }

        public string Name
        {
            get { return _Name; }
        }

        public string Question
        {
            get { return _Question; }
        }

        public string Answer
        {
            get
            {
                return _Answer.Coordinate.X.ToString(CultureInfo.InvariantCulture) + "," +
                       _Answer.Coordinate.Y.ToString(CultureInfo.InvariantCulture) + "," +
                       _Answer.Value.ToString(CultureInfo.InvariantCulture);
            }
        }

        public bool CheckAnswer(string answer)
        {
            try
            {
                return answer.Equals(_Answer);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
