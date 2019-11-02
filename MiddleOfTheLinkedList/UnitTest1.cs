using System;
using System.Collections.Generic;
using Xunit;

namespace MiddleOfTheLinkedList
{

  //  Given a non-empty, singly linked list with head node head, return a middle node of linked list.

  //If there are two middle nodes, return the second middle node.




  //Example 1:

  //Input: [1,2,3,4,5]
  //Output: Node 3 from this list (Serialization: [3,4,5])
  //The returned node has value 3.  (The judge's serialization of this node is [3,4,5]).
  //Note that we returned a ListNode object ans, such that:
  //ans.val = 3, ans.next.val = 4, ans.next.next.val = 5, and ans.next.next.next = NULL.
  //Example 2:

  //Input: [1,2,3,4,5,6]
  //Output: Node 4 from this list (Serialization: [4,5,6])
  //Since the list has two middle nodes with values 3 and 4, we return the second one.


  //Note:

  //The number of nodes in the given list will be between 1 and 100.

  //  *
  //* Definition for singly-linked list.
  public class ListNode
  {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }

  }

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

  public class Solution
  {
    public ListNode MiddleNode(ListNode head)
    {
      int count = head.Count();
      int mid = count / 2;
      return head.GetNodeByIdx(mid);
    }

    private ListNode MiddleNode_Fast(ListNode head)
    {
      var slow = head;
      var fast = head;
      while (fast?.next != null)
      {
        slow = slow.next;
        fast = fast.next.next;
      }
      return slow;
    }


  }

  public class UnitTest1
  {
    [Theory]
    [InlineData(new[] { 1 }, new[] { 1 })]
    [InlineData(new[] { 2 }, new[] { 1, 2 })]
    [InlineData(new[] { 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 })]
    [InlineData(new[] { 4, 5, 6 }, new[] { 1, 2, 3, 4, 5, 6 })]
    public void Test1(int[] expected, int[] array)
    {
      var head = Extenstions.Create(array);
      var result = new Solution().MiddleNode(head);
      var a = result.ToArray();
      Assert.Equal(expected, a);
    }
  }
}
