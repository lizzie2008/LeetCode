using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using static LeetCode.Solution;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            //var retRemoveDuplicates = solution.RemoveDuplicates(new[] { 1, 1, 2 });
            //Console.WriteLine($"RemoveDuplicates Result:{retRemoveDuplicates}");

            //var retRemoveDuplicates2 = solution.RemoveDuplicates2(new[] { 1, 1, 1, 2, 2, 3 });
            //Console.WriteLine($"RemoveDuplicates2 Result:{retRemoveDuplicates2}");

            //var retLongestConsecutive = solution.LongestConsecutive(new[] { 100, 4, 200, 1, 3, 2 });
            //Console.WriteLine($"LongestConsecutive Result:{retLongestConsecutive}");

            //var retTwoSum = solution.TwoSum(new[] { 2, 7, 11, 15 }, 9);
            //Console.WriteLine($"TwoSum Result:{retTwoSum[0]},{retTwoSum[1]}");

            //var retThreeSum = solution.ThreeSum(new[] { -1, 0, 1, 2, -1, -4 });
            //Console.WriteLine("[");
            //foreach (var item in retThreeSum)
            //{
            //    Console.WriteLine("  [" + string.Join(",", item.Select(s=>s.ToString()).ToArray()) + "]");
            //}
            //Console.WriteLine("]");

            //var retThreeSumClosest = solution.ThreeSumClosest(new[] { -1, 2, 1, -4 }, 1);
            //Console.WriteLine($"ThreeSumClosest Result:{retThreeSumClosest}");

            //var retFourSum = solution.FourSum(new[] { 1, 0, -1, 0, -2, 2 }, 0);
            //Console.WriteLine("[");
            //foreach (var item in retFourSum)
            //{
            //    Console.WriteLine("  [" + string.Join(",", item.Select(s => s.ToString()).ToArray()) + "]");
            //}
            //Console.WriteLine("]");

            //var retRemoveElement = solution.RemoveElement(new[] { 3, 2, 2, 3 }, 3);
            //Console.WriteLine($"RemoveElement Result:{retRemoveElement}");

            //var numsMoveZeroes = new[] { 0, 1, 0, 3, 12 };
            //solution.MoveZeroes(numsMoveZeroes);
            //Console.WriteLine("MoveZeroes Result: [" + string.Join(",", numsMoveZeroes) + "]");

            //var numsNextPermutation = new[] { 1, 5, 8, 4, 7, 6, 5, 3, 1 };
            //solution.NextPermutation(numsNextPermutation);
            //Console.WriteLine("  [" + string.Join(",", numsNextPermutation) + "]");


            //var retGetPermutation = solution.GetPermutation(4, 14);
            //Console.WriteLine($"GetPermutation Result:{retGetPermutation}");

            //var retIsValidSudoku = solution.IsValidSudoku(new char[][]
            //{
            //    new char[]{'5','3','.','.','7','.','.','.','.'},
            //    new char[]{'6','.','.','1','9','5','.','.','.'},
            //    new char[]{'.','9','8','.','.','.','.','6','.'},
            //    new char[]{'8','.','.','.','6','.','.','.','3'},
            //    new char[]{'4','.','.','8','.','3','.','.','1'},
            //    new char[]{'7','.','.','.','2','.','.','.','6'},
            //    new char[]{'.','6','.','.','.','.','2','8','.'},
            //    new char[]{'.','.','.','4','1','9','.','.','5'},
            //    new char[]{'.','.','.','.','8','.','.','7','9'}
            //});
            //Console.WriteLine($"IsValidSudoku Result:{retIsValidSudoku}");

            //var retTrap = solution.Trap(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
            //Console.WriteLine($"Trap Result:{retTrap}");

            //var matrix = new int[][]
            //{
            //    new int[] {1, 2, 3},
            //    new int[] {4, 5, 6},
            //    new int[] {7, 8, 9}
            //};
            //solution.Rotate(matrix);
            //Console.WriteLine($"Rotate Result:");
            //for (int i = 0; i < matrix.Length && i < matrix[i].Length; i++)
            //{
            //    Console.WriteLine(string.Join(",", matrix[i].Select(s => s.ToString()).ToArray()));
            //}

            //var retPlusOne = solution.PlusOne(new[] { 9, 9, 9, 9, 9 });
            //Console.WriteLine($"PlusOne Result:{string.Join(",", retPlusOne.Select(s => s.ToString()).ToArray())}");


            //var retClimbStairs = solution.ClimbStairs(2);
            //Console.WriteLine($"ClimbStairs Result:{retClimbStairs}");

            //var matrix = new int[][]
            //{
            //    new int[] {3, 2, 3, 0, 1},
            //    new int[] {4, 5, 6, 6, 3},
            //    new int[] {7, 0, 9, 8, 9},
            //    new int[] {7, 8, 9, 8, 9}

            //};
            //solution.SetZeroes(matrix);
            //Console.WriteLine($"SetZeroes Result:");
            //for (int i = 0; i < matrix.Length && i < matrix[i].Length; i++)
            //{
            //    Console.WriteLine(string.Join(",", matrix[i].Select(s => s.ToString()).ToArray()));
            //}

            //var retCanCompleteCircuit = solution.CanCompleteCircuit(new[] { 5, 11, 9, 4, 3 }, new[] { 6, 7, 5, 9, 5 });
            //Console.WriteLine($"CanCompleteCircuit Result:{retCanCompleteCircuit}");

            //var retCandy = solution.Candy(new[] { 12, 4, 3, 11, 34, 34, 1, 67 });
            //Console.WriteLine($"Candy Result:{retCandy}");

            //var retMajorityElement = solution.MajorityElement(new[] { 1, 3, 3, 2, 3, 2, 3, 3, 4, 3 });
            //Console.WriteLine($"MajorityElement Result:{retMajorityElement}");

            //var nums = new[] { 1, 2, 3, 4, 5, 6, 7 };
            //solution.Rotate(nums, 3);
            //Console.WriteLine("Rotate Result: [" + string.Join(",", nums) + "]");

            //var retContainsDuplicate = solution.ContainsDuplicate(new[] { 1, 3, 2, 4, 3, 6, 9 });
            //Console.WriteLine($"ContainsDuplicate Result:{retContainsDuplicate}");

            //var retContainsNearbyDuplicate = solution.ContainsNearbyDuplicate(new[] { 1, 3, 2, 4, 3, 6, 9 }, 2);
            //Console.WriteLine($"ContainsDuplicate Result:{retContainsNearbyDuplicate}");

            //var retContainsNearbyAlmostDuplicate = solution.ContainsNearbyAlmostDuplicate(new[] { 3, 4, 5, 6, 7, 8 }, 4, 3);
            //Console.WriteLine($"ContainsNearbyAlmostDuplicate Result:{retContainsNearbyAlmostDuplicate}");

            //var nums = solution.ProductExceptSelf(new[] { 1, 2, 3, 4 });
            //Console.WriteLine("Rotate Result: [" + string.Join(",", nums) + "]");

            //var board = new int[,]
            //{
            //    {1, 0, 1, 1, 0},
            //    {0, 1, 0, 0, 1},
            //    {0, 0, 1, 1, 0},
            //    {0, 1, 0, 1, 0}
            //};
            //solution.GameOfLife(board);
            //for (int i = 0; i < board.GetLength(0); i++)
            //{
            //    string str = "";//这里为什么要定义string 还是空的。
            //    for (int j = 0; j < board.GetLength(1); j++)
            //    {
            //        str = str + Convert.ToString(board[i, j]) + " ";
            //    }
            //    Console.WriteLine(str);
            //}

            //var reIncreasingTriplet = solution.IncreasingTriplet(new[] { 1, 4, 3, 2, 3, 2, 3, });
            //Console.WriteLine($"IncreasingTriplet Result:{reIncreasingTriplet}");


            //var head = CreateListNodes(new[] { 1, 2, 3, 4 });
            //Console.Write("原单链表：");
            //PrintListNode(head);
            //var reReverseList = solution.ReverseList(head);
            //Console.Write("反转后单链表：");
            //PrintListNode(reReverseList);

            //var head = CreateListNodes(new[] { 1, 2, 3, 4, 5 });
            //var retReverseBetween = solution.ReverseBetween(head, 2, 4);
            //Console.Write("ReverseBetween：");
            //PrintListNode(retReverseBetween);

            //var head = CreateListNodes(new[] { 1,2,3,4,5 });
            //var retOddEvenList = solution.OddEvenList(head);
            //Console.Write("retOddEvenList：");
            //PrintListNode(retOddEvenList);

            //var l1 = CreateListNodes(new[] { 2, 4, 3 });
            //var l2 = CreateListNodes(new[] { 5, 6, 4 });
            //var retAddTwoNumbers = solution.AddTwoNumbers(l1,l2);
            //Console.Write("AddTwoNumbers：");
            //PrintListNode(retAddTwoNumbers);

            //var head = CreateListNodes(new[] { 1, 4, 3, 2, 5, 2 });
            //var retPartition = solution.Partition(head,3);
            //Console.Write("Partition：");
            //PrintListNode(retPartition);

            //var head = CreateListNodes(new[] { 1, 1, 2, 3, 3 });
            //var retDeleteDuplicates = solution.DeleteDuplicates(head);
            //Console.Write("DeleteDuplicates：");
            //PrintListNode(retDeleteDuplicates);

            //var head = CreateListNodes(new[] { 1, 1, 1, 2, 3 });
            //var retDeleteDuplicates2 = solution.DeleteDuplicates2(head);
            //Console.Write("DeleteDuplicates2：");
            //PrintListNode(retDeleteDuplicates2);

            //var head = CreateListNodes(new[] { 1, 2, 3, 4, 5 });
            //var retRotateRight = solution.RotateRight(head, 2);
            //Console.Write("RotateRight：");
            //PrintListNode(retRotateRight);

            //var head = CreateListNodes(new[] { 1, 2, 3, 4, 5 });
            //var retRemoveNthFromEnd = solution.RemoveNthFromEnd(head, 2);
            //Console.Write("RemoveNthFromEnd：");
            //PrintListNode(retRemoveNthFromEnd);

            //var head = CreateListNodes(new[] { 1, 2, 3, 4 });
            //var retSwapPairs = solution.SwapPairs(head);
            //Console.Write("SwapPairs：");
            //PrintListNode(retSwapPairs);

            //var head = CreateListNodes(new[] { 1, 2, 3, 4, 5 });
            //var retReverseKGroup = solution.ReverseKGroup(head, 3);
            //Console.Write("ReverseKGroup：");
            //PrintListNode(retReverseKGroup);

            //var head = CreateRandomListNodes(new[] { 1, 2, 3, 4, 5 });
            //Console.Write("原链表：");
            //PrintRandomListNode(head);
            //var retCopyRandomList = solution.CopyRandomList(head);
            //Console.Write("深拷贝链表：");
            //PrintRandomListNode(retCopyRandomList);

            //var head = CreateListNodes(new[] { 1, 2, 3, 4, 5 });
            //head.next.next.next.next.next = head.next.next;
            //var retHasCycle = solution.HasCycle(head);
            //Console.WriteLine($"HasCycle Result:{retHasCycle}");

            //var head = CreateListNodes(new[] { 1, 2, 3, 4, 5 });
            //head.next.next.next.next.next = head.next.next;
            //var retDetectCycle = solution.DetectCycle(head);
            //Console.WriteLine($"DetectCycle Result:{retDetectCycle.val}");

            //var head = CreateListNodes(new[] { 1, 2, 3, 4, 5, 6 });
            //solution.ReorderList(head);
            //Console.Write("ReorderList：");
            //PrintListNode(head);

        }


        #region HelperMethords
        /// <summary>
        /// 通过数组构建链表
        /// </summary>
        /// <param name="vals"></param>
        /// <returns></returns>
        private static ListNode CreateListNodes(int[] vals)
        {
            var dummy = new ListNode(0);
            var curr = dummy;
            for (int i = 0; i < vals.Length; i++)
            {
                curr.next = new ListNode(vals[i]);
                curr = curr.next;
            }
            return dummy.next;
        }
        /// <summary>
        /// 单链表打印
        /// </summary>
        /// <param name="node"></param>
        private static void PrintListNode(ListNode node)
        {
            ListNode curr = node;
            var outVals = new List<int>();
            while (curr != null)
            {
                outVals.Add(curr.val);
                curr = curr.next;
            }
            Console.WriteLine(string.Join(" -> ", outVals.Select(s => s.ToString())));
        }
        /// <summary>
        /// 通过数组构建带随机指针的链表
        /// </summary>
        /// <param name="vals"></param>
        /// <returns></returns>
        private static RandomListNode CreateRandomListNodes(int[] vals)
        {
            var dummy = new RandomListNode(0);
            var nodeList = new List<RandomListNode>();
            var curr = dummy;
            for (int i = 0; i < vals.Length; i++)
            {
                curr.next = new RandomListNode(vals[i]);
                nodeList.Add(curr.next);
                curr = curr.next;
            }
            nodeList.Add(null);
            curr = dummy;

            var random = new Random();
            while (curr.next != null)
            {
                var rdm = random.Next(0, nodeList.Count);
                curr.next.random = nodeList.ElementAt(rdm);
                curr = curr.next;
            }

            return dummy.next;
        }
        /// <summary>
        /// 带随机指针的链表打印
        /// </summary>
        /// <param name="node"></param>
        private static void PrintRandomListNode(RandomListNode node)
        {
            RandomListNode curr = node;
            var outVals = new List<string>();
            while (curr != null)
            {
                var randomLable = curr.random == null ? "NULL" : curr.random.label.ToString();
                outVals.Add(curr.label + "[" + randomLable + "]");
                curr = curr.next;
            }
            Console.WriteLine(string.Join(" -> ", outVals));
        }

        #endregion
    }
}
