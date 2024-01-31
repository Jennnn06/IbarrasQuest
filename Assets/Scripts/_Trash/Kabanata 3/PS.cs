using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;
    void Start()
    {
        anim.SetFloat("X", 1);
        anim.SetFloat("Y", 0);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("X", 1);
        anim.SetFloat("Y", 0);
    }
}
