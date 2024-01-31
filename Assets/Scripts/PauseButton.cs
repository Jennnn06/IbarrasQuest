using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseMenu, controls;
    public static bool isPaused;

    public void pauseMenuOpen(){
        pauseMenu.SetActive(true);
        controls.SetActive(false);
        PauseGame();
    }

    public void pauseMenuClose(){
        pauseMenu.SetActive(false);
        controls.SetActive(true);
        ResumeGame();
    }

    public static void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
    

    public static bool IsPaused()
    {
        return isPaused;
    }
}
