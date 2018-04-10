using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool isRealTimePaused = false;

    private GameObject pauseMenuUI;
    private float timeDelay = 5.0f;


    void Start()
    {
        float autoLoadNextLevel = 3.5f;
        pauseMenuUI = GameObject.Find("PauseMenu");

        if (SceneManager.GetActiveScene().buildIndex > 2)
        {
            if (pauseMenuUI != null)
            {
                pauseMenuUI.SetActive(false);
            }
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevel);
            pauseMenuUI = null;
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
                Debug.Log("Resume");
                Resume();
            }
    }

    void FixedUpdate()
    {
       
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

    public void RealTimePause(){
        Time.timeScale = 0;
        isRealTimePaused = true;
        timeDelay = 5.0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
