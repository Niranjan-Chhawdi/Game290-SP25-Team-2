using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunction : MonoBehaviour
{
    public CanvasGroup PauseMenu;
    public String startSceneName = "Intro";
    void Start()
    {
        unPauseGame();
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
                    pauseGame();
                }
                else
                {
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