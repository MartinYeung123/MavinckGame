using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Shoot : MonoBehaviour
{
    public GameObject EnmeyBullet;
    public Transform shotPos;
    public float shotSpace;
    public float shotWait;

    private AudioSource shotAudio;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemyShipFire", shotWait, shotSpace);
        shotAudio = GetComponent<AudioSource>();
    }

    void EnemyShipFire()
    {
       GameObject TempBullet=Instantiate(EnmeyBullet, shotPos.position, shotPos.rotation);
        TempBullet.name = "EnemyAmmo";
        shotAudio.Play();
       
    }

}
