using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    GameObject button;
    public GameObject player;
    Animator animator;
    private bool isRun = true;
    private bool isSwordAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Button");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ButtonClicked()
    {
        isRun = false;
        isSwordAttack = true;
    }
}
