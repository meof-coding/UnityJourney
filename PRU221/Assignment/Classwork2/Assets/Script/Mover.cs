using UnityEngine;
using System.Collections;
using TMPro;

public class Mover : MonoBehaviour
{
    private Vector3 destination;
    protected Bounds screenBounds;
    public TextMeshProUGUI score;

    public int Power { get; set; }

    protected Vector3 getRandomPoint(Vector3 min, Vector3 max)
    {
        int x = (int)Random.Range(min.x, max.x);
        int y = (int)Random.Range(min.y, max.y);

        return new Vector3(x, y, 0);
    }

    private Bounds OrthographicBounds(Camera camera)
    {

        float screenAspect = (float)Screen.width / (float)Screen.height;

        float cameraHeight = camera.orthographicSize * 2;

        Bounds bounds = new Bounds(

            camera.transform.position,

            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));

        return bounds;
    }

    // Use this for initialization
    void Start()
    {
        screenBounds = OrthographicBounds(Camera.main);
        destination = getRandomPoint(screenBounds.min, screenBounds.max);

        Power = 1;
    }

    // Update is called once per frame
    void Update()
    {
        MoveRandom();
    }

    protected void MoveRandom()
    {
        //for all cloned game object after 2s
        if (gameObject.name.Contains("Clone"))
        {
            //destroy if power = 0
            if (Power == 0)
            {
                Destroy(gameObject);
            }
            //handle when power > 0
            else
            {
                //get distance from gameobject to destination
                float difX = Mathf.Abs(gameObject.transform.position.x - destination.x);
                float difY = Mathf.Abs(gameObject.transform.position.y - destination.y);
                //if destination is too close
                if (difX < 0.5 || difY < 0.5)
                {
                    //generate random point
                    destination = getRandomPoint(screenBounds.min, screenBounds.max);
                }
                //else => move game object to destination position
                else
                {
                    gameObject.transform.position = Vector3.MoveTowards(transform.position, destination, 0.5f * Time.deltaTime);
                }
                //if game object is a red ball
                if (gameObject.tag.Equals("Red"))
                {
                    score.text = "Power: " + Power.ToString();
                }
            }
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Red"))
        {
            if (collision.gameObject.CompareTag("Pig"))
            {
                Power++;
            }
            else
            {
                if (Power > collision.gameObject.GetComponent<Mover>().Power)
                {
                    Power += collision.gameObject.GetComponent<Mover>().Power;
                    collision.gameObject.GetComponent<Mover>().Power = 0;
                }
            }
        }
        if (gameObject.CompareTag("Pig"))
        {
            if (collision.gameObject.CompareTag("Cannonball"))
            {
                Destroy(gameObject);
            }
        }
    }
}

