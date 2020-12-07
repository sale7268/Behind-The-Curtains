using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartFunctionality : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("PirateTavern");
    }
}
