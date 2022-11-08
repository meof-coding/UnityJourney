using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButtonBehavior : MonoBehaviour
{
    private Button btnNext;
    // Start is called before the first frame update
    void Start()
    {
        btnNext = gameObject.GetComponent<Button>();
        //gọi ham click
        btnNext.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick()
    {
        Application.LoadLevel("Sample_2");
    }
}
