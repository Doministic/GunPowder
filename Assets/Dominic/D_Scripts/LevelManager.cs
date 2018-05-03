using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Image realTimePauseImage;
    public static bool isPaused = false;
    public static bool isRealTimePaused = false;

    GameManager gameManager;
    private GameObject pauseMenuUI;
    private GameObject realTimePauseUI;
    private float timeDelay = 5;
    private float realTimeWaitTime = 10.0f;

    void Start()
    {
        pauseMenuUI = GameObject.Find("PauseMenu");
        realTimePauseUI = GameObject.Find("RealTimePause");
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().buildIndex > 2 || SceneManager.GetActiveScene().name == "02_Level_DayTime")
        {
            if (pauseMenuUI != null)
            {
                pauseMenuUI.SetActive(false);
            }
            if (realTimePauseUI != null)
            {
                realTimePauseUI.SetActive(false);
            }
        }
        else
        {
            float autoLoadNextLevel = 3.5f;
            Invoke("LoadNextLevel", autoLoadNextLevel);
            pauseMenuUI = null;
            realTimePauseUI = null;
            realTimePauseImage = null;
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
        else if (Input.GetKeyDown(KeyCode.Space) && realTimePauseImage.fillAmount == 1)
        {
            RealTimePause();
        }

        if (isRealTimePaused && realTimePauseImage.fillAmount <= 0)
        {
            Resume();
            realTimePauseUI.SetActive(false);
        }

        if (isRealTimePaused)
        {
            realTimePauseImage.fillAmount -= 1.5f / realTimeWaitTime * Time.unscaledDeltaTime;
        }
        else if (!isRealTimePaused && realTimePauseImage.fillAmount >= 0)
        {
            realTimePauseImage.fillAmount += 0.5f / realTimeWaitTime * Time.unscaledDeltaTime;
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
    }

    public void RealTimePause()
    {
        realTimePauseUI.SetActive(true);
        Time.timeScale = 0;
        isRealTimePaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
