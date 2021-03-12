using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;
using Models;
using LRUCache;

namespace LRUCache.Test
{
    [TestFixture]
    public class LRUcacheTest
    {
        [Test]
        public void LRUCacheTest()
        {
            // max cache size 1000 bytes
            var cache = new LRUCache<int, Person>(1000);
            Person p;

            // create a new person object
            int  i = 1, firstValue = 1;
            var p1 = new Person { Id = i++, FirstName = "Hariom", LastName = "Kuntal" };
            var p2 = new Person { Id = i++, FirstName = "Ruby", LastName = "Kuntal" };
            var p3 = new Person { Id = i++, FirstName = "Dhruv", LastName = "Kuntal" };

            cache.Add(p1.Id, p1);
            cache.Add(p2.Id, p2);
            cache.Add(p3.Id, p3);

            // Assert the size in the cache
            var size = p1.GetSize() + p2.GetSize() + p3.GetSize();
            Assert.AreEqual(size, cache.GetCurrentCacheSize());

            // Add more data to cache so its size exceeds
            while (size < 960)
            {
                p = GetNewObjectForCache(i++);
                size += p.GetSize();
                cache.Add(p.Id, p);
            }

            // get the size
            var csize = cache.GetCurrentCacheSize();
           
            // check the last entry in the cache
            var lastKey = cache.GetTheLastKeyFromLinkedList();
            Assert.AreEqual(lastKey, firstValue);

            // Add another item. Last key item shoud be removed to make some space for this item
            var k = i++;
            var newP = GetNewObjectForCache(k);
            cache.Add(newP.Id, newP);

            lastKey = cache.GetTheLastKeyFromLinkedList();
            Assert.AreNotEqual(lastKey, 1);
            Assert.AreEqual(lastKey, 2);

            // Add another item, last key should be removed again to make some space
            p = GetNewObjectForCache(i++);
            cache.Add(p.Id, p);
            lastKey = cache.GetTheLastKeyFromLinkedList();
            Assert.AreEqual(lastKey, 3);

            // Add an item double the size, 2 elements be removed from the list and the 5th node should become the last node
            p = GetNewObjectForCacheDoubleSize(i++);
            cache.Add(p.Id, p);
            lastKey = cache.GetTheLastKeyFromLinkedList();
            Assert.AreEqual(lastKey, 5);

            // Access a key. It should move to the new head
            var count = cache.GetCacheItemsCount();
            // take the middle element  and access it
            int el = count / 2;
            cache.Get(el);
            // this element should move to the start of the linked list

        }

        private Person GetNewObjectForCache(int key)
        {
            return new Person { Id = key, FirstName = "Bhandari" + key, LastName = "BholeNath" };
        }
        private Person GetNewObjectForCacheDoubleSize(int key)
        {
            return new Person { Id = key, FirstName = "BhandariBhandari" + key, LastName = "BholeNathBholeNath" };
        }
    }
}
