using System;

namespace DataStructures
{
    internal class AVLTree
    {
        #region Class Variables
        private Node root { get; set; }
        private int treeSize = 0;
        #endregion

        #region Class Constructors
        public AVLTree()
        {
            root = null;
        }

        public enum TraversalType
        {
            PreOrder,
            InOrder,
            PostOrder
        }

        public enum Method
        {
            Display,
            Search
        }
        #endregion

        #region Class Functions
        public void AddNode(int _data, Node currentNode = null)
        {
            if (root == null)
            {
                Node newNode = new Node(_data);
                root = newNode;
                treeSize++;
                return;
            }

            if (currentNode == null)
            {
                currentNode = root;
            }

            if (_data < currentNode.GetData())
            {
                if (currentNode.GetLeft() != null)
                {
                    AddNode(_data, currentNode.GetLeft());
                }
                else
                {
                    Node newNode = new Node(_data);
                    newNode.SetParent(currentNode);
                    currentNode.SetLeft(newNode);
                    treeSize++;
                }
            }
            else if (_data >= currentNode.GetData())
            {
                if (currentNode.GetRight() != null)
                {
                    AddNode(_data, currentNode.GetRight());
                }
                else
                {
                    Node newNode = new Node(_data);
                    newNode.SetParent(currentNode);
                    currentNode.SetRight(newNode);
                    treeSize++;
                }
            }
        }

        public void TraverseTree(TraversalType traversal, Method method, int? num = null)
        {
            if (root == null)
            {
                Console.WriteLine($"No Nodes To Display - NULL TREE");
                return;
            }

            try
            {
                Traverse(root, traversal, method, num);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void Traverse(Node currentNode, TraversalType traversal, Method method, int? num = null)
        {
            if (currentNode == null)
            {
                return;
            }

            if (method == Method.Search && num.HasValue && num.Value == currentNode.GetData())
            {
                throw new Exception($"Number found in tree: {num.Value}");
            }

            switch (traversal)
            {
                case TraversalType.PreOrder:
                    //Console.WriteLine(currentNode.GetData());
                    Traverse(currentNode.GetLeft(), traversal, method, num);
                    Traverse(currentNode.GetRight(), traversal, method, num);
                    break;

                case TraversalType.InOrder:
                    Traverse(currentNode.GetLeft(), traversal, method, num);
                    //Console.WriteLine(currentNode.GetData());
                    Traverse(currentNode.GetRight(), traversal, method, num);
                    break;

                case TraversalType.PostOrder:
                    Traverse(currentNode.GetLeft(), traversal, method, num);
                    Traverse(currentNode.GetRight(), traversal, method, num);
                    //Console.WriteLine(currentNode.GetData());
                    break;
            }
        }
        #endregion

        #region Utility Functions
        public void VerifyTree(Node currentNode)
        {
            if (currentNode == null)
            {
                return;
            }

            if (currentNode.GetLeft() != null)
            {
                if (currentNode.GetLeft().GetData() >= currentNode.GetData())
                {
                    Console.WriteLine($"Error: Left child {currentNode.GetLeft().GetData()} is not less than parent {currentNode.GetData()}");
                }
                VerifyTree(currentNode.GetLeft());
            }

            if (currentNode.GetRight() != null)
            {
                if (currentNode.GetRight().GetData() < currentNode.GetData())
                {
                    Console.WriteLine($"Error: Right child {currentNode.GetRight().GetData()} is not greater than parent {currentNode.GetData()}");
                }
                VerifyTree(currentNode.GetRight());
            }

            if (currentNode == GetRoot())
            {
                Console.WriteLine("Tree verified");
            }
        }
        #endregion

        #region Get/Set Functions
        public Node GetRoot()
        {
            return root;
        }
        #endregion
    }
}
