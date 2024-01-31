using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizAnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public Quiz quiz;
    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("Correct Answer");
            quiz.correctAnswerCount++;
        }
        else{
            Debug.Log("Wrong Answer");
        }
        quiz.Proceed();
    }

}
