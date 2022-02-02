using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class MaxDifficultyJobSchedule
    {

        //TopDownApproach
        //In this problem, we have # of job Difficulty and total n number of jobs
        //We have d number of days and need to schedule atleast one job in one day
        //State Variables: i = Current Job & day = Current number of day from total number of days d

        private int n, d;
        private int[,] memo;
        private int[] jobDifficulty;
        private int[] hardestJobRemaining;

        #region Top Down Solution
        public int maxDifficultyTopDown(int[] jobDifficulty, int d)
        {
            int n = jobDifficulty.Length;
            if (n < d)
            {
                return -1;
            }

            hardestJobRemaining = new int[n];
            int hardestJob = 0;
            //precompulte hardest job remaining
            for (int i = n - 1; i >= 0; i--)
            {
                hardestJob = Math.Max(hardestJob, jobDifficulty[i]);
                hardestJobRemaining[i] = hardestJob;
            }

            //Initialize memoization matrix to store computed state values for lookup
            memo = new int[n, d+1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= d; j++ )
                {
                    memo[i, j] = -1;
                }
            }


            this.d = d;
            this.jobDifficulty = jobDifficulty;
            return dp(0,1);
        }

        private int dp(int jobDifficultyIndex, int currentDay)
        {
            //Base case, if currentDay == d, return precomputed value of Max difficulty job compeletd per day
            if (currentDay == d)
                return hardestJobRemaining[jobDifficultyIndex];

            if (memo[jobDifficultyIndex, currentDay] == -1)
            {
                int best = int.MaxValue;
                int hardest = 0; //Indecate hardest Job schedule to complete in currentDay

                //Iterate through all the allowable jobs to be schedule for current day, which can be calculated by 
                //TotalNumberOfJobs - (TotalDays - CurrentDay)
                for (int j = jobDifficultyIndex; j < jobDifficulty.Length - (d - currentDay); j++)
                {
                    //Find hardest job to schedule from alloable jobs to be scheduled in this current Day
                    hardest = Math.Max(hardest, jobDifficulty[j]);

                    //Reccurence Relationship
                    best = Math.Min(best, hardest + dp(j + 1, currentDay + 1));
                }
                memo[jobDifficultyIndex, currentDay] = best; 
            }

            return memo[jobDifficultyIndex, currentDay];
        }
        #endregion

        #region Bottom Top Solution
        public class Solution
        {
            public int MinDifficulty(int[] jobDifficulty, int d)
            {
                int n = jobDifficulty.Length;
                //Boundary check
                if (d > n)
                    return -1;
                //Initialize DP matrix to store state variables i = current job index & day = current day from d days
                int[,] dp = new int[n, d + 1];

                //Fill entire DP array with Int.Max value
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < d + 1; j++)
                    {
                        dp[i, j] = int.MaxValue;
                    }
                }

                //Base Case where Last job has to be scheduled on Last Day
                dp[n - 1, d] = jobDifficulty[n - 1];

                //All the jobs should have been scheduled on Last Day
                //Fill day d and identify Max JobDifficulty job to be scheduled on last day d
                for (int i = n - 2; i >= 0; i--)
                    dp[i, d] = Math.Max(dp[i + 1, d], jobDifficulty[i]);

                //Start to iterate through all the remaining days and calculate minimum job difficulty of job schedule
                for (int day = d - 1; day > 0; day--)
                {
                    //No need to calculate dp[0,1], dp[0,2] or dp[1,2] as each day minimum 1 job has to be scheduled and so start iterating from day - 1
                    //Maximum job to be scheduled each day is n - (d - day)
                    for (int i = day - 1; i < n - (d - day); i++)
                    {
                        //Capture hardest job to schedule on current day to calculate maximum job schedule difficulty for current day
                        int hardest = 0;
                        //Iterate each possible job to schedule on current day
                        for (int j = i; j < n - (d - day); j++)
                        {
                            hardest = Math.Max(hardest, jobDifficulty[j]);
                            dp[i, day] = Math.Min(dp[i, day], hardest + dp[j + 1, day + 1]);
                        }
                    }
                }
                return dp[0, 1];
            }
        }
        #endregion

    }
}
