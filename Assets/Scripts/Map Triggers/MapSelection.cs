using UnityEngine;
using UnityEngine.UI;

public class MapSelection : MonoBehaviour
{
    public Button[] mapButtons;
    public GameObject[] mapImages;

    private int selectedMapIndex = -1;

    private void Start()
    {
        // Hide all map images at the start
        foreach (GameObject mapImage in mapImages)
        {
            mapImage.SetActive(false);
        }

        // Add onClick listeners to map buttons
        for (int i = 0; i < mapButtons.Length; i++)
        {
            int index = i; // Capturing the index to avoid closure issues in the listener
            mapButtons[i].onClick.AddListener(() => SelectMap(index));
        }

        // Load the selected map if it was previously saved
        selectedMapIndex = PlayerPrefs.GetInt("SelectedMap", -1);
        if (selectedMapIndex != -1)
        {
            mapImages[selectedMapIndex].SetActive(true);
        }
    }

    public void SelectMap(int index)
    {
        // Hide previously selected map, if any
        if (selectedMapIndex != -1)
        {
            mapImages[selectedMapIndex].SetActive(false);
        }

        // Show the selected map image
        mapImages[index].SetActive(true);

        // Save the selection to PlayerPrefs
        PlayerPrefs.SetInt("SelectedMap", index);
        PlayerPrefs.Save();

        // Update the selectedMapIndex
        selectedMapIndex = index;
    }
}