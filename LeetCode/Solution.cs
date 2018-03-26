using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Solution
    {
        #region Remove Duplicates from Sorted Array

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                //不重复的话，有效索引+1，将当前元素值记录在索引对应的数组上
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }

        #endregion

        #region Remove Duplicates from Sorted Array II

        public int RemoveDuplicates2(int[] nums)
        {
            int i = 0;
            foreach (var num in nums)
            {
                //判断是否有2个以上重复，有的话有效索引+1，并将当前元素赋值到有效数组
                if (i < 2 || num > nums[i - 2])
                    nums[i++] = num;
            }
            return i;
        }

        #endregion

        #region Longest Consecutive Sequence

        public int LongestConsecutive(int[] nums)
        {
            var numSet = new HashSet<int>(nums);
            //记录最大连续元素个数
            int longestStreak = 0;

            foreach (int num in numSet)
            {
                //存在跟当前元素连续的值
                if (!numSet.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;

                    //每匹配到后面连续的元素，当前最大连续元素个数+1
                    while (numSet.Contains(currentNum + 1))
                    {
                        currentNum += 1;
                        currentStreak += 1;
                    }

                    //最大连续元素个数取当前最大连续元素和记录的最大连续元素个数两者最大者
                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }

            return longestStreak;
        }

        #endregion

        #region Two Sum

        public int[] TwoSum(int[] nums, int target)
        {
            var map = new Hashtable(); ;
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                //匹配成功，返回结果
                if (map.ContainsKey(complement))
                {
                    return new int[] { (int)map[complement], i };
                }
                map.Add(nums[i], i);
            }
            return null;
        }

        #endregion

        #region 3Sum

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            //排序
            Array.Sort(nums);
            var res = new List<IList<int>>();

            //当前元素向后匹配2个元素，所以最后2个元素不用被遍历
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int lo = i + 1, hi = nums.Length - 1, sum = 0 - nums[i];
                    while (lo < hi)
                    {
                        //找到满足条件元素，添加到返回结果队列
                        if (nums[lo] + nums[hi] == sum)
                        {
                            res.Add(new List<int> { nums[i], nums[lo], nums[hi] });
                            //防止重复元素
                            while (lo < hi && nums[lo] == nums[lo + 1]) lo++;
                            while (lo < hi && nums[hi] == nums[hi - 1]) hi--;
                            //夹逼查找
                            lo++; hi--;
                        }
                        else if (nums[lo] + nums[hi] < sum) lo++;
                        else hi--;
                    }
                }
            }
            return res;
        }

        #endregion

        #region 3Sum Closest

        public int ThreeSumClosest(int[] nums, int target)
        {
            int res = nums[0] + nums[1] + nums[nums.Length - 1];

            //排序后遍历
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                //从当前后面的元素和最后一个元素，两边夹逼
                int lo = i + 1, hi = nums.Length - 1;
                while (lo < hi)
                {
                    int sum = nums[i] + nums[lo] + nums[hi];
                    if (sum > target)
                    {
                        hi--;
                    }
                    else
                    {
                        lo++;
                    }
                    //如果此次遍历的3个元素的和更接近，则赋值返回的结果
                    if (Math.Abs(sum - target) < Math.Abs(res - target))
                    {
                        res = sum;
                    }
                }
            }
            return res;
        }

        #endregion

        #region 4Sum

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (nums.Length < 4) return res;

            //排序
            Array.Sort(nums);
            //4阶判断
            for (int i = 0; i < nums.Length - 3; i++)
            {
                //如果最近4个元素之和都大于目标值，因为数组是排序的，后续只可能更大，所以跳出循环
                if (nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 3] > target) break;
                //当前元素和最后3个元素之和小于目标值即本轮最大值都小于目标值，则本轮不满足条件，跳过本轮
                if (nums[i] + nums[nums.Length - 1] + nums[nums.Length - 2] + nums[nums.Length - 3] < target)
                    continue;
                //防止重复组合
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                //3阶判断
                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    //原理同4阶判断
                    if (nums[i] + nums[j] + nums[j + 1] + nums[j + 2] > target) break;
                    if (nums[i] + nums[j] + nums[nums.Length - 1] + nums[nums.Length - 2] < target)
                        continue;

                    int lo = j + 1, hi = nums.Length - 1;
                    while (lo < hi)
                    {
                        //已知元素 nums[i],nums[j],剩下2个元素做夹逼
                        int sum = nums[i] + nums[j] + nums[lo] + nums[hi];
                        if (sum == target)
                        {
                            res.Add(new List<int> { nums[i], nums[j], nums[lo], nums[hi] });
                            while (lo < hi && nums[lo] == nums[lo + 1]) lo++;
                            while (lo < hi && nums[hi] == nums[hi - 1]) hi--;
                            lo++;
                            hi--;
                        }
                        //两边夹逼
                        else if (sum < target) lo++;
                        else hi--;
                    }
                }
            }
            return res;
        }

        #endregion

        #region Remove Element

        public int RemoveElement(int[] nums, int val)
        {
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                //如果不相等，有效长度自增1
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
        }

        #endregion

        #region Move Zeroes

        public void MoveZeroes(int[] nums)
        {
            int index = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] != 0)
                {
                    //非0元素，记录排序
                    nums[index++] = nums[i];
                }
            }
            //非0元素之后的元素全置0
            for (int i = index; i < nums.Length; ++i)
            {
                nums[i] = 0;
            }
        }

        #endregion

        #region Next Permutation

        public void NextPermutation(int[] nums)
        {
            int i = nums.Length - 2;
            //末尾向前查找，找到第一个i，使得A[i] < A[i+1]
            while (i >= 0 && nums[i + 1] <= nums[i])
            {
                i--;
            }
            if (i >= 0)
            {
                //从i下标向后找第一个j,使得A[i]<A[j]
                int j = nums.Length - 1;
                while (j >= 0 && nums[j] <= nums[i])
                {
                    j--;
                }
                //交换i，j
                Swap(nums, i, j);
            }
            //逆置j之后的元素
            Reverse(nums, i + 1);
        }

        #endregion

        #region Permutation Sequence

        public string GetPermutation(int n, int k)
        {
            var sb = new StringBuilder();
            var nums = new List<int>();
            //fact记录n的阶乘
            int fact = 1;
            for (int i = 1; i <= n; i++)
            {
                fact *= i;
                nums.Add(i);
            }
            for (int i = 0, l = k - 1; i < n; i++)
            {
                //计算组合内相对的下标
                fact /= (n - i);
                int index = (l / fact);
                sb.Append(nums.ElementAt(index));
                nums.Remove(nums.ElementAt(index));
                //截取剩下的索引长度，用于下次遍历
                l -= index * fact;
            }
            return sb.ToString();
        }

        #endregion

        #region Valid Sudoku

        public bool IsValidSudoku(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                HashSet<char> rows = new HashSet<char>();
                HashSet<char> columns = new HashSet<char>();
                HashSet<char> cube = new HashSet<char>();

                for (int j = 0; j < 9; j++)
                {
                    //行不能有重复元素
                    if (board[i][j] != '.' && !rows.Add(board[i][j]))
                        return false;
                    //列不能有重复元素
                    if (board[j][i] != '.' && !columns.Add(board[j][i]))
                        return false;
                    //验证九宫格里不能有重复元素
                    int RowIndex = 3 * (i / 3);
                    int ColIndex = 3 * (i % 3);
                    if (board[RowIndex + j / 3][ColIndex + j % 3] != '.' && !cube.Add(board[RowIndex + j / 3][ColIndex + j % 3]))
                        return false;
                }
            }
            return true;
        }

        #endregion

        #region Trapping Rain Water

        public int Trap(int[] height)
        {
            var n = height.Length;

            int peak_index = 0; // 最高的柱子，将数组分为两半
            for (int i = 0; i < n; i++)
                if (height[i] > height[peak_index]) peak_index = i;

            int ans = 0;
            //最高柱子左侧遍历
            for (int i = 0, left_peak = 0; i < peak_index; i++)
            {
                if (height[i] > left_peak) left_peak = height[i];
                else ans += left_peak - height[i];
            }
            //最高柱子右侧遍历
            for (int i = n - 1, right_peak = 0; i > peak_index; i--)
            {
                if (height[i] > right_peak) right_peak = height[i];
                else ans += right_peak - height[i];
            }
            return ans;
        }

        #endregion

        #region 公共方法

        //逆置排序
        private void Reverse(int[] nums, int start)
        {
            int i = start, j = nums.Length - 1;
            while (i < j)
            {
                Swap(nums, i, j);
                i++;
                j--;
            }
        }
        //交换
        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        #endregion

    }
}
