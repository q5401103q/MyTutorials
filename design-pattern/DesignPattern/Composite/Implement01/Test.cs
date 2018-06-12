using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Composite.Implement01
{
    public class Test
    {
        public void TestComposite()
        {
            Tree tree = new Tree("Node0");

            TreeNode node1 = new TreeNode("Node1");
            TreeNode node2 = new TreeNode("Node2");
            TreeNode node3 = new TreeNode("Node3");

            node1.Parent = tree.Root;
            node2.Parent = tree.Root;

            node1.Add(node3);
            node3.Parent = node1;

            tree.Root.Add(node1);
            tree.Root.Add(node2);

            IEnumerable<TreeNode> childrens = tree.Root.GetChildrens();
            foreach (TreeNode node in childrens)
            {
                Console.Out.WriteLine(node.ToString());
            }
        }
    }
}
