using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float fly_Speed = 8;

    void Start()
    {
        Rigidbody rbd = GetComponent<Rigidbody>();
        rbd.velocity = new Vector3(-fly_Speed*Time.deltaTime, 0, 0);

    }

    void Update()
    {

    }

}
