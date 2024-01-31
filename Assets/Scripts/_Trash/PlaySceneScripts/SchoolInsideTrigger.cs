using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolInsideTrigger : MonoBehaviour
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
            School.SetActive(false);
            Outside.SetActive(true);
            
            playerTransform.position = new Vector3(20.85f, 2.04f, 0);

        }
    }


}
