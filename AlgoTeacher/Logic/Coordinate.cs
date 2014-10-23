using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTeacher.Logic
{
    public class Coordinate
    {
        private int _x;
        private int _y;

        public Coordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get
            {
                return _x;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
        }

        public static bool DoesCoordinateExist(Coordinate coordinate, List<Coordinate> coordinateList)
        {
            return coordinateList.Any(coord => (coordinate.X == coord.X) && (coordinate.Y == coord.Y));
        }
    }
}
