using UnityEngine;
using UnityEngine.Playables;

public class PlayInstructions : MonoBehaviour
{
    public PlayableDirector IntroductionTimeline;
    public GameObject InstructionsTimeline;
    public GameObject mainCamera;
    public GameObject tutorialCamera;

    private void Start()
    {
        // Play the first timeline
        IntroductionTimeline.Play();
        // Register a callback to detect when the first timeline ends
        IntroductionTimeline.stopped += OnFirstTimelineFinished;
    }

    private void OnFirstTimelineFinished(PlayableDirector director)
    {
        if (director == IntroductionTimeline)
        {
            InstructionsTimeline.SetActive(true);
            tutorialCamera.SetActive(true);
            mainCamera.SetActive(false);
        }
    }
}
