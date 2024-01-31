using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseOutsideTrigger : MonoBehaviour
{
    public Button aButton;
    public GameObject exclamation;

    public GameObject House;
    public GameObject Outside;

    //Coordinates
    public Transform playerTransform;

    private bool playerInRange;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Student"))
        {
            playerInRange = true;

            //Set exclamation
            exclamation.SetActive(true);

            aButton.onClick.AddListener(OnUIButtonClick);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Student"))
        {
            playerInRange = false;

            //Set exclamation
            exclamation.SetActive(false);
   
        }
    }

    private void OnUIButtonClick(){
        if (playerInRange == true){
            House.SetActive(true);
            Outside.SetActive(false);
            
            playerTransform.position = new Vector3(-16.38f, -19.60f, 0);
        }
    }
}
