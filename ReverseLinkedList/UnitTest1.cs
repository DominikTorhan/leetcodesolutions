using Xunit;

namespace ReverseLinkedList
{
  //  Reverse a singly linked list.

  //Example:

  //Input: 1->2->3->4->5->NULL
  //Output: 5->4->3->2->1->NULL
  //Follow up:

  //A linked list can be reversed either iteratively or recursively.Could you implement both?

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
    public ListNode ReverseList(ListNode head)
    {
      return RecursiveReverse(head);
    }

    public ListNode InterateReverse(ListNode head)
    {
      if (head == null) return null;
      ListNode prev, current, next;
      current = head;
      prev = null;
      while (current.next != null)
      {
        next = current.next;
        current.next = prev;
        prev = current;
        current = next;
      }
      current.next = prev;
      return current;
    }

    public ListNode RecursiveReverse(ListNode head)
    {
      if (head == null) return null;
      return Recursive(head, null);
    }
    private ListNode Recursive(ListNode current, ListNode prev)
    {
      ListNode next;
      next = current.next;
      current.next = prev;
      if (next == null) return current;
      return Recursive(next, current);
    }

  }

  public class UnitTest1
  {

    [Theory]
    [InlineData(new[] { 1 }, new[] { 1 })]
    [InlineData(new[] { 2, 1 }, new[] { 1,2 })]
    [InlineData(new[] { 3, 2, 1 }, new[] { 1,2, 3 })]
    [InlineData(new[] { 5, 4, 3, 2, 1 }, new[] { 1,2, 3, 4, 5 })]
    public void Test1(int[] expected, int[] array)
    {
      var list = new Solution().ReverseList(Extenstions.Create(array));
      Assert.Equal(expected, list.ToArray());
    }
  }
}
