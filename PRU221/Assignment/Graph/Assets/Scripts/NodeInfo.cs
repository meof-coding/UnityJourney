using UnityEngine;
using System;
using System.Collections.Generic;

public class NodeInfo
{
    ///all property of node
    //name of node
    public string Name { get; set; }
    //x co-ordinator of node
    public int X { get; set; }
    //y co-ordinator of node
    public int Y { get; set; }
    //gameObject represent node
    public GameObject Body { get; set; }
    public int visitedCount { get; set; }
    public List<GraphNode<NodeInfo>> visualPath { get; set; }

    //int numberOfVisitedNodes = 0;
    //void Update()
    //{
    //    if (visualPath.Count > 0 && numberOfVisitedNodes < visualPath.Count)
    //    {
    //        GraphNode<NodeInfo> destination = visualPath[numberOfVisitedNodes];

    //        float step = 1 * Time.deltaTime;
    //        // move sprite towards the target location
    //        Vector2 point = new Vector2(destination.data.X, destination.data.Y);
    //        mover.transform.position = Vector2.MoveTowards(mover.transform.position, point, step);

    //        if (mover.transform.position.x == destination.data.X && mover.transform.position.y == destination.data.Y)
    //        {
    //            numberOfVisitedNodes++;
    //        }
    //    }
    //}
}