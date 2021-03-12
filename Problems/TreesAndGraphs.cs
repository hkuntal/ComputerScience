using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class TreesAndGraphs
    {
        // Breadth first approach
        public bool DoesRouteExistBetTwoNodes(Graph graph, GraphNode<int> a, GraphNode<int> b)
        {
            // Do a breadth first approach
            // go from node a to node b. Fitst look at all the adjacent nodes of a
            GraphNode<int> node = a;
            Queue<GraphNode<int>> nodeQueue = new Queue<GraphNode<int>>();
            nodeQueue.Enqueue(a);
            while (nodeQueue.Count != 0)
            {
                var nodeToProcess = nodeQueue.Dequeue();

                //if (IsDestNodeReached(nodeToProcess, b))
                //{
                //    return true;
                //}

                // loop over all of its adjacent nodes and queue them for further processing
                if (nodeToProcess.AdjacencyList != null)
                {
                    foreach (var graphNode in nodeToProcess.AdjacencyList)
                    {
                        if (!graphNode.Visited)
                        {
                            if (IsDestNodeReached(nodeToProcess, b))
                            {
                                return true;
                            }
                            graphNode.Visited = true;
                            // queue the nodes
                            nodeQueue.Enqueue(graphNode);
                        }
                    }
                }
            }
            return false;
        }

        // Depth first approach
        public bool DoesRouteExistBetTwoNodes1(Graph graph, GraphNode<int> a, GraphNode<int> b)
        {
            // check recursively
            return CheckRoute(a, b);
        }

        private static bool CheckRoute(GraphNode<int> node, GraphNode<int> dest)
        {
            if (node == null || node.AdjacencyList == null) return false;

            if (IsDestNodeReached(node, dest))
            {
                return true;
            }

            foreach (var adjNode in node.AdjacencyList)
            {              // check if teh node is already visited do not visited again
                if (!adjNode.Visited)
                {
                    // Mark it as visited
                    node.Visited = true;
                    return CheckRoute(adjNode, dest);
                }
            }
            return false;
        }

        private static bool IsDestNodeReached(GraphNode<int> nodeToProcess, GraphNode<int> b)
        {
            return nodeToProcess == b;
        }


        /*
         * Number of Visible Nodes
    There is a binary tree with N nodes. You are viewing the tree from its left side and can see only the leftmost nodes at each level. 
        Return the number of visible nodes.
    Note: You can see only the leftmost nodes, but that doesn't mean they have to be left nodes. The leftmost node at a level could be a right node.
    Signature
    int visibleNodes(Node root) {
    Input
    The root node of a tree, where the number of nodes is between 1 and 1000, and the value of each node is between 0 and 1,000,000,000
    Output
    An int representing the number of visible nodes.
    Example
                8  <------ root
               / \
             3    10
            / \     \
           1   6     14
              / \    /['---8
        ]0-0
        0
             4   7  13            
    output = 4
         */

        public static int GetVisibleNodesFromLeft(TreeNode<int> root)
        {
            int count = 0;
            CheckLevels(root, null, ref count);
            return count;

        }

        private static void CheckLevels(TreeNode<int> node, TreeNode<int> fatherNode, ref int count)
        {
            
            if (node != null)
            {
                count++;
                // start from the first level
                var nextNode = node.LeftNode != null ? node.LeftNode : node.RightNode;
                if (nextNode == null && fatherNode.RightNode != null)
                {
                    // go to the previous node
                    nextNode = fatherNode.RightNode.LeftNode != null ? fatherNode.RightNode.LeftNode : fatherNode.RightNode.RightNode;
                    node = fatherNode.RightNode;
                }
                CheckLevels(nextNode, node, ref count);
            }
        }

        /*
         * Nodes in a Subtree
You are given a tree that contains N nodes, each containing an integer u which corresponds to a lowercase character c 
        in the string s using 1-based indexing.
You are required to answer Q queries of type [u, c], where u is an integer and c is a lowercase letter. 
        The query result is the number of nodes in the subtree of node u containing c.
Signature
int[] countOfNodes(Node root, ArrayList<Query> queries, String s)
Input
A pointer to the root node, an array list containing Q queries of type [u, c], and a string s
Constraints
N and Q are the integers between 1 and 1,000,000
u is a unique integer between 1 and N
s is of the length of N, containing only lowercase letters
c is a lowercase letter contained in string s
Node 1 is the root of the tree
Output
An integer array containing the response to each query
Example
        1(a)
        /   \
      2(b)  3(a)
s = "aba"
RootNode = 1
query = [[1, 'a']]
Note: Node 1 corresponds to first letter 'a', Node 2 corresponds to second letter of the string 'b', Node 3 corresponds to third letter of the string 'a'.
output = [2]
Both Node 1 and Node 3 contain 'a', so the number of nodes within the subtree of Node 1 containing 'a' is 2.
         */

        // Used as Linked list nodes
        public static int[] CountOfNodes(GeneralTreeNode<int> root, List<Query> queries, String s)
        {
            var result = new List<int>();
            // find the sub node
            foreach (var query in queries)
            {
                var inputNumber = query.U;
                var inputChar = query.C;
                int counter = 0;
                // search the tree for this number, user a breadthfirst approach
                var nodeFound = FindNodeUsingDFS(root, inputNumber);
                GeneralTreeNode<int>.TraverseBFS(nodeFound, (node) =>
                {
                    var pos = node.Value;
                    if (s[pos - 1] == inputChar)
                    {
                        counter++;
                    }

                });
                result.Add(counter);
            }
            return result.ToArray();
        }

        /*
         * The height of a binary tree is the number of edges between the tree's root and its furthest leaf. For example, the following binary tree is of height :
            image
            Function Description

            Complete the getHeight or height function in the editor. It must return the height of a binary tree as an integer.

            getHeight or height has the following parameter(s):

            root: a reference to the root of a binary tree.
            Note -The Height of binary tree with single node is taken as zero.

            Input Format

            The first line contains an integer , the number of nodes in the tree.
            Next line contains  space separated integer where th integer denotes node[i].data.

            Note: Node values are inserted into a binary search tree before a reference to the tree's root node is passed to your function. In a binary search tree, all nodes on the left branch of a node are less than the node value. All values on the right branch are greater than the node value.

            Constraints



            Output Format

            Your function should return a single integer denoting the height of the binary tree.
         */
        public static int GetHeightOfTree(TreeNode<int> root)
        {
            // Write your code here.
            if (root == null || (root.LeftNode == null && root.RightNode == null))
            {
                return 0;
            }
            else
            {
                int leftHeight = 0;
                int rightHeight = 0;
                // traverse the left path
                if (root.LeftNode != null)
                {
                    leftHeight = 1 + GetHeightOfTree(root.LeftNode);
                }
                if (root.RightNode != null)
                {
                    rightHeight = 1 + GetHeightOfTree(root.RightNode);
                }
                return rightHeight > leftHeight ? rightHeight : leftHeight;
            }
        }

        /*
         * Create a minimal binary tree from a sorted integer array
         * Prblem 4.2 from the book Cracking the coding interview
         */
        public static TreeNode<int> CreateMinimalBinaryTree(int[] arr)
        {
            // split the array into two left side goes in left tree and right side 
            // goes in the right sub tree
            return CreateMinimalBinaryTree(arr, 0, arr.Length - 1);
            
        }

        /*
         * Problem # 4.3 from the interview book.
         * Given a binary tree design an algorithm that creates a linked list of all the nodes at each level. If 
         * a tree has depth then there should be D linked lists
         */

        public static void CreateLevelLinkedList(TreeNode<int> root, List<LinkedList<TreeNode<int>>> lists, int level)
        {
            if (root == null) return;

            // Start from the root level
            if(lists.Count == level)
            {
                // Create a new level
                LinkedList<TreeNode<int>> list1 = new LinkedList<TreeNode<int>>();
                LinkedListNode<TreeNode<int>> node1 = new LinkedListNode<TreeNode<int>>(root);
                lists.Add(list1);
                CreateLevelLinkedList(root.LeftNode, lists, level+1);
                CreateLevelLinkedList(root.RightNode, lists, level+1);
            }
            else
            {
                // Means that level already exists, extract and add node to that list
                var linkedList = lists[level];
                linkedList.AddLast(root);
            }
        }

        /*
         * Problem# 4.4 from the interview book
         * Implement a function to see if a binary tree balanced. A balanced binary tree is one where heights of
         * two subtrees never differ more than by one
         */
        public static bool IsBalanced(TreeNode<int> root)
        {
            return false;

            if (Math.Abs(getHeight(root.LeftNode) - getHeight(root.RightNode)) > 1)
            {
                return false;
            }
            else
            {
                return IsBalanced(root.LeftNode) && IsBalanced(root.RightNode);
            }
        }

        private static int getHeight(TreeNode<int> root)
        {
            if (root == null) return 0;

            return Math.Max(getHeight(root.LeftNode), getHeight(root.RightNode)) + 1;
        }

        private static TreeNode<int> CreateMinimalBinaryTree(int[] arr, int start, int end)
        {
            /*
             * array length = 4 index 0 1 2 3 mid = 3/2 = 1
             * array length = 5 index 0 1 2 3 4 mid = 4/2 = 2
             */
            if(start > end)
            {
                return null;
            }
            int mid = (start + end) / 2;
            // create a new node with the middle element
            var node = new TreeNode<int>(arr[mid]);
            node.LeftNode = CreateMinimalBinaryTree(arr, start, mid -1 );
            node.RightNode = CreateMinimalBinaryTree(arr, mid +1, end);
            return node;
        }

        private static int[] getLeftSideArray(int[] arr, int middleIndex)
        {
            if (arr.Length == 1) return arr;
            int[] leftArray = new int[middleIndex + 1];
            for (var i = 0; i <= middleIndex; i++)
            {
                leftArray[i] = arr[i];
            }
            return leftArray;
        }

        private static int[] getRightSideArray(int[] arr, int middleIndex)
        {
            if (arr.Length == 1) return arr;
            int[] rightArray = new int[arr.Length -1 - middleIndex];
            int j = 0;
            for (var i = middleIndex + 1; i <= arr.Length -1; i++)
            {
                rightArray[j] = arr[i];
            }
            return rightArray;
        }

        
        private static GeneralTreeNode<int> FindNodeUsingBFS(GeneralTreeNode<int> root, int inputNumber)
        {
            GeneralTreeNode<int> nodeFound;
            Queue<GeneralTreeNode<int>> queue = new Queue<GeneralTreeNode<int>>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                node.Visited = true;
                if (inputNumber == node.Value)
                {
                    return node;
                }
                foreach(var adjNode in node.ChildNodes)
                {
                    // checking for visited is not required for a tree as its not cyclic but is required for a graph
                    if (!adjNode.Visited)
                    {
                        queue.Enqueue(adjNode);
                    }
                }
            }
            return null;
        }

        private static GeneralTreeNode<int> FindNodeUsingDFS(GeneralTreeNode<int> node, int inputNumber)
        {
            node.Visited = true;
            if (node == null) return null;
            if (inputNumber == node.Value)
            {
                return node;
            }
            else
            {
                foreach (var adjNode in node.ChildNodes)
                {
                    // checking for visited is not required for a tree as its not cyclic but is required for a graph
                    var resultNode = FindNodeUsingDFS(adjNode, inputNumber);
                    if (resultNode != null)
                    {
                        return resultNode;
                    }
                    continue;
                }
            }
            return null;
        }
                
            

        private static void InOrderTraversal(TreeNode<int> node)
        {
            if(node != null)
            {
                InOrderTraversal(node.LeftNode);
                Visit(node);
                InOrderTraversal(node.RightNode);
            }
        }

        private static void PreOrderTraversal(TreeNode<int> node)
        {
            if (node != null)
            {
                Visit(node);
                PreOrderTraversal(node.LeftNode);
                PreOrderTraversal(node.RightNode);
            }
        }
        private static void PostOrderTraversal(TreeNode<int> node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.LeftNode);
                PostOrderTraversal(node.RightNode);
                Visit(node);
            }
        }

        private static void Visit(TreeNode<int> node)
        {
            throw new NotImplementedException();
        }

        public static TreeNode<int> Insert(TreeNode<int> root, int data)
        {
            TreeNode<int> node = null;
            if (root == null)
            {
                // end of tree reached create a new node
                return new TreeNode<int>(data);
            }
            if(data <= root.Value)
            {
                // goes to the left side as its a binary search tree
                node = Insert(root.LeftNode, data);
                root.LeftNode = node;
            }
            else
            {
                // goes to right side of the node
                node = Insert(root.RightNode, data);
                root.RightNode = node;
            }
            return root;
        }
        public class Node<T>
        {
            T value;
            public Node(T value)
            {
                this.value = value;
            }
            public T Value { get; set; }
            public Node<T> NextNode { get; set; }
            public Node<T> PreviousNode { get; set; }
        }

        public class TreeNode<T>
        {
            
            public TreeNode(T value)
            {
                this.Value = value;
                this.ChildNodes = new List<TreeNode<T>>();
            }
            public T Value { get; set; }
            public TreeNode<T> LeftNode { get; set; }
            public TreeNode<T> RightNode { get; set; }

            public List<TreeNode<T>> ChildNodes{ get; set; }
        }

        public class GeneralTreeNode<T>
        {
            public GeneralTreeNode(T value)
            {
                this.Value = value;
                this.ChildNodes = new List<GeneralTreeNode<T>>();
            }

            public GeneralTreeNode(T value, IList<GeneralTreeNode<T>> children)
            {
                this.Value = value;
                this.ChildNodes = children;
            }

            public T Value { get; set; }
            public IList<GeneralTreeNode<T>> ChildNodes { get; set; }

            public bool Visited { get; set; }

            public static void TraverseDFS(GeneralTreeNode<T> node, Action<GeneralTreeNode<T>> func)
            {
                if (node != null)
                {
                    func(node);
                    foreach (var childNode in node.ChildNodes)
                    {
                        TraverseDFS(childNode, func);
                    }
                }
            }

            public static void TraverseBFS(GeneralTreeNode<T> node, Action<GeneralTreeNode<T>> func)
            {
                if (node != null)
                {
                    var queue = new Queue<GeneralTreeNode<T>>();
                    queue.Enqueue(node);
                    while (queue.Count != 0)
                    {
                        var workNode = queue.Dequeue();
                        //visit the node
                        func(workNode);
                        // push all its children in its queue
                        foreach (var childNode in workNode.ChildNodes)
                        {
                            queue.Enqueue(childNode);
                        }
                    }
                }
            }
        }
        
        public class GraphNode<T>
        {
            public GraphNode(T value)
            {
                this.Value = value;
            }
            public T Value { get; set; }
            public List<GraphNode<T>> AdjacencyList { get; set; }

            public static void TraverseDFS(GraphNode<T> node, Action<GraphNode<T>> func)
            {
                if (node != null)
                {
                    func(node);
                    node.Visited = true;
                    foreach (var childNode in node.AdjacencyList)
                    {
                        if (!node.Visited)
                        {
                            TraverseDFS(childNode, func);
                        }
                    }
                }
            }

            public static void TraverseBFS(GraphNode<T> node, Action<GraphNode<T>> func)
            {
                if (node != null)
                {
                    var queue = new Queue<GraphNode<T>>();
                    queue.Enqueue(node);
                    while (queue.Count != 0)
                    {
                        var workNode = queue.Dequeue();
                        //visit the node
                        func(workNode);
                        workNode.Visited = true;
                        // push all its children in its queue
                        foreach (var childNode in workNode.AdjacencyList)
                        {
                            if (!workNode.Visited)
                            {
                                queue.Enqueue(childNode);
                            }
                        }
                    }
                }
            }
            public bool Visited { get; set; }
        }

        public class Graph
        {

        }
        public class Tree
        {

        }

        public class Query
        {
            public Query(int u, char c)
            {
                this.U = u;
                this.C = c;
            }

            public int U { get; set; }
            public char C { get; set; }
        }
    }

}