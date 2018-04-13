using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : BaseSingletonBehaviour<GameManager>
{
    private float timeRemaining;
    private float maxTime = 180;
    private int nightTimeCount;

    void Start()
    {
        print("I Reset");
        nightTimeCount = 0;
        //timeRemaining = maxTime;
        if (TimeRemaining < maxTime)
        {
            timeRemaining = maxTime;
        }
    }

    void Update()
    {
        if (!LevelManager.isPaused)
        {
            timeRemaining -= Time.unscaledDeltaTime;
        }
        else
        {
            timeRemaining -= Time.deltaTime;
        }

        if (timeRemaining <= 0 && SceneManager.GetActiveScene().name == "02_Level_DayTime")
        {
            timeRemaining = maxTime;
            SceneManager.LoadScene("02_Level_NightTime");
        }
        else if (timeRemaining <= 0 && SceneManager.GetActiveScene().name == "02_Level_NightTime")
        {
            nightTimeCount++;
            if (nightTimeCount >= 14)
            {
                WinGame();
            }
            timeRemaining = maxTime;
            SceneManager.LoadScene("02_Level_DayTime");

        }
    }

    public float TimeRemaining
    {
        get { return timeRemaining; }
        set { timeRemaining = value; }
    }

    public void WinGame()
    {
        SceneManager.LoadScene("03_Win_A");
    }
}
