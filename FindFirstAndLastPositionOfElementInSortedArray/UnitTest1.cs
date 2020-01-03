using System;
using Xunit;

namespace FindFirstAndLastPositionOfElementInSortedArray
{

  //  Given an array of integers nums sorted in ascending order, find the starting and ending position of a given target value.

  //Your algorithm's runtime complexity must be in the order of O(log n).

  //If the target is not found in the array, return [-1, -1].

  //Example 1:

  //Input: nums = [5, 7, 7, 8, 8, 10], target = 8
  //Output: [3,4]
  //Example 2:

  //Input: nums = [5, 7, 7, 8, 8, 10], target = 6
  //Output: [-1,-1]

  public class Solution
  {
    public int[] SearchRange(int[] nums, int target)
    {
      if (nums.Length == 0) return new int[] { -1,-1 };
      if (nums.Length == 1)
      {
        if (nums[0] == target) return new int[] { 0, 0 };
        return new int[] { -1, -1 };
      }
      return Search(nums, target, 0, nums.Length - 1);
    }
    private int[] Search(int[] nums, int target, int start, int end)
    {
      int mid = ((end - start) / 2) + start;
      int midVal = nums[mid];
      if (target == midVal) return FinalizeRange(nums, mid);
      if (target == nums[start]) return FinalizeRange(nums, start);
      if (target == nums[end]) return FinalizeRange(nums, end);
      if (end - start < 3) return new int[] { -1, -1 };
      if (target < midVal) return Search(nums, target, start, mid - 1);
      return Search(nums, target, mid + 1, end);
    }
    private int[] FinalizeRange(int[] nums, int index)
    {
      int[] result = new[] { index, index };
      int start;
      int end;
      int val = nums[index];
      for (start = index; start >= 0; start--)
      {
        if (nums[start] != val) break;
        result[0] = start;
      }
      for (end = index; end< nums.Length; end++)
      {
        if (nums[end] != val) break;
        result[1] = end;
      }
      return result;
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(new int[] { 0, 0 }, new int[] { 1 }, 1)]
    [InlineData(new int[] { -1, -1 }, new int[] { 1 }, 0)]
    [InlineData(new int[] { -1, -1 }, new int[] { }, 0)]
    [InlineData(new int[] { -1, -1 }, new int[] { 1, 2 }, 0)]
    [InlineData(new int[] { 3, 4 }, new int[] { 5, 7, 7, 8, 8, 10 }, 8)]
    [InlineData(new int[] { -1, -1 }, new int[] { 5, 7, 7, 8, 8, 10 }, 6)]
    [InlineData(new int[] { 1, 1 }, new int[] { 1,4}, 4)]
    public void Test1(int[] expected, int[] nums, int target)
    {
      var result = new Solution().SearchRange(nums, target);
      Assert.Equal(expected, result);
    }
  }
}
