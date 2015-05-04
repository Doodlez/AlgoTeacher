using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTeacher.Logic
{
    public class TransportTheory
    {
        public int n;
        public int m;
        private int[] give;
        public int[] currentGive;
        public int[] take;
        public int[] currentTake;
        public int[][] c;
        public int[][] x;
        public int[] u;
        public int[] v;
        public bool[] usedU;
        public bool[] usedV;
        public int[][] currentResult;
        public bool[][] basis;
        public int[][] s;
        public int[][] minus;
        public int row;
        public int column;
        public int changeRow;
        public int changeColumn;
        public int resultNum;
        public int minBasis;
        public int z;
        public int minEstimate;
        public int[] cycleX;
        public int[] cycleY;
        public bool globalDFS = false;
        public bool[][] closed;
        public int[][] owner;
        public bool[][] horizontal;
        public bool[][] vertical;

        public void Main() 
        {
            // Надо получить n, m
  
	        for (int i = 1; i <= n; i++)
	        {
		        // получить give[i]
		        currentGive[i] = give[i];    
	        }
  
	        for (int i = 1; i <= m; i++)
	        {
		        // получить take[i]
		        currentTake[i] = take[i];
	        }
  
	        for (int i = 1; i <= n; i++)
		        for (int j = 1; j <= m; j++)
			        // получить c[i][j]
    
	        NorthWest();
  
	        z = Costs();
  
	        while(true)
	        {
		        // Вывод z
		        for (int i = 1; i <= n; i++) {
			        for (int j = 1; j <= m; j++) {
				        // Вывод currentResult[i][j]
			        }
		        }

		        Potentials();
    
		        if (EstimateCheck())
		        {
			        break;
		        }
    
		        minEstimate = MinEstimate();
    
		        globalDFS = false;
		        closed[row][column] = true;
		        DFS(row, column, 1, 1, 1);
		        closed[row][column] = false;
    
		        minBasis = ChooseMinFromBasis(resultNum);
    
		        basis[changeRow][changeColumn] = false;
		        basis[row][column] = true;
    
		        currentResult[row][column] = minBasis;
    
		        for (int h = 2; h <= resultNum; h++)
		        {
			        int x = cycleX[h];
			        int y = cycleY[h];
      
			        if (h % 2 == 1)
			        {
				        currentResult[x][y] += minBasis;
			        }
			        else currentResult[x][y] -= minBasis;
		        }

		        z += minEstimate * minBasis;
	        }
        }

        private void DFS(int i, int j, int sign, int direct, int num)
        {
	        if (globalDFS)
	        {
		        return;
	        }
  
	        cycleX[num] = i;
	        cycleY[num] = j;
  
	        // По вертикали
	        if (direct == 1)
	        { 
		        for (int x = 1; x <= n; x++)
		        {
			        if (basis[x][j] && !IsInCycle(x, j, num) && (i != x))
			        {
				        if (globalDFS)
				        {
					        return;
				        }
	
				        if (!globalDFS)
				        {
					        if (!horizontal[x][j])
					        {
						        if (VerticalCheck(j, min(i, x), max(i, x), i))
						        {
							        CloseVerticalLine(j, min(i, x), max(i, x));
							        closed[x][j] = true;
							        DFS(x, j, -sign, 2, num + 1);
							        closed[x][j] = false;
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
		        for (int y = 1; y <= m; y++)
		        {
			        if (!basis[i][y] && (i == cycleX[1]) && (y == cycleY[1]) && (num > 1))
			        {
				        resultNum = num;
				        globalDFS = true;
	
				        return;
			        }
		        }
    
		        for (int y = 1; y <= m; y++)
		        {
			        if (basis[i][y] && !IsInCycle(i, y, num) && (j != y))
			        {
				        if (globalDFS)
				        {
					        return;
				        }
				        if (!globalDFS)
				        {
					        if (!vertical[i][y])
					        {
						        if (HorizontalCheck(i, min(j, y), max(j, y), j))
						        {
							        CloseHorizontalLine(i, min(j, y), max(j, y));
							        closed[i][y] = true;
							        DFS(i, y, -sign, 1, num + 1);
							        closed[i][y] = false;
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
		        if (horizontal[row][j] && (j != sourceCol))
		        {
			        return false;
		        }
    
		        if (closed[row][j] && (j != sourceCol))
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
		        if (vertical[i][col] && (i != sourceLine))
		        {
			        return false;
		        }
    
		        if (closed[i][col] && (i != sourceLine))
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
		        horizontal[row][j] = true;
	        }
        }

        private void OpenHorizontalLine(int row, int firstCol, int secondCol)
        {
	        for (int j = firstCol; j <= secondCol; j++)
	        {
		        horizontal[row][j] = false;
	        }
        }

        private void CloseVerticalLine(int column, int firstRow, int secondRow)
        {
	        for (int i = firstRow; i <= secondRow; i++)
	        {
		        vertical[i][column] = true;
	        }
        }

        private void OpenVerticalLine(int column, int firstRow, int secondRow)
        {
	        for (int i = firstRow; i <= secondRow; i++)
	        {
		        vertical[i][column] = false;
	        }
        }

        private int ChooseMinFromBasis(int num)
        {
            int min = int.MaxValue;
	        int x, y;
  
	        for (int i = 2; i <= num; i += 2)
	        {
		        x = cycleX[i];
		        y = cycleY[i];
    
		        if (currentResult[x][y] < min)
		        {
			        changeRow = x;
			        changeColumn = y;
			        min = currentResult[x][y];
		        }
	        }
  
	        return min;
        }

        bool IsInCycle(int i, int j, int num)
        {
	        for (int v = 1; v <= num; v++)
	        {
		        if ((cycleX[v] == i) && (cycleY[v] == j))
		        {
			        return true;
		        }
	        }
  
	        return false;
        }

        private void NorthWest() 
        {
	        int r = 1, s = 1;
  
	        while ((r <= n) && (s <= m))
	        {
		        basis[r][s] = true;
    
		        currentResult[r][s] = min(currentGive[r], currentTake[s]);
    
		        currentGive[r] -= currentResult[r][s];
		        currentTake[s] -= currentResult[r][s];
    
		        if (currentGive[r] == 0)
			        r++;
		        else
			        s++;
	        }
        }
 
        private int Costs() 
        {
	        int res = 0;
  
	        for (int i = 1; i <= n; i++)
		        for (int j = 1; j <= m; j++)
			        if (basis[i][j])
				        res += currentResult[i][j] * c[i][j];
      
	        return res;
        }
 
        private void Potentials() 
        {
	        for (int i = 1; i <= n; i++)
		        usedU[i] = false;
  
	        for (int j = 1; j <= m; j++)
		        usedV[j] = false;
  
	        u[1] = 0;
	        usedU[1] = true;
  
	        while (!PotentialsCheck())
	        {
		        for (int i = 1; i <= n; i++)
			        for (int j = 1; j <= m; j++)
			        {
				        if (basis[i][j])
				        {
					        if (usedU[i])
					        {
						        v[j] = c[i][j] - u[i];
						        usedV[j] = true; 
					        }
		  
					        if (usedV[j])
					        {
						        u[i] = c[i][j] - v[j];
						        usedU[i] = true;
					        }
				        }
			        }
	        }
    
	        for (int i = 1; i <= n; i++)
	        {
		        for (int j = 1; j <= m; j++)
		        {
			        if (!basis[i][j])
			        {
				        s[i][j] = c[i][j] - u[i] - v[j];
			        }
			        else s[i][j] = 0;
		        }
	        }
        }

        private bool PotentialsCheck()
        {
	        for (int i = 1; i <= n; i++)
		        if (!usedU[i])
			        return false;
    
	        for (int j = 1; j <= m; j++)
		        if (!usedV[j])
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
	        for (int i = 1; i <= n; i++)
	        {
		        for (int j = 1; j <= m; j++)
		        {
			        if (!basis[i][j])
			        {
				        if (s[i][j] < 0)
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
  
	        for (int i = 1; i <= n; i++)
	        {
		        for (int j = 1; j <= m; j++)
		        {
			        if (!basis[i][j])
			        {
				        if (s[i][j] < min)
				        {
					        min = s[i][j];
					        row = i;
					        column = j;
				        }
			        }
		        }
	        }
  
	        return min;
        }
    }
}
