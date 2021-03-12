using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Test
{
    [TextFixture]
    public class SearchAndSortTest
    {
        [Test]
        public void testSelectionSort()
        {
            var input = new int[] { 5, 6, 1, 3, 7, 0, 8, 9, 4, 2 };
            SearchAndSort.BubbleSort(input);
        }

        [Test]
        public void testBubbleSort()
        {
            var input = new int[] { 5, 6, 1, 3, 7, 0, 8, 9, 4, 2 };
            SearchAndSort.BubbleSort(input);
        }


        [Test]
        public void testBinarySearch()
        {
            var input = new int[] { 1,2,3,4,5,6,7,8,9 };
            var res = SearchAndSort.BinarySearch(input, 3, 0, 8);
            Assert.AreEqual(2, res);

            input = new int[] { 10, 20, 33, 46, 51, 69, 71, 82, 98,101, 567, 1000 };
            res = SearchAndSort.BinarySearch(input, 567, 0, 11);
            Assert.AreEqual(10, res);

            input = new int[] { 10, 20, 33, 46, 51, 69, 71, 82, 98, 101, 567, 1000 };
            res = SearchAndSort.BinarySearch(input, 10, 0, 11);
            Assert.AreEqual(0, res);

            input = new int[] { 10, 20, 33, 46, 51, 69, 71, 82, 98, 101, 567, 1000 };
            res = SearchAndSort.BinarySearch(input, 1000, 0, 11);
            Assert.AreEqual(11, res);


            input = new int[] { 10, 20, 33, 46, 51, 69, 71, 82, 98, 101, 567, 1000 };
            res = SearchAndSort.BinarySearch(input, 5, 0, 11);
            Assert.AreEqual(-1, res);


            input = new int[] { 10, 20, 33, 46, 51, 69, 71, 82, 98, 101, 567, 1000 };
            res = SearchAndSort.BinarySearch(input, 2000, 0, 11);
            Assert.AreEqual(-1, res);

        }

    }
}
