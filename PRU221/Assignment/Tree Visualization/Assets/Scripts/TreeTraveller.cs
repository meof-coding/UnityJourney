using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTraveller : MonoBehaviour
{
    [SerializeField]
    public GameObject node;
    [SerializeField]
    public GameObject line;
    [SerializeField]
    public int distanceX;

    [SerializeField]
    public int distanceY;

    [SerializeField]
    public int rootX;

    [SerializeField]
    public int rootY;
    private BinaryTree<NodeInfo> tree;
    //list tree node
    private List<BinaryTreeNode<NodeInfo>> listNode = new List<BinaryTreeNode<NodeInfo>>();
    // Start is called before the first frame update
    void Start()
    {
        //build tree
        tree = BuildTree();

        //get height of tree
        Debug.Log(tree.GetHeight(tree.Root));

        //DFS traversal of tree
        Debug.Log("DFS Pre-Order traversal of tree");
        PreOrderTraversal(tree.Root);

        //spawn node and line
        SpawnNodeAndLine();
    }

    private void SpawnNodeAndLine()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Pre-order traversal (Root- Left - Right)
    /// </summary>
    /// <param name="tree">tree to traverse</param>
    void PreOrderTraversal(BinaryTreeNode<NodeInfo> node)
    {
        if (node != null)
        {
            //add tree node to list
            listNode.Add(node);
            Debug.Log(node.Data.name + " ");
            if (node.Left != null)
            {
                PreOrderTraversal(node.Left);
            }
            if (node.Right != null)
            {
                PreOrderTraversal(node.Right);
            }
        }
    }

    private BinaryTree<NodeInfo> BuildTree()
    {
        //init tree with root node F
        BinaryTree<NodeInfo> tree = new BinaryTree<NodeInfo>(new NodeInfo { name = "F", x = rootX, y = rootY });
        //init tree node 
        BinaryTreeNode<NodeInfo> nodeB = new BinaryTreeNode<NodeInfo>(new NodeInfo { name = "B", x = rootX, y = rootY }, tree.Root);
        tree.AddNode(nodeB, ChildSide.Left);
        BinaryTreeNode<NodeInfo> nodeA = new BinaryTreeNode<NodeInfo>(new NodeInfo { name = "A", x = rootX, y = rootY }, nodeB);
        tree.AddNode(nodeA, ChildSide.Left);
        BinaryTreeNode<NodeInfo> nodeD = new BinaryTreeNode<NodeInfo>(new NodeInfo { name = "D", x = rootX, y = rootY }, nodeB);
        tree.AddNode(nodeD, ChildSide.Right);
        BinaryTreeNode<NodeInfo> nodeC = new BinaryTreeNode<NodeInfo>(new NodeInfo { name = "C", x = rootX, y = rootY }, nodeD);
        tree.AddNode(nodeC, ChildSide.Left);
        BinaryTreeNode<NodeInfo> nodeE = new BinaryTreeNode<NodeInfo>(new NodeInfo { name = "E", x = rootX, y = rootY }, nodeD);
        tree.AddNode(nodeE, ChildSide.Right);
        BinaryTreeNode<NodeInfo> nodeG = new BinaryTreeNode<NodeInfo>(new NodeInfo { name = "G", x = rootX, y = rootY }, tree.Root);
        tree.AddNode(nodeG, ChildSide.Right);
        BinaryTreeNode<NodeInfo> nodeI = new BinaryTreeNode<NodeInfo>(new NodeInfo { name = "I", x = rootX, y = rootY }, nodeG);
        tree.AddNode(nodeI, ChildSide.Right);
        BinaryTreeNode<NodeInfo> nodeH = new BinaryTreeNode<NodeInfo>(new NodeInfo { name = "H", x = rootX, y = rootY }, nodeI);
        tree.AddNode(nodeH, ChildSide.Left);
        return tree;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
