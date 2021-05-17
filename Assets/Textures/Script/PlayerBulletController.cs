using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{

    public GameManager GameMaz;


    private void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("GameManager");
        GameMaz = go.GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                if(this.name== "EnemyAmmo")
                {
                    //Debug.Log("123");
                    other.SendMessage("Damage", 30, SendMessageOptions.DontRequireReceiver);
                    GameMaz.AttackShake();
                    GameMaz.DamagerPlayer();
                    Destroy(gameObject);
                }else if (this.name== "EnemySpecialAmmo")
                {
                    other.SendMessage("Damage", 30, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("EnemySpecialAmmo");
                    GameMaz.AttackShake();
                    GameMaz.DamagerPlayer();
                    Destroy(gameObject);
                }else if(this.name== "SpecialAmmo")
                {
                    other.SendMessage("Damage", 30, SendMessageOptions.DontRequireReceiver);
                    GameMaz.AttackShake();
                    GameMaz.DamagerPlayer();
                    Destroy(gameObject);
                }else if(this.name== "BossSpcialAttack")
                {
                    other.SendMessage("Damage", 30, SendMessageOptions.DontRequireReceiver);
                    GameMaz.AttackShake();
                    GameMaz.DamagerPlayer();
                    Destroy(gameObject);
                }else if(this.name== "BossAttack")
                {
                    other.SendMessage("Damage", 20, SendMessageOptions.DontRequireReceiver);
                    GameMaz.AttackShake();
                    GameMaz.DamagerPlayer();
                    Destroy(gameObject);
                }
               
                break;
            case "Enemy":
                {
                    //Debug.Log("1234");
                    if (this.name == "PlayerAmmo")
                    {
                        other.SendMessage("Damage2", 30, SendMessageOptions.DontRequireReceiver);
                        Destroy(gameObject);
                    }else if (this.name == "PlayerSpecialAmmo")
                    {
                        other.SendMessage("Damage2", 30, SendMessageOptions.DontRequireReceiver);
                        Destroy(gameObject);
                    }
                    break;

                }
            case "Boss":
                {
                    //Debug.Log("1234");
                    if (this.name == "PlayerAmmo")
                    {
                        other.SendMessage("Damage2", 10, SendMessageOptions.DontRequireReceiver);
                        Destroy(gameObject);
                    }
                    else if (this.name == "PlayerSpecialAmmo")
                    {
                        other.SendMessage("Damage2", 20, SendMessageOptions.DontRequireReceiver);
                        Destroy(gameObject);
                    }
                    break;

                }
        }
    }
}
