using Xunit;

namespace DeleteNodeinaLinkedList
{
  //  Write a function to delete a node(except the tail) in a singly linked list, given only access to that node.

  //Given linked list -- head = [4,5,1,9], which looks like following:





  //Example 1:

  //Input: head = [4,5,1,9], node = 5
  //Output: [4,1,9]
  //  Explanation: You are given the second node with value 5, the linked list should become 4 -> 1 -> 9 after calling your function.
  //  Example 2:

  //Input: head = [4, 5, 1, 9], node = 1
  //  Output: [4,5,9]
  //Explanation: You are given the third node with value 1, the linked list should become 4 -> 5 -> 9 after calling your function.



  //  Note:


  //  The linked list will have at least two elements.
  //  All of the nodes' values will be unique.
  //The given node will not be the tail and it will always be a valid node of the linked list.
  //Do not return anything from your function.


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
      int i = 0; int count = Count(head); int[] array = new int[count]; var node = head; while (node != null)
      {
        array[i] = node.val; node = node.next; i++;
      }
      return array;
    }
    public static ListNode GetNodeByIdx(this ListNode head, int idx)
    {
      var node = head; for (int i = 0; i < idx; i++)
      {
        node = node.next;
      }
      return node;
    }

    public static ListNode GetNodeByVal(this ListNode head, int val)
    {
      var node = head;
      while (node != null)
      {
        if (node.val == val) return node;
        node = node.next;
      }
      return null;
    }

  }

  public class Solution
  {
    public void DeleteNode(ListNode node)
    {
      node.val = node.next.val;
      node.next = node.next.next;
    }
  }

  public class UnitTest1
  {
    //4519
    [Theory]
    [InlineData(new[] { 4, 1, 9 }, new[] { 4, 5, 1, 9 }, 5)]
    [InlineData(new[] { 4, 5, 9 }, new[] { 4, 5, 1, 9 }, 1)]
    [InlineData(new[] { 1, 2, 4 }, new[] { 1, 2, 3, 4 }, 3)]
    public void Test1(int[] expected, int[] headArray, int val)
    {
      ListNode head = Extenstions.Create(headArray);
      ListNode node = head.GetNodeByVal(val);
      new Solution().DeleteNode(node);
      Assert.Equal(expected, head.ToArray());
    }
  }
}
