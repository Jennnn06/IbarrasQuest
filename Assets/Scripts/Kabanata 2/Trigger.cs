using UnityEngine;
using UnityEngine.Playables;

public class Trigger : MonoBehaviour
{
    
    public GameObject dialog;
    public PlayableDirector timeline;
    public GameObject timelineGameObject;

    private bool timelineFinished = false;


    void Update(){
        if (timeline.state != PlayState.Playing && !timelineFinished)
        {
            // Keep the GameObject active
            dialog.SetActive(true);

            // Set a flag to indicate that the timeline has finished
            timelineFinished = true;
        }
    }

}
