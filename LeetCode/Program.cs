using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            ////RemoveDuplicates
            //var retRemoveDuplicates = solution.RemoveDuplicates(new[] { 1, 1, 2 });
            //Console.WriteLine($"RemoveDuplicates Result:{retRemoveDuplicates}");

            ////RemoveDuplicates II
            //var retRemoveDuplicates2 = solution.RemoveDuplicates2(new[] { 1, 1, 1, 2, 2, 3 });
            //Console.WriteLine($"RemoveDuplicates2 Result:{retRemoveDuplicates2}");

            //RemoveDuplicates II
            var retLongestConsecutive = solution.LongestConsecutive(new[] { 100, 4, 200, 1, 3, 2 });
            Console.WriteLine($"LongestConsecutive Result:{retLongestConsecutive}");

            ////TwoSum
            //var retTwoSum = solution.TwoSum(new[] { 2, 7, 11, 15 }, 9);
            //Console.WriteLine($"TwoSum Result:{retTwoSum[0]},{retTwoSum[1]}");
        }
    }
}
