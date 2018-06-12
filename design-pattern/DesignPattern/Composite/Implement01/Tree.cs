using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Composite.Implement01
{
    public class Tree
    {
        private TreeNode root;

        public TreeNode Root
        {
            get { return root; }
            set { root = value; }
        }

        public Tree(string name)
        {
            root = new TreeNode(name);
        }
    }
}
