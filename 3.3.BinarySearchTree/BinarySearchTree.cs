using System;

namespace BST
{
    class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }
    }

    class BinarySearchTree<T> where T : IComparable
    {
        private Node<T> root;

        private BinarySearchTree<T> leftTree;

        private BinarySearchTree<T> rightTree;

        public BinarySearchTree(params T[] items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public BinarySearchTree(T rootValue, BinarySearchTree<T> leftTree = null, BinarySearchTree<T> rightTree = null)
        {
            this.root = new Node<T>() { Value = rootValue };
            this.leftTree = leftTree;
            this.rightTree = rightTree;
        }

        public BinarySearchTree<T> Add(T value)
        {
            if (root == null)
            {
                root = new Node<T>();
                root.Value = value;
                return this;
            }
            if (root.Value.CompareTo(value) > 0)
            {
                if (leftTree == null)
                {
                    leftTree = new BinarySearchTree<T>();
                    root.Left = leftTree.root;
                    leftTree.Add(value);
                }
                else
                {
                    leftTree.Add(value);
                }
            }
            else
            {
                if (rightTree == null)
                {
                    rightTree = new BinarySearchTree<T>();
                    root.Right = rightTree.root;
                    rightTree.Add(value);
                }
                else
                {
                    rightTree.Add(value);
                }
            }
            return this;
        }

        public bool Contain(T item)
        {
            if (root == null)
                return false;

            bool result = false;

            if (root.Value.CompareTo(item) == 0)
            {
                result = true;
            }
            else
            {
                result = this.leftTree != null ? leftTree.Contain(item) : false;
                if (result == true)
                {
                    return result;
                }
                else
                {
                    result = this.rightTree != null ? rightTree.Contain(item) : false;
                }
            }

            return result;
        }

        public T Max()
        {
            BinarySearchTree<T> temp = this;
            while (temp.rightTree != null)
            {
                temp = temp.rightTree;
            }
            return temp.root.Value;
        }

        public T Min()
        {
            BinarySearchTree<T> temp = this;
            while (temp.leftTree != null)
            {
                temp = temp.leftTree;
            }
            return temp.root.Value;
        }

    }

    class BinarySearchTree
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree<int>(15,
                        new BinarySearchTree<int>(6,
                            new BinarySearchTree<int>(3,
                                new BinarySearchTree<int>(2),
                                new BinarySearchTree<int>(4)),
                            new BinarySearchTree<int>(7,
                            null,
                            new BinarySearchTree<int>(13,
                                new BinarySearchTree<int>(9)))),
                        new BinarySearchTree<int>(18,
                            new BinarySearchTree<int>(17),
                            new BinarySearchTree<int>(20)));

        }
    }
}
