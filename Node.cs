﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    class Node
    {
        
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int  Bf { get; set; }

        public int Height { get; set; }
        public Node()
        {

        }
        public Node(int value)
        {
            this.Value = value;

        }

        public String getText()
        {
            return Value.ToString();
        }

        /** public static String getTreeDisplay(Node root)
        {

            StringBuilder sb = new StringBuilder();
            List<List<String>> lines = new List<List<String>>();
            List<Node> level = new List<Node>();
            List<Node> next = new List<Node>();

            level.Add(root);
            int nn = 1;
            int widest = 0;

            while (nn != 0)
            {
                nn = 0;
                List<String> line = new List<String>();
                foreach (Node n in level)
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

                        next.Add(n.Left);
                        next.Add(n.Right);

                        if (n.Left != null) nn++;
                        if (n.Right != null) nn++;
                    }
                }

                if (widest % 2 == 1) widest++;

                lines.Add(line);

                List<Node> tmp = level;
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
        }**/
    }
}

