using BinaryTreeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> treeOne = new BinaryTree<int>();
            treeOne.Add(5);
            treeOne.Add(3);
            treeOne.Add(8);
            treeOne.Add(7);
            treeOne.Add(10);
            treeOne.Add(11);
            treeOne.Add(12);

            BinaryTree<int> treeTwo = new BinaryTree<int>();

            treeTwo.Add(7);
            treeTwo.Add(1);
            treeTwo.Add(5);
            treeTwo.Add(2);
            treeTwo.Add(8);
            treeTwo.Add(6);
            treeTwo.Add(9);
            treeTwo.Add(10);

            BinaryTree<int> treeThree = new BinaryTree<int>();

            treeThree.Add(1);
            treeThree.Add(7);
            treeThree.Add(5);


            BinaryTree<int> treeFour = new BinaryTree<int>();

            treeFour.Add(8);
            treeFour.Add(4);
            treeFour.Add(12);
            treeFour.Add(2);
            treeFour.Add(6);
            treeFour.Add(10);
            treeFour.Add(14);
            treeFour.Add(16);
            treeFour.Add(17);
            treeFour.Add(18);

            Console.WriteLine("PreOrder");
            foreach (var item in treeFour.PreOrder())
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine();
            Console.WriteLine("PostOrder");
            foreach (int item in treeFour.PostOrder())
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine();
            Console.WriteLine("InOrder");
            foreach (int item in treeFour.InOrder())
            {
                Console.Write(item + ", ");
            }

            var testNull = treeFour.FindNode(3);
            var testFindEightNode = treeFour.FindNode(8);




        }
    }
}
