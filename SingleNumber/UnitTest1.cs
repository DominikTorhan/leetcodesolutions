using System;
using System.Collections;
using Xunit;

namespace SingleNumber
{

  //  Given a non-empty array of integers, every element appears twice except for one.Find that single one.

  //Note:

  //Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

  //Example 1:

  //Input: [2,2,1]
  //Output: 1
  //Example 2:

  //Input: [4,1,2,1,2]
  //Output: 4

  public class Solution
  {
    public int SingleNumber(int[] nums)
    {
      if (nums.Length == 1) return nums[0];
      Hashtable tab = new Hashtable();
      for(int i = 0; i < nums.Length; i++)
      {
        var x = nums[i];
        if (tab.Contains(x))
        {
          tab.Remove(x);
        }
        else
        {
          tab.Add(x, x);
        }
      }
      foreach (var v in tab.Keys) return (int)v;
      return 0;
    }
  }


  public class UnitTest1
  {
    [Theory]
    [InlineData(0, new[] { 0 })]
    [InlineData(1, new[] { 2, 2, 1 })]
    [InlineData(2, new[] { 1, 1, 2, 3, 3 })]
    [InlineData(4, new[] { 4, 1, 2, 1, 2 })]
    [InlineData(4, new[] { 2, 1, 4, 1, 2 })]
    public void Test1(int expected, int[] array)
    {
      var result = new Solution().SingleNumber(array);
      Assert.Equal(expected, result);
    }
  }
}
