using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonBehaviourScript : MonoBehaviour
{
    private Button btnLevel;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        btnLevel = gameObject.GetComponent<Button>();
        //gọi ham click
        btnLevel.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick()
    {
        if(level == 1)
        {
            Application.LoadLevel("Sample_1");
        }
        if (level == 2)
        {
            Application.LoadLevel("Sample_2");
        }

    }
}
