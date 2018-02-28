using System;

internal static class T
{
	class TreeNode 
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}

	// TIME COMPLEXIT: O(MAX(m, n))
	// SPACE COMPLEXITY: O(MAX(m, n))

    	static TreeNode MergeTrees(TreeNode t1, TreeNode t2) 
	{
		if(t1 == null && t2 == null) return null;

		var tOneV = t1 != null ? t1.val : 0;
		var tTwoV = t2 != null ? t2.val : 0;

		var mV = tOneV + tTwoV;// 0 is legit value

		var mN = new TreeNode(mV);

		mN.left = MergeTrees(t1 != null ? t1.left : null, t2 != null ? t2.left : null);
		mN.right = MergeTrees(t1 != null ? t1.right : null, t2 != null ? t2.right : null); 

		return mN;
    	}

	// TIME COMPLEXITY: O(MIN(m, n))
	// SPACE COMPLEXITY: None (!)

	static TreeNode MergeTreesBetter(TreeNode t1, TreeNode t2)
	{
		if(t1 == null) return t2;
		if(t2 == null) return t1;

		t1.val = t1.val + t2.val;

		t1.left = MergeTreesBetter(t1.left, t2.left);
		t1.right = MergeTreesBetter(t1.right, t2.right);

		return t1;
	}

	static void Display(TreeNode t)
	{
		if(t == null) return;

		Console.WriteLine(t.val);
		Display(t.left);
		Display(t.right);
	}

	public static void Main()
	{
		var rO = new TreeNode(1)
		{
			left = new TreeNode(3)
			{
				left = new TreeNode(5)
				{
					left = new TreeNode(10)
					{
						left = new TreeNode(20)
					}
				}
			},
			right = new TreeNode(2)
		};

		var rT = new TreeNode(2)
		{
			left = new TreeNode(1)
			{
				right = new TreeNode(4)
			},
			right = new TreeNode(3)
			{
				right = new TreeNode(7)
			}
		};

		Display(rO);
		
		Console.WriteLine("");

		Display(rT);

		var mT = MergeTrees(rO, rT);

		Console.WriteLine("");

		Display(mT);

		var mTB = MergeTreesBetter(rO, rT);

		Console.WriteLine("");

		Display(mTB);
	}
}

