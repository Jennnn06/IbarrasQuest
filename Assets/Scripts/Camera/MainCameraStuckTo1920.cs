using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraStuckTo1920 : MonoBehaviour
{
    public float targetScreenWidth = 1920f; // Your target screen width
    public float targetScreenHeight = 1080f; // Your target screen height

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        AdjustCameraSize();
    }

    void AdjustCameraSize()
    {
        float targetAspect = targetScreenWidth / targetScreenHeight;
        float currentAspect = (float)Screen.width / Screen.height;

        float orthoSize = mainCamera.orthographicSize;
        orthoSize *= targetAspect / currentAspect;

        mainCamera.orthographicSize = orthoSize;
    }
}
