using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Interaction : MonoBehaviour
{

    [Header("Floating Text Prefab")]
    public GameObject correctFloatingText;
    public GameObject wrongFloatingText;

    [Header("Interaction UI State")]
    [SerializeField] private GameObject GreenlandShark;
    [SerializeField] private GameObject Honey;
    [SerializeField] private GameObject Trees;
    [SerializeField] private GameObject Teeth;
    [SerializeField] private GameObject Lighter;
    [SerializeField] private GameObject Kneecap;


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
        Honey.SetActive(false);
        Trees.SetActive(false);
        Teeth.SetActive(false);
        Lighter.SetActive(false);
        Kneecap.SetActive(false);
        Time.timeScale = 1;
        Screen.lockCursor = true;
        Cursor.visible = false;
    }
}
