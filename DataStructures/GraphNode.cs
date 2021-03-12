using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class GraphNode<T>: Node<T>
    {
        private List<int> costs;
        
        public GraphNode() : base() { }
        public GraphNode(T value): base(value) { }
        public GraphNode(T value, NodeList<T> neighbors): base(value, neighbors) { }

        new public NodeList<T> Neighbors
        {
            get
            {
                if(base.Neighbors == null)
                {
                    return null;
                }
                return base.Neighbors;
            }
        }

        public List<int> Costs
        {
            get
            {
                if (costs == null) {
                    return new List<int>(); }
                return costs;
            }
            //set
            //{
            //    this.costs = value;
            //}
        }

       
    }
}
