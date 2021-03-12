using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class QuickSort
    {
        public static int[] SortArray(int[] array)
        {
            // take the first element as the pivot
           
           return Sort(array, 0, 0, array.Length -1);
            // find the pivot
            
        }

        private static int[]  Sort(int[] array, int pivotPos, int i, int j)
        {
            int p = array[pivotPos];
            if (i < j)
            {
                var newPivot = SortAroundPivot(array, i, j);

                // swap the left side around this
                Sort(array, newPivot, 0, newPivot - 1);

                // swap the right around this
                Sort(array, j + 1, j + 2, array.Length - 1 - newPivot);
            }
            return array;
        }

        private static int SortAroundPivot(int[] array, int i, int j)
        {
            // Comparison will be made with the first element of the array. 
            // Consider that as the pivot and test against it
            var pivotPos = i; 
            var p = array[i];
            var firstPos = i;
            var lastPos = j; 
            if (i < j)
            {
                // find the first element > p and last element > p
                while (i <= lastPos && array[i] <= p)
                {
                    i++;
                }
                if (i > lastPos)
                {
                    // means its reached the last position but did not find an element greater than this. so just exit. thats the new pivot
                    Swap(array, firstPos, lastPos);
                    return lastPos;
                }
                while (j >= firstPos && array[j] >= p) // j should not become negative
                {
                    j--;
                }
                if(j < firstPos)
                {
                    // means there is no smaller number than this one, so this will remain where is it
                    return firstPos;
                }
                if (i > j) // j should not have reached to the original position
                {
                    Swap(array, i, j);
                }
            }
            // This position becomes the new pivot and will not change
            //Swap(array, pivotPos, j);
            return j;
        }

        private static void Swap(int[] array, int i, int j)
        {
            if (i == j) return;
            var temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
    }
}
