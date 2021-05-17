using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.velocity = new Vector3(0, 0,speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
