using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Transform WallPos;
    public Vector3 TransformPos;
    // Start is called before the first frame update
    void Start()
    {
        TransformPos = WallPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
