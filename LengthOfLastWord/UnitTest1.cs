using System;
using Xunit;

namespace LengthOfLastWord
{

  public class Solution
  {
    public int LengthOfLastWord(string s)
    {
      if (s == null) return 0;
      if (s == "") return 0;
      s = s.TrimEnd();
      var strs = s.Split();
      if (strs.Length == 0) return 0;
      return strs[strs.Length - 1].Length;
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(0, "")]
    [InlineData(1, "a")]
    [InlineData(1, "a ")]
    [InlineData(2, "a ab")]
    public void Test1(int expected, string s)
    {
      var result = new Solution().LengthOfLastWord(s);
      Assert.Equal(expected, result);
    }
  }
}
