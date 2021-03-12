using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class Recursion
    {
        // Cracking the coding interview. Question# 8.1
        public static int getPossibleWaysToClimb(int n)
        {
            if(n < 0)
            {
                return 0;
            }
            else if(n ==0)
            {
                return 1;
            }
            else
            {
                return getPossibleWaysToClimb(n - 1) + getPossibleWaysToClimb(n - 2) + getPossibleWaysToClimb(n - 3);
            }
        }

        /*
         * Change in a Foreign Currency
You likely know that different currencies have coins and bills of different denominations. In some currencies, it's actually impossible to receive change for a given amount of money. For example, Canada has given up the 1-cent penny. If you're owed 94 cents in Canada, a shopkeeper will graciously supply you with 95 cents instead since there exists a 5-cent coin.
Given a list of the available denominations, determine if it's possible to receive exact change for an amount of money targetMoney. Both the denominations and target amount will be given in generic units of that currency.
Signature
boolean canGetExactChange(int targetMoney, int[] denominations)
Input
1 ≤ |denominations| ≤ 100
1 ≤ denominations[i] ≤ 10,000
1 ≤ targetMoney ≤ 1,000,000
Output
Return true if it's possible to receive exactly targetMoney given the available denominations, and false if not.
Example 1
denominations = [5, 10, 25, 100, 200]
targetMoney = 94
output = false
Every denomination is a multiple of 5, so you can't receive exactly 94 units of money in this currency.
Example 2
denominations = [4, 17, 29]
targetMoney = 75
output = true
You can make 75 units with the denominations [17, 29, 29].
         */

        public static bool canGetExactChange(int targetMoney, int[] denominations)
        {
            if (targetMoney == 0) return true;

            else if (targetMoney > 0)
            {

                for (var i = 0; i < denominations.Length; i++)
                {
                    if (canGetExactChange(targetMoney - denominations[i], denominations)) return true;
                }
            }
            // Write your code here
            return false;
        }

        // find the path from top left to bottom right of a 2D grid. You can only move to the bottom or right
        // problem from the book "interview questions" Q# 8.2

        public static IList<Point> GetPath(bool[,] maze)
        {
            if (maze == null || maze.Length == 0) return null;
            IList<Point> path = new List<Point>();
            // pass the last point and then run backwards
            var rows = maze.GetLength(0);
            var columns = maze.GetLength(1);
            GetPath(maze, rows - 1, columns - 1, path);
            return path;
        }

        public static int[] PrintFibonacciSequence(int n)
        {
            // create an array
            var arr = new int[n];
            for(var i =0; i < n; i++)
            {
                if (i == 0 || i == 1)
                {
                    arr[i] = 1;
                }
                else
                {
                    arr[i] = arr[i - 1] + arr[i - 2];
                }
            }
            return arr;
        }

        public static int[] PrintFibonacciSequenceUsingRecursion(int n)
        {
            // create an array
            var arr = new int[n];
            printFibonacciSeq(n, arr);
            return arr;
        }

        public static int getNthFiboncaiNumber(int n)
        {
            if(n <= 2)
            {
                return 1;
            }
            else
            {
                return getNthFiboncaiNumber(n-1) + getNthFiboncaiNumber(n - 2);
            }
        }
        private static int printFibonacciSeq(int n, int[] result)
        {
            
                if (n <= 2 )
                {
                    result[n - 1] = 1;
                    return 1;
                }
                else
                {
                    var sum = printFibonacciSeq(n -1, result) + printFibonacciSeq(n - 2, result);
                    result[n - 1] = sum;
                    return sum;
                }
            
        }

        private static bool GetPath(bool[,] maze, int row, int column, IList<Point> path)
        {
            // check if this point can be taken as a route
            if (!maze[row, column] || row < 0 || column < 0) return false;

            var isOrigin = row == 0 && column == 0;
            
            // move to the previous point
            if (isOrigin || GetPath(maze, row - 1, column, path) || GetPath(maze, row, column - 1, path))
            {
                var point = new Point(row, column);
                path.Add(point);
                return true;
            }

            return false;
        }

        /*
         * Encrypted Words
You've devised a simple encryption method for alphabetic strings that shuffles the characters in such a way that the resulting string is hard to quickly read, but is easy to convert back into the original string.
When you encrypt a string S, you start with an initially-empty resulting string R and append characters to it as follows:
Append the middle character of S (if S has even length, then we define the middle character as the left-most of the two central characters)
Append the encrypted version of the substring of S that's to the left of the middle character (if non-empty)
Append the encrypted version of the substring of S that's to the right of the middle character (if non-empty)
For example, to encrypt the string "abc", we first take "b", and then append the encrypted version of "a" (which is just "a") and the encrypted version of "c" (which is just "c") to get "bac".
If we encrypt "abcxcba" we'll get "xbacbca". That is, we take "x" and then append the encrypted version "abc" and then append the encrypted version of "cba".
Input
S contains only lower-case alphabetic characters
1 <= |S| <= 10,000
Output
Return string R, the encrypted version of S.
Example 1
S = "abc"
R = "bac"
Example 2
S = "abcd"
R = "bacd"
Example 3
S = "abcxcba"
R = "xbacbca"
Example 4
S = "facebook"
R = "eafcobok"
         */
        public static string findEncryptedWord(string s)
        {
            // Write your code here
            int middleCharIndex = s.Length / 2;
            StringBuilder sb = new StringBuilder();
            getEncryptedString(s, sb);
            return sb.ToString();
        }

        private static void getEncryptedString(string s, StringBuilder sb)
        {
            if (s.Length == 1)
            {
                sb.Append(s);
                return;
            }
            else if (s.Length == 2)
            {
                sb.Append(s[0]);
                sb.Append(s[1]);
            }
            else
            {

                // if even
                if (s.Length % 2 == 0)
                {
                    int middleCharIndex = s.Length / 2;
                    sb.Append(s[middleCharIndex - 1]);
                    // encrypted the left side
                    getEncryptedString(s.Substring(0, middleCharIndex - 1), sb);
                    // encrypted the right side
                    getEncryptedString(s.Substring(middleCharIndex, s.Length - middleCharIndex), sb);
                }
                else
                {
                    // odd
                    int middleCharIndex = s.Length / 2;
                    sb.Append(s[middleCharIndex]);
                    // encrpyed the left side
                    getEncryptedString(s.Substring(0, middleCharIndex), sb);
                    // encrypted the right side
                    getEncryptedString(s.Substring(middleCharIndex + 1, s.Length - middleCharIndex - 1), sb);
                }

            }

        }
    }

    public class Point
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Point(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
