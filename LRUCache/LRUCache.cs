using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;
using System.Collections.Concurrent;
using Interfaces;

namespace LRUCache
{
    public class LRUCache<K, V> where V : ICacheValue
    {
        private IDictionary<K, CacheNode<K, V>> dict;
        private CacheNode<K, V> head = new CacheNode<K, V>();
        private CacheNode<K, V> tail = new CacheNode<K, V>();
        private object linkLock = new Object();
        private int maxCacheSize;
        private int usedCacheSize;
        //private Node<V> tail = new Node<V>();

        public LRUCache(int cahceSize)
        {
            dict = new ConcurrentDictionary<K, CacheNode<K, V>>();
            this.maxCacheSize = cahceSize;
            // connect the head and tails together
            tail.Next = head;
            head.Prev = tail;
        }

        public void Add(K key, V value)
        {
            // check the size to see if it fit in to the cache or not
            usedCacheSize += value.GetSize();
            if(usedCacheSize >= maxCacheSize)
            {
                FreeSomeSpace(usedCacheSize - maxCacheSize);
            }
            var node = new CacheNode<K, V>();
            node.Value = value;
            node.Key = key;
            MoveNodeToFront(node);
            dict.Add(key, node);
        }

        public V Get(K key)
        {
            var value = default(V);

            // return the data from the cache
            if (dict.ContainsKey(key))
            {
                CacheNode<K, V> node = dict[key];
                value  = node.Value;
                MoveNodeToFront(node);
            }
            return value;
        }

        public int GetCurrentCacheSize()
        {
            return usedCacheSize;
        }

        public K GetTheLastKeyFromLinkedList()
        {
            return tail.Next.Key;
        }

        public int GetCacheItemsCount()
        {
            return dict.Count();
        }


        private void MoveNodeToFront(CacheNode<K, V> node)
        {
            lock (linkLock)
            {
                // synchronize this operation. Multiple threads cannot change the header
                if (node != null)
                {
                    // move this to the front of the linked list
                    var prevNode = head.Prev;
                    node.Next = head;
                    node.Prev = prevNode;
                    head.Prev = node;
                    prevNode.Next = node;
                }
            }
        }

        private void FreeSomeSpace(int minSizeToFree)
        {
            lock (linkLock)
            {
                // start deleting the instances from the tail until the size are freeup
                var freedUpSize = 0;
                while (freedUpSize < minSizeToFree)
                {
                    // start from the tail node
                    var nodeToFree = tail.Next;
                    freedUpSize += nodeToFree.Value.GetSize();

                    var nextNode = nodeToFree.Next;
                    tail.Next = nextNode;
                    nextNode.Prev = tail;
                    // remove the referenecs and also delete them from the dictionary
                    var key = nodeToFree.Key;
                    this.usedCacheSize -= nodeToFree.Value.GetSize();
                    dict.Remove(key);
                }
            }
        }
    }
}
