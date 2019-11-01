using System;
using Xunit;

namespace ReverseString
{
  //  Write a function that reverses a string. The input string is given as an array of characters char[].

  //Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.

  //You may assume all the characters consist of printable ascii characters.

  //Example 1:

  //Input: ["h","e","l","l","o"]
  //  Output: ["o","l","l","e","h"]
  //  Example 2:

  //Input: ["H","a","n","n","a","h"]
  //  Output: ["h","a","n","n","a","H"]

  public class UnitTest1
  {
    public class Solution
    {
      public void ReverseString(char[] s)
      {
        int count = s.Length / 2;
        int j;
        char start, end;
        for (int i = 0; i < count; i++)
        {
          j = s.Length - i - 1;
          start = s[i];
          end = s[j];
          s[i] = end;
          s[j] = start;
        }
      }
    }


    [Theory]
    [InlineData(new[] { 'a' }, new[] { 'a' })]
    [InlineData(new[] { 'a', 'b' }, new[] { 'b', 'a' })]
    [InlineData(new[] { 'o', 'l', 'l', 'e', 'h' }, new[] { 'h', 'e', 'l', 'l', 'o' })]
    [InlineData(new[] { 'x', 'o', 'l', 'l', 'e', 'h' }, new[] { 'h', 'e', 'l', 'l', 'o', 'x' })]
    public void Test1(char[] expected, char[] s)
    {
      new Solution().ReverseString(s);
      Assert.Equal(expected, s);
    }
  }
}
