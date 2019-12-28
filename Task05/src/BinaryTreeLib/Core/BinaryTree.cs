using System;
using System.Collections.Generic;

namespace BinaryTreeLib.Core
{
    /// <summary>
    /// Generalized type "binary tree".
    /// </summary>
    /// <typeparam name="T">The type of elements in the BinaryTree.</typeparam>
    [Serializable]
    public class BinaryTree<T>
        where T : IComparable
    {
        /// <summary>
        /// The root of the binary tree.
        /// </summary>
        public Node<T> Root { get; set; }

        /// <summary>
        /// Gets the number of elements contained in the BinaryTree
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public BinaryTree() { }

        /// <summary>
        /// Adding a new node to the binary tree. Balancing the tree relative to the root element.
        /// </summary>
        /// <param name="data">Data to be added to the node.</param>
        public void Add(T data)
        {
            if (Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }

            Root.Add(data);
            Count++;
            Root = Root.Balance(Root);
        }

        /// <summary>
        /// Search for a node by value.
        /// </summary>
        /// <param name="data">Data to be finded in the node.</param>
        /// <param name="node">Found node.</param>
        /// <returns>The root element that was found in the tree.</returns>
        public Node<T> FindNode(T data, Node<T> node = null)
        {
            node = node ?? Root;
            return Root.FindNode(data, node);
        }

        /// <summary>
        /// PreOrder - the current node is processed first, then the left and right subtrees;
        /// </summary>
        /// <returns>A System.Collections.Generic.List`1 containing all the elements that were found in the binary tree.</returns>
        public List<T> PreOrder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return PreOrder(Root);
        }

        /// <summary>
        /// PostOrder - first, the left subtree of the current node is processed, then the root, then the right subtree;
        /// </summary>
        /// <returns>A System.Collections.Generic.List`1 containing all the elements that were found in the binary tree.</returns>
        public List<T> PostOrder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return PostOrder(Root);
        }

        /// <summary>
        /// InOrder - first, the left and right subtrees of the current node are processed, then the node itself.
        /// </summary>
        /// <returns>A System.Collections.Generic.List`1 containing all the elements that were found in the binary tree.</returns>
        public List<T> InOrder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return InOrder(Root);
        }

        private List<T> PreOrder(Node<T> node)
        {
            var list = new List<T>();

            if (node != null)
            {
                list.Add(node.Data);

                if (node.Left != null)
                    list.AddRange(PreOrder(node.Left));
                if (node.Right != null)
                    list.AddRange(PreOrder(node.Right));
            }
            return list;
        }

        private List<T> PostOrder(Node<T> node)
        {
            var list = new List<T>();

            if (node != null)
            {
                if (node.Left != null)
                    list.AddRange(PostOrder(node.Left));
                if (node.Right != null)
                    list.AddRange(PostOrder(node.Right));

                list.Add(node.Data);
            }
            return list;
        }

        private List<T> InOrder(Node<T> node)
        {
            var list = new List<T>();

            if (node != null)
            {
                if (node.Left != null)
                    list.AddRange(InOrder(node.Left));

                list.Add(node.Data);

                if (node.Right != null)
                    list.AddRange(InOrder(node.Right));
            }
            return list;
        }
    }
}
