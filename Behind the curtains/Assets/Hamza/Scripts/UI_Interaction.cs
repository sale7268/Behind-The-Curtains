using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Interaction : MonoBehaviour
{

    [Header("Floating Text Prefab")]
    public GameObject correctFloatingText;
    public GameObject wrongFloatingText;

    [Header("Interaction UI State")]
    [SerializeField] private GameObject GreenlandShark;

    [Header("Interaction UI Text")]
    [SerializeField] private GameObject GreenlandSharkText;

    string correct = "That is correct!! You have earned 100 points.";
    string wrong = "That is Wrong!! Try harder next time.";

    public void CorrectAnswer()
    {
        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().IncrementScore();
        Instantiate(correctFloatingText, transform.position, Quaternion.identity);
        UIDisable();
    }

    public void FalseAnswer()
    {
        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().IncrementClues();
        Instantiate(wrongFloatingText, transform.position, Quaternion.identity);
        UIDisable();
    }

    public void UIDisable()
    {
        GreenlandShark.SetActive(false);
        Time.timeScale = 1;
        Screen.lockCursor = true;
    }
}
