using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HouseInsideTrigger : MonoBehaviour
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
            House.SetActive(false);
            Outside.SetActive(true);
            
            playerTransform.position = new Vector3(-10.02f, -0.49f, 0);
        }
    }


}