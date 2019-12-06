using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BinaryTreeLevelOrderTraversal
{

  //  Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

  //For example:
  //Given binary tree[3, 9, 20, null, null, 15, 7],
  //    3
  //   / \
  //  9  20
  //    /  \
  //   15   7
  //return its level order traversal as:
  //[
  //  [3],
  //  [9,20],
  //  [15,7]
  //]

  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
  }

  public class Solution
  {
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
      Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
      RecursiveNode(0, root, dict);
      IList<IList<int>> list = new List<IList<int>>();
      foreach (var val in dict.Values)
      {
        list.Add(val);
      }
      return list;
    }

    private void RecursiveNode(int level, TreeNode node, Dictionary<int, List<int>> dict)
    {
      if (node == null) return;
      Add(level, node.val, dict);
      RecursiveNode(level + 1, node.left, dict);
      RecursiveNode(level + 1, node.right, dict);
    }

    private void Add(int level, int val, Dictionary<int, List<int>> dict)
    {
      if (!dict.ContainsKey(level)) dict.Add(level, new List<int>());
      dict[level].Add(val);
    }

  }

  public class UnitTest1
  {

    private TreeNode CreateTree1()
    {
      var root = new TreeNode(1);
      return root;
    }
    private TreeNode CreateTree2()
    {
      var root = new TreeNode(1);
      root.left = new TreeNode(2);
      root.right = new TreeNode(3);
      return root;
    }
    private TreeNode CreateTree3()
    {
      var root = new TreeNode(3);
      root.left = new TreeNode(9);
      root.right = new TreeNode(20);
      root.right.left = new TreeNode(15);
      root.right.right = new TreeNode(7);
      return root;
    }


    [Fact]
    public void Test1()
    {
      var root = CreateTree1();
      var result = new Solution().LevelOrder(root);
      Assert.Equal(result[0].ToArray(), new[] { 1 });
    }
    [Fact]
    public void Test2()
    {
      var root = CreateTree2();
      var result = new Solution().LevelOrder(root);
      Assert.Equal(result[0].ToArray(), new[] { 1 });
      Assert.Equal(result[1].ToArray(), new[] { 2, 3 });
    }
    [Fact]
    public void Test3()
    {
      var root = CreateTree3();
      var result = new Solution().LevelOrder(root);
      Assert.Equal(result[0].ToArray(), new[] { 3 });
      Assert.Equal(result[1].ToArray(), new[] { 9, 20 });
      Assert.Equal(result[2].ToArray(), new[] { 15, 7 });
    }

  }
}
