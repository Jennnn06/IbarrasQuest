using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDamaso : MonoBehaviour
{
    public Button aButton;
    public Animator damasoAnim;
    public GameObject warning, warningNiDamaso, triggerDamaso, dialogIbarra, controls;
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
        if(playerInRange ==true){
            damasoAnim.SetFloat("X", 0);
            damasoAnim.SetFloat("Y", 1);
            warningNiDamaso.SetActive(true);
            triggerDamaso.SetActive(false);
            dialogIbarra.SetActive(true);
            controls.SetActive(false);
        }
        

    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            warning.SetActive(false);
            playerInRange = false;
        }
    }

}
