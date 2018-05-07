using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib.Models
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private Tree<T> _head;

        public BinarySearchTree()
        {
        }

        public void Insert(T item)
        {
            _head = InsertTree(_head);

            Tree<T> InsertTree(Tree<T> currTree)
            {
                if (currTree == null)
                    currTree = new Tree<T> { Value = item };

                else if (item.CompareTo(currTree.Value) < 0)
                    currTree.Left = InsertTree(currTree.Left);

                else if (item.CompareTo(currTree.Value) > 0)
                    currTree.Right = InsertTree(currTree.Right);

                return currTree;
            }

        }

        public void Delete(T item)
        {
        }

        public bool Search(T item)
        {
            return SearchTree(_head);

            bool SearchTree(Tree<T> currTree)
            {
                if (currTree == null)
                    return false;

                else if (item.CompareTo(currTree.Value) < 0)
                    SearchTree(currTree.Left);

                else if (item.CompareTo(currTree.Value) > 0)
                    SearchTree(currTree.Right);

                return true;
            }
        }
    }
}
