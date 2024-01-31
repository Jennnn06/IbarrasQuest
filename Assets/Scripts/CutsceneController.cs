using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    private PlayableDirector currentCutscene;
    private bool isPaused = false;
    private const string cutsceneKey = "CutsceneState";

    // Method to pause the cutscene
    public void PauseCutscene()
    {
        if (currentCutscene != null && !isPaused)
        {
            currentCutscene.Pause();
            isPaused = true;
            PlayerPrefs.SetInt(cutsceneKey, isPaused ? 1 : 0);
        }
    }

    // Method to continue the cutscene
    public void ContinueCutscene()
    {
        if (currentCutscene != null && isPaused)
        {
            currentCutscene.Play();
            isPaused = false;
            PlayerPrefs.SetInt(cutsceneKey, isPaused ? 1 : 0);
        }
    }

    // Method to find and set the current cutscene
    private void FindCurrentCutscene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        GameObject[] rootObjects = currentScene.GetRootGameObjects();

        foreach (GameObject gameObject in rootObjects)
        {
            // Check if the object contains a PlayableDirector component
            PlayableDirector cutscene = gameObject.GetComponent<PlayableDirector>();
            if (cutscene != null)
            {
                // You've found the cutscene in the scene
                currentCutscene = cutscene;
                break; // Exit the loop after finding the first cutscene
            }
        }
    }

    // Call this method when you want to pause the cutscene
    public void OnPauseButtonClick()
    {
        FindCurrentCutscene();
        PauseCutscene();
    }

    // Call this method when you want to continue the cutscene
    public void OnContinueButtonClick()
    {
        FindCurrentCutscene();
        ContinueCutscene();
    }
}
