using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Composite.Implement01
{
    public class TreeNode
    {
        private string _name;
        private TreeNode _parent;
        private List<TreeNode> _childrens = new List<TreeNode>();

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public TreeNode Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public TreeNode(string name)
        {
            this._name = name;
        }

        public void Add(TreeNode node)
        {
            _childrens.Add(node);
        }

        public void Remove(TreeNode node)
        {
            _childrens.Remove(node);
        }

        public IEnumerable<TreeNode> GetChildrens()
        {
            return _childrens.AsEnumerable<TreeNode>();
        }

        public override string ToString()
        {
            return string.Format("name is {0}, parent is {1}", _name, _parent == null ? "null" : _parent.Name);
        }
    }
}
