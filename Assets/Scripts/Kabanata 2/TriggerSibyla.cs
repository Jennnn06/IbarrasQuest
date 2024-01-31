using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TriggerSibyla : MonoBehaviour
{
    public Button aButton;
    public GameObject dialogSiby, warning, controls;
    private bool playerInRange;

    
    private void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            warning.SetActive(true);
            aButton.onClick.AddListener(OnUIButtonClick);
        }

    }

    private void OnUIButtonClick(){
        if (playerInRange == true){
            dialogSiby.SetActive(true);
            controls.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            warning.SetActive(false);
            
        }
    }

    public void continueB(){
        dialogSiby.SetActive(false);
        controls.SetActive(true);
    }
     

}
