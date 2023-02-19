using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class TreeTraveller : MonoBehaviour
{
    [SerializeField]
    public GameObject treeNode;

    [SerializeField]
    public GameObject line;

    [SerializeField]
    private float animatorDuration = 5f;

    private int distanceX = 2;
    private int distanceY = -2;

    [SerializeField]
    public int rootX;

    [SerializeField]
    public int rootY;
    private BinaryTree<NodeInfo> tree;

    //Timer
    Timer drawnTimer;
    float startTime;
    int i = 0;

    //list tree node
    private List<BinaryTreeNode<NodeInfo>> listNode = new List<BinaryTreeNode<NodeInfo>>();
    // Start is called before the first frame update
    void Start()
    {
        //build tree
        tree = BuildTree();

        #region Init Timer
        //create and start the timer
        drawnTimer = gameObject.AddComponent<Timer>();
        startTime = Time.time;
        drawnTimer.Duration = 1;
        drawnTimer.Run();
        #endregion

        //get height of tree
        Debug.Log("Height of tree is : " + tree.GetHeight(tree.Root));

        //DFS traversal of tree
        Debug.Log("DFS Pre-Order traversal of tree");
        PreOrderTraversal(tree.Root);

        //spawn node and line
        //Visualize();
    }

    /// <summary>
    /// Visualize whole tree
    /// </summary>
    private void Visualize()
    {
        for (int i = 0; i < listNode.Count; i++)
        {
            BinaryTreeNode<NodeInfo> node = listNode[i];
            BinaryTreeNode<NodeInfo> parent = node.Parent;
            if (parent != null)
            {
                node.Data.x = parent.Data.x + distanceX;
                node.Data.y = listNode[i - 1].Data.y + distanceY;
            }
            //spawn node
            GameObject nodeBody = Instantiate<GameObject>(treeNode, new Vector3(node.Data.x, node.Data.y, 0), Quaternion.identity);
            node.Data.body = nodeBody;
            nodeBody.transform.position = new Vector3(node.Data.x, node.Data.y, 0);
            //set text for nodeName serialize filed in node behavior is node.Data.name
            nodeBody.GetComponent<NodeBehavior>().nodeName.SetText(node.Data.Name);

            //drawline from parent to node
            if (parent != null)
            {
                DrawLine(parent, node);
            }
        }
    }

    /// <summary>
    /// Set up line
    /// </summary>
    private void DrawLine(BinaryTreeNode<NodeInfo> from, BinaryTreeNode<NodeInfo> to)
    {
        //vertical line
        GameObject newLine1 = GameObject.Instantiate<GameObject>(line);
        LineRenderer lineRenderer1 = newLine1.GetComponent<LineRenderer>();
        //set size of line
        lineRenderer1.positionCount = 3;
        List<Vector3> pos1 = new List<Vector3>();
        //vertical
        pos1.Add(new Vector3(from.Data.x, from.Data.y));
        pos1.Add(new Vector3(from.Data.x, to.Data.y));
        //horizontal 
        pos1.Add(new Vector3(to.Data.x, to.Data.y));
        //set positions for linerenderer1 is pos1[0] and pos1[0]
        lineRenderer1.SetPosition(0, pos1[0]);
        lineRenderer1.SetPosition(1, pos1[0]);
        StartCoroutine(AnimateLine(lineRenderer1, pos1, lineRenderer1.positionCount));

        //horizontal line to connect parent node and child node
        // GameObject newLine2 = GameObject.Instantiate<GameObject>(line);
        // LineRenderer lineRenderer2 = newLine2.GetComponent<LineRenderer>();
        // List<Vector3> pos2 = new List<Vector3>();
        // pos2.Add(new Vector3(from.Data.x, to.Data.y));
        // pos2.Add(new Vector3(to.Data.x, to.Data.y));
        // //set positions for linerenderer1 is pos1[0] and pos1[0]
        // lineRenderer2.SetPosition(0, pos2[0]);
        // lineRenderer2.SetPosition(1, pos2[0]);
        // StartCoroutine(AnimateLine(lineRenderer2, pos2));
    }

    /// <summary>
    /// Animate Line Renderer
    /// </summary>
    private IEnumerator AnimateLine(LineRenderer lineRenderer, List<Vector3> position, int pointCount)
    {
        float segmentDuration = animatorDuration / pointCount;
        for (int i = 0; i < pointCount - 1; i++)
        {
            float startTimer = Time.time;
            Vector3 startPosition = position[i];
            Vector3 endPosition = position[i + 1];
            Vector3 pos = startPosition;
            while (pos != endPosition)
            {
                float distCovered = (Time.time - startTimer) / segmentDuration;
                pos = Vector3.Lerp(startPosition, endPosition, distCovered);
                for (int j = i + 1; j < pointCount; j++)
                {
                    lineRenderer.SetPosition(j, pos);
                }
                yield return null;
            }
        }
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
            Debug.Log(node.Data.Name + " ");
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

    /// <summary>
    /// Tree set up
    /// </summary>
    private BinaryTree<NodeInfo> BuildTree()
    {
        //init tree with root node F
        BinaryTree<NodeInfo> tree = new BinaryTree<NodeInfo>(new NodeInfo { Name = "F", x = rootX, y = rootY });
        //init tree node 
        BinaryTreeNode<NodeInfo> nodeB = new BinaryTreeNode<NodeInfo>(new NodeInfo { Name = "B", x = rootX, y = rootY }, tree.Root);
        tree.AddNode(nodeB, ChildSide.Left);
        BinaryTreeNode<NodeInfo> nodeA = new BinaryTreeNode<NodeInfo>(new NodeInfo { Name = "A", x = rootX, y = rootY }, nodeB);
        tree.AddNode(nodeA, ChildSide.Left);
        BinaryTreeNode<NodeInfo> nodeD = new BinaryTreeNode<NodeInfo>(new NodeInfo { Name = "D", x = rootX, y = rootY }, nodeB);
        tree.AddNode(nodeD, ChildSide.Right);
        BinaryTreeNode<NodeInfo> nodeC = new BinaryTreeNode<NodeInfo>(new NodeInfo { Name = "C", x = rootX, y = rootY }, nodeD);
        tree.AddNode(nodeC, ChildSide.Left);
        BinaryTreeNode<NodeInfo> nodeE = new BinaryTreeNode<NodeInfo>(new NodeInfo { Name = "E", x = rootX, y = rootY }, nodeD);
        tree.AddNode(nodeE, ChildSide.Right);
        BinaryTreeNode<NodeInfo> nodeG = new BinaryTreeNode<NodeInfo>(new NodeInfo { Name = "G", x = rootX, y = rootY }, tree.Root);
        tree.AddNode(nodeG, ChildSide.Right);
        BinaryTreeNode<NodeInfo> nodeI = new BinaryTreeNode<NodeInfo>(new NodeInfo { Name = "I", x = rootX, y = rootY }, nodeG);
        tree.AddNode(nodeI, ChildSide.Right);
        BinaryTreeNode<NodeInfo> nodeH = new BinaryTreeNode<NodeInfo>(new NodeInfo { Name = "H", x = rootX, y = rootY }, nodeI);
        tree.AddNode(nodeH, ChildSide.Left);
        return tree;
    }

    // Update is called once per frame
    void Update()
    {
        if (drawnTimer.Finished && i < listNode.Count)
        {
            Debug.Log("Finished");
            //instantiated first node in list node
            if (listNode[i].Parent != null)
            {
                listNode[i].Data.x = listNode[i].Parent.Data.x + distanceX;
                listNode[i].Data.y = listNode[i - 1].Data.y + distanceY;
            }
            GameObject nodeBody = Instantiate<GameObject>(treeNode, new Vector3(listNode[i].Data.x, listNode[i].Data.y, 0), Quaternion.identity);
            listNode[i].Data.body = nodeBody;
            nodeBody.transform.position = new Vector3(listNode[i].Data.x, listNode[i].Data.y, 0);
            //set text for nodeName serialize filed in node behavior is node.Data.name
            nodeBody.GetComponent<NodeBehavior>().nodeName.SetText(listNode[i].Data.Name);
            if (listNode[i].Parent != null)
            {
                DrawLine(listNode[i].Parent, listNode[i]);
            }
            i++;
            drawnTimer.Run();
        }
    }
}
