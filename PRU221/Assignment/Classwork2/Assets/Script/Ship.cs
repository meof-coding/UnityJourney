using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    //bullet direction
    Vector2 thrustDirection = new Vector2(1, 0);
    const float RotateDegreesPerSecond = 180;
    [SerializeField]
    AudioSource shootingSound;
    [SerializeField]
    GameObject radar;
    // shooting support
    [SerializeField]
    GameObject prefabBullet;
    [SerializeField] int damage;
    List<GameObject> objectsInsideArea = new List<GameObject>();

    float minDistance;

    // Start is called before the first frame update
    void Start()
    {
        minDistance = radar.transform.localScale.x;
    }
    public void Rotation(Vector3 positionRotate)
    {
        float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
        transform.Rotate(positionRotate, rotationAmount);
        // change thrust direction to match ship rotation
        float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
        thrustDirection.x = Mathf.Cos(zRotation);
        thrustDirection.y = Mathf.Sin(zRotation);
        Invoke("Shooting", 1f);
    }

    public void Shooting()
    {
        GameObject bullet = Instantiate(prefabBullet, transform.position, Quaternion.identity);
        Bullet script = bullet.GetComponent<Bullet>();
        script.ApplyForce(thrustDirection);
        //if (!gameObject.GetComponent<AudioSource>().isPlaying)
        //{
        //    gameObject.GetComponent<AudioSource>().Play();
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ////put each collision.gameobject into objectsInsideArea
        objectsInsideArea.Add(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject nearestAsteroid = new GameObject();
        foreach (GameObject enemy in objectsInsideArea)
        {
            //get collider posision
            Vector2 colliderPosition = enemy.transform.position;
            //get distance between collider and player
            float distance = Vector2.Distance(colliderPosition, transform.position);
            //if distance is less than minDistance
            if (distance < minDistance)
            {
                //set minDistance to distance
                minDistance = distance;
                nearestAsteroid = enemy;
            }
        }
        Rotation(new Vector3(0f, 0f, Mathf.Atan2(nearestAsteroid.transform.position.y, nearestAsteroid.transform.position.x) * Mathf.Rad2Deg));
        objectsInsideArea.Remove(collision.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        //keeping ship in fixed position
        transform.position = new Vector3(0, 0, 0);
    }
}
