using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Interaction : MonoBehaviour
{
    private IEnumerator coroutine;

    [Header("Interaction UI State")]
    [SerializeField] private GameObject GreenlandShark;

    [Header("Interaction UI Text")]
    [SerializeField] private GameObject GreenlandSharkText;

    string correct = "That is correct!! You have earned 100 points.";
    string wrong = "That is Wrong!! Try harder next time.";

    public void CorrectAnswer()
    {
        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().IncrementScore();
        GreenlandSharkText.GetComponent<TMPro.TextMeshProUGUI>().text = correct;
        UIDisable();
    }

    public void FalseAnswer()
    {
        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().IncrementClues();
        GreenlandSharkText.GetComponent<TMPro.TextMeshProUGUI>().text = wrong;
        UIDisable();
    }

    public void UIDisable()
    {
        Time.timeScale = 1;
        Screen.lockCursor = true;
    }
}
