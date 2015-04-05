using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTeacher.Interface;

namespace AlgoTeacher.Logic.Quest
{
    class IntegerValueQuest : IQuest
    {
        private readonly int _Answer;
        private readonly string _Question;
        private readonly string _Name;

        public IntegerValueQuest(string name, string question, int answer)
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
                int value;
                if (!int.TryParse(answer, out value)) return false;
                return value.Equals(_Answer);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
