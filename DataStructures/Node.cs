﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Node<T>
    {
        private T data;
        private NodeList<T> neighbors = null;
        

        public Node()
        {
        }
        public Node(T data): this(data, null)
        {
            this.data = data;
        }
        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }
        public T Value
        {
            get { return data; }
            set { data = value; }
        }


        protected NodeList<T> Neighbors
        {
            get { return neighbors; }
            set { neighbors = value; }
        }
        
    } 
}
