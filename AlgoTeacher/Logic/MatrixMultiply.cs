using System;
using System.Collections.Generic;
using System.Globalization;
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
            if ( matrix1.ColumnsCount != matrix2.RowsCount )
                return null;

            var coords = GetRandomCoords(matrix1.RowsCount, matrix2.ColumnsCount);

            var resultMatrix = new Matrix(matrix1.RowsCount, matrix2.ColumnsCount);
            for ( var i = 0; i < matrix1.RowsCount; i++ )
            {
                for ( var j = 0; j < matrix2.ColumnsCount; j++ )
                {
                    for ( var k = 0; k < matrix1.ColumnsCount; k++ )
                    {
                        resultMatrix.Values[i][j] += matrix1.Values[i][k] * matrix2.Values[k][j];
                    }

                    var currentCoord = new Coordinate(i+1, j+1);

                    if (Coordinate.DoesCoordinateExist(currentCoord, coords))
                    {
                        var question = new IntegerValueQuest("MatrixQuestion",
                                                             QuestionGenerator.MatrixMultQuestion(i+1, j+1),
                                                             resultMatrix.Values[i][j]);
                        questEvent(null, new QuestEvents.QuestEventArgs(question, currentCoord));
                    }
                    else
                    {
                        fillEvent(null, new FillEvents.FillEventArgs(currentCoord, resultMatrix.Values[i][j].ToString(CultureInfo.InvariantCulture)));
                    }
                    
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
