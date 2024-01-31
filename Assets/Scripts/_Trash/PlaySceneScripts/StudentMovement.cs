using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StudentMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public Animator anim;
    public float moveSpeed;

    public float x, y;
    private bool isWalking;
    
    private Vector3 moveDir;

    public FixedJoystick joystick;
    public GameObject DPAD, joystickGameObject;
   
    public SettingsData settingsData;


    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update(){
        if(joystickGameObject.activeInHierarchy){
            x = joystick.Horizontal;
            y = joystick.Vertical;

            ToMoveAnimation();
        }
        else if(DPAD.activeInHierarchy){
            ToMoveAnimation();
        }  
    }

    public void OnButtonUp(){
        x=0;
        y=0;
    }
    private void ToMoveAnimation(){
        if(x !=0 || y !=0){
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);

            if(!isWalking){
                isWalking = true;
                anim.SetBool("IsMoving", isWalking);
            }
        }
        else{
            if(isWalking){
                isWalking = false;
                anim.SetBool("IsMoving", isWalking);
                StopMoving();
                }   
            }
            moveDir = new Vector3(x, y).normalized;
    }

    private void FixedUpdate(){
        rb.velocity = moveDir * moveSpeed * Time.deltaTime;
    }

    private void StopMoving(){
        rb.velocity = Vector3.zero;
    }

    public void OnPressedUpButton(){
        y = 1;
    }
    
    public void OnPressedDownButton(){
        y = -1;
    }

    public void OnPressedLeftButton(){
        x = -1;
    }

    public void OnPressedRightButton(){
        x = 1;
    }

    private bool IsGameObjectActive(GameObject go)
    {
        return go != null && go.activeInHierarchy;
    }
}
