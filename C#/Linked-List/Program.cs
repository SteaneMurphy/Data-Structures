using System;
using DataStructures;
using System.Diagnostics;

/*******************************************************************************
 *                 SINGLE LINKED LIST AND DOUBLE LINKED LIST                   *
 *                               SOLUTION BY:                                  *
 *                                  STEANE                                     *
 *******************************************************************************/

// This task compares adding 50,000 Nodes to a linked-list. The difference between
// adding to the front and back of a singly-linked list is obvious, with adding to
// the back taking alot longer. This is because the list has to traverse every Node
// to reach the final position in the list before adding a new Node. The same timings
// appear for deleting Nodes at the front vs back of a singly-linked list as well.

// I extended this task by creating a doubly-linked list data structure in an effort
// to alleviate this problem. This type of list traverses the list from both the front
// and the back. All Node functions by addition, deletion or index position take the same
// time in a doubly-linked list, as is evident in the timings results.

// On top of the doubly-linked list, I also added in extra functionality to both lists, in
// that a user can add or delete in either list by an index position. I also created
// automated testing through the use of 'Action' function delegates in an effort to make
// the code more DRY. Any new tests can be added with only 2 extra lines of code.

namespace Main
{
    //main program entrypoint
    internal class Entry
    {
        static void Main(string[] args)
        {
            //linked list instances
            LinkedList linkedList1 = new LinkedList();
            LinkedList linkedList2 = new LinkedList();
            //doubly-linked list instances
            DoubleLinkedList DLinkedList1 = new DoubleLinkedList();
            DoubleLinkedList DLinkedList2 = new DoubleLinkedList();

            //delegate function declarations - singly-linked list
            Action<LinkedList, Random> addFront = (list, r) => list.AddNodeFront(r.Next());
            Action<LinkedList, Random> addBack = (list, r) => list.AddNodeBack(r.Next());
            Action<LinkedList> deleteFront = (list) => list.DeleteNodeFront();
            Action<LinkedList> deleteBack = (list) => list.DeleteNodeBack();

            //delegate function declarations - doubly-linked list
            Action<DoubleLinkedList, Random> addFront2 = (list, r) => list.AddNodeFront(r.Next());
            Action<DoubleLinkedList, Random> addBack2 = (list, r) => list.AddNodeBack(r.Next());
            Action<DoubleLinkedList> deleteFront2 = (list) => list.DeleteNodeFront();
            Action<DoubleLinkedList> deleteBack2 = (list) => list.DeleteNodeBack();

            //generate tests for each category
            GenerateTests(addFront, addBack, deleteFront, deleteBack, addFront2, addBack2,
                deleteFront2, deleteBack2, linkedList1, linkedList2, DLinkedList1, DLinkedList2);
        }

        //tests for each category
        static void GenerateTests(
            Action<LinkedList, Random> addFront,
            Action<LinkedList, Random> addBack,
            Action<LinkedList> deleteFront,
            Action<LinkedList> deleteBack,
            Action<DoubleLinkedList, Random> addFront2,
            Action<DoubleLinkedList, Random> addBack2,
            Action<DoubleLinkedList> deleteFront2,
            Action<DoubleLinkedList> deleteBack2,
            LinkedList linkedList1,
            LinkedList linkedList2,
            DoubleLinkedList DLinkedList1,
            DoubleLinkedList DlinkedList2)
        {
            Stopwatch timer = new Stopwatch();
            Random rnd = new Random();
            int counter;

            //for each type of test (add to front, add to back, etc)
            for (int i = 0; i < 8; i++)
            {
                //set message depending on test being conducted
                TestMessage(i);
                counter = 0;
                timer.Reset();
                timer.Start();
                //for each test case, repeat 50,000 times
                for (int j = 0; j < 50000; j++)
                {
                    switch (i)
                    {
                        case 0:
                            addFront(linkedList1, rnd);             //add nodes to front of list
                            break;
                        case 1:
                            addBack(linkedList2, rnd);              //add nodes to back of list
                            break;
                        case 2:
                            deleteFront(linkedList1);               //delete nodes from front of list
                            break;
                        case 3:
                            deleteBack(linkedList2);                //delete nodes from back of list
                            break;
                        case 4:
                            addFront2(DLinkedList1, rnd);           //add nodes to front of list
                            break;
                        case 5:
                            addBack2(DlinkedList2, rnd);            //add nodes to back of list
                            break;
                        case 6:
                            deleteFront2(DLinkedList1);             //delete nodes from front of list
                            break;
                        case 7:
                            deleteBack2(DlinkedList2);              //delete nodes from back of list
                            break;
                        default:
                            throw new Exception("Error: called test does not exist");
                    }
                    counter++;
                }
                //return time taken per test case
                timer.Stop();
                Console.WriteLine($"   -> Loop iterations: {counter}");
                Console.WriteLine($"   -> Time taken: {timer.Elapsed.ToString(@"m\:ss\.fff")}ms\n");
            }
        }

        //message indicator so it is known what test is being run
        static void TestMessage(int i)
        {
            string[] testMessages = new string[8];
            testMessages[0] = "LinkedList: AddFront() starting...";
            testMessages[1] = "LinkedList: AddBack() starting...";
            testMessages[2] = "LinkedList: DeleteFront() starting...";
            testMessages[3] = "LinkedList: DeleteBack() starting...";
            testMessages[4] = "DoubleLinkedList: AddFront() starting...";
            testMessages[5] = "DoubleLinkedList: AddBack() starting...";
            testMessages[6] = "DoubleLinkedList: DeleteFront() starting...";
            testMessages[7] = "DoubleLinkedList: DeleteBack() starting...";

            Console.WriteLine(testMessages[i]);
        }
    }
}
