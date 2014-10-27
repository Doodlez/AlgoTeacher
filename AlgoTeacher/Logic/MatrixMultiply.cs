using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTeacher.Logic.Quest;

namespace AlgoTeacher.Logic
{
    class MatrixMultiply
    {
        public event QuestEvents.QuestEventHandler questEvent;
        public event FillEvents.FillEventHandler fillEvent;

        public Matrix MatrixMult(Matrix matrix1, Matrix matrix2)
        {
            if ( matrix1.Columns != matrix2.Rows )
                return null;

            var coords = GetRandomCoords(matrix1.Rows, matrix2.Columns);

            var resultMatrix = new Matrix(matrix1.Rows, matrix2.Columns);
            for ( var i = 1; i <= matrix1.Rows; i++ )
            {
                for ( var j = 1; j <= matrix2.Columns; j++ )
                {
                    for ( var k = 1; k <= matrix1.Columns; k++ )
                    {
                        resultMatrix.Values[i][j] += matrix1.Values[i][k] * matrix2.Values[k][j];
                    }

                    var currentCoord = new Coordinate(i, j);

                    if ( Coordinate.DoesCoordinateExist(currentCoord, coords) )
                    {
                        var question = new IntegerValueQuest("MatrixQuestion",
                            QuestionGenerator.MatrixMultQuestion(i, j), resultMatrix.Values[i][j]);
                        questEvent(null, new QuestEvents.QuestEventArgs(question, currentCoord));
                    }
                    fillEvent(null, new FillEvents.FillEventArgs(currentCoord));
                }
            }

            return resultMatrix;
        }

        public static List<Coordinate> GetRandomCoords(int rows, int columns)
        {
            var coords = new List<Coordinate>();
            var random = new Random();

            coords.Add(new Coordinate(1, 1));

            for ( var i = 1; i <= Math.Min(2, columns - 1); i++ )
            {
                while ( true )
                {
                    var newCoord = new Coordinate(1, 2 + random.Next() % (columns - 1));
                    if ( Coordinate.DoesCoordinateExist(newCoord, coords) )
                    {
                        continue;
                    }
                    coords.Add(newCoord);
                    break;
                }
            }

            var cellsCount = (int) (rows * columns * 0.3);

            for ( var i = 1; i <= cellsCount; i++ )
            {
                while ( true )
                {
                    var newCoord = new Coordinate(2 + random.Next() % (rows - 1), 1 + random.Next() % columns);
                    if ( Coordinate.DoesCoordinateExist(newCoord, coords) )
                    {
                        continue;
                    }
                    coords.Add(newCoord);
                    break;
                }
            }

            return coords;
        }
    }
}
