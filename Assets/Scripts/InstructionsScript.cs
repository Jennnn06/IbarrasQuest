using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsScript : MonoBehaviour
{
    public GameObject[] imageObjects;
    public Button nextButton;
    public Button backButton;
    public Button closeButton;

    private int currentIndex = 0;

    void Start()
    {
        nextButton.onClick.AddListener(NextImage);
        backButton.onClick.AddListener(PreviousImage);
        closeButton.onClick.AddListener(CloseViewer);

        closeButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);

        ShowImage(currentIndex);
    }

    void ShowImage(int index)
    {
        if (index >= 0 && index < imageObjects.Length)
        {
            for (int i = 0; i < imageObjects.Length; i++)
            {
                imageObjects[i].SetActive(i == index);
            }

            if (index == imageObjects.Length - 1)
            {
                closeButton.gameObject.SetActive(true);
                nextButton.gameObject.SetActive(false);
            }
            else
            {
                closeButton.gameObject.SetActive(false);
                nextButton.gameObject.SetActive(true);
            }

            if (index == 0)
            {
                backButton.gameObject.SetActive(false);
            }
            else
            {
                backButton.gameObject.SetActive(true);
            }
        }
    }

    void NextImage()
    {
        currentIndex++;
        ShowImage(currentIndex);
    }

    void PreviousImage()
    {
        currentIndex--;
        ShowImage(currentIndex);
    }

    void CloseViewer()
    {
        gameObject.SetActive(false);
    }
}
