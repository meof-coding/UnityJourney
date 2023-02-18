using System.Text;

public class BinaryTreeNode<T>
{
    #region Fields

    T data;
    BinaryTreeNode<T> parent;
    BinaryTreeNode<T> left;
    BinaryTreeNode<T> right;

    #endregion

    #region Constructors

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data">data of the node</param>
    /// <param name="parent">parent for the node</param>
    public BinaryTreeNode(T data, BinaryTreeNode<T> parent)
    {
        this.data = data;
        this.parent = parent;
        left = null;
        right = null;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the Data stored in the node
    /// </summary>
    public T Data
    {
        get { return data; }
    }

    /// <summary>
    /// Gets and sets the parent of the node
    /// </summary>
    public BinaryTreeNode<T> Parent
    {
        get { return parent; }
        set { parent = value; }
    }

    /// <summary>
    /// Gets the left child
    /// </summary>
    /// <value>left child</value>
    public BinaryTreeNode<T> Left
    {
        get { return left; }
    }

    /// <summary>
    /// Gets the right child
    /// </summary>
    /// <value>right child</value>
    public BinaryTreeNode<T> Right
    {
        get { return right; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Adds the given node as a child this node
    /// </summary>
    /// <param name="child">child to add</param>
    /// <returns>true if the child was added, false otherwise</returns>
    public bool AddChild(BinaryTreeNode<T> child, ChildSide side)
    {
        // don't add duplicate children
        if (left == child || right == child)
        {
            return false;
        }
        else if ((side == ChildSide.Left && left != null) ||
            (side == ChildSide.Right && right != null))
        {
            // don't write over existing child
            return false;
        }
        else
        {
            // add as child and add self as parent
            if (side == ChildSide.Left)
            {
                left = child;
            }
            else
            {
                right = child;
            }
            child.Parent = this;
            return true;
        }
    }

    /// <summary>
    /// Removes the given node as a child this node
    /// </summary>
    /// <param name="child">child to remove</param>
    /// <returns>true if the child was removed, false otherwise</returns>
    public bool RemoveChild(BinaryTreeNode<T> child)
    {
        // only remove valid child
        if (left == child)
        {
            child.Parent = null;
            left = null;
            return true;
        }
        else if (right == child)
        {
            child.Parent = null;
            right = null;
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Removes both children for the node
    /// </summary>
    /// <returns>true if the children were removed, false otherwise</returns>
    public bool RemoveBothChildren()
    {
        if (left != null)
        {
            left.Parent = null;
            left = null;
        }
        if (right != null)
        {
            right.Parent = null;
            right = null;
        }
        return true;
    }

    /// <summary>
    /// Converts the node to a string
    /// </summary>
    /// <returns>the string</returns>
    public override string ToString()
    {
        StringBuilder nodeString = new StringBuilder();
        nodeString.Append("[Node Data: " + data +
            " Parent: ");
        if (parent != null)
        {
            nodeString.Append(parent.Data);
        }
        else
        {
            nodeString.Append("null");
        }
        nodeString.Append(" Left: ");
        if (left != null)
        {
            nodeString.Append(left.Data);
        }
        else
        {
            nodeString.Append("null");
        }
        nodeString.Append(" Right: ");
        if (right != null)
        {
            nodeString.Append(right.Data);
        }
        else
        {
            nodeString.Append("null");
        }
        nodeString.Append("]");
        return nodeString.ToString();
    }

    #endregion
}