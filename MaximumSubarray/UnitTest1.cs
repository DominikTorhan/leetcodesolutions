using System;
using Xunit;

namespace MaximumSubarray
{

  //  Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum.

  //Example:

  //Input: [-2,1,-3,4,-1,2,1,-5,4],
  //Output: 6
  //Explanation: [4,-1,2,1] has the largest sum = 6.
  //Follow up:


  //If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.

  //1 2 -> 3 
  //1 2 -1 -> 3 
  //1 2 -9 4 -> 4

  public class Solution
  {
    public int MaxSubArray(int[] nums)
    {
      int len = nums.Length;
      if (len == 0) return 0;
      int sum = nums[0];
      int maxSum = nums[0];
      if (len == 1) return sum;
      for (int i = 1; i < len; i++)
      {
        sum = Math.Max(nums[i], sum + nums[i]);
        maxSum = Math.Max(maxSum, sum);
      }
      return maxSum;
    }

  }

  public class UnitTest1
  {
    [Theory]
    //[InlineData(0, new int[] { })]
    //[InlineData(1, new[] { 1 })]
    //[InlineData(-1, new[] { -1 })]
    //[InlineData(6, new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 })]
    [InlineData(4, new[] { 1, 3, -9, 4 })]
    public void Test1(int expected, int[] nums)
    {
      var result = new Solution().MaxSubArray(nums);
      Assert.Equal(expected, result);
    }
  }
}
