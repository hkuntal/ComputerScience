using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Test
{
    [TestFixture]
    public class RecursionTest
    {
        [Test]
        public void testWaysToClimbNSteps()
        {
            var ways = Recursion.getPossibleWaysToClimb(15);
            Assert.AreEqual(109, ways);
        }

        [Test]
        public void testExactChange()
        {
            var possible = Recursion.canGetExactChange(18, new int[] { 4,5});
            Assert.AreEqual(true, possible);

            possible = Recursion.canGetExactChange(94, new int[] { 5, 10, 25, 100, 200 });
            Assert.AreEqual(false, possible);

            possible = Recursion.canGetExactChange(75, new int[] { 4, 17, 29 });
            Assert.AreEqual(true, possible);
        }

        [Test]
        public void testgetEncryptedString()
        {
            var encString = Recursion.findEncryptedWord("abcxcba");
            Assert.AreEqual("xbacbca", encString);

            encString = Recursion.findEncryptedWord("abcd");
            Assert.AreEqual("bacd", encString);

            encString = Recursion.findEncryptedWord("abc");
            Assert.AreEqual("bac", encString);

            encString = Recursion.findEncryptedWord("facebook");
            Assert.AreEqual("eafcobok", encString);
        }

        [Test]
        public void testTravelPathFromMatrix()
        {
            Recursion.GetPath(new bool[3, 3] { { false, true, false }, { true, true, true }, { false, true, false } });

        }

        [Test]
        public void testGettingFibinacciNumber()
        {
            var result = Recursion.getNthFiboncaiNumber(5);
            Assert.AreEqual(5, result);


            result = Recursion.getNthFiboncaiNumber(8);
            Assert.AreEqual(21, result);


            result = Recursion.getNthFiboncaiNumber(2);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void testPrintFibonacciSequenceUsingRecursion()
        {
            var result = Recursion.PrintFibonacciSequenceUsingRecursion(8);
            Assert.AreEqual(new int[] { 1,1,2,3,5,8,13,21}, result);
        }

        [Test]
        public void testPrintFibonacciSequence()
        {
            var result = Recursion.PrintFibonacciSequence(8);
            Assert.AreEqual(new int[] { 1, 1, 2, 3, 5, 8, 13, 21 }, result);
        }

    }
}
