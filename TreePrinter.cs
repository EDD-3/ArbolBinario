using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    class TreePrinter
    {

        /** Node that can be printed */
        public interface PrintableNode
        {

            // Item left child
            PrintableNode getLeft();

            // Item right child
            PrintableNode getRight();

            // Item text to be printed
            String getText();
        }

        // Print a binary tree.
        public static String getTreeDisplay(PrintableNode root)
        {

            StringBuilder sb = new StringBuilder();
            List<List<String>> lines = new List<List<String>>();
            List<PrintableNode> level = new List<PrintableNode>();
            List<PrintableNode> next = new List<PrintableNode>();

            level.Add(root);
            int nn = 1;
            int widest = 0;

            while (nn != 0)
            {
                nn = 0;
                List<String> line = new List<String>();
                foreach (PrintableNode n in level)
                {
                    if (n == null)
                    {
                        line.Add(null);
                        next.Add(null);
                        next.Add(null);
                    }
                    else
                    {
                        String aa = n.getText();
                        line.Add(aa);
                        if (aa.Length > widest) widest = aa.Length;

                        next.Add(n.getLeft());
                        next.Add(n.getRight());

                        if (n.getLeft() != null) nn++;
                        if (n.getRight() != null) nn++;
                    }
                }

                if (widest % 2 == 1) widest++;

                lines.Add(line);

                List<PrintableNode> tmp = level;
                level = next;
                next = tmp;
                next.Clear();
            }

            int perpiece = lines[lines.Count() - 1].Count() * (widest + 4);
            for (int i = 0; i < lines.Count(); i++)
            {
                List<String> line = lines[i];
                int hpw = (int)Math.Floor(perpiece / 2f) - 1;
                if (i > 0)
                {
                    for (int j = 0; j < line.Count(); j++)
                    {

                        // split node
                        char c = ' ';
                        if (j % 2 == 1)
                        {
                            if (line[j - 1] != null)
                            {
                                c = (line[j] != null) ? '#' : '#';
                            }
                            else
                            {
                                if (j < line.Count() && line[j] != null) c = '#';
                            }
                        }
                        sb.Append(c);

                        // lines and spaces
                        if (line[j] == null)
                        {
                            for (int k = 0; k < perpiece - 1; k++)
                            {
                                sb.Append(' ');
                            }
                        }
                        else
                        {
                            for (int k = 0; k < hpw; k++)
                            {
                                sb.Append(j % 2 == 0 ? " " : "#");
                            }
                            sb.Append(j % 2 == 0 ? "#" : "#");
                            for (int k = 0; k < hpw; k++)
                            {
                                sb.Append(j % 2 == 0 ? "#" : " ");
                            }
                        }
                    }
                    sb.Append('\n');
                }
                for (int j = 0; j < line.Count(); j++)
                {
                    String f = line[j];
                    if (f == null) f = "";
                    int gap1 = (int)Math.Ceiling(perpiece / 2f - f.Length / 2f);
                    int gap2 = (int)Math.Floor(perpiece / 2f - f.Length / 2f);

                    for (int k = 0; k < gap1; k++)
                    {
                        sb.Append(' ');
                    }
                    sb.Append(f);
                    for (int k = 0; k < gap2; k++)
                    {
                        sb.Append(' ');
                    }
                }
                sb.Append('\n');

                perpiece /= 2;
            }
            return sb.ToString();
        }
    }
}
