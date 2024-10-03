using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssessments
{
    public class TreeNode2
    {
        public int Value { get; set; }
        public List<TreeNode2> Children { get; set; }

        public TreeNode2(int value)
        {
            Value = value;
            Children = new List<TreeNode2>();
        }

        public void AddChild(TreeNode2 child)
        {
            Children.Add(child);
        }
    }
}
