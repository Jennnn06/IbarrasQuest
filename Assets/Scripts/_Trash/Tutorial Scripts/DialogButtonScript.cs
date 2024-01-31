using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialogButtonScript : MonoBehaviour
{
    public GameObject dialog;
    public GameObject tl1, tl2;
    public Animator anim;

    public void Close()
    {
        tl2.SetActive(true);
        dialog.SetActive(false);
        anim.SetFloat("X", 0);
        anim.SetFloat("Y", -1);
    }


}
