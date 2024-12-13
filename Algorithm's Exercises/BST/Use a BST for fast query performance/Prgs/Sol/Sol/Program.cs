using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol
{
    public class BinaryNode
    {
        public int Value { get; set; }
        public BinaryNode Parent { get; set; }
        public BinaryNode LeftChild { get; set; }
        public BinaryNode RightChild { get; set; }

        public BinaryNode(BinaryNode node)
            : this(node.Value, node.Parent, node.LeftChild, node.RightChild)
        { }
        public BinaryNode(int value)
            : this(value, null, null, null)
        { }

        public BinaryNode(int value, BinaryNode parent)
            : this(value, parent, null, null)
        { }

        public BinaryNode(int value, BinaryNode leftChild, BinaryNode rightChild)
            : this(value, null, leftChild, rightChild)
        { }

        public BinaryNode(int value, BinaryNode parent, BinaryNode leftChild, BinaryNode rightChild)
        {
            Value = value;
            Parent = parent;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public void Set(BinaryNode node)
        {
            Value = node.Value;
            Parent = node.Parent;
            LeftChild = node.LeftChild;
            RightChild = node.RightChild;
        }
        public void Swap(ref BinaryNode node)
        {
            BinaryNode tmpNode = new BinaryNode(this);
            Value = node.Value;
            Parent = node.Parent;
            LeftChild = node.LeftChild;
            RightChild = node.RightChild;
            node = tmpNode;
        }
    }

    public class BST_
    {
        public BinaryNode Root { get; set; }
        public BST_ LeftChild
        {
            get
            {
                return new BST_(Root.LeftChild);
            }
        }
        public BST_ RightChild
        {
            get
            {
                return new BST_(Root.RightChild);
            }
        }

        public BST_()
            : this((BinaryNode)null)
        { }
        public BST_(BST_ newTree)
            : this(newTree.Root)
        { }
        public BST_(BinaryNode root)
        {
            Root = root;
        }

        /// <summary>
        /// Determine wether the element belongs to the BST or not.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Contains(int element)
        {
            SeekElement(element);
            return registerFind;
        }
        /// <summary>
        /// Inserts the element into the BST.
        /// </summary>
        /// <param name="element">The element to be inserted.</param>
        public void Insert(int element)
        {
            SeekElement(element);
            if (!registerFind)
            {
                BinaryNode newNode = new BinaryNode(element, registerNode);
                if (registerNode == null)
                    Root = newNode;
                else
                {
                    if (element < registerNode.Value)
                        registerNode.LeftChild = newNode;
                    else
                        registerNode.RightChild = newNode;
                }
            }
        }
        /// <summary>
        /// Removes the given element from the BST.
        /// </summary>
        /// <param name="element">The element to be removed.</param>
        public void Remove(int element)
        {
            SeekElement(element);
            if (registerFind)
            {
                BinaryNode valueToReplace;
                bool leftChildAbscent = registerNode.LeftChild == null;
                bool rightChildAbscent = registerNode.RightChild == null;
                if (leftChildAbscent && rightChildAbscent)
                    valueToReplace = null;
                else if (!leftChildAbscent && !rightChildAbscent)
                {
                    valueToReplace = NextNode();
                    BST_ tmpBST = new BST_(valueToReplace);
                    tmpBST.Remove(valueToReplace.Value);

                    valueToReplace.RightChild = registerNode.RightChild;
                    valueToReplace.LeftChild = registerNode.LeftChild;
                }
                else if (leftChildAbscent)
                {
                    valueToReplace = registerNode.RightChild;
                    valueToReplace.LeftChild = registerNode.LeftChild;
                }
                else
                {
                    valueToReplace = registerNode.LeftChild;
                    valueToReplace.RightChild = registerNode.RightChild;
                }

                // Replace the node. (removes)
                BinaryNode parent = registerNode.Parent;
                if (parent == null)     //;Root node
                    Root = valueToReplace;
                else
                    if (parent.RightChild == registerNode)
                        parent.RightChild = valueToReplace;
                    else
                        parent.LeftChild = valueToReplace;
            }
        }

        public void InsertNodeAt(BinaryNode newNode, int element)
        {

        }
        public void SetNodeAt(BinaryNode newNode, int element)
        {
            SeekElement(element);
            if (registerFind)
            {
                registerNode.Set(newNode);
                BinaryNode parent = registerNode.Parent;
                newNode.Parent = registerNode.Parent;
                newNode.LeftChild = registerNode.LeftChild;
            }

        }
        public BST_ SubTreeAt(int element)
        {
            SeekElement(element);
            if (!registerFind)
                registerNode = null;

            return new BST_(registerNode);
        }
        public BinaryNode NextNode()
        {
            BinaryNode toReturn = null;
            if (Root.RightChild != null)
                toReturn = RightChild.FirstNode();

            return toReturn;
        }
        public BinaryNode PrevNode()
        {
            BinaryNode toReturn = null;
            if (Root.LeftChild != null)
                toReturn = LeftChild.LastNode();

            return toReturn;
        }
        public BinaryNode FirstNode()
        {
            BinaryNode subRoot = Root;
            while (subRoot.LeftChild != null)
                subRoot = subRoot.LeftChild;

            return subRoot;
        }
        public BinaryNode LastNode()
        {
            BinaryNode subRoot = Root;
            while (subRoot.RightChild != null)
                subRoot = subRoot.RightChild;

            return subRoot;
        }

        #region AUX_TOOLS
        BinaryNode registerNode;
        bool registerFind;

        /// <summary>
        /// Seeks for an element in the BST.
        /// If the element exists set registerFind to true, otherwise to false.
        /// If the element exists set registerNode to point to the element, otherwise to the node that can be a father to the element.
        /// </summary>
        /// <param name="element">The element to seek.</param>
        void SeekElement(int element)
        {
            registerFind = false;
            registerNode = null;
            if (Root != null)
            {
                BinaryNode subRoot = Root;
                int value;
                while (registerNode == null)
                {
                    value = subRoot.Value;
                    if (element < value && subRoot.LeftChild != null)
                        subRoot = subRoot.LeftChild;
                    else if (element > value && subRoot.RightChild != null)
                        subRoot = subRoot.RightChild;
                    else
                    {
                        if (element == value)
                            registerFind = true;
                        registerNode = subRoot;
                    }
                }
            }
        }
        #endregion
    }

    class Program
    {
        static int[] arr;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string []s = Console.ReadLine().Split();

            arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(s[i]);
            BST_ bst = new BST_(BuildBST(0, n));

            n *= 2;
            for (int i = 0; i < n; i++)
            {
                s = Console.ReadLine().Split();
                if (char.Parse(s[0]) == 'E')
                    bst.Remove(int.Parse(s[1]));
                else
                    Console.WriteLine("{0}", bst.Contains(int.Parse(s[1])));
            }
        }

        static BinaryNode BuildBST(int iPos, int n)
        {
            if (n == 1)
                return new BinaryNode(arr[iPos]);
            else
            {
                BinaryNode root = new BinaryNode(arr[(iPos + n) / 2]);
                n--;
                if (n / 2 >= 1)
                {
                    root.LeftChild = BuildBST(iPos, n / 2);
                    root.LeftChild.Parent = root;
                }
                root.RightChild = BuildBST(iPos + 1 + n  / 2, n - n / 2);
                root.RightChild.Parent = root;

                return root;
            }
        }
    }
}
