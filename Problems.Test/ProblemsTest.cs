using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Problems.Test
{
    [TestFixture]
    class ProblemsTest
    {
        [Test]
        public void LengthOfLongestSubstring_Test()
        {
            var ans = Problems.LengthOfLongestSubstring("aabaab!bb");
            Assert.AreEqual(3, ans);
            ans = Problems.LengthOfLongestSubstring("dvdf");
            Assert.AreEqual(3, ans);
            ans = Problems.LengthOfLongestSubstring("abcabcbb");
            Assert.AreEqual(3, ans);
            ans = Problems.LengthOfLongestSubstring("abba");
            Assert.AreEqual(2, ans);
        }
        [Test]
        public void TestHowManyWaysAMessageCanBeDecoded()
        {
            var input = "111";
            var output = Problems.HowManyWaysAMsgCanBeDecoded(input);
            Assert.AreEqual(3, output);

            input = "123124";
            output = Problems.HowManyWaysAMsgCanBeDecoded(input);
            Assert.AreEqual(9, output);
        }

        [Test]
        public void JumpingOnCloudsTest()
        {
            var minJumps = Problems.jumpingOnClouds(new int[] { 0, 0, 0, 1, 0, 0 });
            Assert.AreEqual(2, minJumps);

        }

        [Test]
        public void TestMaxIncreaseKeepingSkyline()
        {
            int[,] input = new int[4, 4] { { 3, 0, 8, 4 }, { 2, 4, 5, 7 }, { 9, 2, 6, 3 }, { 0, 3, 1, 0 } };
            var increasedInHeight = Problems.MaxIncreaseKeepingSkyline(input);
            Assert.AreEqual(35, increasedInHeight);
        }

        //https://www.hackerrank.com/challenges/count-triplets-1/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        [Test]
        public void TestCountTriplets()
        {
            var triplests = Problems.countTriplets(new List<long> { 1, 2, 2, 4 }, 2);
            Assert.AreEqual(2, triplests);

            triplests = Problems.countTriplets(new List<long> { 1, 3, 9, 9, 27, 81 }, 3);
            Assert.AreEqual(6, triplests);

            triplests = Problems.countTriplets1(new List<long> { 1, 3, 9, 9, 27, 81 }, 3);
            Assert.AreEqual(6, triplests);

        }

        [Test]
        public void TestSherlockAndAnagrams()
        {
            var ans = Problems.SherlockAndAnagrams("kkkk");
            Assert.AreEqual(10, ans);

            ans = Problems.SherlockAndAnagrams("abba");
            Assert.AreEqual(4, ans);

            ans = Problems.SherlockAndAnagrams("abcd");
            Assert.AreEqual(0, ans);

            ans = Problems.SherlockAndAnagrams("ifailuhkqq");
            Assert.AreEqual(3, ans);

            ans = Problems.SherlockAndAnagrams("cdcd");
            Assert.AreEqual(5, ans);


        }

        [Test]
        public void findNumberOfways()
        {
            var ans = Problems.numberOfWays(new int[] { 1, 2, 3, 4, 3 }, 6);
            Assert.AreEqual(2, ans);
        }

        [Test]
        public void findtheRotatedCipher()
        {
            var ans = Problems.getRotatedCipher("zebra-493", 3);
            Assert.AreEqual("cheud-726", ans);

            ans = Problems.getRotatedCipher("All-convoYs-9-be:Alert1.", 4);
            Assert.AreEqual("Epp-gsrzsCw-3-fi:Epivx5.", ans);

            ans = Problems.getRotatedCipher("abcdZXYzxy-999.@", 200);
            Assert.AreEqual("stuvRPQrpq-999.@", ans);

            ans = Problems.getRotatedCipher("abcdZXYzxy-999.@", 0);
            Assert.AreEqual("abcdZXYzxy-999.@", ans);

        }

        [Test]
        public void countSubarrays()
        {
            var ans = Problems.countSubarrays(new int[] { 3, 4, 1, 6, 2 });
            Assert.AreEqual(ans, new int[] { 1, 3, 1, 5, 1 });
        }

        [Test]
        public void testNumbersAddUpInAnArray()
        {
            var input = new int[] { 10, 15, 3, 7 };
            var result = Problems.DoNumbersAddupToK(input, 17);
            Assert.IsTrue(result);

            input = new int[] { 10, 15, 3, 7,56,7,19,5,9,10,11,45,23,88,99,65,13};
            result = Problems.DoNumbersAddupToK(input, 100);
            Assert.IsTrue(!result);
        }

        [Test]
        public void testFindTripletsBruteForce()
        {
            var input = new int[] { -1, 0, 1, 2, -1, -4 };
            var result = Problems.FindTripletsBruteForce(input);

            // output = [[-1,0,1],[-1,2,-1]] which is expected
        }

        [Test]
        public void testIsValidStringPerCount()
        {
            var output = Problems.IsValidStringPerCount1("aabbccddeefghi");
            Assert.IsFalse(output);

            output = Problems.IsValidStringPerCount1("aabbcd");
            Assert.IsFalse(output);

            output = Problems.IsValidStringPerCount1("abcdefghhgfedecba");
            Assert.IsTrue(output);

            output = Problems.IsValidStringPerCount1("aabbc");
            Assert.IsTrue(output);

            var input = "ibfdgaeadiaefgbhbdghhhbgdfgeiccbiehhfcggchgghadhdhagfbahhddgghbdehidbibaeaagaeeigffcebfbaieggabcfbiiedcabfihchdfabifahcbhagccbdfifhghcadfiadeeaheeddddiecaicbgigccageicehfdhdgafaddhffadigfhhcaedcedecafeacbdacgfgfeeibgaiffdehigebhhehiaahfidibccdcdagifgaihacihadecgifihbebffebdfbchbgigeccahgihbcbcaggebaaafgfedbfgagfediddghdgbgehhhifhgcedechahidcbchebheihaadbbbiaiccededchdagfhccfdefigfibifabeiaccghcegfbcghaefifbachebaacbhbfgfddeceababbacgffbagidebeadfihaefefegbghgddbbgddeehgfbhafbccidebgehifafgbghafacgfdccgifdcbbbidfifhdaibgigebigaedeaaiadegfefbhacgddhchgcbgcaeaieiegiffchbgbebgbehbbfcebciiagacaiechdigbgbghefcahgbhfibhedaeeiffebdiabcifgccdefabccdghehfibfiifdaicfedagahhdcbhbicdgibgcedieihcichadgchgbdcdagaihebbabhibcihicadgadfcihdheefbhffiageddhgahaidfdhhdbgciiaciegchiiebfbcbhaeagccfhbfhaddagnfieihghfbaggiffbbfbecgaiiidccdceadbbdfgigibgcgchafccdchgifdeieicbaididhfcfdedbhaadedfageigfdehgcdaecaebebebfcieaecfagfdieaefdiedbcadchabhebgehiidfcgahcdhcdhgchhiiheffiifeegcfdgbdeffhgeghdfhbfbifgidcafbfcd";
            Problems.IsValidStringPerCount1(input);
            Assert.IsTrue(output);
        }

        [Test]
        public void testReturnArrayAsProductOfNumbers()
        {
            var input = new int[] {1, 2, 3, 4, 5};
            var output = Problems.ReturnArrayAsProductOfNumbers1(input);
            Assert.AreEqual(5, output.Length);
            Assert.AreEqual(120, output[0]);
            Assert.AreEqual(60, output[1]);
            Assert.AreEqual(40, output[2]);
            Assert.AreEqual(30, output[3]);
            Assert.AreEqual(24, output[4]);


            input = new int[] { 3, 2, 1 };
            output = Problems.ReturnArrayAsProductOfNumbers1(input);
            Assert.AreEqual(3, output.Length);
            Assert.AreEqual(2, output[0]);
            Assert.AreEqual(3, output[1]);
            Assert.AreEqual(6, output[2]);
        }
    }
}

