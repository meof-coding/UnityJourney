using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Animator animator;
    public GameObject elevator;
    //Level Sound
    public AudioSource levelSound;

    public void SwitchOn()
    {
        animator.SetTrigger("SwitchOn");
        elevator.GetComponent<ElevatorController>().isTrigger = true;
        levelSound.GetComponent<AudioSource>().Play();
    }

    public void SwitchOff()
    {
        animator.SetTrigger("SwitchOff");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
