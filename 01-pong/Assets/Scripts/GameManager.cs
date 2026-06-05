using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public System.Action onReset;
    //очки
    public int scorePlayer1, scorePlayer2;
    //компоненты очков
    public ScoreText scoreText1, scoreText2;

    private void Awake()
    {
        if (Instance)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void OnScoreZoneReached(int id)
    {
        //if (onReset != null)
        //onReset.Invoke();

        onReset?.Invoke();

        //прибавление очков с условием по айди
        if (id == 1)
            scorePlayer1++;
        else if (id == 2)
            scorePlayer2++;

        //обновление очков визуально
        UpdateScores();
    }

    private void UpdateScores()
    {
        scoreText1.SetScore(scorePlayer1);
        scoreText2.SetScore(scorePlayer2);

    }
}
