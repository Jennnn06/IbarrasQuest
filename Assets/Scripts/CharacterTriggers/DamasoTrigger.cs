using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamasoTrigger : MonoBehaviour
{
    public Button aButton;
    public GameObject changeButtonAToMsgImage, changeButtonAToText, controls;
    public GameObject dialog, dialogDamasoNew;
    private bool playerInRange;
    private int clickCount;



    private void Start()
    {
        // Load the click count from PlayerPrefs
        clickCount = PlayerPrefs.GetInt("ButtonClickCount", 0);
        
    }

    private void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            changeButtonAToMsgImage.SetActive(true);
            changeButtonAToText.SetActive(false);
            aButton.onClick.AddListener(OnUIButtonClick);
        }

    }

    private void OnUIButtonClick(){
        if (playerInRange == true && clickCount < 4)
        {
            dialog.SetActive(true);
            controls.SetActive(false);

            // Increment clickCount when it's less than 4
            clickCount++;
            PlayerPrefs.SetInt("ButtonClickCount", clickCount);
            PlayerPrefs.Save();
            PauseButton.PauseGame();
        }
        else if (playerInRange == true && clickCount == 4)
        {
            // Increment clickCount to 5 and activate the new dialog
            clickCount++;
            PlayerPrefs.SetInt("ButtonClickCount", clickCount);
            PlayerPrefs.Save();
            dialogDamasoNew.SetActive(true);
            dialog.SetActive(false);
            controls.SetActive(false);
            PauseButton.PauseGame();
        }
        else if (playerInRange == true && clickCount == 5)
        {
            // If clickCount is already 5, activate the new dialog
            dialogDamasoNew.SetActive(true);
            dialog.SetActive(false);
            controls.SetActive(false);
            PauseButton.PauseGame();
        }
        Debug.Log(clickCount);
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            changeButtonAToMsgImage.SetActive(false);
            changeButtonAToText.SetActive(true);
            playerInRange = false;
        }
    }


}
