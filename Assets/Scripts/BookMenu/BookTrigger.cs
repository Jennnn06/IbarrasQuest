using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BookTrigger : MonoBehaviour
{
    public Button aButton;
    public GameObject changeButtonAToBookImage, changeButtonAToText, controls;
    public GameObject bookMenu;
    private bool playerInRange;

    private void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            changeButtonAToBookImage.SetActive(true);
            changeButtonAToText.SetActive(false);
            aButton.onClick.AddListener(OnUIButtonClick);
        }

    }

    private void OnUIButtonClick(){
        if(playerInRange ==true){
            bookMenu.SetActive(true);
            controls.SetActive(false);
            PauseButton.PauseGame();
        }
        

    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            changeButtonAToBookImage.SetActive(false);
            changeButtonAToText.SetActive(true);
            playerInRange = false;
        }
    }


}
