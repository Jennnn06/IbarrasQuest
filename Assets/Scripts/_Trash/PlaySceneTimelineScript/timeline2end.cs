using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class timeline2end : MonoBehaviour
{
    public PlayableDirector timeline2;
    public GameObject timeline3, mainCamera, motherCamera;
    private bool timelineFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        timeline2.Play();
    }

    // Update is called once per frame
    void Update()
    {
         // Check if the timeline has finished playing
        if (timeline2.state != PlayState.Playing && !timelineFinished)
        {
            // Keep the GameObject active
            timeline3.SetActive(true);
            mainCamera.SetActive(true);
            motherCamera.SetActive(false);
            
            // Set a flag to indicate that the timeline has finished
            timelineFinished = true;
        }
    }
}
