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
        public int Fe { get; set; }

        public Node()
        {

        }
        public Node(int value)
        {
            this.Value = value;
            this.Fe = 0;

        }
    }
}