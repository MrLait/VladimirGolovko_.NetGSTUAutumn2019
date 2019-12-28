using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BinaryTreeLib.Core
{
    [Serializable]
    public class BinaryTree<T>
        where T : IComparable
    {
        public Node<T> Root { get; set; }
        public int Count { get; set; }

        public BinaryTree() { }

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

        public Node<T> FindNode(T data, Node<T> node = null)
        {
            node = node ?? Root;
            return Root.FindNode(data, node);
        }

        public List<T> PreOrder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return PreOrder(Root);
        }

        public List<T> PostOrder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return PostOrder(Root);
        }

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
