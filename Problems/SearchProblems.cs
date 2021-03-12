using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class SearchProblems
    {
        /*
         * Revenue Milestones
            We keep track of the revenue Facebook makes every day, and we want to know on what days Facebook hits certain revenue milestones. Given an array of the revenue on each day, and an array of milestones Facebook wants to reach, return an array containing the days on which Facebook reached every milestone.
            Signature
            int[] getMilestoneDays(int[] revenues, int[] milestones)
            Input
            revenues is a length-N array representing how much revenue FB made on each day (from day 1 to day N). milestones is a length-K array of total revenue milestones.
            Output
            Return a length-K array where K_i is the day on which FB first had milestones[i] total revenue.
            Example
            revenues = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100]
            milestones = [100, 200, 500]
            output = [4, 6, 10]
            Explanation
            On days 4, 5, and 6, FB has total revenue of $100, $150, and $210 respectively. Day 6 is the first time that FB has >= $200 of total revenue.
         */
        public static int[] getMilestoneDays(int[] revenues, int[] milestones)
        {
            int[] mileStoneHitDays = new int[milestones.Length];
            for(var i=0; i < milestones.Length; i++)
            {
                var day = getIndexMileStoneIsHit(revenues, milestones[i]);
                mileStoneHitDays[i] = day + 1;
            }
            // Write your code here
            return mileStoneHitDays;
        }

        /*
         * 1 Billion Users
            We have N different apps with different user growth rates. At a given time t, measured in days, the number of users using an app is g^t (for simplicity we'll allow fractional users), where g is the growth rate for that app. These apps will all be launched at the same time and no user ever uses more than one of the apps.
            After how many full days will we have 1 billion total users across the N apps?
            Signature
            int getBillionUsersDay(float[] growthRates)
            Input
            1.0 < growthRate < 2.0 for all growth rates
            1 <= N <= 1,000
            Output
            Return the number of full days it will take before we have a total of 1 billion users across all N apps.
            Example 1
            growthRates = [1.5]
            output = 52
            Example 2
            growthRates = [1.1, 1.2, 1.3]
            output = 79
            Example 3
            growthRates = [1.01, 1.02]
            output = 1047
         */

        public static int getBillionUsersDay(double[] growthRates)
        {
            // Write your code here
            int days = 0;
            const int billion = 1000000000;
            double totalusers = 0;
            while(totalusers < billion)
            {
                totalusers = 0;
                days++;
                for (var i = 0; i < growthRates.Length; i++)
                {
                    totalusers += Math.Pow(growthRates[i], days);
                }
                
            }
            return days;
        }

        private static int getIndexMileStoneIsHit(int[] revenues, int mileStone)
        {
            int sum = 0;
            for(var i =0; i < revenues.Length; i++)
            {
                sum += revenues[i];
                if(sum >= mileStone)
                {
                    //revenue hit
                    return i;
                }
            }
            return -1;
        }

    }
}
