using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanel, SettingsPanel, AfterPlayPanel, CharactersMenu;

    public void MainMenuPlay(){
        MainMenuPanel.SetActive(false);
        AfterPlayPanel.SetActive(true);
    }

    public void AfterPlayPlay(){
        SceneManager.LoadScene("LoadingScene");
    }
    public void AfterPlayPanelClose(){
        AfterPlayPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void AfterPlayGoCharacter(){
        AfterPlayPanel.SetActive(false);
        CharactersMenu.SetActive(true);
    }
    public void AfterPlayExitCharacter(){
        AfterPlayPanel.SetActive(true);
        CharactersMenu.SetActive(false);
    }
    

    public void SettingsOpen(){
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void SettingsClose(){
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
