using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class MusicalShoot : MonoBehaviour
{
    private PlayerController playshooting;
    private EnemyAI EnemyDead;
    public string[] eventID;
    // Start is called before the first frame update
    void Start()
    {
        playshooting = GetComponent<PlayerController>();
        Koreographer.Instance.RegisterForEvents(eventID[0], PlayerCanShoot);
        Koreographer.Instance.RegisterForEvents(eventID[1], SpeicalAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void PlayerCanShoot(KoreographyEvent koreographyEvent)
    {
        
            playshooting.Attack();
      
    }
    private void SpeicalAmmo(KoreographyEvent koreographyEvent2)
    {
       
            playshooting.PlayerSpecialAmmo();
    }
    //private void EnemyDeadSound(KoreographyEvent koreographyEvent2)
    //{
    //}
}
