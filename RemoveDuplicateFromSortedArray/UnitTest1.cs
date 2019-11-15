using System;
using Xunit;

namespace RemoveDuplicateFromSortedArray
{

  //  Given a sorted array nums, remove the duplicates in-place such that each element appear only once and return the new length.

  //Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.

  //Example 1:

  //Given nums = [1,1,2],

  //Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively.

  //It doesn't matter what you leave beyond the returned length.
  //Example 2:

  //Given nums = [0,0,1,1,1,2,2,3,3,4],

  //Your function should return length = 5, with the first five elements of nums being modified to 0, 1, 2, 3, and 4 respectively.

  //It doesn't matter what values are set beyond the returned length.
  //Clarification:

  //Confused why the returned value is an integer but your answer is an array?

  //Note that the input array is passed in by reference, which means modification to the input array will be known to the caller as well.

  //Internally you can think of this:

  //// nums is passed in by reference. (i.e., without making a copy)
  //int len = removeDuplicates(nums);

  //// any modification to nums in your function would be known by the caller.
  //// using the length returned by your function, it prints the first len elements.
  //for (int i = 0; i < len; i++) {
  //    print(nums[i]);
  //  }



  public class Solution
  {

    public int RemoveDuplicatesSolution(int[] nums)
    {
      if (nums.Length == 0) return 0;
      int i = 0;
      for (int j = 1; j < nums.Length; j++)
      {
        if (nums[j] != nums[i])
        {
          i++;
          nums[i] = nums[j];
        }
      }
      return i + 1;
    }


    public int RemoveDuplicates(int[] nums)
    {
      int num, next;
      int pos = 0;
      if (nums.Length < 2) return nums.Length;
      num = nums[0];
      for (int i = 0; i < nums.Length - 1; i++)
      {
        next = nums[i + 1];
        if (next <= num) continue;
        pos++;
        num = next;
        nums[pos] = next;
      }
      return pos + 1;
    }
  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(0, new int[] { }, new int[] { })]
    [InlineData(1, new int[] { 1 }, new int[] { 1 })]
    [InlineData(1, new int[] { 1, }, new int[] { 1, 1 })]
    [InlineData(2, new int[] { 1, 2 }, new int[] { 1, 1, 2 })]
    [InlineData(3, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
    [InlineData(5, new int[] { 0, 1, 2, 3, 4 }, new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 })]
    [InlineData(3, new int[] { 1, 2, 3 }, new int[] { 1, 1, 2, 3 })]
    public void Test1(int expected, int[] expectedArray, int[] array)
    {
      var result = new Solution().RemoveDuplicates(array);
      Assert.Equal(expected, result);
      for (int i = 0; i < result; i++)
      {
        Assert.Equal(array[i], expectedArray[i]);
      }
      //Assert.Equal(expectedArray, array);
    }
  }
}
