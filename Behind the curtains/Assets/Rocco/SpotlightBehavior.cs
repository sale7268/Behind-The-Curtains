using System;
using System.Collections;
using UnityEngine;

public class SpotlightBehavior : MonoBehaviour
{

    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 5), transform.position.y, transform.position.z);
    }



}
