using System.Collections.Generic;
using Xunit;

namespace ConvertSortedArrayToBinarySearchTree
{
  //  Given an array where elements are sorted in ascending order, convert it to a height balanced BST.

  //For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.

  //Example:

  //Given the sorted array: [-10,-3,0,5,9],

  //One possible answer is: [0,-3,9,-10,null,5], which represents the following height balanced BST:

  //      0
  //     / \
  //   -3   9
  //   /   /
  // -10  5

  //0 1 2
  // 1
  //0 2

  //01234
  //   2
  // 1   4
  //0   3

  //0 1 2 3 4 5 6
  //   3 
  // 1   5
  //0 2 4 6


  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
  }

  public class Solution
  {
    public TreeNode SortedArrayToBST(int[] nums)
    {
      if (nums == null) return null;
      if (nums.Length == 0) return null;
      int middle = nums.Length / 2;
      TreeNode root = new TreeNode(nums[middle]);
      int[] left, right;
      DivideArray(nums, out left, out right);
      Recursive(root, left, right);
      return root;
    }

    private void DivideArray(int[] array, out int[] left, out int[] right)
    {
      int i;
      int countLeft = array.Length / 2;
      int countRight = array.Length / 2;
      if (array.Length % 2 == 0) countRight--;
      left = new int[countLeft];
      right = new int[countRight];
      for (i = 0; i < countLeft; i++)
      {
        left[i] = array[i];
      }
      for (i = 0; i < countRight; i++)
      {
        right[countRight - 1 - i] = array[array.Length - 1 - i];
      }
    }
    private int GetMiddleValue(int[] nums)
    {
      return nums[nums.Length / 2];
    }

    private void Recursive(TreeNode root, int[] numsLeft, int[] numsRight)
    {
      int[] left, right;
      if (numsLeft.Length == 0) return;
      root.left = new TreeNode(GetMiddleValue(numsLeft));
      DivideArray(numsLeft, out left, out right);
      Recursive(root.left, left, right);
      if (numsRight.Length == 0) return;
      root.right = new TreeNode(GetMiddleValue(numsRight));
      DivideArray(numsRight, out left, out right);
      Recursive(root.right, left, right);
    }

  }

  public class BinaryTreeHelper
  {
    public int?[] TreeToArray(TreeNode root)
    {
      List<int?> list = new List<int?>();
      AddToList(root, list);
      return list.ToArray();
    }
    private void AddToList(TreeNode node, List<int?> list)
    {
      if (node == null) return;
      AddToList(node.left, list);
      list.Add(node.val);
      AddToList(node.right, list);
    }

    //int[size] array = new int[size]; 
    //int index = 0; 
    //void storeInOrder(node root)
    //{
    //  if (node == null) return;
    //  storeInOrder(root.leftChild());
    //  array[index++] = root.value;
    //  storeInOrder(root.rightChild());
    //}

  }

  public class UnitTest1
  {
    [Fact]
    public void Test1()
    {
      var tree = new Solution().SortedArrayToBST(new[] { 1 });
      var array = new BinaryTreeHelper().TreeToArray(tree);
      Assert.Equal(array, new int?[] { 1 });
    }
    [Fact]
    public void Test2()
    {
      var tree = new Solution().SortedArrayToBST(new[] { 0, 1, 2 });
      var array = new BinaryTreeHelper().TreeToArray(tree);
      Assert.Equal(array, new int?[] { 0, 1, 2 });
    }
    [Fact]
    public void Test3()
    {
      var tree = new Solution().SortedArrayToBST(new[] { 0, 1, 2, 3, 4, 5, 6 });
      var array = new BinaryTreeHelper().TreeToArray(tree);
      Assert.Equal(array, new int?[] { 0, 1, 2, 3, 4, 5, 6 });
    }

  }
}
