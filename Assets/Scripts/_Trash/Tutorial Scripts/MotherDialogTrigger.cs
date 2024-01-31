using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherDialogTrigger : MonoBehaviour
{

    public Animator anim;
    public GameObject dialog;


   public void OnTriggerEnter2D(Collider2D other){  

        if(other.CompareTag("Mother")){
            dialog.SetActive(true);
            anim.SetFloat("X", 0);
            anim.SetFloat("Y", 1);
        }  

   }

   public void OnTriggerExit2D(Collider2D other){

        if(other.CompareTag("Mother")){
            anim.SetFloat("X", 0);
            anim.SetFloat("Y", 0);
        }
        
   }
   
}
