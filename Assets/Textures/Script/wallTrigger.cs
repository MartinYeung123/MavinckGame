using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")
        {
            return;
        }
        Destroy(other.gameObject);
    }
}
