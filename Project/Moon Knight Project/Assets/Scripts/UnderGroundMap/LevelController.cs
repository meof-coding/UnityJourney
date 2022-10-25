using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Animator animator;
    public GameObject elevator;

    public void SwitchOn()
    {
        animator.SetTrigger("SwitchOn");
        elevator.GetComponent<ElevatorController>().Active();
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
