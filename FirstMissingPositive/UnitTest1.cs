using System;
using System.Collections.Generic;
using Xunit;

namespace FirstMissingPositive
{
  //  Given an unsorted integer array, find the smallest missing positive integer.

  //Example 1:

  //Input: [1,2,0]
  //Output: 3
  //Example 2:

  //Input: [3,4,-1,1]
  //Output: 2
  //Example 3:

  //Input: [7,8,9,11,12]
  //Output: 1
  //Note:

  //Your algorithm should run in O(n) time and uses constant extra space.

  public class Solution
  {
    public int FirstMissingPositive(int[] nums)
    {
      if (nums.Length < 1) return 1;
      Dictionary<int, int> dict = new Dictionary<int, int>();
      for (int i = 0; i< nums.Length; i++)
      {
        if (nums[i] < 1) continue;
        if (dict.ContainsKey(nums[i])) continue;
        dict.Add(nums[i], 0);
      }
      int j = 0;
      while (true)
      {
        j++;
        if (dict.ContainsKey(j)) continue;
        return j;
      }
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(1, new int[] { })]
    [InlineData(3, new int[] { 1, 2, 0 })]
    [InlineData(3, new int[] { 1, 1, 2, 0 })]
    [InlineData(2, new int[] { 3, 4, -1, 1 })]
    [InlineData(1, new int[] { 7, 8, 9, 11, 12 })]
    public void Test1(int expected, int[] nums)
    {
      var result = new Solution().FirstMissingPositive(nums);
      Assert.Equal(expected, result);
    }
  }
}
