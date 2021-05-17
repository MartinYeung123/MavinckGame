using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "PlayerAmmo")
        {
            Destroy(other.gameObject);
        }
    }
}
