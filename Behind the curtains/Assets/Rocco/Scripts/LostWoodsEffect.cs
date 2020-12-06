using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostWoodsEffect : MonoBehaviour
{
    public GameObject room;
    public GameObject initialHall;
    public GameObject roomSpawn;
    
     private void OnTriggerEnter(Collider other)
    {
        if(transform.parent.name == "W Hall"){
            other.GetComponent<Puzzle>().west_correct = true;
            Debug.Log("West");
        }
        else if(transform.parent.name == "E Hall" && other.GetComponent<Puzzle>().west_correct == true){
            other.GetComponent<Puzzle>().east_correct = true;
            Debug.Log("East");
        }
        else if(transform.parent.name == "N Hall" && other.GetComponent<Puzzle>().west_correct == true && other.GetComponent<Puzzle>().east_correct == true){
            other.GetComponent<Puzzle>().north_correct = true;
            Debug.Log("North");
        }
        else{
            other.GetComponent<Puzzle>().west_correct = false;
            other.GetComponent<Puzzle>().east_correct = false;
            other.GetComponent<Puzzle>().north_correct = false;
            Debug.Log("FAIL"); 
       }

        initialHall.transform.position = transform.parent.position;
        initialHall.transform.rotation = transform.parent.rotation;
        Destroy(room);
        Instantiate(room, roomSpawn.transform.position, roomSpawn.transform.rotation);
    }
}
