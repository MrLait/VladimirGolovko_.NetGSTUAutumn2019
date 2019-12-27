using System;

namespace BinaryTreeLib.Core
{
    public class Node<T>
        where T : IComparable
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

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

        public int CompareTo(object obj)
        {
            if (obj is Node<T> item)
            {
                return Data.CompareTo(item);
            }
            else
            {
                throw new ArgumentException("Types do not match");
            }
        }

        public int CompareTo(Node<T> other)
        {
            return Data.CompareTo(other.Data);
        }

        public int BalanceFactor(Node<T> node)
        {
            return (Height(node.Right) - Height(node.Left));
        }

        public int Height(Node<T> node)
        {
            return ((node != null)
                ? (1 + Math.Max(Height(node.Left), Height(node.Right))) : 0);
        }

        public Node<T> Balance(Node<T> p)
        {
            if (BalanceFactor(p) == 2)
            {
                if (BalanceFactor(p.Right) < 0)
                    p.Right = RotateRight(p.Right);
                return RotateLeft(p);
            }

            if (BalanceFactor(p) == -2)
            {
                if (BalanceFactor(p.Left) > 0)
                    p.Left = RotateLeft(p.Left);
                return RotateRight(p);
            }
            return p;
        }

        public Node<T> RotateRight(Node<T> node)
        {
            var newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;
            return newNode;
        }

        public Node<T> RotateLeft(Node<T> node)
        {
            var newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;
            return newNode;

        }
        public override string ToString() => Data.ToString();
    }
}
