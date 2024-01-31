using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TheEndForKab2 : MonoBehaviour
{
    public PlayableDirector timeline;
    public GameObject theEnd;
    private bool timelineFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        timeline.Play();
    }

     // Update is called once per frame
    void Update()
    {
        // Check if the timeline has finished playing
        if (timeline.state != PlayState.Playing && !timelineFinished)
        {
            // Keep the GameObject active
            theEnd.SetActive(true);

            // Set a flag to indicate that the timeline has finished
            timelineFinished = true;
        }
    }
}
