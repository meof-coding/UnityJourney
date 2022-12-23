using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public TMP_Text pointsText;
    public void Setup(int score)
    {
        gameOverUI.SetActive(true);
        pointsText.text = score.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Sample_2");
    }

}
