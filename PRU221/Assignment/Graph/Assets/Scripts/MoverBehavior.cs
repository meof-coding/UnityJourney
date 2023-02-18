using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBehavior : MonoBehaviour
{
    public List<GraphNode<NodeInfo>> visualPath;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.position = position;
    }

    int numberOfVisitedNodes = 0;
    void Update()
    {
        if (visualPath.Count == 0)
        {
            Debug.Log("No path found");
        }
        if (visualPath.Count > 0 && numberOfVisitedNodes < visualPath.Count)
        {
            GraphNode<NodeInfo> destination = visualPath[numberOfVisitedNodes];

            float step = 1 * Time.deltaTime;
            // move sprite towards the target location
            Vector2 point = new Vector2(destination.data.X, destination.data.Y);
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, point, step);

            if (gameObject.transform.position.x == destination.data.X && gameObject.transform.position.y == destination.data.Y)
            {
                numberOfVisitedNodes++;
            }
        }
        if (numberOfVisitedNodes == visualPath.Count)
        {
            Destroy(gameObject);
        }
    }
}
