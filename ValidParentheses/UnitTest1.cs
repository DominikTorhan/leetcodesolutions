using System;
using Xunit;

namespace ValidParentheses
{

  //  Valid Parentheses

  //Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

  //An input string is valid if:

  //Open brackets must be closed by the same type of brackets.
  //Open brackets must be closed in the correct order.
  //Note that an empty string is also considered valid.

  //Example 1:

  //Input: "()"
  //Output: true
  //Example 2:

  //Input: "()[]{}"
  //Output: true
  //Example 3:

  //Input: "(]"
  //Output: false
  //Example 4:

  //Input: "([)]"
  //Output: false
  //Example 5:

  //Input: "{[]}"
  //Output: true

    //(([]))()()
    //01234567

  public class Solution
  {
    //"{[()]}"
    public bool IsValid(string s)
    {
      if (IsValidLast(s)) return true;
      if (s.Length % 2 == 1) return false;
      while (s.Length > 0)
      {
        int idxClosed = GetIdxOfFirstClosed(s);
        if (idxClosed == -1) return false;
        char closed = s[idxClosed];
        char opened = GetOpen(closed);
        string sub = s.Substring(0, idxClosed);
        int idxOpened = sub.LastIndexOf(opened);
        if (idxOpened == -1) return false;
        string sub1 = s.Substring(idxOpened, idxClosed - idxOpened + 1);
        if (!IsValid(sub1)) return false;
        s = s.Remove(idxOpened, sub1.Length);
        if (IsValidLast(s)) return true;
      }
      return false;
    }

    private bool IsValidLast(string s)
    {
      if (s == "") return true;
      if (s == "()") return true;
      if (s == "[]") return true;
      if (s == "{}") return true;
      return false;
    }

    private int GetIdxOfFirstClosed(string s)
    {
      for(int i = 0; i < s.Length; i++)
      {
        char c = s[i];
        if (IsClosed(c)) return i;
      }
      return -1;
    }

    private bool IsClosed(char c)
    {
      if (c == ')') return true;
      if (c == ']') return true;
      if (c == '}') return true;
      return false;
    }

    private char GetOpen(char c)
    {
      if (c == ')') return '(';
      if (c == ']') return '[';
      if (c == '}') return '{';
      return ' ';
    }

  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(true, "")]
    [InlineData(true, "()")]
    [InlineData(true, "()[]{}")]
    [InlineData(true, "{[]}")]
    [InlineData(true, "{[()]}")]
    [InlineData(false, "(]")]
    [InlineData(false, "([)]")]
    [InlineData(false, "((")]
    public void Test1(bool expected, string s)
    {
      var result = new Solution().IsValid(s);
      Assert.Equal(expected, result);
    }
  }
}
