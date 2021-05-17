using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveController : MonoBehaviour
{
    public float fly_Speed=8;
    void Start()
    {
        Rigidbody rbd = GetComponent<Rigidbody>();
        rbd.velocity = transform.forward * fly_Speed;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
