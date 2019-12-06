using System;
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
      TreeNode root = new TreeNode(nums[0]);
      return root;
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
      var tree = new Solution().SortedArrayToBST(new[] { 1 });
      var array = new BinaryTreeHelper().TreeToArray(tree);
      Assert.Equal(array, new int?[] { 1 });
    }

  }
}
