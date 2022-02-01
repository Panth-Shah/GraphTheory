using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGrapthProblems
{
    public class MaximalSquare
    {
        public int maximalSquare(char[][] matrix)
        {
            int row = matrix.Length;
            int column = row > 0 ? matrix[0].Length : 0;

            int[,] dp = new int[row + 1, column + 1];
            int maxSqLen = 0;
            for (int i = 1; i <= row; i++)
            {
                for (int j = 1; j <= column; j++)
                {
                    //If current element is 1, identify if this element is a part of a square else single square
                    if (matrix[i-1][j-1] == '1')
                    {
                        dp[i, j] = Math.Min(Math.Min(dp[i-1,j], dp[i-1,j-1]), dp[i, j-1]) + 1;
                        maxSqLen = Math.Max(maxSqLen, dp[i, j]);
                    }
                }
            }
            //Return area
            return maxSqLen * maxSqLen;
        }
    }
}
