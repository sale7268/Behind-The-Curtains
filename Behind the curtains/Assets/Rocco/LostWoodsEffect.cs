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
        initialHall.transform.position = transform.parent.position;
        initialHall.transform.rotation = transform.parent.rotation * Quaternion.Euler(0, -1, 0);;
        Destroy(room);
        Instantiate(room, roomSpawn.transform.position, roomSpawn.transform.rotation);
    }
}
