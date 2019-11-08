using System;
using Xunit;

namespace MaximumDepthOfBinaryTree
{

  //  Given a binary tree, find its maximum depth.

  //The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

  //Note: A leaf is a node with no children.

  //Example:

  //Given binary tree[3, 9, 20, null, null, 15, 7],

  //    3
  //   / \
  //  9  20
  //    /  \
  //   15   7
  //return its depth = 3.

  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
  }

  public class Solution
  {
    public int MaxDepth(TreeNode root)
    {
      var level = GetLevel(0, root);
      return level;
    }
    private int GetLevel(int init, TreeNode node)
    {
      int levelLeft, levelRight;
      if (node == null) return init;
      int level = init + 1;
      levelLeft = GetLevel(level, node.left);
      levelRight = GetLevel(level, node.right);
      if (levelLeft > levelRight) return levelLeft;
      return levelRight;
    }
  }

  public static class TreeNodeExtentions
  {
    public static TreeNode Create(int?[] array)
    {
      return null;
    }
    public static TreeNode CreateExample()
    {
      var x7 = new TreeNode(7);
      var x15 = new TreeNode(15);
      var x20 = new TreeNode(20){ left = x15, right = x7 };
      return new TreeNode(3) { left = new TreeNode(9), right = x20 };
    }

  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(3)]
    public void Test1(int exprected)
    {
      var result = new Solution().MaxDepth(TreeNodeExtentions.CreateExample());
      Assert.Equal(result, exprected);
    }
  }
}
