using UnityEngine;
using UnityEngine.Playables;

public class TimelineMainMenuEnd : MonoBehaviour
{
    public PlayableDirector timeline;
    public GameObject timelineGameObject;

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
        if (timeline.time >= timeline.duration)
        {
            timelineGameObject.SetActive(false);

            // Set a flag to indicate that the timeline has finished
            timelineFinished = true;
        }

    }
}
