using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    public Slider slider;

    public Image fillBar;
    public int health;

    //10% health = 1 amount

    public void loseHealth(int value)
    {
        if (health <= 0)
        {
            return;
        }
        //Reduce the health
        health -= value;
        //Refresh UI
        slider.value = health;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        slider.wholeNumbers = true;
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        slider.wholeNumbers = true;
    }
}
