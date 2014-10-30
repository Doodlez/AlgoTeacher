using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTeacher.Interface;

namespace AlgoTeacher.Logic.Quest
{
    class DoubleValueQuest :IQuest
    {
        private readonly double _Answer;
        private readonly string _Question;
        private readonly string _Name;

        public DoubleValueQuest(string name, string question, double answer)
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
            get { return _Answer.ToString(CultureInfo.InvariantCulture); }
        }

        public bool CheckAnswer(string answer)
        {
            try
            {
                double value;
                if (!Double.TryParse(answer,out value)) return false; 
                return value.Equals(_Answer);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
