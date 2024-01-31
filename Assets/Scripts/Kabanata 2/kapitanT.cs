using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapitanT : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetFloat("X", 0);
        anim.SetFloat("Y", 1);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("X", 0);
        anim.SetFloat("Y", 1);
    }
}
