using System.IO;
using UnityEngine;
using Unity.VisualScripting;
using Microsoft.Win32.SafeHandles;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class QuestSaveManagement : MonoBehaviour
{    
    public QuestData questData;
    public GameObject[] kabanataTriggers;
    public GameObject[] kabanataQuestions;

    //Achievement to show
    public GameObject damasoAchievement, halfwayAchievement, finishAchievement, damasoQuestion, halfwayQuestion, finishQuestion;
    public GameObject achievementMessage;

    private string damasoKey = "DamasoAchievement";
    private string chapter31Key = "Chapter31Achievement";
    private string chapter63Key = "Chapter63Achievement";
    private bool damasoAchievementDisplayed = false;
    private bool chapter31AchievementDisplayed = false;
    private bool chapter63AchievementDisplayed = false;

    //
    public GameObject quizButton, quizMenu, descCheck;
    public TextMeshProUGUI currentKabanataTitleText;
    public TextMeshProUGUI currentKabanataQuestText;

    //bool for loading the data once
    private bool questDataLoaded = false;
    private bool questStatusChanged = true;
    private bool shouldUpdateTriggers = true;

    

    void Awake(){
        if (!questDataLoaded)
        {
        if (File.Exists(Application.persistentDataPath + "/questData.json"))
        {
            LoadQuestData();
        }
        else
        {
            // If the file doesn't exist, create a new QuestData object
            questData = new QuestData(64); // You can specify the number of chapters you want
            SaveQuestData();
        }

        questDataLoaded = true;
        }
        
    }


    void Start(){
         SwitchKabanataTrigger();
         CheckChapterCompletionForAchievement();
         
    }

    public void Update()
    {
        // Check for changes in quest and quiz completion
        CheckKabanatasAndUpdateCurrent();

        //Check Achievements
        DisplayAchievementNotification();
        CheckChapterCompletionForAchievement();

        // Update the TextMeshPro text with the current Kabanata
        UpdateCurrentKabanataText();
        UpdateCurrentQuestDescription();

        //Call SwitchKabanataTrigger
        if (shouldUpdateTriggers)
        {
            SwitchKabanataTrigger();
            shouldUpdateTriggers = false; // Set the flag to false after updating triggers
        }
        
        HandleQuizButtonActivation();
        QuizChecker();
        
        //Check if sa una sira
        if (questStatusChanged)
        {
            HandleQuizButtonActivation();
            questStatusChanged = false; // Reset the flag after updating
        }
    }

    void SwitchKabanataTrigger()
    {
        int currentKabanataIndex = questData.currentKabanata - 1;
        DeactivateAllKabanataTriggers();

        if (currentKabanataIndex >= 0 && currentKabanataIndex < questData.kabanata64.Count)
        {
            KabanataData currentKabanataData = questData.kabanata64[currentKabanataIndex];

            if (!currentKabanataData.quizCompleted)
            {
                // Quest is completed, and quiz is not completed, so activate the quiz button
                kabanataTriggers[currentKabanataIndex].SetActive(true);
            }
            
        }
    }

    void DeactivateAllKabanataTriggers()
    {
        foreach (var trigger in kabanataTriggers)
        {
        trigger.SetActive(false);
        }
    }

    void QuizChecker()
    {
       int currentKabanataIndex = questData.currentKabanata - 1;
        DeactivateAllQuizQuestions();

        if (currentKabanataIndex >= 0 && currentKabanataIndex < questData.kabanata64.Count)
        {
            if (quizMenu.activeSelf)
            {
                kabanataQuestions[currentKabanataIndex].SetActive(true);
            }
        }
    }
    void DeactivateAllQuizQuestions(){
        foreach (var question in kabanataQuestions)
        {
        question.SetActive(false);
        }
    }

    void HandleQuizButtonActivation()
    {
        int currentKabanataIndex = questData.currentKabanata - 1;

        if (currentKabanataIndex >= 0 && currentKabanataIndex < questData.kabanata64.Count)
        {
            KabanataData currentKabanataData = questData.kabanata64[currentKabanataIndex];

            if (currentKabanataData.questCompleted && !currentKabanataData.quizCompleted)
            {
                // Quest is completed, and quiz is not completed, so activate the quiz button
                quizButton.SetActive(true);
                descCheck.SetActive(true);
            }
            else
            {
                // Either quest is not completed or both quest and quiz are completed, so deactivate the quiz button
                quizButton.SetActive(false);
                descCheck.SetActive(false);
            }
        }
    }
    

    public void LoadQuestData(){
        string json = File.ReadAllText(Application.persistentDataPath + "/questData.json");
        questData = JsonUtility.FromJson<QuestData>(json);
    }

    public void SaveQuestData(){

        //Save
        string json = JsonUtility.ToJson(questData, true);
        string savePath = Path.Combine(Application.persistentDataPath, "questData.json");
        File.WriteAllText(savePath, json);
    }

    //Use mo kapag sa buttons if nagawa na nila ung task
    public void MarkQuestAsCompleted()
    {
        int currentKabanataIndex = questData.currentKabanata - 1;

        if (questData.currentKabanata >= 1 && questData.currentKabanata < 65)
        {
            // Mark the quest of the current Kabanata as completed
            questData.kabanata64[currentKabanataIndex].questCompleted = true;
        }

        SaveQuestData();
        Debug.Log("Quest data saved");

        // Call the method to check Kabanatas and update the current
        CheckKabanatasAndUpdateCurrent();
        questStatusChanged = true;
    }

    public void MarkQuizAsCompleted()
    {
        int currentKabanataIndex = questData.currentKabanata - 1;

        if (questData.currentKabanata >= 1 && questData.currentKabanata < 65)
        {
            // Mark the quiz of the current Kabanata as completed
            questData.kabanata64[currentKabanataIndex].quizCompleted = true;
        }

        SaveQuestData();
        Debug.Log("Quiz data saved");

        // Call the method to check Kabanatas and update the current
        CheckKabanatasAndUpdateCurrent();
        shouldUpdateTriggers = true;
    }

    //Check kung anong kabanata na si player
    public void CheckKabanatasAndUpdateCurrent()
    {
        int current = questData.currentKabanata;

        if (current >= 1 && current <= questData.kabanata64.Count)
        {
            while (current <= questData.kabanata64.Count)
            {
                KabanataData currentKabanataData = questData.kabanata64[current - 1];

                // Check if the quest and quiz are completed for the current Kabanata
                if (currentKabanataData.questCompleted && currentKabanataData.quizCompleted)
                {
                    current++; // Move to the next Kabanata
                }
                else
                {
                    break; // Stop checking when you find a Kabanata that is not completed
                }
            }

            // Update the current Kabanata based on the check
            questData.currentKabanata = current;

            // Update the TextMeshPro text with the current Kabanata
            UpdateCurrentKabanataText();
            UpdateCurrentQuestDescription();
        }
    }

    //Palitan text depende sa kabanata number mo na
    public void UpdateCurrentKabanataText()
    {
        int displayedKabanata = Mathf.Clamp(questData.currentKabanata, 1, 64);
        currentKabanataTitleText.text = "Kabanata " + displayedKabanata;
    }
    public void UpdateCurrentQuestDescription()
    {
        int displayedKabanataIndex = Mathf.Clamp(questData.currentKabanata - 1, 0, questData.questDescriptions.Count - 1);

        if (questData.currentKabanata == 65)
        {
            currentKabanataQuestText.text = "Finish";
        }
        else if (displayedKabanataIndex >= 0 && displayedKabanataIndex < questData.questDescriptions.Count)
        {
            string displayedQuestDescription = questData.questDescriptions[displayedKabanataIndex].description;
            currentKabanataQuestText.text = displayedQuestDescription;
        }
    }
    public void CheckChapterCompletionForAchievement()
    {
        int clickCount = PlayerPrefs.GetInt("ButtonClickCount", 0);
        if (clickCount == 5)
        {
            damasoAchievement.SetActive(true);
            damasoQuestion.SetActive(false);
            damasoAchievementDisplayed = true;
        }
        if (questData.kabanata64[31].questCompleted && questData.kabanata64[31].quizCompleted)
        {
            if (!chapter31AchievementDisplayed)
            {
                halfwayAchievement.SetActive(true); // Display halfway achievement at Chapter 32
                halfwayQuestion.SetActive(false);
                chapter31AchievementDisplayed = true;
            }
        }

        if (questData.kabanata64[63].questCompleted && questData.kabanata64[63].quizCompleted)
        {
            if (!chapter63AchievementDisplayed)
            {
                finishAchievement.SetActive(true);
                finishQuestion.SetActive(false);
                chapter63AchievementDisplayed = true;
            }
        }
    }


    void DisplayAchievementNotification()
    {
        if(damasoAchievementDisplayed && !PlayerPrefs.HasKey(damasoKey))
        {
            StartCoroutine(ShowAchievementMessage(achievementMessage, 2f));
            PlayerPrefs.SetInt(damasoKey, 1);
            PlayerPrefs.Save();
        }
        if (chapter31AchievementDisplayed && !PlayerPrefs.HasKey(chapter31Key))
        {
            // Display Chapter 31 achievement message
            StartCoroutine(ShowAchievementMessage(achievementMessage, 3f));
            PlayerPrefs.SetInt(chapter31Key, 1);
            PlayerPrefs.Save();
        }

        if (chapter63AchievementDisplayed && !PlayerPrefs.HasKey(chapter63Key))
        {
            // Display Chapter 63 achievement message
            StartCoroutine(ShowAchievementMessage(achievementMessage, 3f));
            PlayerPrefs.SetInt(chapter63Key, 1);
            PlayerPrefs.Save();
        }
    }

    IEnumerator ShowAchievementMessage(GameObject achievementMessage, float duration)
    {
        achievementMessage.SetActive(true);
        yield return new WaitForSeconds(duration);
        achievementMessage.SetActive(false);
    }
}
