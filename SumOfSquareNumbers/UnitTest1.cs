using System;
using Xunit;

namespace SumOfSquareNumbers
{

  //  Given a non-negative integer c, your task is to decide whether there're two integers a and b such that a2 + b2 = c.

  //Example 1:

  //Input: 5
  //Output: True
  //Explanation: 1 * 1 + 2 * 2 = 5


  //Example 2:

  //Input: 3
  //Output: False
  public class Solution
  {
    //public bool JudgeSquareSum(int c)
    //{
    //  if (c < 2) return true;
    //  var s = Convert.ToInt32(Math.Sqrt(c));
    //  var p = Convert.ToInt32(s);
    //  if (s % 1 == 0) return true;
    //  var d = c - s;
    //  if (d == 0) return true;
    //  return true;
    //}


    public bool JudgeSquareSum(int c)
    {
      if (c < 2) return true;
      long a, b, i = 0;
      while (true)
      {
        i++;
        a = i * i;
        if (a > c) return false;
        b = c - a;
        if (Math.Sqrt(b) % 1 == 0) return true;
      }
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(true, 1)]
    [InlineData(true, 2)]
    [InlineData(false, 3)]
    [InlineData(true, 4)]
    [InlineData(true, 5)]
    [InlineData(false, 6)]
    [InlineData(false, 7)]
    [InlineData(true, 8)]
    [InlineData(true, 9)]
    [InlineData(true, 13)]
    [InlineData(true, 50)]
    [InlineData(true, 72)]
    [InlineData(true, 82)]
    [InlineData(false, 2147483646)]
    public void Test1(bool expected, int c)
    {
      var result = new Solution().JudgeSquareSum(c);
      Assert.Equal(expected, result);
    }
  }
}
