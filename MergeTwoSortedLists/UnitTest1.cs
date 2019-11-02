using System;
using Xunit;

namespace MergeTwoSortedLists
{
  //  Merge two sorted linked lists and return it as a new list.The new list should be made by splicing together the nodes of the first two lists.

  //Example:

  //Input: 1->2->4, 1->3->4
  //Output: 1->1->2->3->4->4

  public static class Extenstions
  {
    public static ListNode Create(int[] a)
    {
      if (a.Length == 0) return null;
      var node = new ListNode(a[0]);
      var head = node;
      for (int i = 1; i < a.Length; i++)
      {
        var nodeNext = new ListNode(a[i]);
        node.next = nodeNext;
        node = nodeNext;
      }
      return head;
    }

    public static int Count(this ListNode head)
    {
      int count = 0;
      var node = head;
      while (node != null)
      {
        count++;
        node = node.next;
      }
      return count;
    }

    public static int[] ToArray(this ListNode head)
    {
      int i = 0;
      int count = Count(head);
      int[] array = new int[count];
      var node = head;
      while (node != null)
      {
        array[i] = node.val;
        node = node.next;
        i++;
      }
      return array;
    }

    public static ListNode GetNodeByIdx(this ListNode head, int idx)
    {
      var node = head;
      for (int i = 0; i < idx; i++)
      {
        node = node.next;
      }
      return node;
    }

  }


  public class ListNode
  {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
  }

  public class Solution
  {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
      ListNode curr, newHead = null, tail = null;
      if (l1 == null && l2 == null) return null;
      if (l1 == null) return l2;
      if (l2 == null) return l1;
      var node1 = l1;
      var node2 = l2;
      while (true)
      {
        if (IsFirstSmaller(node1, node2))
        {
          curr = node1;
          node1 = node1?.next;
        }
        else
        {
          curr = node2;
          node2 = node2?.next;
        }
        if (curr == null) break;
        if (newHead == null)
        {
          newHead = curr;
          tail = newHead;
        }
        else
        {
          tail.next = curr;
          tail = tail.next;
        }
      }
      return newHead;
    }

    private bool IsFirstSmaller(ListNode n1, ListNode n2)
    {
      if (n2 == null) return true;
      if (n1 == null) return false;
      return n1.val < n2.val;
    }

  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 8, 9 }, new int[] { 1, 8, 9 }, new int[] { 2, 3, 4, 5 })]
    [InlineData(new int[] { }, new int[] { }, new int[] { })]
    [InlineData(new int[] { 0 }, new int[] { }, new int[] { 0 })]
    [InlineData(new int[] { 0 }, new int[] { 0 }, new int[] { })]
    [InlineData(new int[] { 0, 1, 2 }, new int[] { 0, 2 }, new int[] { 1 })]
    [InlineData(new int[] { 1, 2 }, new int[] { 2 }, new int[] { 1 })]
    [InlineData(new[] { 1, 1 }, new[] { 1 }, new[] { 1 })]
    [InlineData(new[] { 1, 1, 2, 2 }, new[] { 1, 2 }, new[] { 1, 2 })]
    [InlineData(new[] { 1, 1, 2, 2, 3, 3 }, new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
    [InlineData(new[] { 1, 1, 2, 3, 4, 4 }, new[] { 1, 2, 4 }, new[] { 1, 3, 4 })]
    //Input: 1->2->4, 1->3->4
    //Output: 1->1->2->3->4->4

    public void Test1(int[] expected, int[] a, int[] b)
    {
      var result = new Solution().MergeTwoLists(Extenstions.Create(a), Extenstions.Create(b));
      Assert.Equal(expected, result.ToArray());
    }
  }
}
