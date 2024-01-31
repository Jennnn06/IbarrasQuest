using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    public List<QuizQuestionAndAnswers> QnA;
    private List<QuizQuestionAndAnswers> originalQuestions;
    public GameObject[] options;
    public int currentQuestion;
    public int correctAnswerCount;

    public GameObject RightPanel, WrongPanel, Closebutton;
    public Button retry;
    public TextMeshProUGUI RightPanelCount, WrongPanelCount;

    public TextMeshProUGUI QuestionTxt;

    private void Start()
    {
        originalQuestions = new List<QuizQuestionAndAnswers>(QnA);
        generateQuestion();
    }

    public void Proceed(){
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers(){
        for(int i = 0; i <options.Length; i++){
            options[i].GetComponent<QuizAnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<QuizAnswerScript>().isCorrect = true;
            }
        }
    }

    public void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else if (correctAnswerCount >= 3)
        {
            RightPanelCount.text=correctAnswerCount.ToString();
            RightPanel.SetActive(true); // Activate right panel when all questions answered correctly
            correctAnswerCount = 0;
        }
        else
        {
            WrongPanelCount.text= correctAnswerCount.ToString();
            WrongPanel.SetActive(true);
            DisableAllOptions();
            correctAnswerCount=0;

            QnA = new List<QuizQuestionAndAnswers>(originalQuestions);
            generateQuestion();
            retry.onClick.AddListener(OnRetryClick);

        }
    }

    public void OnRetryClick()
    {
        WrongPanel.SetActive(false);
        Closebutton.SetActive(true);
        EnableAllOptions();
    }

    public void DisableAllOptions()
    {
        for (int i = 0; i < options.Length; i++)
        {
            Button button = options[i].GetComponent<Button>();
            if (button != null)
            {
                button.interactable = false;
            }
        }
    }
    public void EnableAllOptions(){
        for (int i = 0; i < options.Length; i++)
        {
            Button button = options[i].GetComponent<Button>();
            if (button != null)
            {
                button.interactable = true;
            }
        }
    }

}
