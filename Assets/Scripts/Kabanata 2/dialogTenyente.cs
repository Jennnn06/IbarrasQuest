using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogTenyente : MonoBehaviour
{
    public GameObject dialogTen, dialogNarrator;
    public void continueB(){
        dialogTen.SetActive(false);
        dialogNarrator.SetActive(true);
    }
    
}
