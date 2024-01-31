using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalabasNgBahay : MonoBehaviour
{   
    public Button aButton;
    public GameObject info, mapButton, controls;
    public GameObject changeButtonAToEnterImage, changeButtonAToText;
    private bool playerInRange;

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            info.SetActive(true);
            changeButtonAToEnterImage.SetActive(true);
            changeButtonAToText.SetActive(false);
            aButton.onClick.AddListener(OnUIButtonClick);
            
        }
    }
    private void OnUIButtonClick(){
        if(playerInRange ==true){
            mapButton.SetActive(true);
            controls.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            changeButtonAToEnterImage.SetActive(false);
            changeButtonAToText.SetActive(true);
            playerInRange = false;
            info.SetActive(false);
        }
    }
}
