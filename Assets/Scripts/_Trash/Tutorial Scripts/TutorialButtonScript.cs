using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TutorialButtonScript : MonoBehaviour
{
    public GameObject dialogTutorial;
    public GameObject tl1, tl2, tl3;
    public GameObject controls; 

    public void Continue(){
        
        tl1.SetActive(false);
        tl2.SetActive(false);
        tl3.SetActive(false);
        controls.SetActive(true);
        dialogTutorial.SetActive(false);
        
    }
    
}
