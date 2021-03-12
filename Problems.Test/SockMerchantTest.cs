using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Test
{
    [TestFixture]
    public class SockMerchantTest
    {
        [Test]
        public void testSockProblem()
        {
            var pairs = SockMerchant.sockMerchant1(9, new int[] { 10, 20, 20, 10, 10, 30, 50, 10, 20 });
            Assert.AreEqual(3, pairs);
        }

    }
}
