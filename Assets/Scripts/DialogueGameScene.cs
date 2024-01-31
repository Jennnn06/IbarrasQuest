using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueGameScene : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    float startTime;
    private int index;
    private bool isTyping;
    public GameObject quitButton; // Reference to the quit button GameObject

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                // If the text is currently being typed, stop the typing coroutine
                StopAllCoroutines();
                textComponent.text = lines[index]; // Show the complete line
                isTyping = false;
                ShowQuitButton(); // Show the quit button after stopping typing
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        startTime = Time.realtimeSinceStartup;

        int currentIndex = 0;
        while (currentIndex < lines[index].Length)
        {
            float elapsedTime = Time.realtimeSinceStartup - startTime;

            if (elapsedTime >= textSpeed)
            {
                textComponent.text += lines[index][currentIndex];
                currentIndex++;
                startTime = Time.realtimeSinceStartup;
            }

            yield return null;
        }

        isTyping = false;
        ShowQuitButton();// Show the quit button after typing is complete
    }

    // Function to show the quit button
    void ShowQuitButton()
    {
        quitButton.SetActive(true);
    }

    // Function to hide the quit button
    public void HideQuitButton()
    {
        quitButton.SetActive(false);
    }
}
