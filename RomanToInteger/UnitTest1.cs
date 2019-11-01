using Xunit;

//Roman to Integer

//Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

//Symbol Value
//I             1
//V             5
//X             10
//L             50
//C             100
//D             500
//M             1000
//For example, two is written as II in Roman numeral, just two one's added together. Twelve is written as, XII, which is simply X + II. The number twenty seven is written as XXVII, which is XX + V + II.

//Roman numerals are usually written largest to smallest from left to right.However, the numeral for four is not IIII. Instead, the number four is written as IV.Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX.There are six instances where subtraction is used:

//I can be placed before V (5) and X(10) to make 4 and 9.
//X can be placed before L(50) and C(100) to make 40 and 90.
//C can be placed before D(500) and M(1000) to make 400 and 900.
//Given a roman numeral, convert it to an integer.Input is guaranteed to be within the range from 1 to 3999.

//Example 1:

//Input: "III"
//Output: 3
//Output: 3
//Example 2:

//Input: "IV"
//Output: 4
//Example 3:

//Input: "IX"
//Output: 9
//Example 4:

//Input: "LVIII"
//Output: 58
//Explanation: L = 50, V= 5, III = 3.
//Example 5:

//Input: "MCMXCIV"
//Output: 1994
//Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.


namespace RomanToInteger
{

  public class Solution
  {
    public int RomanToInt(string s)
    {
      char c;
      int n, last = 0;
      int result = 0;
      while (s.Length > 0)
      {
        c = PopChar(ref s);
        n = GetIntByChar(c);
        if (last > n)
        {
          result -= n;
        }
        else
        {
          result += n;
        }
        last = n;
      }
      return result;
    }

    private char PopChar(ref string s)
    {
      char c = s.ToCharArray()[s.Length - 1];
      s = s.Substring(0, s.Length - 1);
      return c;
    }

    private int GetIntByChar(char c)
    {
      switch (c)
      {
        case 'I': return 1;
        case 'V': return 5;
        case 'X': return 10;
        case 'L': return 50;
        case 'C': return 100;
        case 'D': return 500;
        case 'M': return 1000;
      }
      return 0;
    }

  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(7, "VII")]
    [InlineData(8, "VIII")]
    [InlineData(9, "IX")]
    [InlineData(10, "X")]
    [InlineData(15, "XV")]
    [InlineData(16, "XVI")]
    [InlineData(58, "LVIII")]
    [InlineData(1994, "MCMXCIV")]
    public void Test1(int expected, string s)
    {
      var result = new Solution().RomanToInt(s);

      Assert.Equal(expected, result);
    }
  }
}
