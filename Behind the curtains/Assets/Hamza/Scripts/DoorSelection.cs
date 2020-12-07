using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSelection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.lockCursor = true;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Selectable"))
            {
                if(selection.gameObject.name == "OutsideDoor")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        SceneManager.LoadScene("Lobby");
                    }
                }
                if (selection.gameObject.name == "PirateTavernDoor")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        SceneManager.LoadScene("PirateTavern");
                    }
                }
                if (selection.gameObject.name == "RoccoDoor")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        SceneManager.LoadScene("Rocco's Scene");
                    }
                }
                if (selection.gameObject.name == "FinalDoor")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        SceneManager.LoadScene("Lobby");
                    }
                }
            }
        }
    }
}
