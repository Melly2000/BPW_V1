using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPaused;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject resumeButton;

    void Update()
    {
        if (Input.GetKeyDown("escape") && !isPaused)
        {
            Pause();
        }
        else if (Input.GetKeyDown("escape") && isPaused)
        {
            Resume();
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene("Tutorial");
        Debug.Log("Play");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        restartButton.SetActive(false);
        resumeButton.SetActive(true);
        gameOverUI.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        restartButton.SetActive(true);
        resumeButton.SetActive(false);
        gameOverUI.SetActive(false);
        Debug.Log("Resume");
    }
}
