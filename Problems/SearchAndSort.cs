using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class SearchAndSort
    {
        // O(n^2)
        public static void SelectionSort(int[] arr)
        {
            var min = 0;
            for(var i = 0; i < arr.Length; i++)
            {
                for(var j = i+1; j < arr.Length; j++)
                {
                    if(arr[j] < arr[i])
                    {
                        min = j;
                    }
                }
                // swap the elements
                var temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
            }

        }
        // O(n^2) best CASE o(N)
        public static void BubbleSort(int[] arr)
        {
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (var i = 0; i < arr.Length - 1; i++)
                {
                    
                        if (arr[i+1] < arr[i])
                        {
                            // swap the elements
                            var temp = arr[i];
                            arr[i] = arr[i+1];
                            arr[i+1] = temp;
                        swapped = true;
                        }
                    
                }
            }

        }

        // O(nlogn)
        public static void MergeSort()
        {

        }

        public static void InsertionSort()
        {

        }

        public static void QuickSort()
        {

        }

        public static void RadixSort()
        {
            // works on the principle of having a pivot and sorting the elements on the 
            // left and rght of the pivot
        }

        public static void BucketSort()
        {

        }
        
        public static int BinarySearch(int[] arr, int searchElement, int left, int right)
        {
            // binary search works on a sorted array
            int midPosition = (right + left) / 2;
            
            if(left == right)
            {
                if (searchElement == arr[left]) return left;
                else return -1;
            }
            if (right < left) return -1;
           
            if(searchElement < arr[midPosition])
            {
                // search in the left half
                return BinarySearch(arr, searchElement, left, midPosition - 1);
            }
            else if (searchElement > arr[midPosition])
            {
                // search in the right half
                return BinarySearch(arr, searchElement, midPosition + 1, right);
            }
            else 
            {
                return midPosition;
            }          
        }
    }
}
