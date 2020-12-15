using System;
using System.Collections.Generic;

namespace LevelOrder_Traversal_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
		}

		public class TreeNode
		{
			public int val;
			public TreeNode left;
			public TreeNode right;
			public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
			{
				this.val = val;
				this.left = left;
				this.right = right;
			}
		}

		public IList<IList<int>> LevelOrder(TreeNode root)
		{
			var bfsl = new List<IList<int>>();

			if (root == null)
			{
				return bfsl;
			}

			var queue = new Queue<TreeNode>();

			queue.Enqueue(root);

			while (queue.Count != 0)
			{
				var level = new List<int>();
				var size = queue.Count;

				for (var i = 0; i < size; i++)
				{
					var current = queue.Dequeue();
					level.Add(current.val);

					if (current.left != null)
						queue.Enqueue(current.left);

					if (current.right != null)
						queue.Enqueue(current.right);
				}
				bfsl.Add(level);
			}

			return bfsl;
		}
	}
}
