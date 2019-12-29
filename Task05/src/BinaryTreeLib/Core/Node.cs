using System;

namespace BinaryTreeLib.Core
{
    /// <summary>
    /// Binary tree node.
    /// </summary>
    /// <typeparam name="T">The type of elements in the node</typeparam>
    [Serializable]
    public class Node<T>
        where T : IComparable
    {
        private const int LeftBalanceFactor = 2;
        private const int RightBalanceFactor = -2;

        /// <summary>
        /// The data that is stored in the node.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Left node.
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// Right node.
        /// </summary>
        public Node<T> Right { get; set; }

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public Node()
        {
        }

        /// <summary>
        /// Constructor with the data parameter.
        /// </summary>
        /// <param name="data">The data that is stored in the node.</param>
        public Node(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="data">The data that is stored in the node.</param>
        /// <param name="left">The left node.</param>
        /// <param name="right">The right node/</param>
        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Adding a new node to the binary tree.
        /// </summary>
        /// <param name="data">Data to be added to the node.</param>
        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (node.Data.CompareTo(Data) == -1)
            {
                if (Left == null)
                    Left = node;
                else
                    Left.Add(data);

                Left = Balance(Left);
            }
            else
            {
                if (Right == null)
                    Right = node;
                else
                    Right.Add(data);

                Right = Balance(Right);
            }
        }

        /// <summary>
        /// Search for a node by value.
        /// </summary>
        /// <param name="data">Data to be finded in the node.</param>
        /// <param name="node">Found node.</param>
        /// <returns>The node element that was found in the tree.</returns>
        public Node<T> FindNode(T data, Node<T> node = null)
        {
            if (node != null)
            {
                if (data.CompareTo(node.Data) == 0)
                {
                    return node;
                }
            }
            else
            {
                return null;
            }

            if (data.CompareTo(node.Data) == -1)
            {
                if (Left == null)
                    return null;
                else
                    return FindNode(data, node.Left);
            }
            else
            {
                if (Right == null)
                    return null;
                else
                    return FindNode(data, node.Right);
            }
        }

        /// <summary>
        /// Implementation of IComparable interface.
        /// </summary>
        /// <param name="obj">An object to compare with this instance..</param>
        /// <returns>Returns Int32 A value that indicates the relative order of the objects 
        /// being compared.The return value has these meanings: 
        /// Value               Meaning 
        /// Less than zero      This instance precedes obj in the sort order.
        /// Zero                This instance occurs in the same position in the sort order as obj.
        /// Greater than zero   This instance follows obj in the sort order.</returns>
        public int CompareTo(object obj)
        {
            if (obj is Node<T> item)
                return Data.CompareTo(item);
            else
                throw new ArgumentException("Types do not match");
        }

        /// <summary>
        /// The difference in the heights of the right and left subtrees
        /// </summary>
        /// <param name="node">Current node.</param>
        /// <returns>The difference in the heights of the right and left node.</returns>
        public int BalanceFactor(Node<T> node)
        {
            return (Height(node.Right) - Height(node.Left));
        }

        /// <summary>
        /// The height of the node.
        /// </summary>
        /// <param name="node">Current node.</param>
        /// <returns>The height of the current node.</returns>
        public int Height(Node<T> node)
        {
            return ((node != null)
                ? (1 + Math.Max(Height(node.Left), Height(node.Right))) : 0);
        }

        /// <summary>
        /// Balancing nodes.
        /// </summary>
        /// <param name="node">Current node/</param>
        /// <returns>Returns a balanced node.</returns>
        public Node<T> Balance(Node<T> node)
        {
            if (BalanceFactor(node) == LeftBalanceFactor)
            {
                if (BalanceFactor(node.Right) < 0)
                    node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            if (BalanceFactor(node) == RightBalanceFactor)
            {
                if (BalanceFactor(node.Left) > 0)
                    node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            return node;
        }

        /// <summary>
        /// Left turn around node.
        /// </summary>
        /// <param name="node">Current node.</param>
        /// <returns>Returns the new rotated node.</returns>
        public Node<T> RotateLeft(Node<T> node)
        {
            var newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;
            return newNode;
        }

        /// <summary>
        /// Right turn around node.
        /// </summary>
        /// <param name="node">Current node.</param>
        /// <returns>Returns the new rotated node.</returns>
        public Node<T> RotateRight(Node<T> node)
        {
            var newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;
            return newNode;
        }

        /// <summary>
        /// Comparing one node with another.
        /// </summary>
        /// <param name="obj">The compared node.</param>
        /// <returns>True if equal. False if not equal.</returns>
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
                return false;

            Node<T> node = (Node<T>)obj;

            return Data.Equals(node.Data);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hash code.</returns>
        public override int GetHashCode()
        {
            return Data.GetHashCode();
        }

        /// <summary>
        /// Represents class members in string format.
        /// </summary>
        /// <returns>Returns class members in string format.</returns>
        public override string ToString() => Data.ToString();
    }
}
