using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace fizzbuzz
{
  //  Write a program that outputs the string representation of numbers from 1 to n.

  //But for multiples of three it should output “Fizz” instead of the number and for the multiples of five output “Buzz”. 
  //For numbers which are multiples of both three and five output “FizzBuzz”.

  //Example:

  //n = 15,

  //Return:
  //[
  //    "1",
  //    "2",
  //    "Fizz",
  //    "4",
  //    "Buzz",
  //    "Fizz",
  //    "7",
  //    "8",
  //    "Fizz",
  //    "Buzz",
  //    "11",
  //    "Fizz",
  //    "13",
  //    "14",
  //    "FizzBuzz"
  //]

  public class Solution
  {
    public IList<string> FizzBuzz(int n)
    {
      string str;
      bool isThree, isFive;
      List<string> list = new List<string>();
      if (n == 0) return list;
      for (int i = 1; i <= n; i++)
      {
        isThree = i % 3 == 0;
        isFive = i % 5 == 0;
        str = "";
        if (isThree) str += "Fizz";
        if (isFive) str += "Buzz";
        if (str == "") str = i.ToString();
        list.Add(str);
      }
      return list;
    }
  }

  public class UnitTest1
  {

    [Theory]
    [InlineData(new string[] { }, 0)]
    [InlineData(new[] { "1" }, 1)]
    [InlineData(new[] { "1", "2" }, 2)]
    [InlineData(new[] { "1", "2", "Fizz" }, 3)]
    [InlineData(new[] { "1", "2", "Fizz", "4", "Buzz" }, 5)]
    [InlineData(new[] { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" }, 15)]
    public void Test1(string[] expected, int n)
    {
      var result = new Solution().FizzBuzz(n).ToArray();
      Assert.Equal(result, expected);
    }
  }
}
