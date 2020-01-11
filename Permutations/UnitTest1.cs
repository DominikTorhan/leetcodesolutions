using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Permutations
{

  //  Given a collection of distinct integers, return all possible permutations.

  //Example:

  //Input: [1,2,3]
  //  Output:
  //[
  //  [1,2,3],
  //  [1,3,2],
  //  [2,1,3],
  //  [2,3,1],
  //  [3,1,2],
  //  [3,2,1]
  //]

  //2 ->  2
  //12
  //21

  //3 -> 6
  //123
  //132
  //213
  //231
  //312
  //321

  //4 -> 24
  //1234
  //1243
  //1324
  //1342
  //1423
  //1432


  public class Solution
  {

    public IList<IList<int>> Permute(int[] nums)
    {
      IList<IList<int>> list;
      list = new List<IList<int>>();
      if (nums.Length == 0) return list;
      Recur(list, nums, 0);
      return list;
    }

    private void Recur(IList<IList<int>> list, int[] nums, int idx)
    {
      int tmp;
      if (idx == nums.Length)
      {
        list.Add(nums.ToList());
        return;
      }
      for (int i = idx; i<nums.Length; i++)
      {
        tmp = nums[i];
        nums[i] = nums[idx];
        nums[idx] = tmp;

        Recur(list, nums, idx + 1);

        tmp = nums[idx];
        nums[idx] = nums[i];
        nums[i] = tmp;

      }
    }


    public IList<IList<int>> PermuteOld(int[] nums)
    {
      IList<IList<int>> list;
      list = new List<IList<int>>();
      if (nums.Length < 1) return list;
      var factor = Factor(nums.Length);
      for (int j = 0; j < factor; j++)
      {
        list.Add(new List<int>());
      }
      Permute(nums, new List<int>(), list);
      return list;
    }

    private void Permute(int[] nums, List<int> except, IList<IList<int>> list)
    {
      if (nums.Length == except.Count) return;
      var factor = Factor(nums.Length - except.Count - 1);
      List<int> newExcept;

      for (int i = 0; i < nums.Length; i++)
      {
        int counter = 0;
        if (except.Contains(nums[i])) continue;
        foreach (var cln in list)
        {
          if (cln.Contains(nums[i])) continue;
          cln.Add(nums[i]);
          counter++;
          if (counter >= factor) break;
        }
        newExcept = new List<int>();
        newExcept.AddRange(except);
        newExcept.Add(nums[i]);
        Permute(nums, newExcept, list);
      }

    }

    private int Factor(int x)
    {
      int result = 1;
      if (x == 0) return 1;
      if (x < 3) return x;
      for (int i = 2; i <= x; i++)
      {
        result = result * i;
      }
      return result;
    }
  }


  public class UnitTest1
  {

    [Fact]
    public void TestEmpty()
    {
      var nums = new int[] { };
      var result = new Solution().Permute(nums);
      var expected = new List<IList<int>>();
      Assert.Equal(expected, result);
    }


    [Fact]
    public void Test1()
    {
      var nums = new[] { 1 };
      var result = new Solution().Permute(nums);
      var expected = new List<IList<int>>();
      expected.Add(new List<int> { 1 });
      Assert.Equal(expected, result);
    }

    [Fact]
    public void Test2()
    {
      var nums = new[] { 1, 2 };
      var result = new Solution().Permute(nums);
      var expected = new List<IList<int>>();
      expected.Add(new List<int> { 1, 2 });
      expected.Add(new List<int> { 2, 1 });
      Assert.Equal(expected, result);
    }

    [Fact]
    public void Test3()
    {
      var nums = new[] { 1, 2, 3 };
      var result = new Solution().Permute(nums);
      var expected = new List<IList<int>>();
      expected.Add(new List<int> { 1, 2, 3 });
      expected.Add(new List<int> { 1, 3, 2 });
      expected.Add(new List<int> { 2, 1, 3 });
      expected.Add(new List<int> { 2, 3, 1 });
      expected.Add(new List<int> { 3, 2, 1 });
      expected.Add(new List<int> { 3, 1, 2 });
      Assert.Equal(expected, result);
    }

    [Fact]
    public void Test4()
    {
      var nums = new[] { 1, 2, 3, 4 };
      var result = new Solution().Permute(nums);
      var expected = new List<IList<int>>();
      expected.Add(new List<int> { 1, 2, 3, 4 });
      expected.Add(new List<int> { 1, 2, 4, 3 });
      expected.Add(new List<int> { 1, 3, 2, 4 });
      expected.Add(new List<int> { 1, 3, 4, 2 });
      expected.Add(new List<int> { 1, 4, 3, 2 });
      expected.Add(new List<int> { 1, 4, 2, 3 });

      expected.Add(new List<int> { 2, 1, 3, 4 });
      expected.Add(new List<int> { 2, 1, 4, 3 });
      expected.Add(new List<int> { 2, 3, 1, 4 });
      expected.Add(new List<int> { 2, 3, 4, 1 });
      expected.Add(new List<int> { 2, 4, 3, 1 });
      expected.Add(new List<int> { 2, 4, 1, 3 });

      expected.Add(new List<int> { 3, 2, 1, 4 });
      expected.Add(new List<int> { 3, 2, 4, 1 });
      expected.Add(new List<int> { 3, 1, 2, 4 });
      expected.Add(new List<int> { 3, 1, 4, 2 });
      expected.Add(new List<int> { 3, 4, 1, 2 });
      expected.Add(new List<int> { 3, 4, 2, 1 });

      expected.Add(new List<int> { 4, 2, 3, 1 });
      expected.Add(new List<int> { 4, 2, 1, 3 });
      expected.Add(new List<int> { 4, 3, 2, 1 });
      expected.Add(new List<int> { 4, 3, 1, 2 });
      expected.Add(new List<int> { 4, 1, 3, 2 });
      expected.Add(new List<int> { 4, 1, 2, 3 });

      Assert.Equal(expected, result);
    }


  }
}
