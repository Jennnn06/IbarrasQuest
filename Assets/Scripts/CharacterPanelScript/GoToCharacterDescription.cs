using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCharacterDescription : MonoBehaviour
{
    public GameObject CharactersMenu;
    public GameObject Desc;

    public void goDesc(){
        Desc.SetActive(true);
        CharactersMenu.SetActive(false);
    }
}
