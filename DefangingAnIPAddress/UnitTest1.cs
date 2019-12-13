using System;
using Xunit;

namespace DefangingAnIPAddress
{

  //  Given a valid(IPv4) IP address, return a defanged version of that IP address.

  //A defanged IP address replaces every period "." with "[.]".



  //Example 1:

  //Input: address = "1.1.1.1"
  //Output: "1[.]1[.]1[.]1"
  //Example 2:

  //Input: address = "255.100.50.0"
  //Output: "255[.]100[.]50[.]0"


  //Constraints:

  //The given address is a valid IPv4 address.

  public class Solution
  {
    public string DefangIPaddr(string address)
    {
      return address.Replace(".", "[.]");
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData("", "")]
    [InlineData("1[.]1[.]1[.]1", "1.1.1.1")]
    [InlineData("255[.]100[.]50[.]0", "255.100.50.0")]
    public void Test1(string expected, string address)
    {
      var result = new Solution().DefangIPaddr(address);
      Assert.Equal(expected, result);
    }
  }
}
