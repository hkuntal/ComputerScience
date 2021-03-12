using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    /*
     * John works at a clothing store. He has a large pile of socks that he must pair by color for sale. Given an array of integers representing
     * the color of each sock, determine how many pairs of socks with matching colors there are.

For example, there are  socks with colors . There is one pair of color  and one of color . 
    There are three odd socks left, one of each color. The number of pairs is .
     */
    public class SockMerchant
    {
        public static int sockMerchant(int n, int[] ar)
        {
            var pairedIndexes = new List<int>();
            var pairs = 0;
            //loop over the array and check for repetition
            for (var i = 0; i < ar.Length; i++)
            {
                if (pairedIndexes.Contains(i)) continue;
                var elementToCheck = ar[i];
                for (var j = i + 1; j < ar.Length; j++)
                {
                    if (pairedIndexes.Contains(j)) continue;
                    if (ar[j] == elementToCheck)
                    {
                        // pair found
                        pairs += 1;
                        pairedIndexes.Add(i);
                        pairedIndexes.Add(j);
                        break;
                    }
                }
            }
            return pairs;
        }

        public static int sockMerchant1(int n, int[] ar)
        {
            var pairedIndexes = new HashSet<int>();
            var pairs = 0;
            //loop over the array and check for repetition
            for (var i = 0; i < ar.Length; i++)
            {
                if(!pairedIndexes.Contains(ar[i]))
                {
                    pairedIndexes.Add(ar[i]);
                }
                else
                {
                    pairs++;
                    pairedIndexes.Remove(ar[i]);
                }           
            }
            return pairs;
        }
    }
}
