using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MotherFreezeScript : MonoBehaviour
{
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }


    public void Freeze()
    {
        transform.position = initialPosition;
    }
}
