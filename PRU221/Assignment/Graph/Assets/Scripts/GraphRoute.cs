using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GraphRoute<T>
{
    //distance
    public float cost;
    //all neighbor of that node
    public List<GraphEdge<T>> connections;

    public GraphRoute()
    {
        cost = float.MaxValue;
        connections = new List<GraphEdge<T>>();
    }

}