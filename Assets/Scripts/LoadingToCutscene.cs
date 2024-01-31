using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class LoadingToCutscene : MonoBehaviour
{
   public TextMeshProUGUI loadingText;
    public TextMeshProUGUI triviaText;
    public GameObject playerPrefab;
    private Animator playerAnimator;

    private string[] triviaArray = {
        "Trivia: Alam mo bang nakabase ang mga karakter ng Noli Me Tangere sa mga taong malalapit kay Dr. Jose Rizal?",
        "Trivia: Alam mo bang may isa pang chapter na hindi naisama sa pagpupublish ng Noli Me Tangere? Ang tunay na chapter 25 ay may pangalang Elias and Salome",
        "Trivia: Alam mo bang binan sa China ang librong ito?",
    };

    
    private void Start()
    {
        // Start loading the main game scene asynchronously
        playerAnimator = playerPrefab.GetComponent<Animator>();
        playerAnimator.SetFloat("X", 1f);
        StartCoroutine(LoadMainGameScene());
        StartCoroutine(ChangeTrivia());
    }

    private IEnumerator LoadMainGameScene()
    {
        AsyncOperation operation;
        bool hasSaveFile = File.Exists(Application.persistentDataPath + "/playerData.json");

        string sceneName = PlayerPrefs.GetString("SceneName");
        operation = SceneManager.LoadSceneAsync(sceneName);

        operation.allowSceneActivation = false;
        playerAnimator.SetBool("IsMoving", true);
        
        while (!operation.isDone)
        {
            if (operation.progress >= 0.9f)
            {
                loadingText.text = "Loading " +  Mathf.FloorToInt(operation.progress * 100) + "%";
                yield return new WaitForSeconds(6f);

                operation.allowSceneActivation = true;
                
            }
            else
            {
                loadingText.text = "Loading " + Mathf.FloorToInt(operation.progress * 100) + "%";
            }

            yield return null;
        }
        playerAnimator.SetBool("IsMoving", false);
    }

    private IEnumerator ChangeTrivia()
    {
        while (true)
        {
            // Get a random trivia
            string randomTrivia = GetRandomTrivia();

            // Update triviaText with the random trivia
            triviaText.text = randomTrivia;

            // Wait for 2 seconds before changing to the next trivia
            yield return new WaitForSeconds(4f);
        }
    }

    private string GetRandomTrivia()
    {
        int randomIndex = Random.Range(0, triviaArray.Length);
        return triviaArray[randomIndex];
    }
}
