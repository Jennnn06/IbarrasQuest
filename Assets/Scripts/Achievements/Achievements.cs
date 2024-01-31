using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    public Button aButton;
    public GameObject changeButtonAToStar, changeButtonAToText, controls;
    public GameObject achievementsMenu;
    private bool playerInRange;

    private void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            changeButtonAToStar.SetActive(true);
            changeButtonAToText.SetActive(false);
            aButton.onClick.AddListener(OnUIButtonClick);
        }

    }

    private void OnUIButtonClick(){
        if(playerInRange ==true){
            achievementsMenu.SetActive(true);
            controls.SetActive(false);
            PauseButton.PauseGame();
        }
        

    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            changeButtonAToStar.SetActive(false);
            changeButtonAToText.SetActive(true);
            playerInRange = false;
        }
    }
}
