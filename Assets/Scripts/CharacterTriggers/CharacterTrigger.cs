using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTrigger : MonoBehaviour
{
    public Button aButton;
    public GameObject changeButtonAToMsgImage, changeButtonAToText, controls;
    public GameObject dialog;
    private bool playerInRange;


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
        if(playerInRange ==true){
            dialog.SetActive(true);
            controls.SetActive(false);
            PauseButton.PauseGame();
        }
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
