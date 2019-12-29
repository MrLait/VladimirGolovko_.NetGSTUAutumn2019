using BinaryTreeLib.Core;
using NUnit.Framework;

namespace BinaryTreeLibTests.CoreTests
{
    /// <summary>
    /// NodeTests type test and related classes with it.
    /// </summary>
    [TestFixture()]
    public class NodeTests
    {
        /// <summary>
        /// Testing <see cref="Node{T}.Add(T)"/> where T is Int32.
        /// </summary>
        /// <param name="actualData">The data that is stored in the node.</param>
        /// <param name="actualLeft">Left node.</param>
        /// <param name="actualRight">Right node.</param>
        /// <param name="expectedData">The data that is stored in the node.</param>
        /// <param name="expectedLeft">Left node.</param>
        /// <param name="expectedRight">Right node.</param>
        [TestCase(5, 3, 1, 5, 3, 1)]
        [TestCase(8, 3, 1, 8, 3, 1)]
        public void GivenAddWhenTIsIntThenOutIsIntNode(int actualData, int actualLeft, int actualRight,
            int expectedData, int expectedLeft, int expectedRight)
        {
            //Arrange
            Node<int> actualNode = new Node<int>(
                                    actualData,
                new Node<int>(actualLeft), new Node<int>(actualRight));

            Node<int> expectedNode = new Node<int>(expectedData);

            //Act
            expectedNode.Add(expectedLeft);
            expectedNode.Add(expectedRight);

            //Assert
            Assert.AreEqual(expectedNode, actualNode);
        }

        /// <summary>
        /// Testing <see cref="Node{T}.Add(T)"/> where T is String.
        /// </summary>
        /// <param name="actualData">The data that is stored in the node.</param>
        /// <param name="actualLeft">Left node.</param>
        /// <param name="actualRight">Right node.</param>
        /// <param name="expectedData">The data that is stored in the node.</param>
        /// <param name="expectedLeft">Left node.</param>
        /// <param name="expectedRight">Right node.</param>
        [TestCase("c", "b", "a", "c", "b", "a")]
        [TestCase("c", "b", "a", "c", "b", "a")]
        public void GivenAddWhenTSingThenOutIsStringNode(string actualData, string actualLeft, string actualRight,
    string expectedData, string expectedLeft, string expectedRight)
        {
            //Arrange
            Node<string> actualNode = new Node<string>(
                                    actualData,
                new Node<string>(actualLeft), new Node<string>(actualRight));

            Node<string> expectedNode = new Node<string>(expectedData);

            //Act
            expectedNode.Add(expectedLeft);
            expectedNode.Add(expectedRight);

            //Assert
            Assert.AreEqual(expectedNode, actualNode);
        }

        /// <summary>
        /// Testing <see cref="Node{T}.FindNode(T, Node{T})"/>
        /// </summary>
        /// <param name="actualFoundNode">Object to find.</param>
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(-1)]
        [TestCase(0)]
        public void GivenFindNodeWhenArgumentIsIntThenOutIsNull(int actualFoundNode)
        {
            //Arrange
            //Arrange
            Node<int> actualNode = new Node<int>(
                                    5,
                new Node<int>(3), new Node<int>(6));

            //Assert
            Assert.AreEqual(null, actualNode.FindNode(actualFoundNode));
        }

        /// <summary>
        /// Testing <see cref="Node{T}.BalanceFactor(Node{T})"/> where T is Int32.
        /// </summary>
        /// <param name="actualData">The data that is stored in the node.</param>
        /// <param name="actualRight">Right node.</param>
        /// <param name="actualNextRight">Right node.</param>
        /// <param name="expectedData">The data that is stored in the node.</param>
        /// <param name="expectedLeft">Left node.</param>
        /// <param name="expectedRight">Right node.</param>
        [TestCase(1, 2, 3, 2, 1, 3)]
        [TestCase(1, 5, 7, 5, 1, 7)]
        public void GivenBalanceRRWhenTIsIntThenOutIsIntNode(int actualData, int actualRight, int actualNextRight,
            int expectedData, int expectedLeft, int expectedRight)
        {
            //Arrange
            Node<int> actualNotBalancedNode =
                                    new Node<int>(
                                    actualData,
                            null, new Node<int>(
                                                actualRight,
                                            null, new Node<int>(actualNextRight)));

            Node<int> expectedBalancedNode = new Node<int>(expectedData);

            //Act
            var actualBalancedNode = actualNotBalancedNode.Balance(actualNotBalancedNode);

            expectedBalancedNode.Add(expectedLeft);
            expectedBalancedNode.Add(expectedRight);

            //Assert
            Assert.AreEqual(expectedBalancedNode, actualBalancedNode);
        }

        /// <summary>
        /// Testing <see cref="Node{T}.BalanceFactor(Node{T})"/> where T is Int32.
        /// </summary>
        /// <param name="actualData">The data that is stored in the node.</param>
        /// <param name="actualLeft">Left node.</param>
        /// <param name="actualNextLeft">Right node.</param>
        /// <param name="expectedData">The data that is stored in the node.</param>
        /// <param name="expectedLeft">Left node.</param>
        /// <param name="expectedRight">Right node.</param>
        [TestCase(7, 5, 1, 5, 1, 7)]
        [TestCase(10, 7, 1, 7, 1, 10)]
        public void GivenBalanceLLWhenTIsIntThenOutIsIntNode(int actualData, int actualLeft, int actualNextLeft,
    int expectedData, int expectedLeft, int expectedRight)
        {
            //Arrange
            Node<int> actualNotBalancedNode =
                                new Node<int>(
                                    actualData,
                      new Node<int>(
                          actualLeft,
                new Node<int>(
                    actualNextLeft),
                                            null), null);

            Node<int> expectedBalancedNode = new Node<int>(expectedData);

            //Act
            var actualBalancedNode = actualNotBalancedNode.Balance(actualNotBalancedNode);

            expectedBalancedNode.Add(expectedLeft);
            expectedBalancedNode.Add(expectedRight);

            //Assert
            Assert.AreEqual(expectedBalancedNode, actualBalancedNode);
        }

        /// <summary>
        /// Testing <see cref="Node{T}.BalanceFactor(Node{T})"/> where T is Int32.
        /// </summary>
        /// <param name="actualData">The data that is stored in the node.</param>
        /// <param name="actualLeft">Left node.</param>
        /// <param name="actualNextRight">Right node.</param>
        /// <param name="expectedData">The data that is stored in the node.</param>
        /// <param name="expectedLeft">Left node.</param>
        /// <param name="expectedRight">Right node.</param>
        [TestCase(7, 1, 5, 5, 1, 7)]
        [TestCase(10, 1, 7, 7, 1, 10)]
        public void GivenBalanceLRWhenTIsIntThenOutIsIntNode(int actualData, int actualLeft, int actualNextRight,
            int expectedData, int expectedLeft, int expectedRight)
        {
            //Arrange
            Node<int> actualNotBalancedNode =
                                new Node<int>(
                                    actualData,
                      new Node<int>(
                          actualLeft,
                     null, new Node<int>(
                                actualNextRight)), null);

            Node<int> expectedBalancedNode = new Node<int>(expectedData);

            //Act
            var actualBalancedNode = actualNotBalancedNode.Balance(actualNotBalancedNode);

            expectedBalancedNode.Add(expectedLeft);
            expectedBalancedNode.Add(expectedRight);

            //Assert
            Assert.AreEqual(expectedBalancedNode, actualBalancedNode);
        }

        /// <summary>
        /// Testing <see cref="Node{T}.BalanceFactor(Node{T})"/> where T is Int32.
        /// </summary>
        /// <param name="actualData">The data that is stored in the node.</param>
        /// <param name="actualRight">Right node.</param>
        /// <param name="actualNextLeft">Lefth node.</param>
        /// <param name="expectedData">The data that is stored in the node.</param>
        /// <param name="expectedLeft">Left node.</param>
        /// <param name="expectedRight">Right node.</param>
        [TestCase(1, 7, 5, 5, 1, 7)]
        [TestCase(1, 10, 7, 7, 1, 10)]
        public void GivenBalanceRLWhenTIsIntThenOutIsIntNode(int actualData, int actualRight, int actualNextLeft,
    int expectedData, int expectedLeft, int expectedRight)
        {
            //Arrange
            Node<int> actualNotBalancedNode =
                                new Node<int>(
                                    actualData,
                            null, new Node<int>(
                                                actualRight,
                                        new Node<int>(
                                            actualNextLeft), null));

            Node<int> expectedBalancedNode = new Node<int>(expectedData);

            //Act
            var actualBalancedNode = actualNotBalancedNode.Balance(actualNotBalancedNode);

            expectedBalancedNode.Add(expectedLeft);
            expectedBalancedNode.Add(expectedRight);

            //Assert
            Assert.AreEqual(expectedBalancedNode, actualBalancedNode);
        }
    }
}
