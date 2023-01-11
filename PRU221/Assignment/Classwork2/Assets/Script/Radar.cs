using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Radar : MonoBehaviour
{
    [SerializeField] int damage;
    List<Collider2D> objectsInsideArea;
    [SerializeField] float radiusOfDamage;
    [SerializeField] LayerMask mask;
    [SerializeField] GameObject ship;
    GameObject nearestAsteroid;
    private void Awake()
    {
        //radiusOfDamage = GetComponent<CircleCollider2D>().radius;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get halfwidth of gameobject
        float halfWidth = 0.8f * (transform.localScale.x / 2);
        objectsInsideArea = new List<Collider2D>(Physics2D.OverlapCircleAll(new Vector2(0f, 0f), halfWidth, mask));
        float minDistance = Mathf.Infinity;
        //get nearest object in onjectsInsideArea
        if (objectsInsideArea.Count > 0)
        {
            //find object with min distance
            foreach (Collider2D collider in objectsInsideArea)
            {
                //get collider posision
                Vector2 colliderPosition = collider.transform.position;
                //get distance between collider and player
                float distance = Vector2.Distance(colliderPosition, ship.transform.position);
                //if distance is less than minDistance
                if (distance < minDistance)
                {
                    //set minDistance to distance
                    minDistance = distance;
                    nearestAsteroid = collider.gameObject;
                }
            }
            //rotate ship to nearestAsteroid
            ship.GetComponent<Ship>().Rotation(new Vector3(0f, 0f, Mathf.Atan2(minDistance, 0f) * Mathf.Rad2Deg));
            //find nearestAsteroid in colliderPosition and remove it
            if (objectsInsideArea.Contains(nearestAsteroid.GetComponent<Collider2D>()))
            {
                objectsInsideArea.Remove(nearestAsteroid.GetComponent<Collider2D>());
            }

            Debug.Log(nearestAsteroid.transform.position);

            //ship.GetComponent<Ship>().Shooting();
            minDistance = Mathf.Infinity;
        }
    }
}
