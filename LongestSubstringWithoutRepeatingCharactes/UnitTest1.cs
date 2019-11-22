using System;
using System.Collections.Generic;
using Xunit;

namespace LongestSubstringWithoutRepeatingCharactes
{

  //  Given a string, find the length of the longest substring without repeating characters.

  //Example 1:

  //Input: "abcabcbb"
  //Output: 3 
  //Explanation: The answer is "abc", with the length of 3. 
  //Example 2:

  //Input: "bbbbb"
  //Output: 1
  //Explanation: The answer is "b", with the length of 1.
  //Example 3:

  //Input: "pwwkew"
  //Output: 3
  //Explanation: The answer is "wke", with the length of 3. 
  //             Note that the answer must be a substring, "pwke" is a subsequence and not a substring.


  public class Solution
  {
    public int LengthOfLongestSubstring(string s)
    {
      int len = 0, max = 0;
      char c;
      Dictionary<char, int> dict = new Dictionary<char, int>();
      if (string.IsNullOrEmpty(s)) return 0;
      if (s.Length == 1) return 1;
      for(int i = 0; i < s.Length; i++)
      {
        c = s[i];
        if (dict.ContainsKey(c))
        {
          i = dict[c];
          dict.Clear();
          len = 0;
          continue;
        }
        len++;
        if (len > max) max = len;
        dict.Add(c, i);
      }
      return max;
    }
  }

  public class UnitTest1
  {

    [Theory]
    [InlineData(0, "")]
    [InlineData(0, null)]
    [InlineData(1, "a")]
    [InlineData(2, "ab")]
    [InlineData(2, "abb")]
    [InlineData(2, "bba")]
    [InlineData(2, "baba")]
    [InlineData(3, "abcabcbb")]
    [InlineData(1, "bbbbb")]
    [InlineData(3, "pwwkew")]
    [InlineData(3, "babc")]
    [InlineData(10, "qwertyyyyyyyyyqwertyuiop")]
    [InlineData(4, "aaaabaaaaaaabaaaabcaaaacaaaaaaaaaabcdaaaaaaaa")]
    public void Test1(int expected, string s)
    {
      var actual = new Solution().LengthOfLongestSubstring(s);
      Assert.Equal(expected, actual);
    }

  }
}
