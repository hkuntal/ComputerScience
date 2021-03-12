using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class NodeList<T> : List<Node<T>>
    {
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
            {
                base.Add(new Node<T>());
            }
        }
        public Node<T> FindByValue(T value)
        { 
            return null;
            //base.Select(p => p.Value.Equals(value)).First();
            //foreach (Node < T > in base.TrvalueueForAll)
            //{

            //}
        }

    }
}
