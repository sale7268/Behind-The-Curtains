using System;
using System.Collections;
using UnityEngine;

public class SpotlightBehavior : MonoBehaviour
{

        [SerializeField] protected Vector3 m_from;  
        [SerializeField] protected Vector3 m_to;
        [SerializeField] protected float m_frequency = 1.0F;
    
    void Update() {
        movement();
    }

    void movement(){
        Quaternion from = Quaternion.Euler(this.m_from);
            Quaternion to = Quaternion.Euler(this.m_to);
    
            float lerp = 0.5F * (1.0F + Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup * this.m_frequency));
            this.transform.localRotation = Quaternion.Lerp(from, to, lerp);
    }

}
