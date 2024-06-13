using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private float elapsedTime;

    private void Update()
    {
        DisplayTime();
    }


    public void DisplayTime()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime % 60F);
        string RealTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeText.text = RealTime;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
