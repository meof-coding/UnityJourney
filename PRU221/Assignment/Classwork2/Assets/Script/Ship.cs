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

    // shooting support
    [SerializeField]
    GameObject prefabBullet;

    // Start is called before the first frame update
    void Start()
    {

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

    // Update is called once per frame
    void Update()
    {
        //keeping ship in fixed position
        transform.position = new Vector3(0, 0, 0);
    }
}
