using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneActivatorForTriggers : MonoBehaviour
{   
    public GameObject information,cutscenebtnGameObject;
    public Button cutsceneButton;
    public String sceneName;
    private bool playerInRange;

    public void OnTriggerEnter2D(Collider2D other){
     if (other.CompareTag("Player"))
        {
            playerInRange = true;
            information.SetActive(true);
            cutscenebtnGameObject.SetActive(true);
            cutsceneButton.onClick.AddListener(OnUIButtonClick);
        }

    }

    private void OnUIButtonClick(){
        if(playerInRange ==true){
            PlayerPrefs.SetString("SceneName", sceneName);
            SceneManager.LoadScene("LoadingToCutscenes");
        }
        

    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            information.SetActive(false);
            playerInRange = false;
            cutscenebtnGameObject.SetActive(false);
        }
    }

}
