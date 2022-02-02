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
            int rows = matrix.Length, cols = matrix[0].Length;
            int[,] dp = new int[rows, cols];
            int maxsqlen = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        if (matrix[i][j] == '1')
                            dp[i, j] = 1;
                    }
                    else
                    {
                        if (matrix[i][j] == '1')
                        {
                            dp[i, j] = Math.Min(Math.Min(dp[i, j - 1], dp[i - 1, j]), dp[i - 1, j - 1]) + 1;
                        }
                    }
                    maxsqlen = Math.Max(maxsqlen, dp[i, j]);
                }
            }
            return maxsqlen * maxsqlen;
        }
    }
}
