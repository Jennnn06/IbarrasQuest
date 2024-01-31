using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainMenu : MonoBehaviour
{
    public void YesOnClick(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }
    public void YesOnCutscene(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("LoadingScene");
    }
}
