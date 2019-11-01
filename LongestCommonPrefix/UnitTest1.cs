using System;
using Xunit;

//Longest Common Prefix

//Write a function to find the longest common prefix string amongst an array of strings.

//If there is no common prefix, return an empty string "".

//Example 1:

//Input: ["flower","flow","flight"]
//Output: "fl"
//Example 2:

//Input: ["dog","racecar","car"]
//Output: ""
//Explanation: There is no common prefix among the input strings.
//Note:

//All given inputs are in lowercase letters a-z.

namespace LongestCommonPrefix
{

  public class Solution
  {
    public string LongestCommonPrefix(string[] strs)
    {
      string result = "";
      if (strs.Length == 0) return "";
      var s = GetShortestString(strs);
      for (int i = 0; i<s.Length; i++)
      {
        if (!AreAllHaveTheSameCharAtIndex(strs, i)) return result;
        result += s[i];
      }
      return result;
    }

    private bool AreAllHaveTheSameCharAtIndex(string[] strs, int idx)
    {
      char c = strs[0][idx];
      foreach (string s in strs)
      {
        if (c != s[idx]) return false;
      }
      return true;
    }

    private string GetShortestString(string[] strs)
    {
      int lenght = strs[0].Length;
      string shortest = strs[0];
      foreach (string str in strs)
      {
        if (str.Length > lenght) continue;
        shortest = str;
        lenght = shortest.Length;
      }
      return shortest;
    }

  }

  public class UnitTest1
  {
    [Theory]
    [InlineData("", new[] { "" })]
    [InlineData("flow", new[] { "flower", "flow" })]
    [InlineData("fl", new[] { "flower", "flow", "flight" })]
    [InlineData("", new[] { "dog", "racecar", "car" })]
    [InlineData("aaaaaaaa", new[] { "aaaaaaaa", "aaaaaaaa", "aaaaaaaag" })]
    public void Test1(string expected, string[] strs)
    {
      var result = new Solution().LongestCommonPrefix(strs);
      Assert.Equal(expected, result);
    }
  }
}
