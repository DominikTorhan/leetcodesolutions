using System;
using System.Collections.Generic;
using Xunit;

namespace MajorityElement
{

  //  Given an array of size n, find the majority element.The majority element is the element that appears more than ⌊ n/2 ⌋ times.

  //You may assume that the array is non-empty and the majority element always exist in the array.

  //Example 1:

  //Input: [3,2,3]
  //Output: 3
  //Example 2:


  //Input: [2,2,1,1,1,2,2]
  //Output: 2

  public class Solution
  {

    public int MajorityElement(int[] nums)
    {
      int count = nums.Length / 2 + nums.Length % 2;
      Dictionary<int, int> dict = new Dictionary<int, int>();
      for (int i = 0; i < nums.Length; i++)
      {
        var n = nums[i];
        if (dict.ContainsKey(n))
        {
          dict[n]++;
        }
        else
        {
          dict.Add(n, 1);
        }
        if (dict[n] == count) return n;
      }
      return 0;
    }

  }

  public class UnitTest1
  {

    [Theory]
    [InlineData(0, new[] { 0 })]
    [InlineData(2, new[] { 2, 2 })]
    [InlineData(3, new[] { 3, 2, 3 })]
    [InlineData(2, new[] { 2, 2, 1, 1, 1, 2, 2 })]
    public void Test1(int expected, int[] nums)
    {
      var result = new Solution().MajorityElement(nums);
      Assert.Equal(expected, result);
    }

  }

}
