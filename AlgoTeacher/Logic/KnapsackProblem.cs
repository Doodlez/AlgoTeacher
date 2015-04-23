using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTeacher.Logic
{
    public class KnapsackProblem
    {
        public int[] Weights = new int[3];
        public int[] Values = new int[3];

        public void MakeRandomWeights()
        {
            var random = new Random();
            Weights[0] = 3 + random.Next() % 6;
            Weights[1] = Weights[0] + 1 + random.Next() % 5;
            Weights[2] = Weights[1] + 1 + random.Next() % 5;
        }

        public void MakeRandomValues()
        {
            var random = new Random();
            Values[0] = 5 + random.Next() % 10;
            Values[1] = Values[0] + 1 + random.Next() % 5;
            Values[2] = Values[1] + 1 + random.Next() % 5;
        }
    }
}
