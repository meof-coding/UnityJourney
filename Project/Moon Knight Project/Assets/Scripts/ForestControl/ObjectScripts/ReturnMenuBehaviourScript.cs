using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnMenuBehaviourScript : MonoBehaviour
{
    private Button btnReturn;
    // Start is called before the first frame update
    void Start()
    {
        btnReturn = gameObject.GetComponent<Button>();
        //gọi ham click
        btnReturn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TaskOnClick()
    {
        Application.LoadLevel("MainMenu");
    }
}
