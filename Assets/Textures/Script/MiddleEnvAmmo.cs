using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleEnvAmmo : MonoBehaviour
{
    public GameObject EnmeyBullet;
    public int BulletNum;
    public Transform firePos;
    public float angel;
    public float shotSpace;
    public float shotWait;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemyShipFire", shotWait, shotSpace);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void EnemyShipFire() { 
            for (int i = -BulletNum / 2; i < BulletNum / 2 + 1; i++)
            {
            GameObject tempbullet = Instantiate(EnmeyBullet, firePos.position, firePos.rotation);
            tempbullet.transform.position = transform.position;
            tempbullet.transform.rotation = Quaternion.Euler(0, angel * i, 0);
            //tempbullet.transform.Translate(0, 0, 5f);
            tempbullet.name = "EnemySpecialAmmo";
        }
    }
}
