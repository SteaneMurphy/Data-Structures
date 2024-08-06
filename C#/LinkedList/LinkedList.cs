using System;

namespace DataStructures
{
    //This is a data structure for a singly-linked list. This data structure can only
    //traverse its Nodes in one direction, from front to back
    public class LinkedList
    {
        #region Class Variables
        private Node head { get; set; }     //current head node of the linked list
        #endregion

        #region Class Constructors
        //head node null upon list creation
        public LinkedList()
        {
            head = null;
        }
        #endregion

        #region Class Functions
        //for all the following functions, the list traverses its Nodes by using each
        //Node's "GetNext()" function. It will traverse each Node until it reach either a null reference,
        //or it reaches an index point. I have explained this here rather than repeat this process for each function below

        //counts and returns amount of Nodes in list
        public int NodeCount()
        {
            int count = 0;
            Node trackingNode = head;

            while (trackingNode != null)
            {
                trackingNode = trackingNode.GetNext();
                count++;
            }
            return count;
        }

        //displays data content of each Node in list
        public void DisplayNodeList()
        {
            Node trackingNode = head;

            while (trackingNode != null)
            {
                Console.WriteLine($"Node: {trackingNode.GetData()}");
                trackingNode = trackingNode.GetNext();
            }
        }

        //adds a Node to the front of the list
        public void AddNodeFront(int data)
        {
            Node node = new Node(data);
            node.SetNext(head);
            head = node;
        }

        //adds a Node to the back of the list
        public void AddNodeBack(int data)
        {
            //If list is empty add to front of list
            if (head == null)
            {
                AddNodeFront(data);
                return;
            }

            Node node = new Node(data);
            Node trackingNode = head;

            while (trackingNode.GetNext() != null)
            {
                trackingNode = trackingNode.GetNext();
            }
            trackingNode.SetNext(node);
        }

        //adds a Node to a specific index position in the list
        public void AddNodeIndex(int data, int index)
        {
            //if list if empty or index is first position
            //add to front
            if (head == null || index == 0)
            {
                AddNodeFront(data);
                return;
            }

            //if index is longer than list
            //add to back
            if (index >= NodeCount())
            {
                AddNodeBack(data);
                return;
            }

            Node node = new Node(data);
            Node trackingNode = head;
            Node trackingNodePrevious = head;

            for (int i = 0; i < index; i++)
            {
                trackingNodePrevious = trackingNode;
                trackingNode = trackingNode.GetNext();
            }
            trackingNodePrevious.SetNext(node);
            node.SetNext(trackingNode);
        }

        //deletes front-most Node from list
        public void DeleteNodeFront()
        {
            //if list is empty, do nothing
            if (head == null)
            {
                return;
            }

            Node trackingNode = head;
            head = head.GetNext();
        }

        //deletes back-most Node from list
        public void DeleteNodeBack()
        {
            //if list is empty, do nothing
            if (head == null)
            {
                return;
            }

            Node trackingNode = head;
            Node trackingNodePrevious = head;

            while (trackingNode.GetNext() != null)
            {
                trackingNodePrevious = trackingNode;
                trackingNode = trackingNode.GetNext();
            }
            trackingNodePrevious.SetNext(null);
        }

        //delete a specific Node based upon supplied index position
        public void DeleteNodeIndex(int index)
        {
            //if list is empty, do nothing
            if (head == null)
            {
                return;
            }

            //if index is first position, delete from front
            if (index == 0)
            {
                DeleteNodeFront();
                return;
            }

            //if index is greater than size of list,
            //delete from back
            if (index >= NodeCount() - 1)
            {
                DeleteNodeBack();
                return;
            }

            Node trackingNode = head;
            Node trackingNodePrevious = head;

            for (int i = 0; i < index; i++)
            {
                trackingNodePrevious = trackingNode;
                trackingNode = trackingNode.GetNext();
            }
            trackingNodePrevious.SetNext(trackingNode.GetNext());
        }
        #endregion
    }
}
