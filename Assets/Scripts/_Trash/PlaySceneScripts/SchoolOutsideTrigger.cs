using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolOutsideTrigger : MonoBehaviour
{
    public Button aButton;
    public GameObject exclamation;

    public GameObject School;
    public GameObject Outside;

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
            School.SetActive(true);
            Outside.SetActive(false);
            
            playerTransform.position = new Vector3(-22.99f, -9.05f, 0);

            //20.85 2.04
        }
    }
}
