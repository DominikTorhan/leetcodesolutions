using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LetterCombinationsOfaPhoneNumber
{

  //  Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.

  //A mapping of digit to letters(just like on the telephone buttons) is given below.Note that 1 does not map to any letters.




  //Example:


  //Input: "23"
  //Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
  //Note:


  //Although the above answer is in lexicographical order, your answer could be in any order you want.

  public class Solution
  {
    public IList<string> LetterCombinations(string digits)
    {
      var list = new List<string>();
      foreach (var c in digits)
      {
        list = AddNumber(list, c);
      }
      return list;
    }
    private List<string> AddNumber(List<string> list, char charNum)
    {
      var newList = new List<string>();
      if (list.Count == 0) list.Add("");
      foreach (string s in list)
      {
        var chars = GetCharsByNumber(charNum);
        foreach(char c in chars)
        {
          newList.Add(s + c);
        }
      }
      return newList;
    }
    private char[] GetCharsByNumber(char charNum)
    {
      switch (charNum)
      {
        case '2': return new[] { 'a', 'b', 'c' };
        case '3': return new[] { 'd', 'e', 'f' };
        case '4': return new[] { 'g', 'h', 'i' };
        case '5': return new[] { 'j', 'k', 'l' };//jkl
        case '6': return new[] { 'm', 'n', 'o' };//mno
        case '7': return new[] { 'p', 'q', 'r', 's' };//pqrs
        case '8': return new[] { 't', 'u', 'v' };//tuv
        case '9': return new[] { 'w', 'x', 'y', 'z' };//wxyz
      }
      return null;
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(new string[] { }, "")]
    [InlineData(new[] { "a", "b", "c" }, "2")]
    [InlineData(new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" }, "23")]
    [InlineData(new[] { "ag", "ah", "ai", "bg", "bh", "bi", "cg", "ch", "ci" }, "24")]
    public void Test1(string[] expected, string digits)
    {
      var result = new Solution().LetterCombinations(digits).ToArray();
      Assert.Equal(expected, result);
    }
  }
}
