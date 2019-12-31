using System;
using System.Linq;
using Xunit;

namespace ContainerWithMostWater
{

  //  Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate(i, ai). n vertical lines are drawn such that the two endpoints of line i is at(i, ai) and(i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water.
  //Note: You may not slant the container and n is at least 2.
  //The above vertical lines are represented by array[1, 8, 6, 2, 5, 4, 8, 3, 7]. In this case, the max area of water (blue section) the container can contain is 49.
  //       Example:

  //       Input: [1,8,6,2,5,4,8,3,7]
  //Output: 49

  public class Solution
  {
    public int MaxArea(int[] height)
    {
      int val1;
      int len = height.Length;
      int maxArea = 0;
      if (len < 2) return 0;
      for (int i = 0; i < len; i++)
      {
        val1 = height[i];
        if (val1 * (len - i - 1)  < maxArea) continue;
        for (int j = 0; j < len; j++)
        {
          if (i >= j) continue;
          var h = Math.Min(val1, height[j]);
          var area = Math.Abs(i - j) * h;
          maxArea = Math.Max(area, maxArea);
        }
      }
      return maxArea;
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(0, new int[] { })]
    [InlineData(0, new[] { 1 })]
    [InlineData(1, new[] { 1, 1 })]
    [InlineData(0, new[] { 0, 2 })]
    [InlineData(1, new[] { 1, 2 })]
    [InlineData(10, new[] { 9, 2, 5 })]
    [InlineData(4, new[] { 1, 2, 3, 4 })]
    [InlineData(49, new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 })]
    public void Test1(int expected, int[] array)
    {
      var result = new Solution().MaxArea(array);
      Assert.Equal(expected, result);
    }

    [Fact]
    public void TestLong()
    {
      var array = Enumerable.Range(1, 15000).ToArray();
      var result = new Solution().MaxArea(array);
      Assert.Equal(56250000, result);
    }
  }
}