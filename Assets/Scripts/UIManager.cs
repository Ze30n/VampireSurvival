using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;


    public Text scoreText;
    public Text timeText;
    public Text gameOverText;
    public Button restartButton;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }


    public void UpdateTime(float time)
    {
        timeText.text = "Time: " + Mathf.FloorToInt(time);
    }

    public void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void HideGameOver()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }
}
