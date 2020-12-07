using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{

    public GameObject spawnPosition;

    public bool west_correct;
    public bool east_correct;
    public bool north_correct;
    // Update is called once per frame
    void Update()
    {
        if(west_correct == true && east_correct == true && north_correct == true){
            GoToExit();
        }
    }

    void GoToExit(){
        gameObject.SetActive(false);
        transform.position = spawnPosition.transform.position;
        gameObject.SetActive(true);
        west_correct = false;
    }
}
