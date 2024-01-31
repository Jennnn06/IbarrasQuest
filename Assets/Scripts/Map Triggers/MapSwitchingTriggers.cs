using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSwitchingTriggers : MonoBehaviour
{
    public Button aButton;
    public Transform player;
    public float x, y;
    public GameObject info;
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
            player.position = new Vector3(x, y, 0);
        }
        

    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            changeButtonAToText.SetActive(true);
            changeButtonAToEnterImage.SetActive(false);
            playerInRange = false;
            info.SetActive(false);
        }
    }

}
