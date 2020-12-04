using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score UI")]
    public GameObject scoreText, cluesText;

    public GameObject Key;


    public int scoreCount=0, cluesCount=0;

    public void IncrementScore()
    {
        scoreCount += 100;
        cluesCount += 1;

        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = scoreCount.ToString();
        cluesText.GetComponent<TMPro.TextMeshProUGUI>().text = cluesCount.ToString();
    }

    public void IncrementClues()
    {
        cluesCount += 1;
        cluesText.GetComponent<TMPro.TextMeshProUGUI>().text = cluesCount.ToString();

    }
}
