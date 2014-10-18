using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTeacher.Interface
{
    public interface IQuest
    {
        string Name { get;}
        string Question { get;}
        Boolean CheckAnswer(string answer);
    }
}
