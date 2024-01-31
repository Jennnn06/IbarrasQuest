using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogNarrator : MonoBehaviour
{
    public GameObject timeline1, timeline2, dialogNiNarrator;

    public void continueB(){
        timeline1.SetActive(false);
        timeline2.SetActive(true);
        dialogNiNarrator.SetActive(false);
    }
}
