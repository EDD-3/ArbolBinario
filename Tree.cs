﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbolBinario
{
    class Tree
    {
        public int NodeCount { get; private set; }

        private Node _root;
        public bool Flag { private get; set; }
        private List<int> preOrder = new List<int>();
        private List<int> postOrder = new List<int>();
        private List<int> inOrder = new List<int>();
        public Tree()
        {
            _root = null;
            Flag = false;
            NodeCount = 0;
        }

        public Node getRoot => _root;
        public int height => (_root is null) ? 0 : _root.Height;
        public int size => NodeCount;
        public string searchTree(int ValueToSearch) => searchTree(_root, ValueToSearch);
        private string searchTree(Node n,int valueToSearch)
        {
            if (n is null)
                return "Elemento no encontrado";

            else if (n.Value == valueToSearch)
            {
                return n.Value.ToString();
            }
            else if (valueToSearch > n.Value)
            {
               return n.Value.ToString() +"->"+ searchTree(n.Right,valueToSearch);
            }
            else if (valueToSearch < n.Value)
            {
               return n.Value.ToString() +"<-"+ searchTree(n.Left, valueToSearch);
            }
    
                return "EL bromas estuvo aqui";
            
        }

        /**public Boolean contains(int value) => contains(_root, value);

        public Boolean contains(Node node, int value)
        {
            if (node == null) return false;

            int cmp = value.CompareTo(node.Value);

            if (cmp < 0) return contains(node.Left, value);

            if (cmp > 0) return contains(node.Right, value);

            return true;
        }

        public Boolean insert(int value)
        {
            if (value == null) return false;

            if (!contains(_root, value))
            {
                _root = insert(_root, value);
                NodeCount++;
                return true;
            }

            return false;
        }

        private Node insert(Node node, int value)
        {
            // Base case.
            if (node == null) return new Node (value);

            // Compare current value to the value in the node.
            int cmp = value.CompareTo(node.Value);

            // Insert node in left subtree.
            if (cmp < 0)
            {
                node.Left = insert(node.Left, value);
                ;

                // Insert node in right subtree.
            }
            else
            {
                node.Right = insert(node.Right, value);
            }

            // Update balance factor and height values.
            update(node);

            // Re-balance tree.
            return balance(node);
        }

        private void update(Node node)
        {
            int leftNodeHeight = (node.Left == null) ? -1 : node.Left.Height;
            int rightNodeHeight = (node.Right == null) ? -1 : node.Right.Height;

            // Update this node's height.
            node.Height = 1 + Math.Max(leftNodeHeight, rightNodeHeight);

            // Update balance factor.
            node.Bf = rightNodeHeight - leftNodeHeight;
        }

        // Re-balance a node if its balance factor is +2 or -2.
        private Node balance(Node node)
        {

            // Left heavy subtree.
            if (node.Bf == -2)
            {

                // Left-Left case.
                if (node.Left.Bf <= 0)
                {
                    return leftLeftCase(node);

                    // Left-Right case.
                }
                else
                {
                    return leftRightCase(node);
                }

                // Right heavy subtree needs balancing.
            }
            else if (node.Bf == +2)
            {

                // Right-Right case.
                if (node.Right.Bf >= 0)
                {
                    return rightRightCase(node);

                    // Right-Left case.
                }
                else
                {
                    return rightLeftCase(node);
                }
            }

            // Node either has a balance factor of 0, +1 or -1 which is fine.
            return node;
        }

        private Node leftLeftCase(Node node)
        {
            return rightRotation(node);
        }

        private Node leftRightCase(Node node)
        {
            node.Left = leftRotation(node.Left);
            return leftLeftCase(node);
        }

        private Node rightRightCase(Node node)
        {
            return leftRotation(node);
        }

        private Node rightLeftCase(Node node)
        {
            node.Right = rightRotation(node.Right);
            return rightRightCase(node);
        }

        private Node leftRotation(Node node)
        {
            Node newParent = node.Right;
            node.Right = newParent.Left;
            newParent.Left = node;
            update(node);
            update(newParent);
            return newParent;
        }

        private Node rightRotation(Node node)
        {
            Node newParent = node.Left;
            node.Left = newParent.Right;
            newParent.Right = node;
            update(node);
            update(newParent);
            return newParent;
        }
        **/
        /**public int obtainFe(Node x)
        {
            if (x == null)
                return -1;
            else
                return x.Fe;
        }

        public Node leftRotation(Node c)
        {
            Node auxiliary = c.Left;
            c.Left = auxiliary.Right;
            auxiliary.Right = c;
            c.Fe = Math.Max(obtainFe(c.Left), obtainFe(c.Right)) + 1;
            auxiliary.Fe = Math.Max(obtainFe(auxiliary.Left), obtainFe(auxiliary.Right)) + 1;
            return auxiliary;
        }

        public Node rightRotation(Node c)
        {
            Node auxiliary = c.Right;
            c.Right = auxiliary.Left;
            auxiliary.Left = c;
            c.Fe = Math.Max(obtainFe(c.Left), obtainFe(c.Right)) + 1;
            auxiliary.Fe = Math.Max(obtainFe(auxiliary.Left), obtainFe(auxiliary.Right)) + 1;
            return auxiliary;
        }

        public Node doubleRightRotation(Node c)
        {
            Node temporal;
            c.Left = rightRotation(c.Left);
            temporal = leftRotation(c);
            return temporal;
        }

        public Node doubleLeftRotation(Node c)
        {
            Node temporal;
            c.Right = leftRotation(c.Right);
            temporal = rightRotation(c);
            return temporal;
        }

        public Node insertAVL(Node n, Node subAr)
        {
            Node newFather = subAr;

            if (n.Value < subAr.Value)
            {
                if (subAr.Left == null)
                {
                    subAr.Left = n;
                }
                else
                {
                    subAr.Left = insertAVL(n, subAr.Left);
                    if ((obtainFe(subAr.Left) - obtainFe(subAr.Right)) == 2)
                    {
                        if (n.Value < subAr.Left.Value)
                        {
                            newFather = leftRotation(subAr);
                        }
                        else
                        {
                            newFather = doubleLeftRotation(subAr);
                        }
                    }
                }

            }
            else if (n.Value > subAr.Value)
            {
                if (subAr.Right == null)
                {
                    subAr.Right = n;
                }
                else
                {
                    subAr.Right = insertAVL(n, subAr.Right);
                    if ((obtainFe(subAr.Right) - obtainFe(subAr.Left)) == 2)
                    {
                        if (n.Value > subAr.Right.Value)
                        {
                            newFather = rightRotation(subAr);
                        }
                        else
                        {
                            newFather = doubleRightRotation(subAr);
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Nodo duplicado");
            }

            if ((subAr.Left==null) && (subAr.Right != null))
            {
                subAr.Fe = subAr.Right.Fe + 1;
            }
            else if ((subAr.Right == null) && (subAr.Left != null))
            {
                subAr.Fe = subAr.Left.Fe + 1;
            }
            else
            {
                subAr.Fe = Math.Max(obtainFe(subAr.Left), obtainFe(subAr.Right)) + 1;
            }
            return newFather;
        }

        public void insertAVL(int d)
        {
            Node n = new Node(d);

            if (_root == null)
            {
                _root = n;
            }
            else
            {
                _root = insertAVL(n, _root);
            }
        } **/

        public List<int> preOrden()
        {
            preOrden(_root);
            return preOrder;
        }

        private void preOrden(Node n)
        {
            if (!Flag)
            {
                if (n != null)
                {
                    preOrder.Add(n.Value);
                    preOrden(n.Left);
                    preOrden(n.Right);
                }
            }
            else
            {
                if (n != null)
                {
                    preOrder.Add(n.Value);
                    preOrden(n.Right);
                    preOrden(n.Left);

                }
            }
        }

        
        public List<int> postOrden()
        {
            postOrden(_root);
            return postOrder;
        }

        private void postOrden(Node n)
        {
            if (!Flag)
            {
                if (n != null)
                {
                    postOrden(n.Left);
                    postOrden(n.Right);
                    postOrder.Add(n.Value);

                }
            }
            else
            {
                if (n != null)
                {
                    postOrden(n.Right);
                    postOrden(n.Left);
                    postOrder.Add(n.Value);

                }
            }

        }

        public List<int> inOrden()
        {
            inOrden(_root);
            return inOrder;
        }

        private void inOrden(Node n)
        {
            if (!Flag)
            {
                if (n != null)
                {
                    inOrden(n.Left);
                    inOrder.Add(n.Value);
                    inOrden(n.Right);

                }
            }
            else
            {
                if (n != null)
                {
                    inOrden(n.Right);
                    inOrder.Add(n.Value);
                    inOrden(n.Left);

                }
            }

        }
        public void Insert(int data)
        {
            // 1. If the tree is empty, return a new, single node 
            if (_root is null)
            {
                _root = new Node(data);
                NodeCount = 1;
                return;
            }
            // 2. Otherwise, recur down the tree 
            InsertRec(_root, new Node(data));
        }
        private void InsertRec(Node root, Node newNode)
        {
            

            if (root is null)
            {
                root = newNode;
            }

            if (root.Value == newNode.Value)
            
                root.Value = newNode.Value;
            
            else
            {
                if (newNode.Value < root.Value)
                {
                    if (root.Left is null)
                    {
                        root.Left = newNode;
                        NodeCount++;
                    }

                    else
                        InsertRec(root.Left, newNode);

                }
                else
                {
                    if (root.Right is null)
                    {
                        root.Right = newNode;
                        NodeCount++;
                    }
                        
                    else
                        InsertRec(root.Right, newNode);
                } 
            }

             


        }

        private void DisplayTree(Node root)
        {
            if (root is null) return;

            DisplayTree(root.Left);
            System.Console.Write(root.Value + " ");
            DisplayTree(root.Right);
        }
        public void DisplayTree()
        {
            DisplayTree(_root);
        }
    }
}
