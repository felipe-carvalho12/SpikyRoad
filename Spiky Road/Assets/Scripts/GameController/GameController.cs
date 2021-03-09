using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] Text textScore;
    float score;
    public static bool gameOver;

    private void Start()
    {
        Time.timeScale = 1;
        gameOver = false;
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
        }
        else
        {
            textScore.text = $"{Mathf.Floor(score)}";
            score += .1f;
        }
    }
}
