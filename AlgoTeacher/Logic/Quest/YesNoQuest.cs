using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTeacher.Interface;

namespace AlgoTeacher.Logic.Quest
{
    class YesNoQuest : IQuest
    {

        private readonly bool _Answer;
        private readonly string _Question;
        private readonly string _Name;

        public YesNoQuest(string name, string question, bool answer)
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
            return answer.Equals(_Answer.ToString());
        }
    }
}
