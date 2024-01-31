using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class timeline1end : MonoBehaviour
{
    public PlayableDirector timeline;
    public Animator anim;
    public GameObject dialog;
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
            anim.SetFloat("X", 0);
            anim.SetFloat("Y", 1);
            // Keep the GameObject active
            dialog.SetActive(true);
            
            // Set a flag to indicate that the timeline has finished
            timelineFinished = true;
        }

    }
}
