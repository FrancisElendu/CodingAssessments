using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssessments
{
    public class TreeNode
    {
        //public int Value;
        //public TreeNode Left;
        //public TreeNode Right;

        //public TreeNode(int value)
        //{
        //    Value = value;
        //    Left = null;
        //    Right = null;
        //}

        public int Value { get; set; }
        public List<TreeNode> Children { get; set; }

        public TreeNode(int value)
        {
            Value = value;
            Children = new List<TreeNode>();
        }

        public void AddChild(TreeNode child)
        {
            Children.Add(child);
        }
    }
}
