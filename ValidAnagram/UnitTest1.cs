using System;
using System.Collections.Generic;
using Xunit;

namespace ValidAnagram
{

  public class Solution
  {
    public bool IsAnagram(string s, string t)
    {
      Dictionary<char, int> dict = new Dictionary<char, int>();
      foreach (var c in s)
      {
        if (!dict.ContainsKey(c)) dict.Add(c, 0);
        dict[c]++;
      }
      foreach (var c in t)
      {
        if (!dict.ContainsKey(c)) return false;
        dict[c]--;
        if (dict[c] == 0) dict.Remove(c);
      }
      if (dict.Count != 0) return false;
      return true;
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(true, "", "")]
    [InlineData(true, "a", "a")]
    [InlineData(false, "b", "a")]
    [InlineData(true, "ba", "ab")]
    [InlineData(false, "car", "rat")]
    [InlineData(true, "anagram", "nagaram")]
    public void Test1(bool expected, string s, string t)
    {
      var result = new Solution().IsAnagram(s, t);
      Assert.Equal(expected, result);
    }
  }
}
