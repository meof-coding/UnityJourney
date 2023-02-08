using UnityEngine;

public class GraphEdge<T>
{
    //Node head
    public GraphNode<T> head { get; set; }
    //Node tail
    public GraphNode<T> tail { get; set; }
    //distance from node head to tail
    public float distance { get; set; }
}