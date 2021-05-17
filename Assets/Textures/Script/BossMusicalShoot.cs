using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class BossMusicalShoot : MonoBehaviour
{
    private BossAI playshooting;
    private EnemyAI EnemyDead;
    public string[] eventID;
    // Start is called before the first frame update
    void Start()
    {
        playshooting = GetComponent<BossAI>();
        Koreographer.Instance.RegisterForEvents(eventID[0], PlayerCanShoot);
        Koreographer.Instance.RegisterForEvents(eventID[1], SpeicalAmmo);
        Koreographer.Instance.RegisterForEvents(eventID[2], SpeicalAmmo2);
        Koreographer.Instance.RegisterForEvents(eventID[3], SpeicalAmmo3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void PlayerCanShoot(KoreographyEvent koreographyEvent)
    {
        
            playshooting.BossAttack();
      
    }
    private void SpeicalAmmo(KoreographyEvent koreographyEvent2)
    {

        playshooting.BossSpcialAttack();

    }

    private void SpeicalAmmo2(KoreographyEvent koreographyEvent3)
    {

        playshooting.BossSpcialAttack2();
    }

    private void SpeicalAmmo3(KoreographyEvent koreographyEvent3)
    {

        playshooting.BossSpcialAttack3();
    }
    //private void EnemyDeadSound(KoreographyEvent koreographyEvent2)
    //{
    //}
}
