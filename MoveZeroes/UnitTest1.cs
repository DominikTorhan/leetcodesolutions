using System;
using Xunit;

namespace MoveZeroes
//  Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

//Example:

//Input: [0,1,0,3,12]
//Output: [1,3,12,0,0]
//Note:

//You must do this in-place without making a copy of the array.
//Minimize the total number of operations.

//Input: [0,1,0,3,12] -> p0 (p1(1) -> 0)
//Input: [1,0,0,3,12] -> p1
//Input: [1,0,0,3,12] -> p1 (3 -> 1) -> p2
//Input: [1,3,0,0,12] -> 2 (12 -> 2) -> p3
//Input: [1,3,12,0,0] -> 3 (12 -> 2) -> p4

//0001 p0
//0001 p0
//0001 p0
//1000 p1

//101
//
{

  public class Solution
  {
    public void MoveZeroes(int[] nums)
    {
      int curr, next, pos = -1;
      for (int i = 0; i < nums.Length - 1; i++)
      {
        curr = nums[i];
        next = nums[i + 1];
        if (pos == -1 && curr == 0) pos = i;

        if (curr == 0 && next != 0)
        {
          nums[pos] = next;
          nums[i + 1] = 0;
          pos++;
        }
      }
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(new[] { 1, 0 }, new[] { 1, 0 })]
    [InlineData(new[] { 1, 0 }, new[] { 0, 1 })]
    [InlineData(new[] { 1, 1, 0 }, new[] { 1, 0, 1 })]
    [InlineData(new[] { 1, 3, 12, 0, 0 }, new[] { 0, 1, 0, 3, 12 })]
    [InlineData(new[] { 12, 0, 0, 0, 0, 0 }, new[] { 0, 0, 0, 0, 0, 12 })]
    public void Test1(int[] expected, int[] array)
    {
      new Solution().MoveZeroes(array);
      Assert.Equal(expected, array);
    }
  }
}
