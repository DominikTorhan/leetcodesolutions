using System;
using Xunit;

namespace RotateImage
{

  //  You are given an n x n 2D matrix representing an image.

  //Rotate the image by 90 degrees (clockwise).

  //Note:

  //You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.

  //Example 1:

  //Given input matrix =
  //[
  //  [1, 2, 3],
  //  [4,5,6],
  //  [7,8,9]
  //],

  //rotate the input matrix in-place such that it becomes:
  //[
  //  [7,4,1],
  //  [8,5,2],
  //  [9,6,3]
  //]
  //Example 2:

  //Given input matrix =
  //[
  //  [ 5, 1, 9,11],
  //  [ 2, 4, 8,10],
  //  [13, 3, 6, 7],
  //  [15,14,12,16]
  //], 

  //rotate the input matrix in-place such that it becomes:
  //[
  //  [15,13, 2, 5],
  //  [14, 3, 4, 1],
  //  [12, 6, 8, 9],
  //  [16, 7,10,11]
  //]

  //0 1 2 3 4
  //1 1 2 3 4
  //2 1 2 3 4
  //3 1 2 3 4
  //4 1 2 3 4

  public class Solution
  {

    //2
    //00 01 11 10

    //2 in 4
    //11 12 22 21

    //3
    //00 02 22 20
    //01 12 21 10

    //3 in 5
    //11 13 33 31
    //12 23 32 21


    //4
    //00 03 33 30
    //01 13 32 20
    //02 23 31 10

    //5
    //00 04 44 40
    //01 14 43 30
    //02 24 42 20
    //03 34 41 10

    public void Rotate(int[][] matrix)
    {
      int len;

      for (int i = 0; i < matrix.Length / 2; i++)
      {
        len = matrix.Length - (i * 2);
        for (int j = 0; j < len - 1; j++)
        {
          Rotate(matrix, j, i, len);
        }
      }

    }

    private void Rotate(int[][] matrix, int startIndex, int offset, int len)
    {
      int val, temp;
      int x, y;

      int end = len - 1;

      x = offset;
      y = startIndex + offset;
      val = matrix[x][y];

      x = startIndex + offset;
      y = end + offset;
      temp = matrix[x][y];
      matrix[x][y] = val;
      val = temp;

      x = end + offset;
      y = end - startIndex + offset;
      temp = matrix[x][y];
      matrix[x][y] = val;
      val = temp;

      x = end - startIndex + offset;
      y = offset;
      temp = matrix[x][y];
      matrix[x][y] = val;
      val = temp;

      x = offset;
      y = startIndex + offset;
      matrix[x][y] = val;

    }


  }

  public class UnitTest1

  {

    [Fact]
    public void Test2()
    {
      int[][] matrix, expected;
      matrix = new[] { new[] { 1, 2 }, new[] { 3, 4 } };
      expected = new[] { new[] { 3, 1 }, new[] { 4, 2 } };
      new Solution().Rotate(matrix);
      Assert.Equal(expected, matrix);
    }

    [Fact]
    public void Test3()
    {
      int[][] matrix, expected;
      matrix = new[] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 } };
      expected = new[] { new[] { 7, 4, 1 }, new[] { 8, 5, 2 }, new[] { 9, 6, 3 } };
      new Solution().Rotate(matrix);
      Assert.Equal(expected, matrix);
    }
    //1  2  3  4
    //5  6  7  8
    //9  10 11 12
    //13 14 15 16

    //13  9  5  1
    //14  10  6  2
    //15  11 7  3
    //16  12 8  4
    [Fact]
    public void Test4()
    {
      int[][] matrix, expected;
      matrix = new[] { new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 }, new[] { 9, 10, 11, 12 }, new[] { 13, 14, 15, 16 } };
      expected = new[] { new[] { 13, 9, 5, 1 }, new[] { 14, 10, 6, 2 }, new[] { 15, 11, 7, 3 }, new[] { 16, 12, 8, 4 } };
      new Solution().Rotate(matrix);
      Assert.Equal(expected, matrix);
    }

    //1  2  3  4  5
    //6  7  8  9  10
    //11 12 13 14 15
    //16 17 18 19 20
    //21 22 23 24 25

    //21 16 11 6  1
    //22 17 12 7  2
    //23 18 13 8  3
    //24 19 14 9  4
    //25 20 15 10 5
    [Fact]
    public void Test5()
    {
      int[][] matrix, expected;
      matrix = new[] { new[] { 1, 2, 3, 4,5 }, new[] { 6, 7, 8,9,10 }, new[] { 11, 12,13,14,15 }, new[] { 16,17,18,19,20 }, new[] { 21, 22, 23, 24, 25 } };
      expected = new[] { new[] { 21, 16, 11, 6,1 }, new[] { 22, 17, 12,7,2 }, new[] { 23, 18,13,8,3 }, new[] { 24,19,14,9,4 }, new[] { 25, 20, 15, 10, 5 } };
      new Solution().Rotate(matrix);
      Assert.Equal(expected, matrix);
    }


  }
}
