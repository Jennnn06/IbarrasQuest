using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSiby : MonoBehaviour
{
    public GameObject dialogSiby;
    public GameObject triggerDamaso, triggerSibyla, controls;

    public void continueB(){
        dialogSiby.SetActive(false);
        triggerDamaso.SetActive(true);
        triggerSibyla.SetActive(false);
        controls.SetActive(true);
    }
}
