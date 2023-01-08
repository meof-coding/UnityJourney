using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEngine;
using TMPro;

public class Mover : MonoBehaviour
{
    const float spawnTime = 2;
    Timer spawnTimer;
    float Speed { get; set; }
    int Power { get; set; }
    float startTime;
    [SerializeField]
    TMP_Text score;

    // On collision operation.
    public virtual void OnCollisionOperation(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Food"))
        {
            Destroy(collision.gameObject);
            //scale size of gameobject
            gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0f);
            Power++;
            score.text = "score: " + Power.ToString();
            //if (Power <= 0)
            //{
            //    //GameObject explosion = Object.Instantiate<GameObject>(circlePrefabs, gameObject.transform.position, Quaternion.identity);
            //    //Helper.GetGameMonitor().Score += 1;
            //    Destroy(collision.gameObject);
            //}
        }
    }

    //generate random position
    public virtual void OnPlacedRandom(GameObject circle)
    {
        //set Transition.position of red circle
        Vector2 spawnPosition = RandomPosition();
        circle.transform.position = spawnPosition;
        // Instantiate(red, spawnPosition, Quaternion.identity);
    }

    // Creates a random position in the camera.
    private static Vector2 RandomPosition()
    {
        float spawnY = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        return new Vector2(spawnX, spawnY);

    }

    //create and start the timer 

    public virtual void InitSpawn(GameObject circlePrefabs)
    {
        //create and start the timer
        spawnTimer = circlePrefabs.AddComponent<Timer>();
        startTime = Time.time;
        spawnTimer.Duration = spawnTime;
        spawnTimer.Run();
    }

    public virtual void SpawnRandom(GameObject circlePrefabs)
    {
        if (spawnTimer.Finished)
        {
            //spawn the circle
            SpawnCircle(circlePrefabs); Debug.Log("Elapsed time is: " + (Time.time - startTime) + " seconds");
            //rerun the timer
            spawnTimer.Run();
        }
    }

    public void SpawnCircle(GameObject circlePrefabs)
    {
        GameObject circle = Instantiate<GameObject>(circlePrefabs, RandomPosition(), Quaternion.identity /*dont rotate that game object*/) as GameObject;
        OnPlacedRandom(circle);
    }


    //moving random
    public virtual void MoveRandom()
    {
        Vector2 direction = RandomPosition();
        //set Transition.position of red circle
        GetComponent<Rigidbody2D>().AddForce(direction * 0.05f, ForceMode2D.Impulse);
    }


    // On collision entry 2D.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollisionOperation(collision);
    }
}

