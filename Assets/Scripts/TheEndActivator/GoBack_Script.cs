using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GoBack_Script : MonoBehaviour
{
    public void goBack(){
        SceneManager.LoadScene("LoadingScene");
    }

}
