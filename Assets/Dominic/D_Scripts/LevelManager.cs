﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
     public static bool isPaused = false;
    public static bool isRealTimePaused = false;

    private GameObject pauseMenuUI;
    private GameObject realTimePauseUI;
    private float timeDelay;


    void Start()
    {
        float autoLoadNextLevel = 3.5f;
        pauseMenuUI = GameObject.Find("PauseMenu");
        realTimePauseUI = GameObject.Find("RealTimePause");
        
        if (SceneManager.GetActiveScene().buildIndex > 2)
        {
            
            if (pauseMenuUI != null)
            {
                pauseMenuUI.SetActive(false);
            }

            if(realTimePauseUI != null){
                realTimePauseUI.SetActive(false);
            }
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevel);
            pauseMenuUI = null;
            realTimePauseUI = null;
        }
    }

    void Update()
    {
        timeDelay -= Time.unscaledDeltaTime;

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            RealTimePause();
        }
        // Debug.Log(timeDelay);
        if (isRealTimePaused && timeDelay <= 0)
        {
            Resume();
            realTimePauseUI.SetActive(false);
        }
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        isRealTimePaused = false;
        timeDelay = 5.0f;
    }

    public void RealTimePause()
    {
        realTimePauseUI.SetActive(true);
        Time.timeScale = 0;
        timeDelay = 5.0f;
        isRealTimePaused = true;
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
