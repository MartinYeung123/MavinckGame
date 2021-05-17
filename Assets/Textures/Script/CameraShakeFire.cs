using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeFire : MonoBehaviour
{
    public Animator camAnim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            camAnim.SetTrigger("Shake");
            
        }
    }
}
