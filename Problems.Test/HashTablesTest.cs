using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Test
{
    [TestFixture]
    public class HashTablesTest
    {
        [Test]
        public void TestCheckMagazine()
        {
            var obj = new HashTables();
            var magazine = new String[] {"give", "me", "one", "grand", "today", "night"};
            var note = new String[] { "give", "one", "grand", "today" };
            var result = obj.CheckMagazine(magazine, note);
            Assert.AreEqual(true, result);

            magazine = new String[] { "two", "times", "three", "is", "not", "four" };
            note = new String[] { "two", "times", "two", "is", "four" };
            result = obj.CheckMagazine(magazine, note);
            Assert.AreEqual(false, result);

            magazine = new String[] { "ive", "got", "a", "lovely", "bunch", "of", "coconuts" };
            note = new String[] { "ive", "got", "some", "coconuts" };
            result = obj.CheckMagazine(magazine, note);
            Assert.AreEqual(false, result);

        }
    }
}
