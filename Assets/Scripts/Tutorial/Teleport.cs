using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    public Button aButton;
    public GameObject info, aButtonImage, aButtonText;
    
    public PlayerSaveManager playerSaveManager;
    private bool playerInRange;

    private void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            aButtonImage.SetActive(true);
            aButtonText.SetActive(false);
            aButton.onClick.AddListener(OnUIButtonClick);
            info.SetActive(true);
        }

    }

    private void OnUIButtonClick(){
        if(playerInRange ==true){
          playerSaveManager.SaveNewPlayerData();  
          SceneManager.LoadScene("LoadingScene");
        }
        

    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            aButtonImage.SetActive(false);
            aButtonText.SetActive(true);
            playerInRange = false;
            info.SetActive(false);
        }
    }

}
