using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Test
{
    [TestFixture]
    public class SearchProblemsTest
    {
        [Test]
        public void testGetMilestoneDays()
        {
            var result = SearchProblems.getMilestoneDays(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 }, new int[] { 100, 200, 500 });
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(result[0], 4);
            Assert.AreEqual(result[1], 6);
            Assert.AreEqual(result[2], 10);

            result = SearchProblems.getMilestoneDays(new int[] { 700, 800, 600, 400, 600, 700 }, new int[] { 3100, 2200, 800, 2100, 1000 });
            Assert.AreEqual(result.Length, 5);
            Assert.AreEqual(result[0], 5);
            Assert.AreEqual(result[1], 4);
            Assert.AreEqual(result[2], 2);
            Assert.AreEqual(result[3], 3);
            Assert.AreEqual(result[4], 2);
        }

        [Test]
        public static void testgetBillionUsersDay()
        {
            var result = SearchProblems.getBillionUsersDay(new double[] { 1.1, 1.2, 1.3 });
            Assert.AreEqual(79, result);
        }
    }
}
