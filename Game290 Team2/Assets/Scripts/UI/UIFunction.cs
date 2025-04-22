using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunction : MonoBehaviour
{
    private AudioManager audioManager;
    public CanvasGroup PauseMenu;
    public String startSceneName = "Intro";
    void Start()
    {
        unPauseGame();
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void startGame()
    {
        SceneManager.LoadScene(startSceneName);
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }

    void Update()
    {
        if (PauseMenu != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (PauseMenu.alpha == 0)
                {
                    audioManager.PlayPauseSound();
                    pauseGame();
                }
                else
                {
                    audioManager.PlayUnPauseSound();
                    unPauseGame();
                }
            }

        }
    }
    public void pauseGame()
    {
        PauseMenu.alpha = 1;
        PauseMenu.interactable = true;
        PauseMenu.blocksRaycasts = true;
        Time.timeScale = 0f;
    }
    public void unPauseGame()
    {
        PauseMenu.alpha = 0;
        PauseMenu.interactable = false;
        PauseMenu.blocksRaycasts = false;
        Time.timeScale = 1f;
    }
}