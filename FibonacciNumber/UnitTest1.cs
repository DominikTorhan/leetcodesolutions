using System;
using System.Collections.Generic;
using Xunit;

namespace FibonacciNumber
{

  //  The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, 
  //such that each number is the sum of the two preceding ones, starting from 0 and 1. That is,

  //F(0) = 0,   F(1) = 1
  //F(N) = F(N - 1) + F(N - 2), for N > 1.
  //Given N, calculate F(N).

  //Example 1:

  //Input: 2
  //Output: 1
  //Explanation: F(2) = F(1) + F(0) = 1 + 0 = 1.
  //Example 2:

  //Input: 3
  //Output: 2
  //Explanation: F(3) = F(2) + F(1) = 1 + 1 = 2.
  //Example 3:

  //Input: 4
  //Output: 3
  //Explanation: F(4) = F(3) + F(2) = 2 + 1 = 3.


  //Note:

  //0 ≤ N ≤ 30.

  public class Solution
  {
    Dictionary<int, int> cache = new Dictionary<int, int>();

    public int Fib(int N)
    {
      if (N == 0) return 0;
      if (N == 1) return 1;
      if (cache.ContainsKey(N)) return cache[N];
      var a = Fib(N - 1);
      var b = Fib(N - 2);
      var sum = a + b;
      cache.Add(N, sum);
      return sum;
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(1, 1)]
    [InlineData(1, 2)]
    [InlineData(2, 3)]
    [InlineData(3, 4)]
    [InlineData(5, 5)]
    [InlineData(8, 6)]
    [InlineData(13, 7)]
    [InlineData(21, 8)]
    [InlineData(34, 9)]
    [InlineData(832040, 30)]
    public void Test1(int expected, int N)
    {
      var result = new Solution().Fib(N);
      Assert.Equal(expected, result);
    }
  }
}
