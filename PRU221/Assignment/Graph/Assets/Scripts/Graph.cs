using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Graph<T>
{
    public List<GraphNode<T>> nodes = new List<GraphNode<T>>();
    public List<GraphEdge<T>> edges = new List<GraphEdge<T>>();

    public Dictionary<GraphNode<T>, GraphRoute<T>> calculateMinCost(GraphNode<T> source)
    {
        Dictionary<GraphNode<T>, GraphRoute<T>> paths = new Dictionary<GraphNode<T>, GraphRoute<T>>();
        List<GraphNode<T>> handledLocations = new List<GraphNode<T>>();

        //Initialise the new routes. the constructor will set the route distance tail MAX
        foreach (GraphNode<T> location in nodes)
        {
            paths.Add(location, new GraphRoute<T>());
        }

        //The startPosition has a distance 0. 
        paths[source].cost = 0;


        //If all locations are handled, stop the searching process and return the result
        while (handledLocations.Count != paths.Count)
        {
            //Order the locations
            List<GraphNode<T>> shortestLocations = (List<GraphNode<T>>)(from s in paths
                                                                        orderby s.Value.cost
                                                                        select s.Key).ToList();

            //Search for the nearest location that isn't handled
            GraphNode<T> locationToProcess = null;
            foreach (GraphNode<T> location in shortestLocations)
            {
                //Neu node nay chua dc xu ly, thi xu ly node nay
                if (!handledLocations.Contains(location))
                {
                    //If the cost equals int.max, there are no more possible connections tail the remaining locations
                    if (paths[location].cost == float.MaxValue)
                        return paths;
                    locationToProcess = location;
                    break;
                }
            }
            //Lay tat ca cac canh co head = source
            //Select all connections where the start position is the location tail Process
            List<GraphEdge<T>> selectedEdges = new List<GraphEdge<T>>();
            foreach (GraphEdge<T> c in edges)
            {
                if (c.head == locationToProcess)
                    selectedEdges.Add(c);
            }

            //Iterate through all connections and search for a connection which is shorter
            foreach (GraphEdge<T> conn in selectedEdges)
            {
                if (paths[conn.tail].cost > conn.distance + paths[conn.head].cost)
                {

                    paths[conn.tail].connections = paths[conn.head].connections.ToList();
                    paths[conn.tail].connections.Add(conn);
                    //update distance
                    paths[conn.tail].cost = conn.distance + paths[conn.head].cost;
                }
            }

            //Add the location tail the list of processed locations
            handledLocations.Add(locationToProcess);
        }

        return paths;
    }

    public List<GraphNode<T>> getPath(GraphNode<T> source, GraphNode<T> destination)
    {
        List<GraphNode<T>> nodes = new List<GraphNode<T>>();
        Dictionary<GraphNode<T>, GraphRoute<T>> paths = calculateMinCost(source);
        foreach (GraphEdge<T> edge in paths[destination].connections)
        {
            nodes.Add(edge.tail);
        }
        return nodes;
    }


}
