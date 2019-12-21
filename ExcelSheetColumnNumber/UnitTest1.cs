using System;
using Xunit;

namespace ExcelSheetColumnNumber
{

  //  Given a column title as appear in an Excel sheet, return its corresponding column number.

  //For example:

  //    A -> 1
  //    B -> 2
  //    C -> 3
  //    ...
  //    Z -> 26
  //    AA -> 27
  //    AB -> 28 
  //    ...
  //Example 1:

  //Input: "A"
  //Output: 1
  //Example 2:

  //Input: "AB"
  //Output: 28
  //Example 3:

  //Input: "ZY"
  //Output: 701


  public class Solution
  {
    const int con = 64;
    public int TitleToNumber(string s)
    {
      int sum = 0, num, mult;
      for (int i =s.Length-1; i>=0; i--)
      {
        mult = s.Length - i - 1;
        num = (int)s[i] - con;
        if (mult > 0) num *= Convert.ToInt32(Math.Pow(26, mult));
        sum += num;
      }
      return sum;
    }
  }

  public class UnitTest1
  {

    [Theory]
    [InlineData(1, "A")]
    [InlineData(2, "B")]
    [InlineData(3, "C")]
    [InlineData(26, "Z")]
    [InlineData(27, "AA")]
    [InlineData(28, "AB")]
    [InlineData(701, "ZY")]
    [InlineData(702, "ZZ")]
    [InlineData(703, "AAA")]
    public void Test1(int expected, string s)
    {
      var result = new Solution().TitleToNumber(s);
      Assert.Equal(expected, result);
    }
  }
}
