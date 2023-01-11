using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabHub;

    [SerializeField]
    GameObject prefabAsteroid;

    const float spawnTime = 2;
    Timer spawnTimer;
    float startTime;
    Vector3 hubBottomPosition;
    GameObject hubRight;
    GameObject hubTop;
    GameObject hubBottom;
    // Start is called before the first frame update
    void Start()
    {
        // save asteroid radius
        //BoxCollider2D collider = prefabHub.GetComponent<BoxCollider2D>();
        //get box collider size
        //Destroy(hub);
        // calculate screen width and height
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        float screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;

        // right side hub
        hubRight = Instantiate<GameObject>(prefabHub);
        hubRight.transform.position = new Vector2(ScreenUtils.ScreenRight,
                //random range 
                Random.Range(ScreenUtils.ScreenBottom, ScreenUtils.ScreenBottom + screenHeight));
        InitSpawn(hubRight);

        //top side hub
        hubTop = Instantiate<GameObject>(prefabHub);
        hubTop.transform.position = new Vector2(Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenLeft + screenWidth),
                ScreenUtils.ScreenTop);
        InitSpawn(hubTop);

        // bottom side hub
        hubBottom = Instantiate<GameObject>(prefabHub);
        hubBottom.transform.position = new Vector2(Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenLeft + screenWidth),
                ScreenUtils.ScreenBottom);
        InitSpawn(hubBottom);

    }

    public virtual void InitSpawn(GameObject asteroidPrefabs)
    {
        //create and start the timer
        spawnTimer = asteroidPrefabs.AddComponent<Timer>();
        startTime = Time.time;
        spawnTimer.Duration = spawnTime;
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {

        if (spawnTimer.Finished)
        {
            SpawnFromHub(Direction.Right, hubRight.transform.position);
            //script.Initialize(Direction.Up, hubBottom.transform.position);
            SpawnFromHub(Direction.Up, hubBottom.transform.position);
            SpawnFromHub(Direction.Down, hubTop.transform.position);
            //rerun the timer
            spawnTimer.Run();
        }
    }

    private void SpawnFromHub(Direction direction, Vector3 spawnPosition)
    {
        GameObject asteroid = Instantiate<GameObject>(prefabAsteroid);
        Asteroid script = asteroid.GetComponent<Asteroid>();
        //spawn asteroid in difference direction
        script.Initialize(direction, spawnPosition);
    }
}
