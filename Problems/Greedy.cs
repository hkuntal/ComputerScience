using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class Greedy
    {
        /*
         * Slow Sums
Suppose we have a list of N numbers, and repeat the following operation until we're left with only a single number: Choose any two numbers and replace them with their sum. Moreover, we associate a penalty with each operation equal to the value of the new number, and call the penalty for the entire list as the sum of the penalties of each operation.
For example, given the list [1, 2, 3, 4, 5], we could choose 2 and 3 for the first operation, which would transform the list into [1, 5, 4, 5] and incur a penalty of 5. The goal in this problem is to find the worst possible penalty for a given input.
Signature:
int getTotalTime(int[] arr)
Input:
An array arr containing N integers, denoting the numbers in the list.
Output format:
An int representing the worst possible total penalty.
Constraints:
1 ≤ N ≤ 10^6
1 ≤ Ai ≤ 10^7, where *Ai denotes the ith initial element of an array.
The sum of values of N over all test cases will not exceed 5 * 10^6.
Example
arr = [4, 2, 1, 3]
output = 26
First, add 4 + 3 for a penalty of 7. Now the array is [7, 2, 1]
Add 7 + 2 for a penalty of 9. Now the array is [9, 1]
Add 9 + 1 for a penalty of 10. The penalties sum to 26.
         */

        public static int getTotalTime(int[] arr)
        {
            var maxSum = 0;
            var penalty = 0;
            var index1 = 0;
            var index2 = 0;

            var newArray = arr;
            while (newArray.Length != 1)
            {
                // collapse the array and create a new one
                getMaxIndexesAndSum(newArray, out index1, out index2, out maxSum);
                newArray = getNewArray(newArray, index1, index2, maxSum);
                penalty += maxSum;
            }
            return penalty;
        }

        private static int[] getNewArray(int[] arr, int index1, int index2, int sum)
        {
            var newArr = new int[arr.Length - 1];
            var lastIndex = 0;
            for(var i = 0; i < arr.Length; i++)
            {
                if (i != index1 && i != index2)
                {
                    newArr[lastIndex] = arr[i];
                    lastIndex++;
                }
                
            }
            // replace the last index with the sum
            
            newArr[lastIndex] = sum;
            
            return newArr;
        }

        private static void getMaxIndexesAndSum(int[] arr, out int index1, out int index2, out int maxSum)
        {
            maxSum = 0;
            index1 = 0;
            index2 = 0;
            // Write your code here
            for (var i = 0; i < arr.Length - 1; i++)
            {
                for (var j = i + 1; j < arr.Length; j++)
                {
                    var sum = arr[i] + arr[j];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        index1 = i;
                        index2 = j;
                    }
                }
            }
        }
    }
}

