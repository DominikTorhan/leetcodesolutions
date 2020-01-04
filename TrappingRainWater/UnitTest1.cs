using System;
using Xunit;

namespace TrappingRainWater
{

  //  Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.


  //The above elevation map is represented by array[0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]. In this case, 6 units of rain water (blue section) are being trapped. Thanks Marcos for contributing this image!


  //          Example:


  //          Input: [0,1,0,2,1,0,1,3,2,1,2,1]
  //Output: 6

  public class Solution
  {
    public int Trap(int[] height)
    {
      int vol = 0;
      int start = -1, end;
      if (height.Length < 3) return 0;
      while (true)
      {
        start++;
        if (start >= height.Length - 1) break;
        if (height[start] <= height[start + 1]) continue;
        end = FindUp(height, start);
        if (end == -1) continue;
        vol += GetVolume(height, start, end);
        start = end - 1;
      }
      return vol;
    }
    private int FindUp(int[] height, int start)
    {
      int end = -1;
      int endLevel = 0;
      int lev = height[start];
      for (int i = start + 1; i < height.Length; i++)
      {
        if (height[i] >= lev) return i;
        if (endLevel > height[i]) continue;
        endLevel = height[i];
        end = i;
      }
      return end;
    }
    private int GetVolume(int[] height, int start, int end)
    {
      int vol = 0;
      int lev = Math.Min(height[start], height[end]);
      for (int i = start + 1; i < end; i++)
      {
        vol += lev - height[i];
      }
      return vol;
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(0, new int[] { })]
    [InlineData(0, new int[] { 1 })]
    [InlineData(0, new int[] { 0, 1 })]
    [InlineData(0, new int[] { 1, 1, 1 })]
    [InlineData(1, new int[] { 1, 0, 1 })]
    [InlineData(6, new [] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 })]
    [InlineData(1, new [] { 6, 0, 1})]
    [InlineData(5, new [] { 6, 0, 1, 0, 2})]
    public void Test1(int expected, int[] height)
    {
      var result = new Solution().Trap(height);
      Assert.Equal(expected, result);
    }
  }
}
