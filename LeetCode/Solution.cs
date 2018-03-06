using System;
using System.Collections.Generic;

namespace LeetCode
{
    class Solution
    {
        #region RemoveDuplicates

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }

        #endregion

        #region RemoveDuplicates II

        public int RemoveDuplicates2(int[] nums)
        {
            int i = 0;
            foreach (var num in nums)
            {
                if (i < 2 || num > nums[i - 2])
                    nums[i++] = num;
            }
            return i;
        }

        #endregion

        #region LongestConsecutive

        public int LongestConsecutive(int[] nums)
        {
            var numSet = new HashSet<int>(nums);

            int longestStreak = 0;

            foreach (int num in numSet)
            {
                if (!numSet.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;

                    while (numSet.Contains(currentNum + 1))
                    {
                        currentNum += 1;
                        currentStreak += 1;
                    }

                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }

            return longestStreak;
        }

        #endregion

        #region TwoSum

        public int[] TwoSum(int[] nums, int target)
        {
            int first, sencond;
            for (int i = 0; i < nums.Length; i++)
            {
                first = nums[i];
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j)
                    {
                        sencond = nums[j];
                        if (first + sencond == target)
                        {
                            return new int[] { i, j };
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
