using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTeacher.Interface;

namespace AlgoTeacher.Logic.Quest
{
    class SelectFromRangeQuest : IQuest
    {
        private readonly string _Answer;
        private readonly string _Question;
        private readonly string _Name;
        private readonly int _Range;

        public SelectFromRangeQuest(string name, string question, string answer, int range)
        {
            _Name = name;
            _Question = question;
            _Answer = answer;
            _Range = range;
        }

        public string Name
        {
            get { return _Name; }
        }

        public string Question
        {
            get { return _Question; }
        }

        public bool CheckAnswer(string answer)
        {
            throw new NotImplementedException();
        }
    }
}
