using System;
using System.ComponentModel;

namespace DataStructures
{
    public class BinaryTree
    {
        //class variables
        private Node root { get; set; }
        private int nodeAmount = 0;

        //initialisation
        public BinaryTree()
        {
            root = null;
        }

        //define the tree traversal types
        public enum TraversalType
        {
            PreOrder,
            InOrder,
            PostOrder
        }

        //define the tree function:
        //display logs each Node (according to traversal type)
        //search traverses the tree until the desired number is found (according to traversal type)
        public enum Method 
        {
            Display,
            Search
        }

        //class functions

        //adds a new Node to the Tree
        //if root is null, create and set root to new node
        //if number is less than current node's number and the node has children
        //or if the number is greater than/equal to the current node's number and the node has children
        //then call the AddNode function again, passing in the current node as root
        //when there are no more child nodes, insert the new node and set its number
        public void AddNode(int _data, Node currentNode = null) 
        {
            if (root == null) 
            {
                Node newNode = new Node(_data);
                root = newNode;
                nodeAmount++;
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
                    nodeAmount++;
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
                    nodeAmount++;
                }
            }
        }

        //moves through the tree depending on traversal type
        //if there are no nodes, return from function
        //call traversal function and pass in:
        // - traversal type
        // - tree method type
        // - number to search (otherwise null)

        //int? is nullable type so that parameter can be optional

        //try/catch(exception) is used to interrupt the recursive algorithm, otherwise
        //recursion will still happen after the number has been found which is a waste of resources
        public (long, bool) TraverseTree(TraversalType traversal, Method method, int? num = null) 
        {
            long nodesTraversed = 0;
            bool numFound = false;

            if (root == null) 
            {
                Console.WriteLine($"No Nodes To Display - NULL TREE");
                return (nodesTraversed, false);
            }

            (nodesTraversed, numFound)  = Traverse(root, traversal, method, num);
            if (numFound)
            {
                return (nodesTraversed, true);
            }
            return (nodesTraversed, false);
        }

        //moves through the tree depending on traversal type
        //if current node is null - reached end of this leg of the tree
        //switch statement determines traversal method to use:
        // - pre-order
        // - in-order
        // - post-order
        //traversal type in this case simply determines when the current node's number is printed to console
        //the code is not DRY because I wanted to simulate the three traversal methods, in reality, the current node can be checked
        //at the beginning of the function and left/right processed one after the other
        public (long, bool) Traverse(Node currentNode, TraversalType traversal, Method method, int? num = null, long _nodesTraversed = 0) 
        {
            long nodesTraversed = _nodesTraversed;
            bool numFound = false;

            if (currentNode == null) 
            {
                return (nodesTraversed, false);
            }

            nodesTraversed++;

            switch (traversal)
            {
                case TraversalType.PreOrder:
                    (nodesTraversed, numFound) = CurrentNode(currentNode, method, num, nodesTraversed);
                    if (numFound)
                    {
                        return (nodesTraversed, true);
                    }
                    (nodesTraversed, numFound) = Traverse(currentNode.GetLeft(), traversal, method, num, nodesTraversed);
                    if (numFound) 
                    {
                        return (nodesTraversed, true);
                    }
                    (nodesTraversed, numFound) = Traverse(currentNode.GetRight(), traversal, method, num, nodesTraversed);
                    if (numFound) 
                    {
                        return (nodesTraversed, true);
                    }
                    break;

                case TraversalType.InOrder:
                    (nodesTraversed, numFound) = Traverse(currentNode.GetLeft(), traversal, method, num, nodesTraversed);
                    if (numFound)
                    {
                        return (nodesTraversed, true);
                    }
                    (nodesTraversed, numFound) = CurrentNode(currentNode, method, num, nodesTraversed);
                    if (numFound)
                    {
                        return (nodesTraversed, true);
                    }
                    (nodesTraversed, numFound) = Traverse(currentNode.GetRight(), traversal, method, num, nodesTraversed);
                    if (numFound)
                    {
                        return (nodesTraversed, true);
                    }
                    break;

                case TraversalType.PostOrder:
                    (nodesTraversed, numFound) = Traverse(currentNode.GetLeft(), traversal, method, num, nodesTraversed);
                    if (numFound)
                    {
                        return (nodesTraversed, true);
                    }
                    (nodesTraversed, numFound) = Traverse(currentNode.GetRight(), traversal, method, num, nodesTraversed);
                    if (numFound)
                    {
                        return (nodesTraversed, true);
                    }
                    (nodesTraversed, numFound) = CurrentNode(currentNode, method, num, nodesTraversed);
                    if (numFound)
                    {
                        return (nodesTraversed, true);
                    }
                    break;
            }
            return (nodesTraversed, false);
        }

        private (long, bool) CurrentNode(Node currentNode, Method method, int? num, long nodesTraversed)
        {
            if (method == Method.Search && num.HasValue && num.Value == currentNode.GetData())
            {
                //Console.WriteLine(currentNode.GetData());
                //Console.WriteLine($"\nNumber found in tree: {num.Value}");
                return (nodesTraversed, true);
            }
            else if (method == Method.Display)
            {
                Console.WriteLine(currentNode.GetData());
            }

            return (nodesTraversed, false);
        }

        //moves through the tree and verifies that each Node's children conform to the
        //data structure rules (left is less than parent, right is greater than parent)
        //if a comparison fails one of the above conditions, an error is thrown
        //VerifyTree is called recursively until next child node is null, for each leg
        public bool VerifyTree(Node currentNode)
        {
            if (currentNode == null) 
            {
                return true;
            }

            if (currentNode.GetLeft() != null)
            {
                if (currentNode.GetLeft().GetData() >= currentNode.GetData())
                {
                    Console.WriteLine($"Error: Left child {currentNode.GetLeft().GetData()} is not less than parent {currentNode.GetData()}");
                    return false;
                }
                if (!VerifyTree(currentNode.GetLeft()))
                {
                    return false;
                }
            }

            if (currentNode.GetRight() != null)
            {
                if (currentNode.GetRight().GetData() < currentNode.GetData())
                {
                    Console.WriteLine($"Error: Right child {currentNode.GetRight().GetData()} is not greater than parent {currentNode.GetData()}");
                    return false;
                }
                if (!VerifyTree(currentNode.GetRight())) 
                {
                    return false;
                }
            }

            return true;
        }

        //Get/Set functions

        //returns the root Node
        public Node GetRoot() 
        {
            return root;
        }

        public int GetNodeAmount() 
        {
            return nodeAmount;
        }
    }
}
