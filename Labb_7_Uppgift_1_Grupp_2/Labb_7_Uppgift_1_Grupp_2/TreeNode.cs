using System;
using System.Collections.Generic;
using System.Text;

namespace Labb_7_Uppgift_1_Grupp_2
{
    internal class TreeNode
    {
        public string Id { get; private set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public TreeNode? FirstChild { get; set; }
        public TreeNode? NextSibling { get; set; }

        public TreeNode(string type, string name) 
        {
            Id = Guid.NewGuid().ToString();
            Type = type;
            Name = name;
        }

        public override string ToString() 
        {
            return $"{Type}: {Name}";
        }
    }
}
