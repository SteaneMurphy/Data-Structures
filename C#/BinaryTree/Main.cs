using System;
using System.Diagnostics;
using System.Numerics;

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
            int numToFind = rnd.Next(0, amount);

            for (int i = 0; i < amount; i++)
            {
                newTree.AddNode(rnd.Next(0, amount));
            }

            //test: search using PreOrder
            bool test = newTree.VerifyTree(newTree.GetRoot());
            timer.Start();
            (long nodesTraversed, bool numFound) = newTree.TraverseTree(BinaryTree.TraversalType.PreOrder, BinaryTree.Method.Search, numToFind);
            timer.Stop();

            //output messaging and timings
            Console.WriteLine($"\nSEARCH ON: {numToFind}");

            Console.WriteLine("\nBINARY TREE SEARCH (Pre-Order)");
            Console.WriteLine($"   -> Total nodes: {newTree.GetNodeAmount()}");
            Console.WriteLine($"   -> Tree verified: {test}");
            Console.WriteLine($"   -> Nodes searched: {nodesTraversed}");
            Console.WriteLine($"   -> Number found: {numFound}");
            Console.WriteLine($"   -> Time taken: {timer.Elapsed.ToString(@"m\:ss\.fff")}ms");

            //test: search using InOrder
            bool test2 = newTree.VerifyTree(newTree.GetRoot());
            timer.Reset();
            timer.Start();
            (long nodesTraversed2, bool numFound2) = newTree.TraverseTree(BinaryTree.TraversalType.InOrder, BinaryTree.Method.Search, numToFind);
            timer.Stop();

            //output messaging and timings
            Console.WriteLine("\nBINARY TREE SEARCH (In-Order)");
            Console.WriteLine($"   -> Total nodes: {newTree.GetNodeAmount()}");
            Console.WriteLine($"   -> Tree verified: {test2}");
            Console.WriteLine($"   -> Nodes searched: {nodesTraversed2}");
            Console.WriteLine($"   -> Number found: {numFound2}");
            Console.WriteLine($"   -> Time taken: {timer.Elapsed.ToString(@"m\:ss\.fff")}ms");

            //test: search using PostOrder
            bool test3 = newTree.VerifyTree(newTree.GetRoot());
            timer.Reset();
            timer.Start();
            (long nodesTraversed3, bool numFound3) = newTree.TraverseTree(BinaryTree.TraversalType.PostOrder, BinaryTree.Method.Search, numToFind);
            timer.Stop();

            //output messaging and timings
            Console.WriteLine("\nBINARY TREE SEARCH (Post-Order)");
            Console.WriteLine($"   -> Total nodes: {newTree.GetNodeAmount()}");
            Console.WriteLine($"   -> Tree verified: {test3}");
            Console.WriteLine($"   -> Nodes searched: {nodesTraversed3}");
            Console.WriteLine($"   -> Number found: {numFound3}");
            Console.WriteLine($"   -> Time taken: {timer.Elapsed.ToString(@"m\:ss\.fff")}ms");
        }
    }
}
