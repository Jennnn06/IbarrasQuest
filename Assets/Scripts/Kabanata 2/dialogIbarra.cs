using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogIbarra : MonoBehaviour
{
    public GameObject dialogNiIbarra, dialogNiTenyente;
    public Animator tenyenteGuevarra, Ibarra;

    public void continueB(){
        dialogNiIbarra.SetActive(false);
        tenyenteGuevarra.SetFloat("X", -1);
        tenyenteGuevarra.SetFloat("Y", 0);
        Ibarra.SetFloat("X", 1);
        Ibarra.SetFloat("Y", 0);
        dialogNiTenyente.SetActive(true);
    }
}
