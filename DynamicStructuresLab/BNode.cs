using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamicStructuresLab
{
    public class BNode<T>
    {
        public BNode<T>? LeftNode { get; set; }
        public BNode<T>? RightNode { get; set; }
        public T? Data { get; set; }
    }
}
