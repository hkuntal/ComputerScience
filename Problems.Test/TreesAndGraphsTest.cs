using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Problems.TreesAndGraphs;

namespace Problems.Test
{
    [TestFixture]
    public class TreesAndGraphsTest
    {
        [Test]
        public void TestGetVisibleNodesFromLeft()
        {
            TreeNode<int> root_1 = new TreeNode<int>(8);
            root_1.LeftNode = new TreeNode<int>(3);
            root_1.RightNode = new TreeNode<int>(10);
            root_1.LeftNode.LeftNode = new TreeNode<int>(1);
            root_1.LeftNode.RightNode = new TreeNode<int>(6);
            root_1.RightNode.RightNode = new TreeNode<int>(14);
            root_1.LeftNode.RightNode.LeftNode = new TreeNode<int>(4);
            root_1.LeftNode.RightNode.RightNode = new TreeNode<int>(7);
            root_1.RightNode.RightNode.LeftNode = new TreeNode<int>(13);
            int expected_1 = 4;
            int output_1 = TreesAndGraphs.GetVisibleNodesFromLeft(root_1);
            Assert.AreEqual(expected_1, output_1);


            TreeNode<int> root_2 = new TreeNode<int>(10);
            root_2.LeftNode = new TreeNode<int>(8);
            root_2.RightNode = new TreeNode<int>(15);
            root_2.LeftNode.LeftNode = new TreeNode<int>(4);
            root_2.LeftNode.LeftNode.RightNode = new TreeNode<int>(5);
            root_2.LeftNode.LeftNode.RightNode.RightNode = new TreeNode<int>(6);
            root_2.RightNode.LeftNode = new TreeNode<int>(14);
            root_2.RightNode.RightNode = new TreeNode<int>(16);

            int expected_2 = 5;
            int output_2 = TreesAndGraphs.GetVisibleNodesFromLeft(root_2);
            Assert.AreEqual(expected_2, output_2);
        }

        [Test]
        public void TestcountOfNodes()
        {
            // Testcase 2
            int n_2 = 7, q_2 = 3;
            String s_2 = "abaacab";
            GeneralTreeNode<int> root_2 = new GeneralTreeNode<int>(1);
            root_2.ChildNodes.Add(new GeneralTreeNode<int>(2));
            root_2.ChildNodes.Add(new GeneralTreeNode<int>(3));
            root_2.ChildNodes.Add(new GeneralTreeNode<int>(7));
            root_2.ChildNodes[0].ChildNodes.Add(new GeneralTreeNode<int>(4));
            root_2.ChildNodes[0].ChildNodes.Add(new GeneralTreeNode<int>(5));
            root_2.ChildNodes[1].ChildNodes.Add(new GeneralTreeNode<int>(6));

            var queries_2 = new List<Query>();
            queries_2.Add(new Query(1, 'a'));
            queries_2.Add(new Query(2, 'b'));
            queries_2.Add(new Query(3, 'a'));
            int[] output_2 = TreesAndGraphs.CountOfNodes(root_2, queries_2, s_2);
            int[] expected_2 = { 4, 1, 2 };
            Assert.AreEqual(expected_2, output_2);

            //Testcase 1
            int n_1 = 3, q_1 = 1;
            String s_1 = "aba";
            GeneralTreeNode<int> root_1 = new GeneralTreeNode<int>(1);
            root_1.ChildNodes.Add(new GeneralTreeNode<int>(2));
            root_1.ChildNodes.Add(new GeneralTreeNode<int>(3));
            var queries_1 = new List<Query>();
            queries_1.Add(new Query(1, 'a'));
            int[] output_1 = TreesAndGraphs.CountOfNodes(root_1, queries_1, s_1);
            int[] expected_1 = { 2 };
            Assert.AreEqual(expected_1, output_1);

            
        }

        [Test]
        public void GetHeightOfTreeTest()
        {
            // crate a tree
            TreeNode<int> root = new TreeNode<int>(3);
            TreesAndGraphs.Insert(root, 2);
            TreesAndGraphs.Insert(root, 1);
            TreesAndGraphs.Insert(root, 5);
            TreesAndGraphs.Insert(root, 4);
            TreesAndGraphs.Insert(root, 6);
            TreesAndGraphs.Insert(root, 7);
            var height = TreesAndGraphs.GetHeightOfTree(root);
            Assert.AreEqual(3, height);

            root = new TreeNode<int>(3);
            TreesAndGraphs.Insert(root, 2);
            TreesAndGraphs.Insert(root, 1);
            TreesAndGraphs.Insert(root, 5);
            TreesAndGraphs.Insert(root, 4);
            TreesAndGraphs.Insert(root, 6);
            TreesAndGraphs.Insert(root, 7);
            TreesAndGraphs.Insert(root, 8);
            TreesAndGraphs.Insert(root, 20);
            TreesAndGraphs.Insert(root, 19);
            TreesAndGraphs.Insert(root, 18);
            TreesAndGraphs.Insert(root, 16);
            TreesAndGraphs.Insert(root, 15);
            TreesAndGraphs.Insert(root, 17);
            height = TreesAndGraphs.GetHeightOfTree(root);
            Assert.AreEqual(9, height);
        }

        [Test]
        public void CreateLevelLinkedList()
        {
            // create a new tree sructure
            TreeNode<int> root = new TreeNode<int>(3);
            TreesAndGraphs.Insert(root, 2);
            TreesAndGraphs.Insert(root, 1);
            TreesAndGraphs.Insert(root, 3);
            TreesAndGraphs.Insert(root, 5);
            TreesAndGraphs.Insert(root, 4);
            TreesAndGraphs.Insert(root, 6);
            List<LinkedList<TreeNode<int>>> list = new List<LinkedList<TreeNode<int>>>();
            TreesAndGraphs.CreateLevelLinkedList(root, list, 0);

            // View the content of the list to see the linkedlist structure
        }

        [Test]
        public void TesIfABinaryTreeIsBalancedOrNot()
        {
            // create a new tree sructure
            TreeNode<int> root = new TreeNode<int>(3);
            TreesAndGraphs.Insert(root, 2);
            TreesAndGraphs.Insert(root, 1);
            TreesAndGraphs.Insert(root, 3);
            TreesAndGraphs.Insert(root, 5);
            TreesAndGraphs.Insert(root, 4);
            TreesAndGraphs.Insert(root, 6);
            List<LinkedList<TreeNode<int>>> list = new List<LinkedList<TreeNode<int>>>();
            var output = TreesAndGraphs.IsBalanced(root);
        }
    }
}

