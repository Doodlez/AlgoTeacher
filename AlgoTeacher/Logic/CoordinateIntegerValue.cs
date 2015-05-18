using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTeacher.Logic
{
    class CoordinateIntegerValue
    {
        private Coordinate _coordinate;
        private int _value;

        public CoordinateIntegerValue(Coordinate coordinate, int value)
        {
            _coordinate = coordinate;
            _value = value;
        }

        public Coordinate Coordinate
        {
            get { return _coordinate; }
        }

        public int Value
        {
            get { return _value; }
        }
    }
}
