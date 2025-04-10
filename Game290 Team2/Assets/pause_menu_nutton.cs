using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu_nutton : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private bool isMuted = false;
    public static bool isPaused;

    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        SceneManager.LoadScene("main_menu");
        Time.timeScale = 1;
    }

    public void resume()
    {
        Debug.Log("Resume" + Time.timeScale);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void mute()
    {
        ToggleMute();
    }

    private void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0 : 1;
    }
}

