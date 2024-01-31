using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continueButton : MonoBehaviour
{
    public GameObject dialog, controls;

    public void continueB(){
        dialog.SetActive(false);

        controls.SetActive(true);
    }
    
}
