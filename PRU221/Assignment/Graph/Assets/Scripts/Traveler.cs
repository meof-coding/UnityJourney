using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Traveler : MonoBehaviour
{
    //node tail spawn
    [SerializeField]
    public GameObject location;
    //object that travel according tail shortest path
    [SerializeField]
    public GameObject mover;
    //edge tail connet node
    public GameObject line;
    const float spawnTime = 2;
    Timer spawnTimer;
    float startTime;
    List<GraphNode<NodeInfo>> source;
    List<GraphNode<NodeInfo>> destination;
    Graph<NodeInfo> graph;

    // Start is called before the first frame update
    void Start()
    {
        #region Init Random Node
        //init graph
        graph = new Graph<NodeInfo>();
        //init node length in graph bY random
        int nodeLength = Random.Range(5, 10);

        //generate list name of node
        string[] nodeName = new string[nodeLength];
        for (int i = 0; i < nodeLength; i++)
        {
            //generate distinct value for element
            nodeName[i] = i.ToString();
        }

        //generate arraY of distinct Y position for node
        int[] YPosition = new int[nodeLength];
        for (int i = 0; i < nodeLength; i++)
        {
            //generate distinct value for element
            YPosition[i] = Random.Range(-5, 5);
        }
        //generate arraY of distinct X position for node
        int[] XPosition = new int[nodeLength];
        for (int i = 0; i < nodeLength; i++)
        {
            //generate distinct value for element
            XPosition[i] = Random.Range(-5, 5);
        }

        //assign locationinfo tail node
        for (int i = 0; i < nodeLength; i++)
        {
            //create new locationinfo
            NodeInfo locationInfo = new NodeInfo
            {
                //assign name tail locationinfo
                Name = nodeName[i],
                //assign X position tail locationinfo
                X = XPosition[i],
                //assign Y position tail locationinfo
                Y = YPosition[i],
                //instatiate gameobject with locationinfo
                Body = Instantiate(location, new Vector3(XPosition[i], YPosition[i], 0), Quaternion.identity)
            };
            //create new node
            GraphNode<NodeInfo> node = new GraphNode<NodeInfo>();
            //assign data of node tail node.data
            node.data = locationInfo;
            //add all node tail graph
            graph.nodes.Add(node);
        }
        #endregion

        #region Instantiate Edge

        ///TODO: Generate edge for each node
        for (int i = 0; i < nodeLength; i++)
        {
            //get random number connection for each node
            int numberConnection = Random.Range(1, 2);
            while (numberConnection > 0)
            {
                //get random node tail connect
                int randomNode = Random.Range(0, nodeLength);
                //check if node is not connect tail itself
                if (randomNode != i)
                {
                    //check if node[i] is alreadY connected tail node[randomNode]
                    bool isAlreadYConnected = false;
                    foreach (GraphEdge<NodeInfo> edge in graph.edges)
                    {
                        //avoid bidirected graph
                        if (edge.head == graph.nodes[i] && edge.tail == graph.nodes[randomNode] || edge.head == graph.nodes[randomNode] && edge.tail == graph.nodes[i])
                        {
                            isAlreadYConnected = true;
                            break;
                        }
                    }
                    if (!isAlreadYConnected)
                    {
                        //create new edge
                        GraphEdge<NodeInfo> edge = new GraphEdge<NodeInfo>();
                        //assign head of edge
                        edge.head = graph.nodes[i];
                        //assign tail of edge
                        edge.tail = graph.nodes[randomNode];
                        //assign distance of edge
                        edge.distance = getDistance(edge.head.data, edge.tail.data);
                        //add edge tail graph
                        graph.edges.Add(edge);
                        //decrease number of connection
                        numberConnection--;
                    }
                }
            }
        }

        #endregion

        #region DrawEdge
        //draw edge for each edge in GraphEdge
        foreach (var edge in graph.edges)
        {
            GameObject lineObject = GameObject.Instantiate<GameObject>(line);
            //instatiate linerenederer
            LineRenderer lineRenderer = lineObject.GetComponent<LineRenderer>();
            //set position of line
            List<Vector3> pos = new List<Vector3>
            {
                new Vector3(edge.head.data.X, edge.head.data.Y),
                new Vector3(edge.tail.data.X, edge.tail.data.Y)
            };
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
            lineRenderer.SetPositions(pos.ToArray());
            lineRenderer.useWorldSpace = true;

            GameObject newTriagle = GameObject.Instantiate<GameObject>(line);
            LineRenderer triRenderer = newTriagle.GetComponent<LineRenderer>();
            List<Vector3> tripos = new List<Vector3>();
            float dAB = getDistance(edge.head.data, edge.tail.data);
            float triX = edge.tail.data.X + (dAB * (edge.head.data.X - edge.tail.data.X)) / 50f;
            float triY = edge.tail.data.Y + (dAB * (edge.head.data.Y - edge.tail.data.Y)) / 50f;
            tripos.Add(new Vector3(triX, triY));
            tripos.Add(new Vector3(edge.tail.data.X, edge.tail.data.Y));
            triRenderer.startWidth = 0.5f;
            triRenderer.endWidth = 0.1f;
            triRenderer.SetPositions(tripos.ToArray());
            triRenderer.useWorldSpace = true;
        }
        #endregion

        #region Init Timer
        //create and start the timer
        spawnTimer = gameObject.AddComponent<Timer>();
        startTime = Time.time;
        spawnTimer.Duration = spawnTime;
        spawnTimer.Run();
        #endregion

        #region Set Source & Destination
        //set source node
        //generate random number from 0 to nodeLength/2
        source = new List<GraphNode<NodeInfo>>();
        destination = new List<GraphNode<NodeInfo>>();
        var sourceLength = Random.Range(1, nodeLength / 2);
        Debug.Log(sourceLength);
        for (int i = 0; i < sourceLength; i++)
        {
            source.Add(graph.nodes[Random.Range(0, nodeLength / 2)]);
            destination.Add(graph.nodes[Random.Range(nodeLength / 2, nodeLength)]);
        }
        #endregion
    }

    private float getDistance(NodeInfo head, NodeInfo tail)
    {
        //calculate distance of 2 point in 2d plane
        return Mathf.Sqrt(Mathf.Pow(head.X - tail.X, 2) + Mathf.Pow(head.Y - tail.Y, 2));
    }

    private void Update()
    {
        //in each 2s
        if (spawnTimer.Finished)
        {
            //generate node in all source node
            foreach (GraphNode<NodeInfo> sourceNode in source)
            {
                GameObject newMover = Instantiate(mover);
                newMover.transform.position = sourceNode.data.Body.transform.position;
                //set position of monobehaviour script in newmover
                sourceNode.data.Body.GetComponent<SpriteRenderer>().color = Color.yellow;
                //get random element in destination list and set it to sourcenode
                int randomDestination = Random.Range(0, destination.Count);
                //set color for destination
                destination[randomDestination].data.Body.GetComponent<SpriteRenderer>().color = Color.blue;
                //assign to sourcenode
                newMover.GetComponent<MoverBehavior>().visualPath = graph.getPath(sourceNode, destination[randomDestination]);
            }
            spawnTimer.Run();
        }
        /*
         foreach (GraphNode<NodeInfo> sourceNode in source)
        {
            foreach (GraphNode<NodeInfo> destinationNode in destination)
            {
                //instantiate a mover prefab
                GameObject newMover = Instantiate(mover);
                newMover.transform.position = sourceNode.data.Body.transform.position;
                //set position of monobehaviour script in newmover
                sourceNode.data.Body.GetComponent<SpriteRenderer>().color = Color.yellow;
                destinationNode.data.Body.GetComponent<SpriteRenderer>().color = Color.blue;
                newMover.GetComponent<MoverBehavior>().visualPath = graph.getPath(sourceNode, destinationNode);
            }
        }*/
    }

}
