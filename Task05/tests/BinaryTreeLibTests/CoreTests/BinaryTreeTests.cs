using BinaryTreeLib.Core;
using NUnit.Framework;
using System;

namespace BinaryTreeLibTests.CoreTests
{
    /// <summary>
    /// BinaryTreeTests type test and related classes with it.
    /// </summary>
    [TestFixture()]
    public class BinaryTreeTests
    {
        /// <summary>
        /// Initialization of a int binary tree.
        /// </summary>
        /// <returns>Returns a new int binary tree.</returns>
        public static BinaryTree<int> InitialIntBinaryTree()
        {
            BinaryTree<int> actualBinaryTree = new BinaryTree<int>();

            actualBinaryTree.Add(5);
            actualBinaryTree.Add(3);
            actualBinaryTree.Add(8);
            actualBinaryTree.Add(7);
            actualBinaryTree.Add(10);
            actualBinaryTree.Add(11);
            actualBinaryTree.Add(12);

            return actualBinaryTree;
        }

        /// <summary>
        /// Initialization of a string binary tree.
        /// </summary>
        /// <returns>Returns a new string binary tree.</returns>
        public static BinaryTree<string> InitialStringBinaryTree()
        {
            BinaryTree<string> actualBinaryTree = new BinaryTree<string>();

            actualBinaryTree.Add("a");
            actualBinaryTree.Add("b");
            actualBinaryTree.Add("c");
            actualBinaryTree.Add("d");
            actualBinaryTree.Add("e");
            actualBinaryTree.Add("f");
            actualBinaryTree.Add("g");

            return actualBinaryTree;
        }

        /// <summary>
        /// Testing <see cref="BinaryTreeLib.Core.BinaryTree{T}.Add(T)"/> where T is Int32.
        /// </summary>
        [TestCase()]
        public void GivenAddWhenTIsIntThenOutIsIntBinaryTree()
        {
            //Arrange
            BinaryTree<int> actualBinaryTree = InitialIntBinaryTree();
            BinaryTree<int> expectedBinaryTree = new BinaryTree<int>();

            //Act
            expectedBinaryTree.Count = 7;
            expectedBinaryTree.Root =
                                        new Node<int>(8,
                    new Node<int>(5,
            new Node<int>(3), new Node<int>(7)),
                                                    new Node<int>(11,
                                            new Node<int>(10), new Node<int>(12)));

            //Assert
            Assert.AreEqual(expectedBinaryTree, actualBinaryTree);
        }

        /// <summary>
        /// Testing <see cref="BinaryTreeLib.Core.BinaryTree{T}.Add(T)"/> where T is String.
        /// </summary>
        [TestCase()]
        public void GivenAddWhenTIsStringThenOutIsStringBinaryTree()
        {
            //Arrange
            BinaryTree<string> actualBinaryTree = InitialStringBinaryTree();
            BinaryTree<string> expectedBinaryTree = new BinaryTree<string>();

            //Act
            expectedBinaryTree.Count = 7;
            expectedBinaryTree.Root =
                                        new Node<string>("d",
                    new Node<string>("b",
            new Node<string>("a"), new Node<string>("c")),
                                                    new Node<string>("f",
                                            new Node<string>("e"), new Node<string>("g")));

            //Assert
            Assert.AreEqual(expectedBinaryTree, actualBinaryTree);
        }

        /// <summary>
        /// Testing <see cref="BinaryTreeLib.Core.BinaryTree{T}.Add(T)"/> where T is Int32 and String.
        /// </summary>
        [TestCase()]
        public void GivenAddWhenActualTIntExpectedTStringThenOutIsNotEquel()
        {
            //Arrange
            BinaryTree<int> actualBinaryTree = InitialIntBinaryTree();
            BinaryTree<string> expectedBinaryTree = new BinaryTree<string>();

            //Act
            expectedBinaryTree.Count = 7;
            expectedBinaryTree.Root =
                                        new Node<string>("d",
                    new Node<string>("b",
            new Node<string>("a"), new Node<string>("c")),
                                                    new Node<string>("f",
                                            new Node<string>("e"), new Node<string>("g")));

            //Assert
            Assert.AreNotEqual(expectedBinaryTree, actualBinaryTree);
        }

        /// <summary>
        /// Testing <see cref="BinaryTreeLib.Core.BinaryTree{T}.Add(T)"/> when NullReferenceException.
        /// </summary>
        [TestCase()]
        public void GivenAddWhenArgumentIsNullThenOutIsNullReferenceException()
        {
            //Arrange
            BinaryTree<string> actualBinaryTree = new BinaryTree<string>();

            //Assert
            Assert.That(() => actualBinaryTree.Add(null), Throws.TypeOf<NullReferenceException>());
        }

        /// <summary>
        /// Testing <see cref="BinaryTreeLib.Core.BinaryTree{T}.FindNode(T, Node{T})"/>
        /// </summary>
        /// <param name="actualNode">Object to find.</param>
        /// <param name="expectedNode">Found object.</param>
        [TestCase(3, 3)]
        [TestCase(5, 5)]
        [TestCase(8, 8)]
        [TestCase(7, 7)]
        [TestCase(10, 10)]
        [TestCase(11, 11)]
        [TestCase(12, 12)]
        public void GivenFindNodeWhenArgumentIsIntThenOutIsFoundNode(int actualNode, int expectedNode)
        {
            //Arrange
            BinaryTree<int> actualBinaryTree = InitialIntBinaryTree();
            Node<int> expectedBinaryNode = new Node<int>();

            //Act
            expectedBinaryNode.Data = expectedNode;

            //Assert
            Assert.AreEqual(expectedBinaryNode, actualBinaryTree.FindNode(actualNode));
        }

        /// <summary>
        /// Testing <see cref="BinaryTreeLib.Core.BinaryTree{T}.FindNode(T, Node{T})"/>
        /// </summary>
        /// <param name="actualNode">Object to find.</param>
        /// <param name="expectedNode">Found object.</param>
        [TestCase(-1, null)]
        [TestCase(0, null)]
        public void GivenFindNodeWhenArgumentIsIntThenOutIsNull(int actualNode, string expectedNode)
        {
            //Arrange
            BinaryTree<int> actualBinaryTree = InitialIntBinaryTree();

            //Assert
            Assert.AreEqual(expectedNode, actualBinaryTree.FindNode(actualNode));
        }

        /// <summary>
        /// Testing <see cref="BinaryTreeLib.Core.BinaryTree{T}.PreOrder"/>
        /// </summary>
        /// <param name="expectedBinaryTreeToPreOrderStr">A string containing all the elements that were found in the binary tree.</param>
        /// <param name="initEmpty">BinaryTree is null?</param>
        [TestCase("8 5 3 7 11 10 12 ", false)]
        [TestCase("", true)]
        public void GivenPreOrderWhenTIsIntThenOutIsString(string expectedBinaryTreeToPreOrderStr, bool initEmpty)
        {
            //Arrange
            BinaryTree<int> actualBinaryTree;

            if (!initEmpty)
                actualBinaryTree = InitialIntBinaryTree();
            else
                actualBinaryTree = new BinaryTree<int>();

            string actualBinaryTreeToPreOrderStr = string.Empty;

            //Act
            foreach (var item in actualBinaryTree.PreOrder())
            {
                actualBinaryTreeToPreOrderStr += item + " ";
            }

            //Assert
            Assert.AreEqual(expectedBinaryTreeToPreOrderStr, actualBinaryTreeToPreOrderStr);
        }

        /// <summary>
        /// Testing <see cref="BinaryTreeLib.Core.BinaryTree{T}.PostOrder"/>
        /// </summary>
        /// <param name="expectedBinaryTreeToPostOrderStr">A string containing all the elements that were found in the binary tree.</param>
        /// <param name="initEmpty">BinaryTree is null?</param>
        [TestCase("3 7 5 10 12 11 8 ", false)]
        [TestCase("", true)]
        public void GivenPostOrderWhenTIsIntThenOutIsString(string expectedBinaryTreeToPostOrderStr, bool initEmpty)
        {
            //Arrange
            BinaryTree<int> actualBinaryTree;

            if (!initEmpty)
                actualBinaryTree = InitialIntBinaryTree();
            else
                actualBinaryTree = new BinaryTree<int>();

            string actualBinaryTreeToPostOrderStr = string.Empty;

            //Act
            foreach (var item in actualBinaryTree.PostOrder())
            {
                actualBinaryTreeToPostOrderStr += item + " ";
            }

            //Assert
            Assert.AreEqual(expectedBinaryTreeToPostOrderStr, actualBinaryTreeToPostOrderStr);
        }

        /// <summary>
        /// Testing <see cref="BinaryTreeLib.Core.BinaryTree{T}.InOrder"/>
        /// </summary>
        /// <param name="expectedBinaryTreeToInOrderStr">A string containing all the elements that were found in the binary tree.</param>
        /// <param name="initEmpty">BinaryTree is null?</param>
        [TestCase("3 5 7 8 10 11 12 ", false)]
        [TestCase("", true)]
        public void GivenInOrderWhenTIsIntThenOutIsString(string expectedBinaryTreeToInOrderStr, bool initEmpty)
        {
            //Arrange
            BinaryTree<int> actualBinaryTree;

            if (!initEmpty)
                actualBinaryTree = InitialIntBinaryTree();
            else
                actualBinaryTree = new BinaryTree<int>();

            string actualBinaryTreeToInOrderStr = string.Empty;

            //Act
            foreach (var item in actualBinaryTree.InOrder())
            {
                actualBinaryTreeToInOrderStr += item + " ";
            }

            //Assert
            Assert.AreEqual(expectedBinaryTreeToInOrderStr, actualBinaryTreeToInOrderStr);
        }

        /// <summary>
        /// Test cases for type <see cref="BinaryTree{T}"/>
        /// </summary>
        /// <param name="expectedHashCode">Expected square HashCode</param>
        [TestCase(15.0)]
        public void GivenGetHashCodeThenOutIsGetHashCode(double expectedHashCode)
        {
            //Arrange
            BinaryTree<int> actualBinaryTree = InitialIntBinaryTree();

            //Act
            double actualHashCode = actualBinaryTree.GetHashCode();

            //Assert
            Assert.AreEqual(expectedHashCode, actualHashCode);
        }
    }
}
