using System;
using System.Collections.Generic;
using System.Linq;

namespace LevelOrder_Traversal_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
			Program prog = new Program();
			//TreeNode root = new TreeNode(1);
			//root.left = new TreeNode(2);
			//root.right = new TreeNode(3);
			//root.left.left = new TreeNode(4);
			//root.left.right = new TreeNode(5);
			//root.right.right = new TreeNode(7);
			//var result = p.LevelOrder(root);
			//foreach(var res in result)
			//             Console.WriteLine(string.Join(",", res));

			NArrayTreeNode body = new NArrayTreeNode("<body>");
			NArrayTreeNode div1 = new NArrayTreeNode("<div>");
			NArrayTreeNode div2 = new NArrayTreeNode("<div>");
			NArrayTreeNode h1 = new NArrayTreeNode("<h1>");
			NArrayTreeNode h2 = new NArrayTreeNode("<h2>");
			NArrayTreeNode h3 = new NArrayTreeNode("<h3>");
			NArrayTreeNode a = new NArrayTreeNode("<a>");
			NArrayTreeNode p = new NArrayTreeNode("<p>");
			body.children = new List<NArrayTreeNode>() { div1, h1, div2 };
			div1.children = new List<NArrayTreeNode>() { h2, h3 };
			div2.children = new List<NArrayTreeNode>() { a, p };
			var result = prog.TraverseTree(body);
			foreach(var res in result)
                Console.WriteLine(string.Join(",", res));
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

		List<List<string>> TraverseTree(NArrayTreeNode root)
		{
			List<List<string>> result = new List<List<string>>();
			if (root == null) return result;
			Queue<NArrayTreeNode> q = new Queue<NArrayTreeNode>();
			q.Enqueue(root);
			while (q.Count > 0)
			{
				int length = q.Count;
				List<string> res = new List<string>();
				while (length-- > 0)
				{
					var item = q.Dequeue();
					res.Add(item.val);
					item.children.ForEach(child => q.Enqueue(child));
				}
				result.Add(res);
			}

			return result;
		}
	}

	public class NArrayTreeNode
    {
		public string val;
		public List<NArrayTreeNode> children;
		
		public NArrayTreeNode(string val = "")
        {
			this.val = val;
        }
	}
}
