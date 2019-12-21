using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace GenerateParentheses
{

  //  Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

  //For example, given n = 3, a solution set is:

  //1 1
  //2 2 (1)
  //3 5 (4)
  //4 13 (12)

  //[
  //  "((()))",
  //  "(()())",
  //  "(())()",
  //  "()(())",
  //  "()()()"
  //]

  //4
  //(((())))
  //((()()))
  //((())())
  //(())()()
  //(()(()))
  //(()()())
  //((()))()
  //(()())()
  //()((()))
  //()(()())
  //()()(())
  //()(())()
  //()()()()

  public class Solution
  {
    public IList<string> GenerateParenthesis(int n)
    {
      List<string> cln = new List<string>();
      var dict = Generate(n);
      foreach (string s in dict.Keys)
      {
        if (!IsParenthesisCorrect(s)) continue;
        cln.Add(s);
      }
      return cln;
    }

    private bool IsParenthesisCorrect(string s)
    {
      while (true)
      {
        if (s == "") return true;
        if (!s.Contains("()")) return false;
        s = s.Replace("()", "");
      }
    }

    //brute force
    private Dictionary<string, string> Generate(int n)
    {
      Dictionary<string, string> dict = new Dictionary<string, string>();
      dict.Add("(", "");
      for (int i = 2; i <= n * 2; i++)
      {
        dict = UpdateDict(dict);
      }
      return dict;
    }

    private Dictionary<string, string> UpdateDict(Dictionary<string,string> dict)
    {
      Dictionary<string, string> newDict = new Dictionary<string, string>();
      foreach (string key in dict.Keys)
      {
        newDict.Add(key + "(", "");
        newDict.Add(key + ")", "");
      }
      return newDict;
    }

  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(new[] { "()" }, 1)]
    [InlineData(new[] { "(())", "()()" }, 2)]
    [InlineData(new[] { "((()))", "(()())", "(())()", "()(())", "()()()" }, 3)]
    public void Test1(string[] expected, int n)
    {
      var result = new Solution().GenerateParenthesis(n).ToArray();
      Assert.Equal(expected, result);
    }
  }
}
