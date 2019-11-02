using System;
using Xunit;

namespace RemoveDuplicatesFromSortedList
{
  //  Given a sorted linked list, delete all duplicates such that each element appear only once.

  //Example 1:

  //Input: 1->1->2
  //Output: 1->2
  //Example 2:

  //Input: 1->1->2->3->3
  //Output: 1->2->3

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
    public ListNode DeleteDuplicates(ListNode head)
    {
      if (head == null) return null;
      var node = head;
      var curr = node;
      while(true)
      {
        if (node.next == null)
        {
          curr.next = null;
          break;
        }
        if (node.val != node.next.val)
        {
          curr.next = node.next;
          curr = curr.next;
        }
        node = node.next;
      }
      return head;
    }
  }


  public class UnitTest1
  {
    [Theory]
    [InlineData(new int[] { }, new int[] { })]
    [InlineData(new[] { 1 }, new[] { 1 })]
    [InlineData(new[] { 1 }, new[] { 1, 1 })]
    [InlineData(new[] { 1, 2 }, new[] { 1, 2 })]
    [InlineData(new[] { 1, 2 }, new[] { 1, 1, 2 })]
    [InlineData(new[] { 1, 2, 3 }, new[] { 1, 1, 2, 3, 3 })]
    [InlineData(new[] { 1 }, new[] { 1, 1, 1 })]
    public void Test1(int[] expected, int[] list)
    {
      var result = new Solution().DeleteDuplicates(Extenstions.Create(list));
      Assert.Equal(expected, result.ToArray());
    }
  }
}
