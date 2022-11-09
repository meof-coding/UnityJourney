using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarButtonBehavior : MonoBehaviour
{
    private Button btnPlay;
    // Start is called before the first frame update
    void Start()
    {
        btnPlay = gameObject.GetComponent<Button>();
        //gọi ham click
        btnPlay.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick()
    {
        Application.LoadLevel("LevelMenu");
    }
}
