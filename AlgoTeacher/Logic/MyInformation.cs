using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTeacher.Logic
{
    public class MyInformation
    {
        public string BasicInformation { get; private set; }

        public MyInformation(string text)
        {
            BasicInformation = text;
        }

    }
}
