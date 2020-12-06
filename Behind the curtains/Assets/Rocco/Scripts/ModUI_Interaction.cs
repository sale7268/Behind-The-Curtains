using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModUI_Interaction : MonoBehaviour
{

    [Header("Interaction UI State")]
    [SerializeField] private GameObject GreenlandShark;
    [SerializeField] private GameObject Honey;
    [SerializeField] private GameObject Trees;

    public void Continue()
    {
        UIDisable();
    }
    public void UIDisable()
    {
        GreenlandShark.SetActive(false);
        Honey.SetActive(false);
        Trees.SetActive(false);

        Time.timeScale = 1;
        Screen.lockCursor = true;
    }
}
