using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetButtonBehaviourScript : MonoBehaviour
{
    private Button btnReset;
    // Start is called before the first frame update
    void Start()
    {
        btnReset = gameObject.GetComponent<Button>();
        //gọi ham click
        btnReset.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TaskOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
