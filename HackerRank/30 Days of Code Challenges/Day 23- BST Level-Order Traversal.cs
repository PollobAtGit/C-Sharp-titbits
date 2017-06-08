using System;
using System.Collections.Generic;

internal class Ans
{
    static void Main(String[] args)
    {
        Node root=null;
        int T=Int32.Parse(Console.ReadLine());
        while(T-->0){
            int data=Int32.Parse(Console.ReadLine());
            root=insert(root,data);            
        }
        //levelOrder(root);
        levelOrderLoop(root);
    }

    private static Queue<Node> _container = new Queue<Node>();
    static void levelOrder(Node root)
    {
        if(root == null) return;

        _container.Enqueue(root);   
        LevelOrderRecursive(_container.Dequeue());
    }

    private static void LevelOrderRecursive(Node root)
    {
        if(root == null) return;

        Console.Write(root.data + " ");

        if(root.left != null) _container.Enqueue(root.left);
        if(root.right != null) _container.Enqueue(root.right);

        if(_container.Count != 0) LevelOrderRecursive(_container.Dequeue());
        return;
    }

    static void levelOrderLoop(Node root)
    {
        if(root != null) _container.Enqueue(root);

        while(_container.Count != 0)
        {
            var currentNode = _container.Dequeue();

            Console.Write(currentNode.data + " ");
            
            if(currentNode.left != null) _container.Enqueue(currentNode.left);
            if(currentNode.right != null) _container.Enqueue(currentNode.right);
        }
    }

    static Node insert(Node root, int data)
    {
        if(root==null){
            return new Node(data);
        }
        else{
            Node cur;
            if(data<=root.data){
                cur=insert(root.left,data);
                root.left=cur;
            }
            else{
                cur=insert(root.right,data);
                root.right=cur;
            }
            return root;
        }
    }

    private class Node
    {
        public Node left,right;
        public int data;
        
        public Node(int data)
        {
            this.data=data;
            left=right=null;
        }
    }
}
