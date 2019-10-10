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
                tree.Insert(rnd.Next(0, 2000));
            }

            //tree.Flag = true;


            Console.WriteLine("Nodos en preorden");
            foreach (int nodo in tree.preOrden())
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
            }

            Console.WriteLine("\n");

            MessageBox.Show(tree.NodeCount.ToString());

            Console.WriteLine("Ingresa numero");
            int find = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n" + tree.searchTree(find));
            Console.ReadKey();

            // tree.DisplayTree();
 

        }
    }
}
