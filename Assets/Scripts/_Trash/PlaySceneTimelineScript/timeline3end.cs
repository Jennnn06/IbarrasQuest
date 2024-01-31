using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class timeline3end : MonoBehaviour
{
    public GameObject tutorialGameObject;
    public PlayableDirector timeline3;
    private bool timelineFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        timeline3.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeline3.state != PlayState.Playing && !timelineFinished)
        {
            // Keep the GameObject active
            tutorialGameObject.SetActive(true);
            
            // Set a flag to indicate that the timeline has finished
            timelineFinished = true;
        }
    }
}
