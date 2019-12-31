using System;
using Xunit;

namespace ClimbingStairs
{

  //  You are climbing a stair case. It takes n steps to reach to the top.

  //Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?

  //Note: Given n will be a positive integer.

  //Example 1:

  //Input: 2
  //Output: 2
  //Explanation: There are two ways to climb to the top.
  //1. 1 step + 1 step
  //2. 2 steps
  //Example 2:

    //1 1 2 3 5 8 13 21

  //Input: 3
  //Output: 3
  //Explanation: There are three ways to climb to the top.
  //1. 1 step + 1 step + 1 step
  //2. 1 step + 2 steps
  //3. 2 steps + 1 step

  //4
  //1111
  //121
  //112
  //211
  //22

  //5 -> 8
  //11111
  //1211
  //1121
  //1112
  //122
  //2111
  //212
  //221

  //6 -> 13
  //111111
  //12111
  //11211
  //11121
  //11112
  //1221
  //1122
  //1212
  //21111
  //2211
  //2112
  //2121
  //222

  public class Solution
  {
    public int ClimbStairs(int n)
    {
      if (n == 0) return 0;
      if (n == 1) return 1;
      return Fibonacci(n + 1);
    }
    private int Fibonacci(int n)
    {
      int val = 0, prev1 = 1, prev2 = 1;
      for(int i = 2; i < n; i++)
      {
        val = prev1 + prev2;
        prev2 = prev1;
        prev1 = val;
      }
      return val;
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(5, 4)]
    [InlineData(8, 5)]
    [InlineData(13, 6)]
    [InlineData(21, 7)]
    [InlineData(1134903170, 44)]
    public void Test1(int expected, int n)
    {
      var result = new Solution().ClimbStairs(n);
      Assert.Equal(expected, result);
    }
  }
}
