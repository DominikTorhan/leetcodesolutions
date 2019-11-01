using System;
using Xunit;

//Palindrome Number

//Determine whether an integer is a palindrome.An integer is a palindrome when it reads the same backward as forward.

//Example 1:

//Input: 121
//Output: true
//Example 2:

//Input: -121
//Output: false
//Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
//Example 3:

//Input: 10
//Output: false
//Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
//Follow up:

//Coud you solve it without converting the integer to a string?

namespace palindromeNumber
{

  public class Solution
  {
    public bool IsPalindrome(int x)
    {
      if (x < 0) return false;

      var rev = ReverseInt(x);

      return (x == rev);
    }

    private int ReverseInt(int x)
    {
      int pop;
      int rev = 0;
      while(x > 0)
      {
        pop = popInt(ref x);
        rev = push(rev, pop);
      }
      return rev;
    }

    private int popInt(ref int x)
    {
      int pop = x % 10;
      x -= pop;
      x /= 10;
      return pop;
    }
    private int push(int x, int pop)
    {
      int val = x;
      val *= 10;
      val += pop;
      return val;
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(true, 121)]
    [InlineData(false, -121)]
    [InlineData(false, 10)]
    [InlineData(false, 1126542094)]
    [InlineData(true, 10000001)]
    public void Test1(bool expected, int x)
    {
      var result = new Solution().IsPalindrome(x);
      Assert.Equal(expected, result);
    }
  }
}
