using System;
using System.Collections.Generic;
using Xunit;

namespace ContainsDuplicate
{

  public class Solution
  {
    public bool ContainsDuplicate(int[] nums)
    {
      Dictionary<int, int> dict = new Dictionary<int, int>();
      foreach (int i in nums)
      {
        if (dict.ContainsKey(i)) return true;
        dict.Add(i, i);
      }
      return false;
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(false, new[] { 1 })]
    [InlineData(true, new[] { 1, 1 })]
    public void Test1(bool expected, int[]nums)
    {
      var result = new Solution().ContainsDuplicate(nums);
      Assert.Equal(expected, result);
    }
  }
}
