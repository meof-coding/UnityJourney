using UnityEngine;
using System.Collections;

public class HubSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabHub;
    // Use this for initialization
    void Start()
    {
        // save asteroid radius
        GameObject hub = Instantiate<GameObject>(prefabHub);
        CircleCollider2D collider = prefabHub.GetComponent<CircleCollider2D>();
        float hubRadius = collider.radius;
        Destroy(hub);

        // calculate screen width and height
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        float screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;

        // right side asteroid
        prefabHub = Instantiate<GameObject>(prefabHub);
        prefabHub.transform.position = new Vector2(ScreenUtils.ScreenRight - hubRadius / 2,
                ScreenUtils.ScreenBottom + screenHeight / 2);

        //top side asteroid
        prefabHub = Instantiate<GameObject>(prefabHub);
        prefabHub.transform.position = new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
                ScreenUtils.ScreenTop - hubRadius / 2);

        // bottom side asteroid
        prefabHub = Instantiate<GameObject>(prefabHub);
        prefabHub.transform.position = new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
                ScreenUtils.ScreenBottom + hubRadius / 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

