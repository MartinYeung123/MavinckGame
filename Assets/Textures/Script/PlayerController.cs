using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    
    public float speed;
    public float till;
    public bool isfly = true;
    public bool isDamage = false;
    public Transform StartPos;

    public Boundary bound;
    public GameManager Gamemaz;

    public GameObject Player_bullet;
    public GameObject PlayerSpcialAmmo;

    public AudioSource Player_Bullet;
    public GameObject PlayerAmmo;
    public Transform firePos;
    private Rigidbody rbd;
    //public Button button;

    public GameObject exp_explpr;
    public int BulletNum;
    public float angel;

    public int hp = 100;

    private float PlayerHealth;
    public Image hp_bag;

    ////模拟手机按键
    //[DllImport("user32.dll", EntryPoint = "keybd_event")]
    //public static extern void keybd_event(
    //    byte bVk,
    //    byte bScan,
    //    int dwFlags,//0为按下 1为按住 2为释放
    //    int dwExtraInfo

    //    );

    ////public void InputButtonA()
    ////{
    ////    //keybd_event(65, 0, 0, 0);
    ////    keybd_event(65, 0, 2, 0);
    ////    //keybd_event(65, 0, 2, 0);
    ////}
    void Start()
    {




        GameObject go = GameObject.FindGameObjectWithTag("GameManager");
        Gamemaz = go.GetComponent<GameManager>();
        PlayerHealth = hp;
        rbd = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        if (isfly == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPos.position, 0.5f);
            if (Vector3.Distance(transform.position, StartPos.position) < 0.05f)
            {
                isfly = false;
            }
        }
        //Attack();
    }
    private void FixedUpdate()
    {
        if (isfly == false)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 vel = new Vector3(h, 0, v);
            rbd.velocity = vel * speed;

            rbd.rotation = Quaternion.Euler(0, 0, -rbd.velocity.x * (1) * till);
            float posX = Mathf.Clamp(rbd.position.x, bound.xMin, bound.xMax);
            float posZ = Mathf.Clamp(rbd.position.z, bound.zMin, bound.zMax);
            transform.position = new Vector3(posX, -19.5f, posZ);
        }
    }
   public void Attack()
    {
        if (isDamage == false)
        {

            if (isfly == false)
            {
                //if (Input.GetKeyDown(KeyCode.Space))
                //{
                Player_Bullet.Play();
                GameObject tempBullet = Instantiate(PlayerAmmo, firePos.position, firePos.rotation);
                tempBullet.name = "PlayerAmmo";

                //}
            }
        }
    }
    public void Damage(int damage)
    {
        if (isDamage == false)
        {
            if (isfly == false)
            {
                if (hp > 0)
                {
                    PlayerHealth -= damage;
                    hp_bag.fillAmount = PlayerHealth / hp;
                    if (PlayerHealth <= 0)
                    {
                        Destroy(this.gameObject);
                        Player_bullet.SetActive(false);
                        Instantiate(exp_explpr, transform.position, transform.rotation);
                        Gamemaz.GameOver();

                    }
                    else
                    {

                    }
                }
            }
        }
        else
        {
            return;
        }
    }
    public void PlayerSpecialAmmo()
    {
        if (isDamage == false)
        {


            for (int i = -BulletNum / 2; i < BulletNum / 2 + 1; i++)
            {
                GameObject tempbullet = Instantiate(PlayerSpcialAmmo, firePos.position, firePos.rotation);
                //tempbullet.transform.Rotate(0, angel * i, 0);
                tempbullet.transform.position = transform.position;
                tempbullet.transform.rotation = Quaternion.Euler(0, angel * i, 0);
                //tempbullet.transform.Translate(0, 0, 5f);
                tempbullet.name = "PlayerSpecialAmmo";
                Player_Bullet.Play();
                if (hp < -0)
                {
                    Destroy(tempbullet);
                }
            }
        }
    }
    public void FinishedGame()
    {
        isfly = true;
    }
    public void LockHealthUp()
    {
        isDamage = true;
    }
}
