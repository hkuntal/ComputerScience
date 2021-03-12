using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sorting;
using NUnit.Framework;
using NUnit.Mocks;

namespace Algorithms.Test.Sorting
{
    [TestFixture]
    public class MergeSortTest
    {
        [Test]
        public void TestMergeSort()
        {
            //given
            int[] array = new int[] { 7, 3, 5, 99, 2, 45, 34, 86, 12, 90 };
            int[] sortedArray = new int[] { 2, 3, 5, 7, 12, 34, 45, 86, 90, 99 };

            //When calling sort
            MergeSort objMergeSort = new MergeSort();
            var result = objMergeSort.SortArray(array);

            // validate
            // check that elements are ascending order
            var pass = false;
            Assert.AreEqual(sortedArray.Length, result.Length);
            for(var i= 0; i < sortedArray.Length; i++)
            {
                if (result[i] != sortedArray[i])
                {
                    Assert.Fail();
                    break;
                }
                pass = true;
            }
            if(pass)
            {
                Assert.Pass();
            }

        }
    }
}
