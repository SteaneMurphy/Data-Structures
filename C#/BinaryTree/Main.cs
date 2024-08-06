using System;
using System.Diagnostics;

/*******************************************************************************
 *                              BINARY TREES                                   *
 *                               SOLUTION BY:                                  *
 *                                 STEANE                                      *
 *******************************************************************************/

namespace DataStructures
{
    internal class Entry
    {
        static void Main(string[] args)
        {
            BinaryTree newTree = new BinaryTree();
            Random rnd = new Random();
            Stopwatch timer = new Stopwatch();
            int amount = 150000;

            for (int i = 0; i < amount; i++)
            {
                if (i == amount - 1)
                {
                    newTree.AddNode(i + 1);
                }
                else 
                {
                    newTree.AddNode(rnd.Next());
                }
            }

            newTree.TraverseTree(BinaryTree.TraversalType.PreOrder, BinaryTree.Method.Display);
            newTree.VerifyTree(newTree.GetRoot());
            newTree.TraverseTree(BinaryTree.TraversalType.PreOrder, BinaryTree.Method.Search, 150000);
        }
    }
}
