using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PlayInstructionsDialog : MonoBehaviour
{
    public PlayableDirector InstructionsTimeline;
    public GameObject panelOfInstructions;

    private void Start()
    {
        // Play the first timeline
        InstructionsTimeline.Play();
        // Register a callback to detect when the first timeline ends
        InstructionsTimeline.stopped += OnFirstTimelineFinished;
    }

    private void OnFirstTimelineFinished(PlayableDirector director)
    {
        if (director == InstructionsTimeline)
        {
            //activate instructions
            panelOfInstructions.SetActive(true);
        }
    }

}
