using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGoBack : MonoBehaviour
{
    public GameObject characterMenu, characterDesc;

    public void goBackCharacter(){
        characterMenu.SetActive(true);
        characterDesc.SetActive(false);
    }
}
