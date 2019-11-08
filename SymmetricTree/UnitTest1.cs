using System;
using Xunit;

namespace SymmetricTree
{

  //  Given a binary tree, check whether it is a mirror of itself(ie, symmetric around its center).

  //For example, this binary tree [1,2,2,3,4,4,3] is symmetric:

  //    1
  //   / \
  //  2   2
  // / \ / \
  //3  4 4  3



  //But the following[1, 2, 2, null, 3, null, 3] is not:

  //    1
  //   / \
  //  2   2
  //   \   \
  //   3    3



  //Note:
  //Bonus points if you could solve it both recursively and iteratively.


  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
  }

  public class Solution
  {
    public bool IsSymmetric(TreeNode root)
    {
      if (root == null) return true;
      return Symm(root.left, root.right);
    }

    private bool Symm(TreeNode left, TreeNode right)
    {
      if (left == null && right == null) return true;
      if (left == null || right == null) return false;
      if (left.val != right.val) return false;
      if (!Symm(left.left, right.right)) return false;
      if (!Symm(left.right, right.left)) return false;
      return true;
    }
    
  }

  public static class TreeNodeExtentions
  {
    public static TreeNode Create(int[] array)
    {
      if (array.Length == 0) return null;
      var root = new TreeNode(array[0]);

      return root;
    }
    public static TreeNode CreateExample()
    {
      var x7 = new TreeNode(7);
      var x15 = new TreeNode(15);
      var x20 = new TreeNode(20) { left = x15, right = x7 };
      return new TreeNode(3) { left = new TreeNode(9), right = x20 };
    }


    public static TreeNode CreateExample2()
    {
      //    1
      //   / \
      //  2   2
      // / \ / \
      //3  4 4  3

      var left = new TreeNode(2) { left = new TreeNode(3), right = new TreeNode(4) };
      var right = new TreeNode(2) { left = new TreeNode(4), right = new TreeNode(3) };
      return new TreeNode(1) { left = left, right = right };
    }

  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(true, new [] { 1, 2, 3 })]
    public void Test1(bool expected, int[] array)
    {
      var result = new Solution().IsSymmetric(TreeNodeExtentions.CreateExample2());
      Assert.Equal(expected, result);

    }
  }
}
