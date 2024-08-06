using System;

namespace DataStructures
{
    //This is a data structure for a doubly-linked list. It can traverse its Nodes
    //in a forwards and backwards direction. This data structure is much more efficient than
    //the singly-linked list. This list also tracks how many Nodes it currently has.
    internal class DoubleLinkedList
    {
        #region Class Variables
        private Node head { get; set; }         //current head Node of the linked list
        private Node tail { get; set; }         //current tail Node of the linked list
        private int listSize = 0;               //current amount of Nodes in list
        #endregion

        #region Class Constructors
        //head and tail nodes null upon creation
        public DoubleLinkedList()
        {
            head = null;
            tail = null;
        }
        #endregion

        #region Class Functions
        //for all the following functions, the list traverses its Nodes by using each
        //Node's "GetNext()" or "GetPrev()" functions. The head Node will traverse forwards and the tail
        //Node will traverse backwards. They will keep traversing until they either meet or reach a specific
        //index position. I have explained this here so as to not repeat this functionality in every function

        //counts and returns amount of Nodes in list
        public int NodeCount()
        {
            int headCount = 0;
            int tailCount = 0;
            Node trackingHead = head;
            Node trackingTail = tail;

            while ((trackingHead != trackingTail) && (trackingHead.GetNext() != trackingTail))
            {
                trackingHead = trackingHead.GetNext();
                headCount++;
                trackingTail = trackingTail.GetPrev();
                tailCount++;
            }
            return (headCount + tailCount) + 2;
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

            //if list is empty, set head and tail to initial Node
            if (head == null)
            {
                head = node;
                tail = node;
                return;
            }

            head.SetPrev(node);
            node.SetNext(head);
            head = node;
            listSize++;
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
            tail.SetNext(node);
            node.SetPrev(tail);
            tail = node;
            listSize++;
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
            if (index >= listSize)
            {
                AddNodeBack(data);
                return;
            }

            Node node = new Node(data);

            Node trackingHead = head;
            Node trackingTail = tail;

            int headCount = 0;
            int tailCount = listSize + 1;
            //while head or tail does not equal the index
            while (headCount != index && tailCount != index)
            {
                trackingHead = trackingHead.GetNext();
                headCount++;
                trackingTail = trackingTail.GetPrev();
                tailCount--;
            }
            //if head or tail reach index first
            if (headCount == index)
            {
                Node nodePrev = trackingHead.GetPrev();
                node.SetNext(trackingHead);
                trackingHead.SetPrev(node);
                node.SetPrev(nodePrev);
                nodePrev.SetNext(node);
            }
            else if (tailCount == index)
            {
                Node nodePrev = trackingTail.GetPrev();
                node.SetNext(trackingTail);
                trackingTail.SetPrev(node);
                node.SetPrev(nodePrev);
                nodePrev.SetNext(node);
            }
        }

        //deletes front-most Node from list
        public void DeleteNodeFront()
        {
            //if list is empty, do nothing
            if (head == null)
            {
                return;
            }

            //if last Node in list, null head/tail
            if (head.GetNext() == null)
            {
                head = null;
                tail = null;
                return;
            }

            Node trackingNode = head;
            head = head.GetNext();
            head.SetPrev(null);
            listSize--;
        }

        //deletes back-most Node from list
        public void DeleteNodeBack()
        {
            //if list empty, do nothing
            if (head == null)
            {
                return;
            }

            //if last Node in list, null head/tail
            if (tail.GetPrev() == null)
            {
                head = null;
                tail = null;
                return;
            }

            Node trackingNode = tail;
            tail = tail.GetPrev();
            tail.SetNext(null);
            listSize--;
        }

        //deletes Node based on supplied index position
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

            //if index is greater than list size, delete from back
            if (index >= listSize - 1)
            {
                DeleteNodeBack();
                return;
            }

            Node trackingHead = head;
            Node trackingTail = tail;

            int headCount = 0;
            int tailCount = listSize + 1;
            //while the head or tail does not equal the index
            while (headCount != index && tailCount != index)
            {
                trackingHead = trackingHead.GetNext();
                headCount++;
                trackingTail = trackingTail.GetPrev();
                tailCount--;
            }
            //if head or tail is first to reach index
            if (headCount == index)
            {
                Node nodePrev = trackingHead.GetPrev();
                Node nodeNext = trackingHead.GetNext();
                nodePrev.SetNext(trackingHead.GetNext());
                nodeNext.SetPrev(trackingHead.GetPrev());
            }
            else if (tailCount == index)
            {
                Node nodePrev = trackingTail.GetPrev();
                Node nodeNext = trackingTail.GetNext();
                nodePrev.SetNext(trackingTail.GetNext());
                nodeNext.SetPrev(trackingTail.GetPrev());
            }
        }
        #endregion
    }
}
