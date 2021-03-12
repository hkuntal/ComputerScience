using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class CacheNode<K, T> : Node<T>
    {
        public CacheNode<K, T> Prev { get; set; }
        public CacheNode<K, T> Next { get; set; }

        public K Key { get; set; }
    }
}
