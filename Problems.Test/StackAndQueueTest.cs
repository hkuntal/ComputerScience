using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Test
{
    [TestFixture]
    class StackAndQueueTest
    {
        [Test]
        public void TestStringIsBalancedWithBrackets()
        {
            var input = "{[()]}";
            var output = StacksAndQueues.isBalanced(input);
            Assert.AreEqual(true, output);

            input = "{}()";
            output = StacksAndQueues.isBalanced(input);
            Assert.AreEqual(true, output);

            input = "{(})";
            output = StacksAndQueues.isBalanced(input);
            Assert.AreEqual(false, output);

            input = ")";
            output = StacksAndQueues.isBalanced(input);
            Assert.AreEqual(false, output);

        }
    }
}
