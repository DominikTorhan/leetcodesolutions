using System;
using Xunit;

namespace LongestPalindromicSubstring
{

  //  Given a string s, find the longest palindromic substring in s.You may assume that the maximum length of s is 1000.

  //Example 1:

  //Input: "babad"
  //Output: "bab"
  //Note: "aba" is also a valid answer.
  //Example 2:

  //Input: "cbbd"
  //Output: "bb"

  public class Solution
  {
    public string LongestPalindrome(string s)
    {
      string maxPal = "";
      if (string.IsNullOrEmpty(s)) return "";
      for (int i = 0; i < s.Length; i++)
      {
        if (maxPal.Length >= s.Length - i) continue; 
        var pal = GetPalindrom(s, i);
        if (pal.Length > maxPal.Length) maxPal = pal;
      }
      return maxPal;
    }
    private string GetPalindrom(string s, int start)
    {
      char c = s[start];
      for (int j = s.Length - 1; j >= start; j--)
      {
        if (c != s[j]) continue;
        string s1 = s.Substring(start, j - start + 1);
        if (IsPalindrom(s1)) return s1;
      }
      return "";
    }
    private bool IsPalindrom(string s)
    {
      int mid = s.Length / 2;
      for (int i = 0; i < mid; i++)
      {
        int j = s.Length - 1 - i;
        if (s[i] != s[j]) return false;
      }
      return true;
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData("", "")]
    [InlineData("bab", "babad")]
    [InlineData("bb", "cbbd")]
    [InlineData("aa", "123456aa")]
    [InlineData("a", "a1")]
    [InlineData("a", "a123456")]
    [InlineData("ranynar", "civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth")]
    public void Test1(string expected, string s)
    {
      var result = new Solution().LongestPalindrome(s);
      Assert.Equal(expected, result);
    }
  }
}
