using System;
using System.Collections.Generic;
using Xunit;

namespace UniquePaths
{

  public class Solution
  {
    Dictionary<Tuple<int, int>, int> dict = new Dictionary<Tuple<int, int>, int>();
    public int UniquePaths(int m, int n)
    {
      int val;
      if (m == 1) return 1;
      if (n == 1) return 1;
      if (m == 2) return n;
      if (n == 2) return m;
      //3 x 3 -> 2 x 3 + 2 x 3
      if (dict.ContainsKey(new Tuple<int, int>(m, n))) return dict[new Tuple<int, int>(m, n)];
      if (dict.ContainsKey(new Tuple<int, int>(n, m))) return dict[new Tuple<int, int>(n, m)];
      val = UniquePaths(m, n - 1) + UniquePaths(m - 1, n);
      dict.Add(new Tuple<int, int>(m,n), val);
      return val;
    }
  }
  public class UnitTest1
  {
    [Theory]
    [InlineData(1,3,1)]
    [InlineData(2,2,2)]
    [InlineData(6,3,3)]
    [InlineData(28,3,7)]
    [InlineData(1916797311, 51,9)]
    public void Test1(int expected, int m, int n)
    {
      var result = new Solution().UniquePaths(m, n);
      Assert.Equal(expected,result);
    }
  }
}
