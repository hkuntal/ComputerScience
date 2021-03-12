using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public static class Problems
    {
        public static int LengthOfLongestSubstring(string s)
        {
            // This is a variation of the slidong window
            var dict = new Dictionary<char, int>();
            var objSubString = new SubString();

            // start from the first character
            objSubString.StartIndex = 1;
            var subStringLength = 0;
            for (var i = 1; i <= s.Length; i++)
            {
                if (dict.ContainsKey(s[i - 1]))
                {
                    // save the substring length in some variable
                    var currentSubStringLength = GetSubStringLength(objSubString);
                    subStringLength = currentSubStringLength > subStringLength ? currentSubStringLength : subStringLength;

                    // reset the substring start index to start a new index which will be the repeasted charater + 1
                    if (dict[s[i - 1]] >= objSubString.StartIndex)
                    {
                        // update the start index only when index of the current letter is more or less than the start index
                        objSubString.StartIndex = dict[s[i - 1]] + 1;
                    }
                    // update the new position and remove the old entries
                    //dict = new Dictionary<char, int>();
                    dict[s[i - 1]] = i;
                }
                else
                {
                    dict.Add(s[i - 1], i);

                }
                objSubString.EndIndex = i;
            }
            var len = GetSubStringLength(objSubString);
            return Math.Max(len, subStringLength);
        }

        private static int GetSubStringLength(SubString objSubString)
        {
            return objSubString.EndIndex - objSubString.StartIndex + 1;
        }

        private class SubString
        {
            public int StartIndex { get; set; }
            public int EndIndex { get; set; }
        }

        // Complete the jumpingOnClouds function below.
        public static int jumpingOnClouds(int[] c)
        {

            var minJumps = 0;
            var i = 0;
            while (i < c.Length)
            {
                if (c[i] == 0)
                {
                    // can jump, check can we jump 2 steps
                    if (i < c.Length - 2 && c[i + 2] == 0)
                    {
                        minJumps += 1;
                        i += 2;
                    }
                    else if (i < c.Length - 1 && c[i + 1] == 0)
                    {
                        minJumps += 1;
                        i += 1;
                    }
                    else if (i < c.Length - 2 && c[i + 2] == 0)
                    {
                        // cannot jump to next step, so need to jump after that
                        // this is assumed to be zero
                        minJumps += 1;
                        i += 2;
                    }

                }
            }
            return minJumps;
        }

        // https://leetcode.com/problems/group-the-people-given-the-group-size-they-belong-to/
        public static IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            var people = groupSizes.Length;
            var dict = new Dictionary<int, List<List<int>>>();
            for (var i = 0; i < groupSizes.Length; i++)
            {
                if (!dict.ContainsKey(groupSizes[i]))
                {
                    dict.Add(groupSizes[i], new List<List<int>> { new List<int> { i } });
                }
                else
                {
                    var key = groupSizes[i];
                    var lists = dict[key];
                    // check the lemgth
                    if (lists[lists.Count - 1].Count == groupSizes[i])
                    {
                        // create a new list
                        lists.Add(new List<int> { i });
                    }
                    else
                    {
                        lists[lists.Count - 1].Add(i);
                    }
                }
            }
            IList<IList<int>> returnType = new List<IList<int>>();
            foreach (var lists in dict.Values)
            {
                foreach (var list in lists)
                {
                    returnType.Add(list);
                }
            }

            return returnType;
        }

        //https://leetcode.com/problems/max-increase-to-keep-city-skyline/
        public static int MaxIncreaseKeepingSkyline(int[,] grid)
        {

            int[] leftView = new int[grid.GetLength(0)];
            int[] topView = new int[grid.GetLength(1)];
            int increasedHeight = 0;
            // get the left view
            for (var i = 0; i < grid.GetLength(0); i++)
            {
                int max = 0;
                for (var j = 0; j < grid.GetLength(1); j++)
                {

                    leftView[i] = Math.Max(leftView[i], grid[i, j]);
                    topView[j] = Math.Max(topView[j], grid[i, j]);
                    /*
                    if (grid[i, j] > max)
                    {
                        max = grid[i, j];
                    }
                    */
                }
                // got the max value in the row
                //leftView[i] = max;
            }

            /*
            // get the top view
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                int max = 0;
                for (var i = 0; i < grid.GetLength(0); i++)
                {
                    if (grid[i, j] > max)
                    {
                        max = grid[i, j];
                    }
                }
                // got the max value in the row
                topView[j] = max;
            }
            */

            // now increase the height with teh above constraints
            for (var i = 0; i < grid.GetLength(0); i++)
            {
                for (var j = 0; j < grid.GetLength(1); j++)
                {
                    increasedHeight += Math.Min(leftView[i], topView[j]) - grid[i, j];
                }
            }
            return increasedHeight;
        }

        // https://www.hackerrank.com/challenges/count-triplets-1/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        public static long countTriplets(List<long> arr, long r)
        {
            int tripletsInGp = 0;
            int i = 0, j = 0, k = 0;
            var len = arr.Count;
            bool tripletFound = false;
            List<string> tripletsFoundSoFar = new List<string>();
            while (i < len - 2)
            {
                tripletFound = false;
                j = i + 1;
                while (j < len - 1)
                {
                    tripletFound = false;
                    if (AreTheseInGeometricProgression(arr[i], arr[j], r))
                    {
                        tripletFound = false;
                        k = j + 1;
                        while (k < len)
                        {
                            if (AreTheseInGeometricProgression(arr[j], arr[k], r))
                            {
                                tripletsInGp++;
                                tripletFound = true;
                                // check for next elements if they have the same value
                                while (k + 1 < len && arr[k] == arr[k + 1])
                                {
                                    tripletsInGp++;
                                    k++;
                                }
                                break;
                            }
                            k++;
                        }
                    }
                    if (tripletFound)
                    {
                        while (j + 1 < len - 1 && arr[j] == arr[j + 1])
                        {
                            tripletsInGp++;
                            j++;
                        }
                        tripletFound = false;
                        break;
                    }
                    else
                        j++;
                }
                i++;
            }
            return tripletsInGp;
        }

        public static long countTriplets1(List<long> arr, long r)
        {
            long tripletsInGp = 0;
            int i = 0, j = 0, k = 0;
            var len = arr.Count;
            bool tripletFound = false;
            IDictionary<long, long> dict = new Dictionary<long, long>();
            long possibleCoefficient = 0;
            for (i = 0; i < arr.Count; i++)
            {
                var value = arr[i];
                if (value == 1)
                {
                    if (!dict.ContainsKey(value))
                    {
                        dict.Add(value, 1);
                        possibleCoefficient = 1;
                    }
                    else
                    {
                        dict[value]++;
                    }
                }
                else
                {
                    // check if this can be part of GP with ration r
                    long power = 0;
                    var isGp = checkELementPartofGP(value, possibleCoefficient, r, out power);
                    if (isGp)
                    {
                        if (!dict.ContainsKey(value))
                        {
                            dict.Add(value, 1);
                        }
                        else
                        {
                            dict[value]++;
                        }
                        if (dict.ContainsKey((long)Math.Pow(r, power - 1)) && dict.ContainsKey((long)Math.Pow(r, power - 2)))
                        {
                            tripletsInGp += dict[(long)Math.Pow(r, power - 1)] * dict[(long)Math.Pow(r, power - 2)];
                        }
                    }
                }
            }
            return tripletsInGp;
        }

        // Cracking the coding interview Q 1.1
        public static bool DoesStringHaveUniqueCharacters(string s)
        {
            // we are not supposed to use another data structure
            bool unique = true;
            foreach (Char c in s)
            {

            }

            return unique;
        }

        //https://www.hackerrank.com/challenges/sherlock-and-anagrams/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        public static int SherlockAndAnagrams(string s)
        {
            int count = 0;
            int maxSubStringLength = s.Length - 1;
            //int maxSubStringLength = 1;
            int subLength = 1;
            IDictionary<string, int> dict = new Dictionary<string, int>();
            IList<string> list = new List<string>();
            while (subLength <= maxSubStringLength)
            {
                int[] charArray = new int[26];

                HashSet<char> coll = new HashSet<char>();
                // check for substring of length sublength

                for (var i = 0; i <= s.Length - subLength; i++)
                {
                    var subString = new String(s.Substring(i, subLength).OrderBy(c => c).ToArray());

                    if (!dict.ContainsKey(subString))
                    {
                        dict.Add(subString, 1);
                        //list.Add(subString);
                    }
                    else
                    {
                        dict[subString]++;
                    }
                }
                subLength++;
            }

            // loop over the keys to see if they are anagrams of each other or not
            /*
            for (var i = 0; i < list.Count; i++)
            {
                var anagramFound = false;
                for (var j = i + 1; j < list.Count; j++)
                {
                    var anagram = areStringsAnagrams(list[i], list[j]);
                    if (anagram)
                    {
                        count += dict[list[i]] * dict[list[j]];
                        anagramFound = true;    
                    }
                    
                }
                
                    if (dict[list[i]] > 1)
                    {
                        count += getCombinations(dict[list[i]], 2);
                    }
                
                
            }
            */
            foreach (var key in dict.Keys)
            {
                count += getCombinations(dict[key], 2);
            }
            return count;

        }

        // from facebook site
        /*
         * Given a list of n integers arr[0..(n-1)], determine the number of different pairs of elements within it which sum to k.
            If an integer appears in the list multiple times, each copy is considered to be different; that is, two pairs are considered different if one pair includes at least one array index which the other doesn't, even if they include the same values.
            Signature
            int numberOfWays(int[] arr, int k)
            Input
            n is in the range [1, 100,000].
            Each value arr[i] is in the range [1, 1,000,000,000].
            k is in the range [1, 1,000,000,000].
            Output
            Return the number of different pairs of elements which sum to k.
         */
        public static int numberOfWays(int[] arr, int k)
        {
            // Write your code here
            // loop over the array and check number of combinations it can form
            var pairs = 0;
            for (var i = 0; i < arr.Length - 1; i++)
            {
                for (var j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == k)
                    {
                        pairs++;
                    }
                }
            }
            return pairs;
        }

        /*
         * Rotational Cipher
One simple way to encrypt a string is to "rotate" every alphanumeric character by a certain amount. Rotating a character means replacing it with another character that is a certain number of steps away in normal alphabetic or numerical order.
For example, if the string "Zebra-493?" is rotated 3 places, the resulting string is "Cheud-726?". Every alphabetic character is replaced with the character 3 letters higher (wrapping around from Z to A), and every numeric character replaced with the character 3 digits higher (wrapping around from 9 to 0). Note that the non-alphanumeric characters remain unchanged.
Given a string and a rotation factor, return an encrypted string.
         */
        public static string getRotatedCipher(string input, int rfactor)
        {
            string rotatedString = "";
            StringBuilder encString = new StringBuilder();
            byte a = (byte)'a';
            byte z = (byte)'z';
            byte A = (byte)'A';
            byte Z = (byte)'Z';

            foreach (char s in input)
            {
                // s is alphabet
                if (a <= (byte)s && (byte)s <= z)
                {
                    encString.Append(getNextAlphabet(s, rfactor));
                }
                // s is upper case alphabet
                else if (A <= (byte)s && (byte)s <= Z)
                {
                    encString.Append(getNextAlphabetUpper(s, rfactor));
                }
                else if (Int32.TryParse(s.ToString(), out int j))
                {
                    encString.Append(getNextNumber(j, rfactor));
                }

                // s is number
                else
                {
                    encString.Append(s);
                }
                // s is symbol
            }

            return encString.ToString();
        }


        /*
         * Contiguous Subarrays
You are given an array arr of N integers. For each index i, you are required to determine the number of contiguous subarrays that fulfills the following conditions:
The value at index i must be the maximum element in the contiguous subarrays, and
These contiguous subarrays must either start from or end on index i.
Signature
int[] countSubarrays(int[] arr)
Input
Array arr is a non-empty list of unique integers that range between 1 to 1,000,000,000
Size N is between 1 and 1,000,000
Output
An array where each index i contains an integer denoting the maximum number of contiguous subarrays of arr[i]
Example:
arr = [3, 4, 1, 6, 2]
output = [1, 3, 1, 5, 1]
Explanation:
For index 0 - [3] is the only contiguous subarray that starts (or ends) with 3, and the maximum value in this subarray is 3.
For index 1 - [4], [3, 4], [4, 1]
For index 2 - [1]
For index 3 - [6], [6, 2], [1, 6], [4, 1, 6], [3, 4, 1, 6]
For index 4 - [2]
So, the answer for the above input is [1, 3, 1, 5, 1]
         */

        public static int[] countSubarrays(int[] arr)
        {
            int[] outputArray = new int[arr.Length];
            for (var i = 0; i < arr.Length; i++)
            {
                // for (var j = i; j < arr.Length; j++)
                // go in forward direction
                int f = i + 1;
                while (f < arr.Length)
                {
                    if (arr[f] > arr[i])
                    {
                        break;
                    }
                    f++;
                }
                // check how many sub arrays can get formed
                outputArray[i] = f - i;


                // go backwards
                int p = i - 1;
                while (p >= 0)
                {
                    if (arr[p] > arr[i])
                    {
                        break;
                    }
                    p--;
                }
                // check how many sub arrays can get formed
                outputArray[i] += i - p - 1;
            }

            return outputArray;
        }

        /*
         * https://leetcode.com/problems/3sum/
         * Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.
            Note:
            The solution set must not contain duplicate triplets.
            Example:
            Given array nums = [-1, 0, 1, 2, -1, -4],
            A solution set is:
            [
              [-1, 0, 1],
              [-1, -1, 2]
            ]
         */
        public static IList<IList<int>> FindTripletsBruteForce(int[] arr)
        {
            var tripletGroup = new List<IList<int>>();
            var resulthashset = new HashSet<string>();
            for (var i = 0; i < arr.Length - 2; i++)
            {
                for (var j = i + 1; j < arr.Length - 1; j++)
                {
                    // check for the double sum
                    var sum = arr[i] + arr[j];
                    var diff = 0 - sum;
                    // check for any element that is equal to diff
                    for (var k = j + 1; k < arr.Length; k++)
                    {
                        if (arr[k] == diff)
                        {
                            IList<int> triplet = new List<int>();
                            triplet.Add(arr[i]);
                            triplet.Add(arr[j]);
                            triplet.Add(arr[k]);
                            var sortedArray = triplet.ToArray<int>();
                            Array.Sort(sortedArray);
                            var str = String.Join("", sortedArray);
                            if (!resulthashset.Contains(str))
                            {
                                resulthashset.Add(str);
                                tripletGroup.Add(triplet);
                            }
                            break;
                        }
                    }
                }
            }
            return tripletGroup;
        }

        public static IList<IList<int>> FindTripletsOptimized(int[] arr)
        {
            // optmization can be done by sorting the array upfront
            var tripletGroup = new List<IList<int>>();
            var resulthashset = new HashSet<string>();
            for (var i = 0; i < arr.Length - 2; i++)
            {
                for (var j = i + 1; j < arr.Length - 1; j++)
                {
                    // check for the double sum
                    var sum = arr[i] + arr[j];
                    var diff = 0 - sum;
                    // check for any element that is equal to diff
                    for (var k = j + 1; k < arr.Length; k++)
                    {
                        if (arr[k] == diff)
                        {
                            IList<int> triplet = new List<int>();
                            triplet.Add(arr[i]);
                            triplet.Add(arr[j]);
                            triplet.Add(arr[k]);
                            var sortedArray = triplet.ToArray<int>();
                            Array.Sort(sortedArray);
                            var str = String.Join("", sortedArray);
                            if (!resulthashset.Contains(str))
                            {
                                resulthashset.Add(str);
                                tripletGroup.Add(triplet);
                            }
                            break;
                        }
                    }
                }
            }
            return tripletGroup;
        }

        /*
         * This problem was recently asked by Google.

Given a list of numbers and a number k, return whether any two numbers from the list add up to k.

For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.

Bonus: Can you do this in one pass?
         */

        public static bool DoNumbersAddupToK(int[] arr, int k)
        {
            var lookUpNos = new HashSet<int>();

            for (var i = 0; i < arr.Length; i++)
            {
                if (lookUpNos.Contains(arr[i]))
                {
                    return true;
                }
                int nextNo = k - arr[i];
                lookUpNos.Add(nextNo);
            }
            return false;
        }

        /*
         * Sherlock considers a string to be valid if all characters of the string appear the same number of times. It is also valid if he can remove just  character at  index in the string, and the remaining characters will occur the same number of times. Given a string , determine if it is valid. If so, return YES, otherwise return NO.

For example, if , it is a valid string because frequencies are . So is  because we can remove one  and have  of each character in the remaining string. If  however, the string is not valid as we can only remove  occurrence of . That would leave character frequencies of .

Function Description

Complete the isValid function in the editor below. It should return either the string YES or the string NO.

isValid has the following parameter(s):

s: a string
Input Format

A single string .

Constraints

Each character 
Output Format

Print YES if string  is valid, otherwise, print NO.

Sample Input 0

aabbcd
Sample Output 0

NO
Explanation 0

Given , we would need to remove two characters, both c and d  aabb or a and b  abcd, to make it valid. We are limited to removing only one character, so  is invalid.

Sample Input 1

aabbccddeefghi
Sample Output 1

NO
Explanation 1

Frequency counts for the letters are as follows:

{'a': 2, 'b': 2, 'c': 2, 'd': 2, 'e': 2, 'f': 1, 'g': 1, 'h': 1, 'i': 1}

There are two ways to make the valid string:

Remove  characters with a frequency of : .
Remove  characters of frequency : .
Neither of these is an option.

Sample Input 2

abcdefghhgfedecba
Sample Output 2

YES
Explanation 2

All characters occur twice except for  which occurs  times. We can delete one instance of  to have a valid string.
        https://www.hackerrank.com/challenges/sherlock-and-valid-string/problem
         */
        public static bool IsValidStringPerCount(string input)
        {
            if (String.IsNullOrEmpty(input)) return false;

            // check the frequency of each character in the string, and see if any can ve removed
            var frequencyTable = new Dictionary<char, int>();

            foreach (char letter in input)
            {
                if (frequencyTable.ContainsKey(letter))
                {
                    frequencyTable[letter]++;
                }
                else
                {
                    frequencyTable.Add(letter, 1);
                }
            }

            // after adding check if the frequency of all the letters match
            var initialCount = 0;
            var frequencyItemCount = new Dictionary<int, int>();

            int minCount = 0;
            int maxCount = 0;
            // sort the dictionary based on the value
            // get all the frquenceies anthe character count
            foreach (var item in frequencyTable)
            {
                if (frequencyItemCount.ContainsKey(item.Value))
                {
                    frequencyItemCount[item.Value]++;
                }
                else
                {
                    {
                        frequencyItemCount.Add(item.Value, 1);
                    }
                }
            }
            // for the string to be valid there should not be more than
            // 2 entries in the dict
            if (frequencyItemCount.Count > 2) return false;

            // check the character count of lower frquence vs larger frequency
            var keys = frequencyItemCount.Keys;
            KeyValuePair<int, int> k1;
            KeyValuePair<int, int> k2;

            k1 = frequencyItemCount.ElementAt(0);
            k2 = frequencyItemCount.ElementAt(1);

            // between these two elements the differe in frquncy should be 1
            if (Math.Abs(k1.Key - k2.Key) > 1) return false;
            // the character cout should also differ by for t
            if ((k1.Key > k2.Key && k1.Value == 1)
                || (k2.Key > k1.Key && k2.Value == 1)) return true;

            return false;

        }

        public static bool IsValidStringPerCount1(string input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            if (input.Length <= 3) return true;

            // check the frequency of each character in the string, and see if any can ve removed
            var frequencyTable = new Dictionary<char, int>();
            var array = new int[26];

            foreach (char letter in input)
            {
                array[letter - 'a']++;
            }

            // sort the array
            Array.Sort(array);
            int i = 0;
            while (array[i] == 0)
            {
                i++;
            }

            var minFreq = array[i];
            var maxFreq = array[25];
            if (minFreq == maxFreq) return true;
            if (array[i] == array[24] && array[25] - array[24] == 1) return true; // there is exactly one element to be removed
            if (array[i + 1] == array[25] && (array[i + 1] - array[i] == 1 || array[i] == 1)) return true;
            //if (array[25] == array[24]) return false; // there is more than than one element to be removed
            //if (Math.Abs(minFreq - maxFreq) > 1) return false;// there are more than one element to be removed
            return false;
        }

        /*
         * Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.

For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be [2, 3, 6].

Follow-up: what if you can't use division?
         */
        public static int[] ReturnArrayAsProductOfNumbers(int[] input)
        {
            var output = new int[input.Length];
            for (var i = 0; i < input.Length; i++)
            {
                var product = 1;
                for (var j = 0; j < input.Length; j++)
                {
                    if (j == i) continue;
                    product = product * input[j];
                }
                output[i] = product;
            }
            return output;
        }


        //optimized solution in one pass
        public static int[] ReturnArrayAsProductOfNumbers1(int[] input)
        {
            var output = new int[input.Length];
            var product = 1;
            for (var i = 0; i < input.Length; i++)
            {
                product = product * input[i];
            }

            for (var j = 0; j < input.Length; j++)
            {
                output[j] = product / input[j];
            }
            return output;
        }

        /*
         * This problem was asked by Facebook.

Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.

For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.

You can assume that the messages are decodable. For example, '001' is not allowed.
         */

        public static int HowManyWaysAMsgCanBeDecoded(string message)
        {
            // take the example of 111 -aaa, ak, ka
            if (String.IsNullOrEmpty(message)) return 0;
            int ways = 1;
            var i = 0;
            while (i < message.Length - 1)
            {
                if (Convert.ToInt32(message.Substring(i, 2)) <= 26)
                {
                    ways++;
                    int j = i + 2;
                    while (j < message.Length - 1)
                    {
                        if (Convert.ToInt32(message.Substring(j, 2)) <= 26)
                        {
                            ways++;
                        }
                        j += 1;
                    }
                }
                i += 1;
            }
            return ways;
        }
        private static char getNextAlphabetUpper(char s, int rfactor)
        {
            if (rfactor > 26)
            {
                rfactor = rfactor % 26 == 0 ? 26 : rfactor % 26;
            }
            // advance by 3
            char nextc = (char)((byte)s + rfactor);
            if ((byte)nextc > (byte)'Z')
            {
                byte pos = (byte)((byte)nextc - (byte)'Z');
                return (char)((byte)'A' + pos - 1);
            }
            return nextc;
        }
        private static char getNextAlphabet(char s, int rfactor)
        {
            if (rfactor > 26)
            {
                rfactor = rfactor % 26 == 0 ? 26 : rfactor % 26;
            }
            // advance by 3
            char nextc = (char)((byte)s + rfactor);
            if((byte)nextc > (byte)'z')
            {
                byte pos = (byte)((byte)nextc - (byte)'z');
                return (char)((byte)'a' + pos - 1);
            }
            return nextc;
        }

        private static int getNextNumber(int s, int rfactor)
        {
            if (rfactor > 10)
            {
                rfactor = rfactor % 10;
            }
            // advance by 3
            int incNum = s + rfactor;
            if ((s + rfactor) > 9)
            {
                return (s + rfactor -1 ) - 9 ;
            }
            return incNum;
        }

        private static bool areStringsAnagrams(string S1, string S2)
        {
            if (S1.Length != S2.Length) return false;
            char[] a = S1.ToCharArray();
            char[] b = S2.ToCharArray();

            Array.Sort(a);
            Array.Sort(b);

            
            for(var i=0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;

            }
            return true;
        }

        private static int getCombinations(int n, int p)
        {
            return fact(n) / (fact(p) * fact(n - p));
        }

        private static int fact(int p)
        {
            int fact = 1;
            while(p>0)
            {
                fact *= p;
                p--;
            }
            return fact;
        }

        private static bool checkELementPartofGP(long v, long possibleCoefficient, long r, out long divisiblePower)
        {
            long remainder = 0;
            var power = 1;
            long coefficient = 0;
            while(remainder == 0)
            {
                remainder = v % (long)Math.Pow(r, power);
                coefficient = v / (long)Math.Pow(r, power);
                if (remainder == 0 && coefficient > 1)
                {
                    power++;
                }
                else if(remainder == 0 && coefficient == 1)
                {
                    divisiblePower = power;
                    return true;
                }
                else if(remainder != 0)
                {
                    divisiblePower = power;
                    return false;
                }
            }
            divisiblePower = power;
            return false;

        }

        private static bool AreTheseInGeometricProgression(long a, long b, long r)
        {
            // get the constant
            return (b / a == r);
        }

        

    }
}






