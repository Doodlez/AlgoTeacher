using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTeacher.Interface
{
    public class Help
    {
        public Help(string name, List<string> content)
        {
            Name = name;
            Content = content;
        }

        public string Name;

        public List<string> Content;
    }
}
