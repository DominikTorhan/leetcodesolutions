using Xunit;

namespace SameTree
{

  //  Given two binary trees, write a function to check if they are the same or not.

  //Two binary trees are considered the same if they are structurally identical and the nodes have the same value.

  //Example 1:

  //Input:     1         1
  //          / \       / \
  //         2   3     2   3

  //        [1,2,3], [1,2,3]

  //Output: true
  //Example 2:

  //Input:     1         1
  //          /           \
  //         2             2

  //        [1,2], [1,null,2]

  //Output: false
  //Example 3:

  //Input:     1         1
  //          / \       / \
  //         2   1     1   2

  //        [1,2,1], [1,1,2]

  //Output: false

  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
  }

  public class Solution
  {
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
      if (!AreNodesEqual(p, q)) return false;
      if (p == null && q == null) return true;
      if (!IsSameTree(p?.left, q?.left)) return false;
      if (!IsSameTree(p?.right, q?.right)) return false;
      return true;
    }
    private bool AreNodesEqual(TreeNode p, TreeNode q)
    {
      if (p == null && q == null) return true;
      if (p == null) return false;
      if (q == null) return false;
      if (p.val == q.val) return true;
      return false;
    }
  }

  public class UnitTest1
  {

    private TreeNode CreateTree(int[] array)
    {
      var root = CreateNode(array[0]);
      root.left = CreateNode(array[1]);
      root.right = CreateNode(array[2]);
      return root;
    }

    private TreeNode CreateNode(int val)
    {
      if (val == 0) return null;
      return new TreeNode(val);
    }

    [Theory]
    [InlineData(true, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
    [InlineData(false, new int[] { 1, 2, 3 }, new int[] { 1, 3, 2 })]
    [InlineData(false, new int[] { 1, 0, 3 }, new int[] { 1, 3, 2 })]
    public void Test1(bool expected, int[] a1, int[] a2)
    {
      var result = new Solution().IsSameTree(CreateTree(a1), CreateTree(a2));
      Assert.Equal(expected, result);
    }
  }
}
