using UnityEngine;
using UnityEngine.Playables;

public class TheEndActivator : MonoBehaviour
{
    public PlayableDirector timeline;
    public GameObject theEnd;
    private bool timelineFinished = false;
    private bool alreadyActivated = false;
    private const string cutsceneKey = "CutsceneState";

    // Start is called before the first frame update
    void Start()
    {
        timeline.Play();
        PlayerPrefs.DeleteKey(cutsceneKey);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the timeline has finished playing and is not paused
        if (timeline.state != PlayState.Playing && !timelineFinished &&
            PlayerPrefs.GetInt(cutsceneKey, 0) == 0 && !alreadyActivated)
        {
            // Keep the GameObject active
            theEnd.SetActive(true);

            // Set a flag to indicate that the timeline has finished
            timelineFinished = true;
            alreadyActivated = true;
        }
        else if (timelineFinished && PlayerPrefs.GetInt(cutsceneKey, 0) == 1)
        {
            // If the timeline finished but cutscene was paused, deactivate the end sequence
            theEnd.SetActive(false);
        }
    }
}
