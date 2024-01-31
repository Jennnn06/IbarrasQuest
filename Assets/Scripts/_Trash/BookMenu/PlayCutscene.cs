using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayCutscene : MonoBehaviour
{
    private string sceneToLoad;

    public void SetSceneToLoad(string sceneName)
    {
        sceneToLoad = sceneName;
    }

    public void OnPlayButtonClicked()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
