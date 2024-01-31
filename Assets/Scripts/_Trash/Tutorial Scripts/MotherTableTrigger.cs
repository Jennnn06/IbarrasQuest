using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherTableTrigger : MonoBehaviour
{

    public GameObject mainCamera;
    public GameObject motherCamera;
    public GameObject tl1, tl2, tl3;

    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Mother")){
            mainCamera.SetActive(true);
            motherCamera.SetActive(false);

            tl1.SetActive(false);
            tl2.SetActive(false);
            tl3.SetActive(true);
        }
    }
}
