using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib.Models
{
    public class Tree<T>
    {
        public T Value { get; set; }
        public Tree<T> Left { get; set; }
        public Tree<T> Right { get; set; }
    }
}
