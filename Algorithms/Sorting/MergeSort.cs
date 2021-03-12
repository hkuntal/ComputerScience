using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class MergeSort
    {

        int[] finalArray;

        public int[] SortArray(int[] array)
        {
            //get the length
            var len = array.Length;
            var leftPos = 0;
            var rightPos = len - 1;
            finalArray = new int[len];
            Sort(array, leftPos, rightPos);
            Console.WriteLine($"sorted array: {string.Join(",", array)}");
            return array;
        }

        private void Sort(int[] array, int leftPos, int rightPos)
        {
            Console.WriteLine(String.Format("Entering Sort - LeftPos:{0} RightPos:{1}", leftPos, rightPos));
            if (leftPos < rightPos)
            {
                var midPos = (leftPos + rightPos) / 2;
                //Console.WriteLine("MiddlePos: " + midPos);
                //start breaking down the left side
                Console.WriteLine(String.Format("Left Array - LeftPos:{0} RightPos:{1}", leftPos, midPos));
                Sort(array, leftPos, midPos);


                // start using the right size and merging the right side
                Console.WriteLine(String.Format("Right Array - LeftPos:{0} RightPos:{1}", midPos + 1, rightPos));
                Sort(array, midPos + 1, rightPos);

                //Merge the two arrays
                Merge(array, leftPos, midPos, rightPos);
            }
        }

        private void Merge(int[] array, int leftPos, int mid, int rightPos)
        {

            Console.WriteLine($"Merge Called {leftPos} {mid} {rightPos}");
            // read it into two arrays. First - from leftPos to mid and from mid to rightPos
            // Sort them and put it into the original array
            var leftPointer = leftPos;
            var rightPointer = mid + 1;
            int i = 0;
            var finalArray = new int[rightPos - leftPos + 1];
            //create a temp array            
            while (leftPointer <= mid && rightPointer <= rightPos)
            {
                if (array[leftPointer] <= array[rightPointer])
                {
                    //store the lower item first
                    finalArray[i] = array[leftPointer];
                    leftPointer++;
                }
                else
                {
                    finalArray[i] = array[rightPointer];
                    rightPointer++;
                }
                i++;
            }


            // if any items are left in the roght array move them into the temp
            while (rightPointer <= rightPos)
            {
                finalArray[i] = array[rightPointer];
                i++;
                rightPointer++;
            }

            // if any item left in the left array add it to the temp array
            while (leftPointer <= mid)
            {
                finalArray[i] = array[leftPointer];
                i++;
                leftPointer++;
            }

            // put the content back into the original array
            for (i = 0; i < finalArray.Length; i++)
            {
                array[leftPos] = finalArray[i];
                leftPos++;
            }
        }
    }
}
