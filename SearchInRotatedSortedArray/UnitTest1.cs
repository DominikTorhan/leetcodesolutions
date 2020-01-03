using System;
using Xunit;

namespace SearchInRotatedSortedArray
{

  //  Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

  //(i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).

  //You are given a target value to search.If found in the array return its index, otherwise return -1.

  //You may assume no duplicate exists in the array.

  //Your algorithm's runtime complexity must be in the order of O(log n).

  //Example 1:

  //Input: nums = [4, 5, 6, 7, 0, 1, 2], target = 0
  //Output: 4
  //Example 2:

  //Input: nums = [4, 5, 6, 7, 0, 1, 2], target = 3
  //Output: -1

  public class Solution
  {
    public int Search(int[] nums, int target)
    {
      if (nums.Length < 1) return -1;
      return Search(nums, target, 0, nums.Length - 1);
    }
    private int Search(int[] nums, int target, int start, int end)
    {
      int mid;
      int valStart, valMid, valEnd;
      mid = ((end - start) / 2) + start;
      valStart = nums[start];
      valMid = nums[mid];
      valEnd = nums[end];
      if (valStart == target) return start;
      if (valEnd == target) return end;
      if (valMid == target) return mid;
      if (end - start < 3) return -1;

      if (valStart > valMid)
      {
        if (target > valStart) return Search(nums, target, start, mid);
        if (target < valMid) return Search(nums, target, start, mid);
      }
      if (valStart < valMid && target > valStart && target < valMid)
      {
        return Search(nums, target, start, mid);
      }
      return Search(nums, target, mid, end);
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(-1, new int[] { }, 0)]
    [InlineData(-1, new int[] { 2, 3, 0, 1 }, 4)]
    [InlineData(4, new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)]
    [InlineData(5, new int[] { 4, 5, 6, 7, 0, 1, 2 }, 1)]
    [InlineData(-1, new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3)]
    [InlineData(1, new int[] { 4, 5, 6, 0, 1, 2, 3 }, 5)]
    [InlineData(4, new int[] { 4, 5, 6, 0, 1, 2, 3 }, 1)]
    [InlineData(1, new int[] { 5, 1, 2, 3,4 }, 1)]
    public void Test1(int expected, int[] nums, int target)
    {
      var result = new Solution().Search(nums, target);
      Assert.Equal(expected, result);
    }
  }
}
