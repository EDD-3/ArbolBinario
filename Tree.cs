using System;
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
        readonly int COUNT = 10;
        public Node _root { get; set; }
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

        public void treeToVine(Node root)
        {
            Node temp;
            Node tail = root;
            Node rest = tail.Right;
            
            while (rest != null)
            {
                if (rest.Left == null)
                {
                    tail = rest;
                    rest = rest.Right;
                }
                else
                {
                    temp = rest.Left;
                    rest.Left = temp.Right;
                    temp.Right = rest;
                    rest = temp;
                    tail.Right = temp;
                }
            }
        }

        public void vineToTree(Node root, double size)
        {
            double leaves = size + 1 - Math.Pow(2,Math.Log(size+1 , 2));
            compress(root, Convert.ToInt32(leaves));
            size = size - leaves;

            while (size > 1)
            {
                compress(root, Convert.ToInt32(size / 2));
                size = size / 2;
            }

        }

        public void compress (Node root, int count)
        {
            Node scanner;
            Node child; 
            scanner = root;

            for (int i = 0; i < count; i++)
            {

                if (scanner.Right is null || scanner.Left is null)
                {
                    continue;
                }

                child = scanner.Right;
                scanner.Right = child.Right;
                scanner = scanner.Right;
                child.Right = scanner.Left;
                scanner.Left = child;
            }
        }

        private void storeBSTNodes(Node root, List<Node> nodes)
        {
            if (root == null)
            {
                return;
            }
            
                storeBSTNodes(root.Left, nodes);
                nodes.Add(root);
                storeBSTNodes(root.Right, nodes);
         
        }

        private Node buildTreeUtil(List<Node> nodes, int start, int end)
        {
            if(start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            Node node = nodes[mid];

            node.Left = buildTreeUtil(nodes, start, mid - 1);
            node.Right = buildTreeUtil(nodes, mid + 1, end);

            return node;
        }

        public Node buildTree(Node root)
        {
            List<Node> nodes = new List<Node>();
            storeBSTNodes(root, nodes);

            int n = nodes.Count;
            return buildTreeUtil(nodes, 0, n - 1);

        }

        private void print2DUtil(Node root, int space)
        {
            // Base case  
            if (root == null)
                return;

            // Increase distance between levels  
            space += COUNT;

            // Process right child first  
            print2DUtil(root.Right, space);

            // Print current node after space  
            // count  
            Console.Write("\n");
            for (int i = COUNT; i < space; i++)
                Console.Write(" ");
            Console.Write(root.Value + "\n");

            // Process left child  
            print2DUtil(root.Left, space);
        }

        // Wrapper over print2DUtil()  
        public void print2D(Node root)
        {
            // Pass initial space count as 0  
            print2DUtil(root, 0);
        }

    }
}
