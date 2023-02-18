using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// A binary tree
/// </summary>
/// <typeparam name="T">type of values stored in tree</typeparam>
public class BinaryTree<T>
{
    #region Fields

    BinaryTreeNode<T> root = null;
    List<BinaryTreeNode<T>> nodes = new List<BinaryTreeNode<T>>();

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="value">value of the root node</param>
    public BinaryTree(T value)
    {
        root = new BinaryTreeNode<T>(value, null);
        nodes.Add(root);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the number of nodes in the tree
    /// </summary>
    public int Count
    {
        get { return nodes.Count; }
    }

    /// <summary>
    /// Gets the root of the tree
    /// </summary>
    public BinaryTreeNode<T> Root
    {
        get { return root; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Get height of binary tree by getting is the number of nodes in the longest branch of the tree
    /// Going to node of left side of root node by depth until it has no left node
    /// Going to node of right side of above node by depth until it has no right node
    /// Then from that node, get the right node of it
    /// </summary>
    public int GetHeight(BinaryTreeNode<T> node)
    {
        if (node == null)
        {
            return 0;
        }
        else
        {
            int leftHeight = GetHeight(node.Left);
            int rightHeight = GetHeight(node.Right);

            if (leftHeight > rightHeight)
            {
                return leftHeight + 1;
            }
            else
            {
                return rightHeight + 1;
            }
        }
    }


    /// <summary>
    /// Clears all the nodes from the tree
    /// </summary>
    void Clear()
    {
        // remove all the children from each node
        // so nodes can be garbage collected
        foreach (BinaryTreeNode<T> node in nodes)
        {
            node.Parent = null;
            node.RemoveBothChildren();
        }

        // now remove all the nodes from the tree and set root to null
        for (int i = nodes.Count - 1; i >= 0; i--)
        {
            nodes.RemoveAt(i);
        }
        root = null;
    }

    /// <summary>
    /// Adds the given node to the tree. If the given node is
    /// null the method returns false. If the parent node is null
    /// or isn't in the tree the method returns false. If the given
    /// node is already a child of the parent node the method returns
    /// false
    /// </summary>
    /// <param name="node">node to add</param>
    /// <param name="side">side to add to for parent</param>
    /// <returns>true if the node is added, false otherwise</returns>
    public bool AddNode(BinaryTreeNode<T> node, ChildSide side)
    {
        if (node == null ||
            node.Parent == null ||
            !nodes.Contains(node.Parent))
        {
            return false;
        }
        else if (node.Parent.Left == node ||
            node.Parent.Right == node)
        {
            // node already a child of parent
            return false;
        }
        else
        {
            // add child as tree node and as a child to parent
            nodes.Add(node);
            return node.Parent.AddChild(node, side);
        }
    }

    /// <summary>
    /// Removes the given node from the tree. If the node isn't 
    /// found in the tree, the method returns false.
    /// 
    /// Note that the subtree with the node to remove as its
    /// root is pruned from the tree
    /// </summary>
    /// <param name="removeNode">node to remove</param>
    /// <returns>true if the node is removed, false otherwise</returns>
    public bool RemoveNode(BinaryTreeNode<T> removeNode)
    {
        if (removeNode == null)
        {
            return false;
        }
        else if (removeNode == root)
        {
            // removing the root clears the tree
            Clear();
            return true;
        }
        else
        {
            // remove as child of parent
            bool success = removeNode.Parent.RemoveChild(removeNode);
            if (!success)
            {
                return false;
            }

            // remove node from tree
            success = nodes.Remove(removeNode);
            if (!success)
            {
                return false;
            }

            // check for branch node
            if (removeNode.Left != null)
            {
                // recursively prune left subtree
                RemoveNode(removeNode.Left);
            }
            if (removeNode.Right != null)
            {
                // recursively prune right subtree
                RemoveNode(removeNode.Right);
            }

            return true;
        }
    }

    /// <summary>
    /// Finds a tree node with the given value. If there
    /// are multiple tree nodes with the given value the
    /// method returns the first one it finds
    /// </summary>
    /// <param name="value">value to find</param>
    /// <returns>tree node or null if not found</returns>
    public BinaryTreeNode<T> Find(T value)
    {
        foreach (BinaryTreeNode<T> node in nodes)
        {
            if (node.Data.Equals(value))
            {
                return node;
            }
        }
        return null;
    }

    /// <summary>
    /// Converts the tree to a comma-separated string of nodes
    /// </summary>
    /// <returns>comma-separated string of nodes</returns>
    public override String ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("Root: ");
        if (root != null)
        {
            builder.Append(root.Data + " ");
        }
        else
        {
            builder.Append("null");
        }
        for (int i = 0; i < Count; i++)
        {
            builder.Append(nodes[i].ToString());
            if (i < Count - 1)
            {
                builder.Append(",");
            }
        }
        return builder.ToString();
    }

    #endregion
}