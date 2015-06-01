using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTeacher.Logic.Quest;

namespace AlgoTeacher.Logic
{
    public class TransportTask
    {
        public const int N = 50;

        public int NumberOfGivers;
        public int NumberOfTakers;
        public int[] NeedsOfGivers = new int[N];
        public int[] NeedsOfTakers = new int[N];
        public MyMatrix Prices;
        public int[] PotentialsOfGivers = new int[N];
        public int[] PotentialsOfTakers = new int[N];
        public bool[] UsedPotentialsOfGivers = new bool[N];
        public bool[] UsedPotentialsOfTakers = new bool[N];
        public int[][] CurrentResult = new int[N][];
        public bool[][] Basis = new bool[N][];
        public int[][] S = new int[N][];
        public int Row;
        public int Column;
        public int ChangeRow;
        public int ChangeColumn;
        public int ResultNum;
        public int MinBasis;
        public int BestResult;
        public int MinimalEstimate;
        public int[] CycleX = new int[N];
        public int[] CycleY = new int[N];
        public bool GlobalDFS = false;
        public bool[][] Closed = new bool[N][];
        public int[][] Owner = new int[N][];
        public bool[][] Horizontal = new bool[N][];
        public bool[][] Vertical = new bool[N][];

        public event QuestEvents.QuestEventHandler questEvent;
        public event FillEvents.FillEventHandler fillEvent;
        public string _language;

        public TransportTask(int numberOfGivers, int numberOfTakers, int[] needsOfGivers, int[] needsOfTakers, MyMatrix pricesMatrix, string langluage)
        {
            _language = langluage;
            NumberOfGivers = numberOfGivers;
            NumberOfTakers = numberOfTakers;

            for (var i = 1; i <= numberOfGivers; i++)
            {
                NeedsOfGivers[i] = needsOfGivers[i - 1];
            }

            for (var i = 1; i <= numberOfTakers; i++)
            {
                NeedsOfTakers[i] = needsOfTakers[i - 1];
            }

            Prices = pricesMatrix;

            for (int i = 0; i < N; i++)
            {
                Basis[i] = new bool[N];
                CurrentResult[i] = new int[N];
                S[i] = new int[N];
                Closed[i] = new bool[N];
                Owner[i] = new int[N];
                Horizontal[i] = new bool[N];
                Vertical[i] = new bool[N];
            }
        }

        public static int[] GetGiversTakers(int lowerLimit, int upperLimit)
        {
            int[] result = new int[2];
            var random = new Random();

            result[0] = random.Next(lowerLimit, upperLimit);
            result[1] = random.Next(lowerLimit, upperLimit);

            return result;
        }

        public static int[][] GetRandomNeeds(int givers, int takers)
        {
            int[][] result = new int[2][];

            result[0] = new int[givers];
            result[1] = new int[takers];

            var random = new Random();
            int giversLimit = 8 - givers;
            int takersLimit = 8 - takers;

            int giversSum = 0, takersSum = 0;

            for (int i = 0; i < givers; i++)
            {
                result[0][i] = random.Next(1, giversLimit + 1) * 10;
                giversSum += result[0][i];
            }

            for (int i = 0; i < takers; i++)
            {
                result[1][i] = random.Next(1, takersLimit + 1) * 10;
                takersSum += result[1][i];
            }

            if (giversSum != takersSum)
            {
                int arrayIndex;
                int abs = Math.Abs(giversSum - takersSum);

                if (giversSum > takersSum)
                    arrayIndex = 0;
                else
                    arrayIndex = 1;

                while (abs > 0)
                {
                    int index = MinArrayElement(result[arrayIndex]);
                    result[arrayIndex][index] -= 10;
                    abs -= 10;
                }
            }
            
            return result;
        }

        private static int MinArrayElement(int[] arr)
        {
            int maxValue = int.MinValue;
            int index = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                    index = i;
                }
            }

            return index;
        }

        public int Main() 
        {
	        NorthWest();
  
	        BestResult = Costs();
  
	        while(true)
	        {
		        Potentials();
    
		        if (EstimateCheck())
		        {
		            return BestResult;
		        }
    
                // спрашиваем про минимальное значение S
		        MinimalEstimate = MinEstimate();

                var minEstimateCoord = new Coordinate(Row, Column);
                var minEstimateQuestion = new IntegerValueQuest("Transport question",
                                                     QuestionGenerator.TransportTaskQuestion(_language),
                                                     MinimalEstimate);
                questEvent(null, new QuestEvents.QuestEventArgs(minEstimateQuestion, minEstimateCoord));

                for (int i = 1; i <= NumberOfGivers; i++)
                {
                    for (int j = 1; j <= NumberOfTakers; j++)
                    {
                        if (i != Row || j != Column)
                        {
                            var estimateCoord = new Coordinate(i, j);
                            fillEvent(null, new FillEvents.FillEventArgs(estimateCoord, MinimalEstimate.ToString(CultureInfo.InvariantCulture)));
                        }
                    }
                }

                GlobalDFS = false;
		        Closed[Row][Column] = true;
		        DFS(Row, Column, 1, 1, 1);
		        Closed[Row][Column] = false;
    
		        MinBasis = ChooseMinFromBasis(ResultNum);

                var minBasisCoord = new Coordinate(Row, Column);
                var minBasisQuestion = new IntegerValueQuest("Transport question",
                                                     QuestionGenerator.TransportTaskQuestion(_language),
                                                     MinBasis);
                questEvent(null, new QuestEvents.QuestEventArgs(minBasisQuestion, minBasisCoord));
    
		        Basis[ChangeRow][ChangeColumn] = false;
		        Basis[Row][Column] = true;
    
		        CurrentResult[Row][Column] = MinBasis;

	            int counter = 1;
		        for (int h = 2; h <= ResultNum; h++)
		        {
			        int x = CycleX[h];
			        int y = CycleY[h];
      
			        if (h % 2 == 1)
			        {
				        CurrentResult[x][y] += MinBasis;
			        }
			        else CurrentResult[x][y] -= MinBasis;

		            var basisCoord = new Coordinate(x, y);
                    if ( counter < 3 )
                    {
                        var basisQuestion = new IntegerValueQuest("Transport question",
                                                             QuestionGenerator.TransportTaskQuestion(_language),
                                                             CurrentResult[x][y]);
                        questEvent(null, new QuestEvents.QuestEventArgs(basisQuestion, basisCoord));
                    }
                    else
                    {
                        fillEvent(null, new FillEvents.FillEventArgs(basisCoord, CurrentResult[x][y].ToString(CultureInfo.InvariantCulture)));
                    }

		            ++counter;
		        }

		        BestResult += MinimalEstimate * MinBasis;
	        }
        }

        private void DFS(int i, int j, int sign, int direct, int num)
        {
	        if (GlobalDFS)
	        {
		        return;
	        }
  
	        CycleX[num] = i;
	        CycleY[num] = j;
  
	        // По вертикали
	        if (direct == 1)
	        { 
		        for (int x = 1; x <= NumberOfGivers; x++)
		        {
			        if (Basis[x][j] && !IsInCycle(x, j, num) && (i != x))
			        {
				        if (GlobalDFS)
				        {
					        return;
				        }
	
				        if (!GlobalDFS)
				        {
					        if (!Horizontal[x][j])
					        {
						        if (VerticalCheck(j, min(i, x), max(i, x), i))
						        {
							        CloseVerticalLine(j, min(i, x), max(i, x));
							        Closed[x][j] = true;
							        DFS(x, j, -sign, 2, num + 1);
							        Closed[x][j] = false;
							        OpenVerticalLine(j, min(i, x), max(i, x));
						        }
					        }
				        }
			        }
		        }
	        }
  
	        // По горизонтали
	        if (direct == 2)
	        {
		        for (int y = 1; y <= NumberOfTakers; y++)
		        {
			        if (!Basis[i][y] && (i == CycleX[1]) && (y == CycleY[1]) && (num > 1))
			        {
				        ResultNum = num;
				        GlobalDFS = true;
	
				        return;
			        }
		        }
    
		        for (int y = 1; y <= NumberOfTakers; y++)
		        {
			        if (Basis[i][y] && !IsInCycle(i, y, num) && (j != y))
			        {
				        if (GlobalDFS)
				        {
					        return;
				        }
				        if (!GlobalDFS)
				        {
					        if (!Vertical[i][y])
					        {
						        if (HorizontalCheck(i, min(j, y), max(j, y), j))
						        {
							        CloseHorizontalLine(i, min(j, y), max(j, y));
							        Closed[i][y] = true;
							        DFS(i, y, -sign, 1, num + 1);
							        Closed[i][y] = false;
							        OpenHorizontalLine(i, min(j, y), max(j, y));
						        }
					        }
				        }
			        }
		        }
	        }
        }

        private bool HorizontalCheck(int row, int firstCol, int secondCol, int sourceCol)
        {
	        for (int j = firstCol; j <= secondCol; j++)
	        {
		        if (Horizontal[row][j] && (j != sourceCol))
		        {
			        return false;
		        }
    
		        if (Closed[row][j] && (j != sourceCol))
		        {
			        return false;
		        }
	        }
  
	        return true;
        }

        private bool VerticalCheck(int col, int firstRow, int secondRow, int sourceLine)
        {
	        for (int i = firstRow; i <= secondRow; i++)
	        {
		        if (Vertical[i][col] && (i != sourceLine))
		        {
			        return false;
		        }
    
		        if (Closed[i][col] && (i != sourceLine))
		        {
			        return false;
		        }
	        }
  
	        return true;
        }

        private void CloseHorizontalLine(int row, int firstCol, int secondCol)
        {
	        for (int j = firstCol; j <= secondCol; j++)
	        {
		        Horizontal[row][j] = true;
	        }
        }

        private void OpenHorizontalLine(int row, int firstCol, int secondCol)
        {
	        for (int j = firstCol; j <= secondCol; j++)
	        {
		        Horizontal[row][j] = false;
	        }
        }

        private void CloseVerticalLine(int column, int firstRow, int secondRow)
        {
	        for (int i = firstRow; i <= secondRow; i++)
	        {
		        Vertical[i][column] = true;
	        }
        }

        private void OpenVerticalLine(int column, int firstRow, int secondRow)
        {
	        for (int i = firstRow; i <= secondRow; i++)
	        {
		        Vertical[i][column] = false;
	        }
        }

        private int ChooseMinFromBasis(int num)
        {
            int min = int.MaxValue;
	        int x, y;
  
	        for (int i = 2; i <= num; i += 2)
	        {
		        x = CycleX[i];
		        y = CycleY[i];
    
		        if (CurrentResult[x][y] < min)
		        {
			        ChangeRow = x;
			        ChangeColumn = y;
			        min = CurrentResult[x][y];
		        }
	        }
  
	        return min;
        }

        bool IsInCycle(int i, int j, int num)
        {
	        for (int v = 1; v <= num; v++)
	        {
		        if ((CycleX[v] == i) && (CycleY[v] == j))
		        {
			        return true;
		        }
	        }
  
	        return false;
        }

        public void NorthWest()
        {
	        int r = 1, s = 1;
            int counter = 0;
  
	        while ((r <= NumberOfGivers) && (s <= NumberOfTakers))
	        {
		        Basis[r][s] = true;
    
		        CurrentResult[r][s] = min(NeedsOfGivers[r], NeedsOfTakers[s]);

                // TODO: добавить fillEvent
                // вызываем только тогда, когда значение в базисной клетке больше нуля.
                if (CurrentResult[r][s] > 0)
                {
                    var currentCoord = new Coordinate(r, s);
                    var question = new IntegerValueQuest("Transport question",
                                                         QuestionGenerator.TransportTaskQuestion(_language),
                                                         CurrentResult[r][s]);
                    if (counter < 3)
                    {
                        questEvent(null, new QuestEvents.QuestEventArgs(question, currentCoord));
                    }
                    else
                    {
                        fillEvent(null, new FillEvents.FillEventArgs(currentCoord, CurrentResult[r][s].ToString(CultureInfo.InvariantCulture)));   
                    }

                    ++counter;
                }
    
		        NeedsOfGivers[r] -= CurrentResult[r][s];
		        NeedsOfTakers[s] -= CurrentResult[r][s];
    
		        if (NeedsOfGivers[r] == 0)
			        r++;
		        else
			        s++;
	        }
        }
 
        private int Costs() 
        {
	        int res = 0;

            for ( int i = 1; i <= NumberOfGivers; i++ )
                for ( int j = 1; j <= NumberOfTakers; j++ )
                    if (Basis[i][j])
                        res += CurrentResult[i][j] * Prices.Values[i - 1][j - 1];
      
	        return res;
        }
 
        private void Potentials() 
        {
	        for (int i = 1; i <= NumberOfGivers; i++)
		        UsedPotentialsOfGivers[i] = false;
  
	        for (int j = 1; j <= NumberOfTakers; j++)
		        UsedPotentialsOfTakers[j] = false;
  
	        PotentialsOfGivers[1] = 0;
	        UsedPotentialsOfGivers[1] = true;

            int counter = 0;
  
	        while (!PotentialsCheck())
	        {
		        for (int i = 1; i <= NumberOfGivers; i++)
                {
                    for ( int j = 1; j <= NumberOfTakers; j++ )
                    {
                        if ( Basis[i][j] )
                        {
                            if ( UsedPotentialsOfGivers[i] )
                            {
                                PotentialsOfTakers[j] = Prices.Values[i - 1][j - 1] - PotentialsOfGivers[i];

                                var question = new IntegerValueQuest("Transport question",
                                    QuestionGenerator.TransportTaskQuestion(_language),
                                    PotentialsOfTakers[j]);

                                int x = NumberOfGivers + 1;
                                int y = j;
                                var currentCoord = new Coordinate(x, y);

                                if ( counter < 3 )
                                {
                                    questEvent(null, new QuestEvents.QuestEventArgs(question, currentCoord));
                                }
                                else
                                {
                                    fillEvent(null, new FillEvents.FillEventArgs(currentCoord, PotentialsOfTakers[j]
                                        .ToString(CultureInfo.InvariantCulture)));
                                }

                                UsedPotentialsOfTakers[j] = true;
                                ++counter;
                            }

                            if ( UsedPotentialsOfTakers[j] )
                            {
                                PotentialsOfGivers[i] = Prices.Values[i - 1][j - 1] - PotentialsOfTakers[j];

                                var question = new IntegerValueQuest("Transport question",
                                    QuestionGenerator.TransportTaskQuestion(_language),
                                    PotentialsOfGivers[i]);

                                int x = i;
                                int y = NumberOfTakers + 1;
                                var currentCoord = new Coordinate(x, y);

                                if ( counter < 3 )
                                {
                                    questEvent(null, new QuestEvents.QuestEventArgs(question, currentCoord));
                                }
                                else
                                {
                                    fillEvent(null, new FillEvents.FillEventArgs(currentCoord, PotentialsOfGivers[i].
                                        ToString(CultureInfo.InvariantCulture)));
                                }

                                UsedPotentialsOfGivers[i] = true;
                                ++counter;
                            }
                        }
                    }   
		        }
	        }
    
	        SValues();
        }

        private bool PotentialsCheck()
        {
	        for (int i = 1; i <= NumberOfGivers; i++)
		        if (!UsedPotentialsOfGivers[i])
			        return false;
    
	        for (int j = 1; j <= NumberOfTakers; j++)
		        if (!UsedPotentialsOfTakers[j])
			        return false;
    
	        return true;
        }

        private void SValues()
        {
            for ( int i = 1; i <= NumberOfGivers; i++ )
            {
                for ( int j = 1; j <= NumberOfTakers; j++ )
                {
                    if ( !Basis[i][j] )
                    {
                        S[i][j] = Prices.Values[i - 1][j - 1] - PotentialsOfGivers[i] - PotentialsOfTakers[j];
                    }
                    else
                        S[i][j] = 0;
                }
            }
        }

        private int min(int a, int b) 
        {
	        if (a < b)
		        return a;
  
	        return b;
        }

        private int max(int a, int b) 
        {
	        if (a > b)
		        return a;
  
	        return b;
        }

        private bool EstimateCheck()
        {
	        for (int i = 1; i <= NumberOfGivers; i++)
	        {
		        for (int j = 1; j <= NumberOfTakers; j++)
		        {
			        if (!Basis[i][j])
			        {
				        if (S[i][j] < 0)
				        {
					        return false;
				        }
			        }
		        }
	        }
  
	        return true;
        }

        private int MinEstimate()
        {
            int min = int.MaxValue;
  
	        for (int i = 1; i <= NumberOfGivers; i++)
	        {
		        for (int j = 1; j <= NumberOfTakers; j++)
		        {
			        if (!Basis[i][j])
			        {
				        if (S[i][j] < min)
				        {
					        min = S[i][j];
					        Row = i;
					        Column = j;
				        }
			        }
		        }
	        }
  
	        return min;
        }
    }
}
