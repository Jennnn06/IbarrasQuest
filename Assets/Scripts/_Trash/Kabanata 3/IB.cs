using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IB : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {
        anim.SetFloat("X", 0);
        anim.SetFloat("Y", -1);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("X", 0);
        anim.SetFloat("Y", -1);
    }
}
