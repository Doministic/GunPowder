using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : BaseSingletonBehaviour<GameManager>
{

    private float timeRemaining;
    private float maxTime = 180;

    void Start()
    {
        timeRemaining = maxTime;
    }

    void Update()
    {    
        if(!LevelManager.isPaused)
        {
            timeRemaining -= Time.fixedUnscaledDeltaTime;
        }
		else 
		{
			timeRemaining -= Time.deltaTime;
		}

        if (timeRemaining <= 0 && SceneManager.GetActiveScene().name == "02_Level_DayTime")
        {
			timeRemaining = maxTime;
            SceneManager.LoadScene("03_Win_A");
        }
		else if(timeRemaining <= 0 && SceneManager.GetActiveScene().name == "02_Level_NightTime"){
			timeRemaining = maxTime;
			SceneManager.LoadScene("02_Level_DayTime");
		}
    }

    public float TimeRemaining
    {
        get { return timeRemaining; }
        set { timeRemaining = value; }
    }
}
