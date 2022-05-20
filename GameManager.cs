using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (score % 1000 == 0)
            {
                difficulty++;
            }
        }
    }

    private void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(CountDownRoutine());
    }

    IEnumerator CountDownRoutine()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            if (time == 0) Debug.Log("Game Over");
        }
    }
}