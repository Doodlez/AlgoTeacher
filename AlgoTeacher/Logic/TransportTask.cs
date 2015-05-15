using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTeacher.Logic
{
    public class TransportTask
    {
        public int NumberOfGivers;
        public int NumberOfTakers;
        public int[] NeedsOfGivers;
        public int[] NeedsOfTakers;
        public Matrix Prices;
        public int[] PotentialsOfGivers;
        public int[] PotentialsOfTakers;
        public bool[] UsedPotentialsOfGivers;
        public bool[] UsedPotentialsOfTakers;
        public int[][] CurrentResult;
        public bool[][] Basis;
        public int[][] S;
        public int Row;
        public int Column;
        public int ChangeRow;
        public int ChangeColumn;
        public int ResultNum;
        public int MinBasis;
        public int BestResult;
        public int MinimalEstimate;
        public int[] CycleX;
        public int[] CycleY;
        public bool GlobalDFS = false;
        public bool[][] Closed;
        public int[][] Owner;
        public bool[][] Horizontal;
        public bool[][] Vertical;

        public TransportTask(int numberOfGivers, int numberOfTakers, int[] needsOfGivers, int[] needsOfTakers, Matrix pricesMatrix)
        {
            NumberOfGivers = numberOfGivers;
            NumberOfTakers = numberOfTakers;
            NeedsOfGivers = needsOfGivers;
            NeedsOfTakers = needsOfTakers;
            Prices = pricesMatrix;
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

            for (int i = 0; i < givers; i++)
            {
                result[0][i] = random.Next(1, giversLimit + 1) * 10;
                result[1][i] = random.Next(1, takersLimit + 1) * 10;
            }

            return result;
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
    
		        MinimalEstimate = MinEstimate();
    
		        GlobalDFS = false;
		        Closed[Row][Column] = true;
		        DFS(Row, Column, 1, 1, 1);
		        Closed[Row][Column] = false;
    
		        MinBasis = ChooseMinFromBasis(ResultNum);
    
		        Basis[ChangeRow][ChangeColumn] = false;
		        Basis[Row][Column] = true;
    
		        CurrentResult[Row][Column] = MinBasis;
    
		        for (int h = 2; h <= ResultNum; h++)
		        {
			        int x = CycleX[h];
			        int y = CycleY[h];
      
			        if (h % 2 == 1)
			        {
				        CurrentResult[x][y] += MinBasis;
			        }
			        else CurrentResult[x][y] -= MinBasis;
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

        private void NorthWest() 
        {
	        int r = 1, s = 1;
  
	        while ((r <= NumberOfGivers) && (s <= NumberOfTakers))
	        {
		        Basis[r][s] = true;
    
		        CurrentResult[r][s] = min(NeedsOfGivers[r], NeedsOfTakers[s]);
    
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
  
	        while (!PotentialsCheck())
	        {
		        for (int i = 1; i <= NumberOfGivers; i++)
			        for (int j = 1; j <= NumberOfTakers; j++)
			        {
				        if (Basis[i][j])
				        {
					        if (UsedPotentialsOfGivers[i])
					        {
						        PotentialsOfTakers[j] = Prices.Values[i - 1][j - 1] - PotentialsOfGivers[i];
						        UsedPotentialsOfTakers[j] = true; 
					        }
		  
					        if (UsedPotentialsOfTakers[j])
					        {
						        PotentialsOfGivers[i] = Prices.Values[i - 1][j - 1] - PotentialsOfTakers[j];
						        UsedPotentialsOfGivers[i] = true;
					        }
				        }
			        }
	        }
    
	        for (int i = 1; i <= NumberOfGivers; i++)
	        {
		        for (int j = 1; j <= NumberOfTakers; j++)
		        {
			        if (!Basis[i][j])
			        {
				        S[i][j] = Prices.Values[i - 1][j - 1] - PotentialsOfGivers[i] - PotentialsOfTakers[j];
			        }
			        else S[i][j] = 0;
		        }
	        }
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
