using System;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxDifficultyJobSchedule maxJobSchedule = new MaxDifficultyJobSchedule();
            maxJobSchedule.maxDifficulty(new int[] { 6,5,10,3,2,1}, 3);
        }
    }
}
