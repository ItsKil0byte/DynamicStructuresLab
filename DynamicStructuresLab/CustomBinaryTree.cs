using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab
{
    public class CustomBinaryTree<T> where T : IComparable<T>
    {
        public BNode<T>? Root { get; set; }
       

        public void Insert(T value)
        {
            Root = InsertRecursive(Root, value);
        }

        private BNode<T> InsertRecursive(BNode<T> node, T value)
        {
            if (node == null)
            {
                return new BNode<T> (value);
            }

            if (value.CompareTo(node.Data) < 0)
            {
                node.LeftNode = InsertRecursive(node.LeftNode, value);
            }
            else if (value.CompareTo(node.Data) > 0)
            {
                node.RightNode = InsertRecursive(node.RightNode, value);
            }

            return node;
        }

        public bool Search(T value)
        {
            return SearchRecursive(Root, value) != null;
        }

        private BNode<T> SearchRecursive(BNode<T> node, T value)
        {
            if (node == null || node.Data.CompareTo(value) == 0)
            {
                return node;
            }

            if (value.CompareTo(node.Data) < 0)
            {
                return SearchRecursive(node.LeftNode, value);
            }
            else
            {
                return SearchRecursive(node.RightNode, value);
            }
        }

        public void InOrderTraversal()
        {
            InOrderRecursive(Root);
            Console.WriteLine();
        }

        private void InOrderRecursive(BNode<T> node)
        {
            if (node != null)
            {
                InOrderRecursive(node.LeftNode);
                Console.Write(node.Data + " ");
                InOrderRecursive(node.RightNode);
            }
        }

        public void PrintTree()
        {
            PrintTreeRecursive(Root, "", true);
        }

        private void PrintTreeRecursive(BNode<T> node, string indent, bool isRight)
        {
            if (node != null)
            {
                
                PrintTreeRecursive(node.RightNode, indent + (isRight ? "     " : "    "), false);

                Console.WriteLine(indent + (isRight ? "└── " : "┌── ") + node.Data);


                PrintTreeRecursive(node.LeftNode, indent + (isRight ? "      " : "    "), true);
            }
        }
        public int GetDepth()
        {
            return GetDepthRecursive(Root);
        }
        private int GetDepthRecursive(BNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            
            int leftDepth = GetDepthRecursive(node.LeftNode);
            int rightDepth = GetDepthRecursive(node.RightNode);

            
            return Math.Max(leftDepth, rightDepth) + 1;
        }
    }
}
