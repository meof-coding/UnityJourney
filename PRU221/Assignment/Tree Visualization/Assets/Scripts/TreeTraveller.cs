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
    private Tree<NodeInfo> tree;

    //Timer
    Timer drawnTimer;
    float startTime;
    int i = 0;

    //list tree node
    private List<TreeNode<NodeInfo>> listNode = new List<TreeNode<NodeInfo>>();
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
        DFSTraversal(tree.Root);

        //spawn node and line
        //Visualize();
    }

    /// <summary>
    /// Visualize whole tree
    /// </summary>
    //private void Visualize()
    //{
    //    for (int i = 0; i < listNode.Count; i++)
    //    {
    //        BinaryTreeNode<NodeInfo> node = listNode[i];
    //        BinaryTreeNode<NodeInfo> parent = node.Parent;
    //        if (parent != null)
    //        {
    //            node.Data.x = parent.Data.x + distanceX;
    //            node.Data.y = listNode[i - 1].Data.y + distanceY;
    //        }
    //        //spawn node
    //        GameObject nodeBody = Instantiate<GameObject>(treeNode, new Vector3(node.Data.x, node.Data.y, 0), Quaternion.identity);
    //        node.Data.body = nodeBody;
    //        nodeBody.transform.position = new Vector3(node.Data.x, node.Data.y, 0);
    //        //set text for nodeName serialize filed in node behavior is node.Data.name
    //        nodeBody.GetComponent<NodeBehavior>().nodeName.SetText(node.Data.Name);

    //        //drawline from parent to node
    //        if (parent != null)
    //        {
    //            DrawLine(parent, node);
    //        }
    //    }
    //}

    /// <summary>
    /// Set up line
    /// </summary>
    private void DrawLine(TreeNode<NodeInfo> from, TreeNode<NodeInfo> to)
    {
        //vertical line
        GameObject newLine1 = GameObject.Instantiate<GameObject>(line);
        LineRenderer lineRenderer1 = newLine1.GetComponent<LineRenderer>();
        //set size of line
        lineRenderer1.positionCount = 3;
        List<Vector3> pos1 = new List<Vector3>();
        //vertical
        pos1.Add(new Vector3(from.Value.x, from.Value.y));
        pos1.Add(new Vector3(from.Value.x, to.Value.y));
        //horizontal 
        pos1.Add(new Vector3(to.Value.x, to.Value.y));
        //set positions for linerenderer1 is pos1[0] and pos1[0]
        lineRenderer1.SetPosition(0, pos1[0]);
        lineRenderer1.SetPosition(1, pos1[0]);
        StartCoroutine(AnimateLine(lineRenderer1, pos1, lineRenderer1.positionCount));
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
    /// DFS traversal of tree
    /// </summary>
    private void DFSTraversal(TreeNode<NodeInfo> root)
    {
        //pre-order traversal of non-binary tree
        if (root != null)
        {
            Debug.Log(root.Value.Name);
            listNode.Add(root);
            foreach (TreeNode<NodeInfo> child in root.Children)
            {
                DFSTraversal(child);
            }
        }
    }

    /// <summary>
    /// Tree set up
    /// </summary>
    private Tree<NodeInfo> BuildTree()
    {
        //init tree with root node F
        Tree<NodeInfo> tree = new Tree<NodeInfo>(new NodeInfo { Name = "F", x = rootX, y = rootY });
        //init tree node 
        TreeNode<NodeInfo> nodeB = new TreeNode<NodeInfo>(new NodeInfo { Name = "B", x = rootX, y = rootY }, tree.Root);
        tree.AddNode(nodeB);
        TreeNode<NodeInfo> nodeA = new TreeNode<NodeInfo>(new NodeInfo { Name = "A", x = rootX, y = rootY }, nodeB);
        tree.AddNode(nodeA);
        TreeNode<NodeInfo> nodeD = new TreeNode<NodeInfo>(new NodeInfo { Name = "D", x = rootX, y = rootY }, nodeB);
        tree.AddNode(nodeD);
        TreeNode<NodeInfo> nodeC = new TreeNode<NodeInfo>(new NodeInfo { Name = "C", x = rootX, y = rootY }, nodeD);
        tree.AddNode(nodeC);
        TreeNode<NodeInfo> nodeE = new TreeNode<NodeInfo>(new NodeInfo { Name = "E", x = rootX, y = rootY }, nodeD);
        tree.AddNode(nodeE);
        TreeNode<NodeInfo> nodeG = new TreeNode<NodeInfo>(new NodeInfo { Name = "G", x = rootX, y = rootY }, tree.Root);
        tree.AddNode(nodeG);
        TreeNode<NodeInfo> nodeI = new TreeNode<NodeInfo>(new NodeInfo { Name = "I", x = rootX, y = rootY }, nodeG);
        tree.AddNode(nodeI);
        TreeNode<NodeInfo> nodeH = new TreeNode<NodeInfo>(new NodeInfo { Name = "H", x = rootX, y = rootY }, nodeI);
        tree.AddNode(nodeH);
        TreeNode<NodeInfo> nodeK = new TreeNode<NodeInfo>(new NodeInfo { Name = "K", x = rootX, y = rootY }, nodeB);
        tree.AddNode(nodeK);
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
                listNode[i].Value.x = listNode[i].Parent.Value.x + distanceX;
                listNode[i].Value.y = listNode[i - 1].Value.y + distanceY;
            }
            GameObject nodeBody = Instantiate<GameObject>(treeNode, new Vector3(listNode[i].Value.x, listNode[i].Value.y, 0), Quaternion.identity);
            listNode[i].Value.body = nodeBody;
            nodeBody.transform.position = new Vector3(listNode[i].Value.x, listNode[i].Value.y, 0);
            //set text for nodeName serialize filed in node behavior is node.Data.name
            nodeBody.GetComponent<NodeBehavior>().nodeName.SetText(listNode[i].Value.Name);
            if (listNode[i].Parent != null)
            {
                DrawLine(listNode[i].Parent, listNode[i]);
            }
            i++;
            drawnTimer.Run();
        }
    }
}
