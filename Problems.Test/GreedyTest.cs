using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Test
{
    [TestFixture]
    public class GreedyTest
    {
        [Test]
        public void testGetTotalTime()
        {
            var worstCost = Greedy.getTotalTime(new int[] { 4, 2, 1, 3 });
            Assert.AreEqual(26, worstCost);

            worstCost = Greedy.getTotalTime(new int[] { 2, 3, 9, 8, 4 });
            Assert.AreEqual(88, worstCost);
        }

    }
}
