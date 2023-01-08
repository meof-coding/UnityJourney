using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    public float duration = 0.2f;
    public GameObject circlePrefabs { get; set; }
    public float Speed { get; set; }
    public int Power { get; set; }

    // On collision operation.
    public virtual void OnCollisionOperation(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("whiteCircle"))
        {
            Power++;
            if (Power <= 0)
            {
                //GameObject explosion = Object.Instantiate<GameObject>(circlePrefabs, gameObject.transform.position, Quaternion.identity);
                //Helper.GetGameMonitor().Score += 1;
                Destroy(gameObject);
            }
        }
    }

    //generate random position
    public virtual void OnPlacedRandom(GameObject circle)
    {
        //set Transition.position of red circle
        float spawnY, spawnX;
        RandomPosition(out spawnY, out spawnX);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        circle.transform.position = spawnPosition;
        // Instantiate(red, spawnPosition, Quaternion.identity);
    }

    // Creates a random position in the camera.
    private static void RandomPosition(out float spawnY, out float spawnX)
    {
        spawnY = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        spawnX = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

    }

    //moving random
    public virtual void MoveRandom()
    {
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;
        //generate random angle between 0 and 2PI (360 degrees)
        float angle = Random.Range(0, 2 * Mathf.PI); //Unity uses radians for taking sin and cos
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        //random force
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        //set Transition.position of red circle
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);
    }


    // On collision entry 2D.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("onCollisionEnter2D");
    }
}

