using System;

internal static class Ans
{
    internal static void Main()
    {
        var root = CreateRoot();
        
        Console.WriteLine("PREORDERTRAVERSAL DISCOVERED PATH\n\t" + PreOrderTraversal(root));
        Console.WriteLine();
        Console.WriteLine("POSTORDERTRAVERSAL DISCOVERED PATH\n\t" + PostOrderTraversal(root));
        Console.WriteLine();
        Console.WriteLine("INORDERTRAVERSAL DISCOVERED PATH\n\t" + InOrderTraversal(root));
    }

    internal static System.String InOrderTraversal(Node rootOfSubTree)
    {
        if(rootOfSubTree.Children == null) return rootOfSubTree.ToString();

        var discoveredPaths = new System.String[rootOfSubTree.Children.Length + 1];
        var i = 0;
        
        discoveredPaths[1] = rootOfSubTree.ToString();//Choosing index '1' to keep the root path (in-order)

        foreach(var child in rootOfSubTree.Children)
        {
            if(i == 1) i++;
            discoveredPaths[i++] = InOrderTraversal(child);
        }

        return System.String.Join(", ", discoveredPaths);
    }

    internal static System.String PostOrderTraversal(Node rootOfSubTree)
    {
        if(rootOfSubTree.Children == null) return rootOfSubTree.ToString();

        var discoveredPaths = new System.String[rootOfSubTree.Children.Length + 1];
        var i = 0;

        foreach(var child in rootOfSubTree.Children) discoveredPaths[i++] = PostOrderTraversal(child);
        discoveredPaths[i] = rootOfSubTree.ToString();

        return System.String.Join(", ", discoveredPaths);
    }

    internal static System.String PreOrderTraversal(Node rootOfSubTree)
    {
        if(rootOfSubTree.Children == null) return rootOfSubTree.ToString();

        var discoveredPaths = new System.String[rootOfSubTree.Children.Length + 1];
        var i = 0;
        discoveredPaths[i++] = rootOfSubTree.ToString();

        foreach(var child in rootOfSubTree.Children) discoveredPaths[i++] = PreOrderTraversal(child);

        return System.String.Join(", ", discoveredPaths);
    }

    internal static Node CreateRoot()
    {
        var root = new Node { Content = "Root" };

        root.Children = new Node[] 
        { 
            new Node 
            { 
                Content = "hOneLeft",
                Children = new Node[]
                {
                    new Node 
                    { 
                        Content = "hTwoLLeft",
                        Children = new Node[]
                        {
                            new Node 
                            { 
                                Content = "hThreeLLeft",
                                Children = new Node[]
                                {
                                    new Node 
                                    { 
                                        Content = "hFourLLeft",
                                        Children = new Node[]
                                        {
                                            new Node { Content = "hFiveLLeft" }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new Node { Content = "hTwoLMid" },
                    new Node { Content = "hTwoLRight" }
                }
            },
            new Node 
            { 
                Content = "hOneMid",
                Children = new Node[]
                {
                    new Node { Content = "hTwoMLeft" },
                    new Node { Content = "hTwoMRight" }
                }
            },
            new Node 
            { 
                Content = "hOneRight",
                Children = new Node[]
                {
                    new Node { Content = "hTwoRLeft" },
                    new Node { Content = "hTwoRRight" }
                }
            }
        };

        return root;
    }
}

internal class Node
{
    public Node[] Children { get; set; }
    public System.String Content { get; set; }

    public override string ToString() => Content;
}
