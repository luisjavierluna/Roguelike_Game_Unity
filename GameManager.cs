using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int time = 50;

    public int difficulty = 1;

    [SerializeField] int score;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            UIManager.instance.UpdateScoreText(score);
            if (score % 1000 == 0)
            {
                difficulty++;
            }
        }
    }

    public bool gameOver;

    private void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        UIManager.instance.UpdateScoreText(score);
        UIManager.instance.UpdateTimeText(time);

        StartCoroutine(CountDownRoutine());
    }

    IEnumerator CountDownRoutine()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            UIManager.instance.UpdateTimeText(time);
            if (time == 0)
            {
                gameOver = true;
                UIManager.instance.ShowGameOverScreen();
            }
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
}