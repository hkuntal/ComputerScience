using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class LinkedListsProblems
    {
        // problem 2.1 from the book interview questions
        public void RemoveDuplicates(LinkedList<int> linkedList)
        {
            HashSet<int> set = new HashSet<int>();
            var node = linkedList.First;
            while (node != null)
            {
                if (!set.Contains(node.Value))
                {
                    set.Add(node.Value);
                }
                else
                {
                    // this is duplicate remove it
                    linkedList.Remove(node);
                }

                node = node.Next;
            }
        }
    }
}