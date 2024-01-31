using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BookKabanata : MonoBehaviour
{
    public GameObject tableOfContents;
    public GameObject chapterPanel;
    public Button[] tableOfContentsButtons; // An array to hold the 7 buttons in the Table of Contents.
    public Button[] chapterButtons; // An array to hold the 10 Chapter Buttons.
    public TMP_Text[] chapterButtonTexts; // An array to hold the TMP Text components of the 10 buttons in Chapter Buttons.

    public GameObject[] gameObjectsToToggle; // An array to hold the 6 game objects to toggle (disable/enable).
    public Button nextChapterButton; // Assign the "Next" button for navigating to the next set of chapters.
    public Button backChapterButton; // Assign the "Back" button for navigating to the previous set of chapters.

    private int currentChapterSet = 0; // Track the current chapter set.


    private void Start()
    {
        // Attach a common click event to all the buttons in the table of contents array.
        for (int i = 0; i < tableOfContentsButtons.Length; i++)
        {
            int rangeStart = (i * 10) + 1;
            int rangeEnd = (i + 1) * 10;
            int index = i;

            tableOfContentsButtons[i].onClick.AddListener(() =>
            {
                ShowChapterButtons(rangeStart, rangeEnd, index);
            });
        }

        // Attach click events to the Chapter Buttons to load scenes based on button text.
        for (int i = 0; i < chapterButtons.Length; i++)
        {
            int chapterIndex = i;
            chapterButtons[i].onClick.AddListener(() =>
            {
                LoadSceneFromButtonText(chapterButtonTexts[chapterIndex].text);
            });
        }

         // Attach click events to the "Next" and "Back" buttons.
        nextChapterButton.onClick.AddListener(ShowNextChapterSet);
        backChapterButton.onClick.AddListener(ShowPreviousChapterSet);

        // Initially, disable the "Next" and "Back" buttons if there are no more sets of chapters to show.
        UpdateButtonInteractability();
    }

    private void ShowChapterButtons(int startChapter, int endChapter, int buttonIndex)
    {
        // Activate the "Chapter Buttons" and deactivate the "Table of Contents."
        chapterPanel.SetActive(true);
        tableOfContents.SetActive(false);

        // Update the text of the 10 chapter buttons based on the selected range using TMP Text components.
        for (int i = 0; i < chapterButtonTexts.Length; i++)
        {
            int chapter = startChapter + i;
            chapterButtonTexts[i].text = $"Kabanata {chapter}";
        }

        // If the button index is less than 6, trigger the OnBackOrExitButtonClicked() method.
        if (buttonIndex <= 5)
        {
            OnBackOrExitButtonClicked();
        }
        else if (buttonIndex == tableOfContentsButtons.Length - 1)
        {
            foreach (var gameObjectToToggle in gameObjectsToToggle)
            {
                if (gameObjectToToggle.activeSelf)
                {
                    gameObjectToToggle.SetActive(false);
                }
            }
        }
        // Update the current chapter set based on the button index.
        currentChapterSet = buttonIndex;
        UpdateButtonInteractability();
    }

    public void OnBackOrExitButtonClicked(){
        // Handle back button click, re-enable the specified game objects.
        foreach (var gameObjectToToggle in gameObjectsToToggle)
        {
            gameObjectToToggle.SetActive(true);
        }
    }

    private void LoadSceneFromButtonText(string buttonText)
    {
        // Replace "Kabanata " to get the chapter number from the button text.
        string chapterNumber = buttonText.Replace("Kabanata ", "");

        // Load a scene based on the chapter number.
        int sceneToLoad;
        if (int.TryParse(chapterNumber, out sceneToLoad))
        {
            string sceneName = "Kabanata" + sceneToLoad;
            PlayerPrefs.SetString("SceneName", sceneName);
            SceneManager.LoadScene("LoadingToCutscenes");
        }
    }
    private void ShowNextChapterSet()
    {
        // Increment the current chapter set.
        currentChapterSet++;

        // Calculate the start and end chapters for the next set.
        int startChapter = currentChapterSet * 10 + 1;
        int endChapter = (currentChapterSet + 1) * 10;

        // Update the text of the 10 chapter buttons for the next set.
        for (int i = 0; i < chapterButtonTexts.Length; i++)
        {
            int chapter = startChapter + i;
            chapterButtonTexts[i].text = $"Kabanata {chapter}";
        }

        // Update the interactability of the "Next" and "Back" buttons based on the current chapter set.
        UpdateButtonInteractability();
        // If it's the last chapter set, toggle off the 6 buttons.
        if (currentChapterSet == tableOfContentsButtons.Length - 1)
        {
            foreach (var gameObjectToToggle in gameObjectsToToggle)
            {
                if (gameObjectToToggle.activeSelf)
                {
                    gameObjectToToggle.SetActive(false);
                }
            }
        }
    }

    private void ShowPreviousChapterSet()
    {
        // Decrement the current chapter set.
        currentChapterSet--;

        // Calculate the start and end chapters for the previous set.
        int startChapter = currentChapterSet * 10 + 1;
        int endChapter = (currentChapterSet + 1) * 10;


        // Update the text of the 10 chapter buttons for the previous set.
        for (int i = 0; i < chapterButtonTexts.Length; i++)
        {
            int chapter = startChapter + i;
            chapterButtonTexts[i].text = $"Kabanata {chapter}";
        }

        // Update the interactability of the "Next" and "Back" buttons based on the current chapter set.
        UpdateButtonInteractability();
        // Toggle on the 6 buttons.
        foreach (var gameObjectToToggle in gameObjectsToToggle)
        {
            if (!gameObjectToToggle.activeSelf)
            {
                gameObjectToToggle.SetActive(true);
            }
        }
        
}

    private void UpdateButtonInteractability()
    {
        // Deactivate the "Next" button if there are no more sets of chapters to show.
        nextChapterButton.gameObject.SetActive(currentChapterSet < tableOfContentsButtons.Length - 1);

        // Deactivate the "Back" button if it's the first chapter set.
        backChapterButton.gameObject.SetActive(currentChapterSet > 0);
    }
}
