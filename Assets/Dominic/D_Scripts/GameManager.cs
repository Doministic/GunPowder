using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : BaseSingletonBehaviour<GameManager>
{
    public float maxTime = 182;
    
    private float timeRemaining;
    private int nightTimeCount;

    void Start()
    {     
        nightTimeCount = 0;
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
            if (nightTimeCount >= 3)
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
