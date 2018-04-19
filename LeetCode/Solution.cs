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
            Reverse(nums, i + 1, nums.Length);
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

        #region Rotate Image

        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            /*
            * 沿着副对角线反转，再沿着水平中线反转
            * 1 2 3     9 6 3     7 4 1
            * 4 5 6  => 8 5 2  => 8 5 2
            * 7 8 9     7 4 1     9 6 3
            */
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n - i; ++j)
                    Swap(matrix, i, j, n - 1 - j, n - 1 - i);
            for (int i = 0; i < n / 2; ++i)
                for (int j = 0; j < n; ++j)
                    Swap(matrix, i, j, n - 1 - i, j);
        }

        #endregion

        #region Plus One

        public int[] PlusOne(int[] digits)
        {
            //从数组最后一位计算
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                //如果不需要进位，加1后直接返回
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }

                //数字9需要进位，加1后变0，高位继续加1
                digits[i] = 0;
            }

            //最高位需要进位，如9999，最终应为10000
            int[] newNumber = new int[digits.Length + 1];
            newNumber[0] = 1;

            return newNumber;
        }

        #endregion

        #region Climbing Stairs

        public int ClimbStairs(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            int first = 1;
            int second = 1;

            for (int i = 2; i <= n; i++)
            {
                //f(n)=f(n-1)+f(n-2)
                int third = first + second;
                first = second;
                second = third;
            }
            return second;
        }

        #endregion

        #region Set Matrix Zeroes

        public void SetZeroes(int[][] matrix)
        {
            //标记第0列
            int col0 = 1;
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            //正向遍历，在第0行和第0列进行标记
            for (int i = 0; i < rows; i++)
            {
                //如果第0列含有零元素
                if (matrix[i][0] == 0) col0 = 0;
                for (int j = 1; j < cols; j++)
                    if (matrix[i][j] == 0)
                        matrix[i][0] = matrix[0][j] = 0;
            }
            //反向遍历，将标记含零的行和列置零
            for (int i = rows - 1; i >= 0; i--)
            {
                for (int j = cols - 1; j >= 1; j--)
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                        matrix[i][j] = 0;
                if (col0 == 0) matrix[i][0] = 0;
            }
        }

        #endregion

        #region Gas Station

        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int start = 0;
            int total = 0;
            int tank = 0;

            for (int i = 0; i < gas.Length; i++)
            {
                //油不够到下一个站点，记录start下个站点
                if ((tank = tank + gas[i] - cost[i]) < 0)
                {
                    start = i + 1;
                    total += tank;
                    tank = 0;
                }
            }
            return (total + tank < 0) ? -1 : start;
        }

        #endregion

        #region Candy

        public int Candy(int[] ratings)
        {
            int sum = 0;
            int[] left2right = new int[ratings.Length];
            int[] right2left = new int[ratings.Length];
            //默认每个小孩给1颗糖
            for (int i = 0; i < ratings.Length; i++)
            {
                left2right[i] = 1;
                right2left[i] = 1;
            }
            //正向扫描
            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    left2right[i] = left2right[i - 1] + 1;
                }
            }
            //反向扫描
            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                {
                    right2left[i] = right2left[i + 1] + 1;
                }
            }
            //比较正反扫描后，至少需要的糖的数量
            for (int i = 0; i < ratings.Length; i++)
            {
                sum += Math.Max(left2right[i], right2left[i]);
            }
            return sum;
        }

        #endregion

        #region Majority Element

        public int MajorityElement(int[] nums)
        {
            int result = nums[0];
            int count = 1;

            foreach (var num in nums)
            {
                //如果count不是>0，替换成当前元素
                if (count == 0)
                {
                    result = num;
                    count += 1;
                }
                else if (result == num)
                {
                    //增加
                    count += 1;
                }
                else
                {
                    //抵消
                    count -= 1;
                }
            }

            return result;
        }

        #endregion

        #region Rotate Array

        public void Rotate(int[] nums, int k)
        {
            k %= nums.Length;
            //逆置前n-k数组
            Reverse(nums, 0, nums.Length - k);
            //逆置后k数组
            Reverse(nums, nums.Length - k, nums.Length);
            //整体再逆置
            Reverse(nums, 0, nums.Length);
        }

        #endregion

        #region Contains Duplicate

        public bool ContainsDuplicate(int[] nums)
        {
            var set = new HashSet<int>();
            foreach (var num in nums)
            {
                //判断元素已存在
                if (set.Contains(num)) return true;
                set.Add(num);
            }

            return false;
        }

        #endregion

        #region Contains Duplicate II

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                //保证Hahs表中的所有元素满足与当前元素下标差不超过k
                if (i > k) set.Remove(nums[i - k - 1]);
                //判断是否有重复数据
                if (!set.Add(nums[i])) return true;
            }
            return false;
        }

        #endregion

        #region Contains Duplicate III

        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (nums == null || nums.Length < 2 || k < 1 || t < 0)
                return false;

            var set = new SortedSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int left = nums[i] - t;
                int right = nums[i] + t;

                //判断二叉树中是否满足与nums[i]绝对值之差最大为t的元素
                var subSet = set.GetViewBetween(left, right);
                if (subSet.Any())
                    return true;
                set.Add(nums[i]);

                //大小为k的窗口向前移动
                if (i >= k)
                    set.Remove(nums[i - k]);
            }
            return false;
        }

        #endregion

        #region Product of Array Except Self

        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            res[0] = 1;
            //先累计左侧乘积，左侧没有默认为1
            for (int i = 1; i < n; i++)
            {
                res[i] = res[i - 1] * nums[i - 1];
            }
            int right = 1;
            //再累计右侧乘积，右侧没有默认为1
            for (int i = n - 1; i >= 0; i--)
            {
                res[i] *= right;
                right *= nums[i];
            }
            return res;
        }

        #endregion

        #region Game of Life

        public void GameOfLife(int[,] board)
        {
            if (board == null || board.Length == 0) return;
            int m = board.GetLength(0), n = board.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int lives = LiveNeighbors(board, m, n, i, j);

                    // 刚开始第2个bit为肯定是0，我们只用考虑2个bit变为1的情况
                    if (board[i, j] == 1 && lives >= 2 && lives <= 3)
                    {
                        //编码: 01 ---> 11
                        board[i, j] = 3;
                    }
                    if (board[i, j] == 0 && lives == 3)
                    {
                        //编码: 00 ---> 10
                        board[i, j] = 2;
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //解码下一状态
                    board[i, j] >>= 1;
                }
            }
        }

        public int LiveNeighbors(int[,] board, int m, int n, int i, int j)
        {
            int lives = 0;
            for (int x = Math.Max(i - 1, 0); x <= Math.Min(i + 1, m - 1); x++)
            {
                for (int y = Math.Max(j - 1, 0); y <= Math.Min(j + 1, n - 1); y++)
                {
                    lives += board[x, y] & 1;
                }
            }
            //解码当前状态，如果是存活状态，计数+1
            lives -= board[i, j] & 1;
            return lives;
        }

        #endregion

        #region Increasing Triplet Subsequence

        public bool IncreasingTriplet(int[] nums)
        {
            int x1 = Int32.MaxValue;
            int x2 = Int32.MaxValue;
            foreach (var num in nums)
            {
                //x1保存最小值
                if (num <= x1)
                {
                    x1 = num;
                }
                //x2保存第二小值
                else if (num <= x2)
                {
                    x2 = num;
                }
                //如果存在比x2还大的值，条件成立，返回true
                else
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Reverse Linked List

        public ListNode ReverseList(ListNode head)
        {
            ListNode reverse = null;
            ListNode curr = head;
            while (curr != null)
            {
                //移动节点
                ListNode nextTemp = curr.next;
                //将当前节点加到头结点位置，节点next为之前反转的单链表
                curr.next = reverse;
                reverse = curr;
                curr = nextTemp;
            }
            return reverse;
        }

        #endregion

        #region Reverse Linked List II

        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (head == null) return null;
            //创建一个头结点，默认指向初始链表
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            //声明pre指针，将pre移动到链表m位置
            ListNode pre = dummy;
            for (int i = 0; i < m - 1; i++) pre = pre.next;

            //记录m位置的元素节点->start
            ListNode start = pre.next;
            //记录m+1位置的元素节点->then
            ListNode then = start.next;

            //反转m到n元素（头插法）
            for (int i = 0; i < n - m; i++)
            {
                start.next = then.next;
                then.next = pre.next;
                pre.next = then;
                then = start.next;
            }

            return dummy.next;
        }

        #endregion

        #region Odd Even Linked List

        public ListNode OddEvenList(ListNode head)
        {
            if (head != null)
            {
                //声明奇数链表，偶数链表，并保存偶数链表头结点位置
                ListNode odd = head, even = head.next, evenHead = even;

                while (even != null && even.next != null)
                {
                    //当前元素的下个元素指向下个元素的下个元素
                    odd.next = odd.next.next;
                    even.next = even.next.next;
                    //向后移动当前元素
                    odd = odd.next;
                    even = even.next;
                }
                //奇数链表，偶数链表收尾相连
                odd.next = evenHead;
            }
            return head;
        }

        #endregion

        #region Add Two Numbers

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            //接收返回的链表
            ListNode dummyHead = new ListNode(0);
            ListNode p = l1, q = l2, curr = dummyHead;
            //进位
            int carry = 0;

            while (p != null || q != null)
            {
                //判断有没有值，没有值默认赋0
                int x = (p != null) ? p.val : 0;
                int y = (q != null) ? q.val : 0;
                //对应值之和（包括进位）
                int sum = carry + x + y;
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                if (p != null) p = p.next;
                if (q != null) q = q.next;
            }
            //最后节点有进位情况
            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }
            return dummyHead.next;
        }

        #endregion

        #region Partition List

        public ListNode Partition(ListNode head, int x)
        {
            //接收小于目标值的链表和大于等于目标值的链表
            ListNode left_dummy = new ListNode(-1); // 头结点
            ListNode right_dummy = new ListNode(-1); // 头结点
            ListNode left_cur = left_dummy;
            ListNode right_cur = right_dummy;

            for (ListNode cur = head; cur != null; cur = cur.next)
            {
                if (cur.val < x)
                {
                    left_cur.next = cur;
                    left_cur = cur;
                }
                else
                {
                    right_cur.next = cur;
                    right_cur = cur;
                }
            }
            //组个2个链表
            left_cur.next = right_dummy.next;
            right_cur.next = null;
            return left_dummy.next;
        }

        #endregion

        #region Remove Duplicates from Sorted List

        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode current = head;
            while (current != null && current.next != null)
            {
                //移除相邻重复的元素，即指向下下个元素
                if (current.next.val == current.val)
                {
                    current.next = current.next.next;
                }
                else
                {
                    current = current.next;
                }
            }
            return head;
        }

        #endregion

        #region Remove Duplicates from Sorted List II

        public ListNode DeleteDuplicates2(ListNode head)
        {
            if (head == null) return null;
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode pre = dummy;
            ListNode cur = head;

            while (cur != null)
             {
                //如果相邻元素相等，继续移动游标
                while (cur.next != null && cur.val == cur.next.val)
                {
                    cur = cur.next;
                }
                if (pre.next == cur)
                {
                    //没有重复元素，pre向后移动一位
                    pre = pre.next;
                }
                else
                {
                    //删除中间重复的元素
                    pre.next = cur.next;
                }
                cur = cur.next;
            }
            return dummy.next;
        }

        #endregion

        #region 公共方法

        //逆置排序 O(n)
        private void Reverse(int[] nums, int start, int end)
        {
            int i = start, j = end - 1;
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
        private void Swap(int[][] matrix,
        int i, int j, int p, int q)
        {
            int tmp = matrix[i][j];
            matrix[i][j] = matrix[p][q];
            matrix[p][q] = tmp;
        }

        #endregion

        /// <summary>
        /// 单链表
        /// </summary>
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
