using System;
using Xunit;

namespace ValidNumber
{

  //  Validate if a given string can be interpreted as a decimal number.

  //Some examples:
  //"0" => true
  //" 0.1 " => true
  //"abc" => false
  //"1 a" => false
  //"2e10" => true
  //" -90e3   " => true
  //" 1e" => false
  //"e3" => false
  //" 6e-1" => true
  //" 99e2.5 " => false
  //"53.5e93" => true
  //" --6 " => false
  //"-+3" => false
  //"95a54e53" => false

  //Note: It is intended for the problem statement to be ambiguous. You should gather all requirements up front before implementing one. However, here is a list of characters that can be in a valid decimal number:

  //Numbers 0-9
  //Exponent - "e"
  //Positive/negative sign - "+"/"-"
  //Decimal point - "."
  //Of course, the context of these characters also matters in the input.

  //Update (2015-02-10):
  //The signature of the C++ function had been updated.If you still see your function signature accepts a const char* argument, please click the reload button to reset your code definition.

  public class Solution
  {
    public bool IsNumber(string s)
    {
      s = s.TrimStart();
      s = s.TrimEnd();
      if (s.Contains("e")) return IsNumberWithE(s);
      if (s.Contains(".")) return IsNumberWithComma(s);
      if (int.TryParse(s, out _)) return true;
      if (long.TryParse(s, out _)) return true;
      return false;
    }
    private bool IsNumberWithE(string s)
    {
      var strs = s.Split('e');
      if (strs.Length != 2) return false;
      var s0 = strs[0];
      var s1 = strs[1];
      if (s0 == "") return false;
      if (s1 == "") return false;
      if (s0.Contains(' ')) return false;
      if (!float.TryParse(s0, out _)) return false;
      if (s1.Contains(' ')) return false;
      if (long.TryParse(s1, out _)) return true;
      if (int.TryParse(s1, out _)) return true;
      return false;
    }

    private bool IsNumberWithComma(string s)
    {
      if (s == ".") return false;
      if (s == "-.") return false;
      if (s == "+.") return false;
      var strs = s.Split('.');
      if (strs.Length != 2 && strs.Length != 1) return false;
      var s0 = strs[0];
      var s1 = strs[1];
      if (!IsValidInt_S0(s0)) return false;
      if (!IsValidInt_S1(s1)) return false;
      return true;
    }
    private bool IsValidInt_S0(string s)
    {
      if (s == "") return true;
      if (s.Contains(' ')) return false;
      if (s == "+") return true;
      if (s == "-") return true;
      if (int.TryParse(s, out _)) return true;
      if (long.TryParse(s, out _)) return true;
      return false;
    }

    private bool IsValidInt_S1(string s)
    {
      if (s == "") return true;
      if (s.Contains(' ')) return false;
      if (s.Contains('-')) return false;
      if (s.Contains('+')) return false;
      if (int.TryParse(s, out _)) return true;
      if (long.TryParse(s, out _)) return true;
      return false;
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(true, "0")]
    [InlineData(true, " 0.1")]
    [InlineData(false, "abc")]
    [InlineData(false, "1 a")]
    [InlineData(true, "2e10")]
    [InlineData(true, " -90e3   ")]
    [InlineData(false, " 1e")]
    [InlineData(false, "e3")]
    [InlineData(true, " 6e-1")]
    [InlineData(false, " 99e2.5 ")]
    [InlineData(true, "53.5e93")]
    [InlineData(false, " --6 ")]
    [InlineData(false, "-+3")]
    [InlineData(false, "95a54e53")]
    [InlineData(false, ".")]
    [InlineData(false, "x.a")]
    [InlineData(true, ".1")]
    [InlineData(true, "3.")]
    [InlineData(false, ". 1")]
    [InlineData(false, ".-4")]
    [InlineData(true, "-1.")]
    [InlineData(false, "1 .")]
    [InlineData(true, "+.8")]
    [InlineData(true, " +.8")]
    [InlineData(false, ".+8")]
    [InlineData(false, "96 e5")]
    [InlineData(true, " 005047e+6")]
    [InlineData(true, "5897972791")]
    [InlineData(true, "-.1")]
    [InlineData(true, "-.18205126")]
    [InlineData(false, "-.V")]
    [InlineData(false, " -.")]
    [InlineData(true, "109727237193.1 ")]
    [InlineData(true, "44e016912630333")]
    public void Test1(bool expected, string s)
    {
      var result = new Solution().IsNumber(s);
      Assert.Equal(expected, result);
    }
  }
}
