using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
   
    public GameObject player;
    Animator animator;
    private bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        gameObject.SetActive(isActive);
    }
    
}
