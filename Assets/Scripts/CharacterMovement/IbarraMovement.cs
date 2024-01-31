using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IbarraMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public Animator anim;
    public float moveSpeed;
    private float modifiedSpeed = 500f; 

    public float x, y;
    private bool isWalking;
    
    private Vector3 moveDir;

    public FixedJoystick joystick;
    public Button[] dPadButtons;
    public GameObject DPAD, joystickGameObject;
   
    public SettingsData settingsData;


    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update(){
        if(!PauseButton.IsPaused()){
            if(joystickGameObject.activeInHierarchy){
                x = joystick.Horizontal;
                y = joystick.Vertical;

                ToMoveAnimation();
            }
            else if(DPAD.activeInHierarchy){
                ToMoveAnimation();
            }
        }
        else{
            OnButtonUp();
            StopMoving();
            OnBButtonPointerUp();
            anim.SetBool("IsIdle", true);
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

    public void StopMoving(){
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

    public void OnBButtonPointerDown()
    {
        moveSpeed = modifiedSpeed;
    }

    public void OnBButtonPointerUp()
    {
        moveSpeed = 300f; // Change movement speed back to normal when B button is released
    }

}
