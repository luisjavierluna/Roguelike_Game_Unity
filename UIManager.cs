using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] Text scoreText, healthText, timeText;

    [SerializeField] Text finalScoreText;

    [SerializeField] GameObject gameOverScreen;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void UpdateScoreText(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

    public void UpdateHealthText(int newHealth)
    {
        healthText.text = newHealth.ToString();
    }

    public void UpdateTimeText(int newTime)
    {
        timeText.text = newTime.ToString();
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        finalScoreText.text = GameManager.instance.Score.ToString();
    }
}
