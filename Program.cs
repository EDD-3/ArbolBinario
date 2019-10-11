using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbolBinario
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Tree tree = new Tree();
        

            for ( int i= 0; i <= 1000 ; i++)
            {
                tree.Insert(rnd.Next(0, 7));
            }
             
            /**
            Node test = tree.createRightVine(tree._root);
            int count = tree.getNodeCount(test);
            tree.Insert(tree.balanceVine(test, count).Value);
            tree.print2D(tree._root);


            Console.WriteLine("Nodos en preorden");
            foreach (int nodo in tree.preOrden())
            {
                Console.Write(nodo + " ");
            }
            Console.ReadKey();
            **/

            //tree.Flag = true;

            /**
            
            Console.WriteLine("Nodos en preorden");
            foreach (int nodo in tree.postOrden())
            {
                Console.Write(nodo + " ");
            }
            
            Console.WriteLine("\nNodos en postorden");
            foreach (int nodo in tree.postOrden())
            {
                Console.Write(nodo + " ");
            }

            Console.WriteLine("\nNodos en inorden");
            foreach (int nodo in tree.inOrden())
            {
                Console.Write(nodo + " ");
            }**/


            Console.WriteLine("\n");
            

            //MessageBox.Show(tree.NodeCount.ToString());

            tree._root = tree.buildTree(tree._root);

            /**
            Console.WriteLine("Nodos en preorden");
            foreach (int nodo in tree.preOrden())
            {
                Console.Write(nodo + " ");
            }**/



            //tree.treeToVine(tree.getRoot);
            //tree.vineToTree(tree.getRoot, tree.size);

            try
            {
                Console.WriteLine("Ingresa numero");
                int find = Math.Abs(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("\n" + tree.searchTree(find));

                Console.WriteLine("\n");
                tree.print2D(tree._root);
         

                Console.WriteLine("\n");
                Console.WriteLine("Nodos en preorden");

                foreach (int nodo in tree.preOrden())
                {
                    Console.Write(nodo + " ");
                }
                Console.ReadKey();

            } catch (FormatException c)
            {
                Console.WriteLine(c);
                Console.ReadKey();

            }



        }
    }
}
