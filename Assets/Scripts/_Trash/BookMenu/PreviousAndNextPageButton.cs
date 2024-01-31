using UnityEngine;
using UnityEngine.UI;

public class PreviousAndNextPageButton : MonoBehaviour
{
    public PanelActivationManager activationManager;
    public GameObject previousPageButton, nextPageButton;

    public GameObject kabanata1to5, kabanata6to10, kabanata11to15, kabanata16to20;
    public int currentPageNumber = 1;

    public void NextPage()
    {
        currentPageNumber++;
        if (currentPageNumber == 2)
        {
            kabanata1to5.SetActive(false);
            kabanata6to10.SetActive(true);
            previousPageButton.SetActive(true);
            
        }
        else if(currentPageNumber == 3){
            kabanata6to10.SetActive(false);
            kabanata11to15.SetActive(true);
        }
        else if(currentPageNumber == 4){
            kabanata11to15.SetActive(false);
            kabanata16to20.SetActive(true);
            nextPageButton.SetActive(false);
        }
    }
    public void PreviousPage(){
        currentPageNumber--;

        if(currentPageNumber == 1){
            kabanata1to5.SetActive(true);
            kabanata6to10.SetActive(false);
            previousPageButton.SetActive(false);
        }
        else if(currentPageNumber == 2){
            kabanata6to10.SetActive(true);
            kabanata11to15.SetActive(false);
            previousPageButton.SetActive(true);
        }
        else if(currentPageNumber == 3){
            kabanata11to15.SetActive(true);
            kabanata16to20.SetActive(false);
            nextPageButton.SetActive(true);
        }
        else if(currentPageNumber == 4){
            kabanata16to20.SetActive(true);
        }
        
    }
    
    public void OnNextButtonClicked()
    {
        // Deactivate all registered objects
        activationManager.DeactivateRegisteredObjects();
    }
}
