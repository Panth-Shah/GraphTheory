using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGrapthProblems
{
    //Problem# 1770
    public class MaxScoreFromMultiplicationOps
    {
        public int maximumScore(int[] nums, int[] multipliers)
        {
            int n = nums.Length;
            int m = multipliers.Length;
            int[,] dp = new int[m + 1,m + 1];

            for (int i = m - 1; i >= 0; i--)
            {
                for (int left = i; left >= 0; left--)
                {
                    int mult = multipliers[i];
                    int right = n - 1 - (i - left);
                    dp[i,left] = Math.Max(mult * nums[left] + dp[i + 1,left + 1],
                                           mult * nums[right] + dp[i + 1,left]);
                
                }
            }

            return dp[0,0];
        }

        static void Main(string[] args)
        {
            MaxScoreFromMultiplicationOps maxSumOps = new MaxScoreFromMultiplicationOps();
            maxSumOps.maximumScore(new int[] { 1,2,3}, new int[]{3,2,1});
        }
    }
}
