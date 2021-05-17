using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private GameManager GameMaz;
    public int scoreValue;
    public GameObject exp_enm;

    //boss子弹
    public GameObject NomralAmmo;
    public GameObject SpecialAmmo;
    public Transform firePos;
    public Transform SpecialfirePos;
    public Transform SpecialfirePos2;
    public Transform SpecialfirePos3;

    public int BulletNum;
    public float angel;
    //特殊炮口
    public int BulletNum2;
    public float angel2;
    //特殊炮口1
    public int BulletNum3;
    public float angel3;
    //特殊炮口2
    public int BulletNum4;
    public float angel4;
    //子弹攻击速度
    public float shotSpace;
    public float shotWait;

    //最大最小随机速度
    public float dodgeMinSpeed;
    public float dodgeMaxSpeed;

    //开始闪避等待的时间
    public float waitMin;
    public float waitMax;
    //闪避最短最长的时间
    public float dodgeMinTime;
    public float dodgeMaxTime;
    //闪避加速度
    public float accelerSpeed;
    //偏转量
    public float till;
    //边界
    public Boundary bound;
    //随机闪避目标速度
    private float dodgeTargeSpeed;
    private Rigidbody rbd;
    //boss生命值
    public int hp;
    private float currentHealth;
    public Image hp_bag;

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("GameManager");
        GameMaz = go.GetComponent<GameManager>();
        currentHealth = hp;
        rbd = GetComponent<Rigidbody>();
        StartCoroutine(CalcDodgeSpeed());
        //InvokeRepeating("BossAttack", shotWait, shotSpace);
    }

    IEnumerator CalcDodgeSpeed()
    {
        while (true)
        {


            yield return new WaitForSeconds(Random.Range(waitMin, waitMax));
            dodgeTargeSpeed = Random.Range(dodgeMinSpeed, dodgeMaxSpeed);
            if (transform.position.y > 5.37)
            {
                //敌人飞船在右边，往左闪避
                dodgeTargeSpeed = -dodgeTargeSpeed;
            }
            yield return new WaitForSeconds(Random.Range(dodgeMinTime, dodgeMaxTime));
            dodgeTargeSpeed = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        //通过加速度产生的渐变速度
        float dodgeVal = Mathf.MoveTowards(rbd.velocity.x, dodgeTargeSpeed, Time.deltaTime * accelerSpeed);
        rbd.velocity = new Vector3(dodgeVal, 0, rbd.velocity.z);

        rbd.rotation = Quaternion.Euler(0, 0, -rbd.velocity.x * (1) * till);
        float posX = Mathf.Clamp(rbd.position.x, bound.xMin, bound.xMax);
        float posZ = Mathf.Clamp(rbd.position.z, bound.zMin, bound.zMax);
        rbd.position = new Vector3(posX, -19.5f, posZ);
    }

    public void BossAttack()
    {
        for (int i = -BulletNum / 2; i < BulletNum / 2 + 1; i++)
        {
            GameObject tempbullet = Instantiate(NomralAmmo, firePos.position, firePos.rotation);
            tempbullet.transform.Rotate(0, angel * i, 0);
            //tempbullet.transform.Translate(0, 0, 5f);
            tempbullet.name = "BossAttack";
            if (hp < -0)
            {
                Destroy(tempbullet);
            }
        }
    }

    public void BossSpcialAttack()
    {
        for (int i = -BulletNum2 / 2; i < BulletNum2 / 2 + 1; i++)
        {
            GameObject tempbullet = Instantiate(SpecialAmmo, SpecialfirePos.position, SpecialfirePos.rotation);
            tempbullet.transform.Rotate(0, angel2 * i, 0);
            //tempbullet.transform.Translate(0, 0, 5f);
            tempbullet.name = "BossSpcialAttack";
            if (hp < -0)
            {
                Destroy(tempbullet);
            }
        }
    }


    public void BossSpcialAttack2()
    {
        for (int i = -BulletNum2 / 2; i < BulletNum2 / 2 + 1; i++)
        {
            GameObject tempbullet = Instantiate(SpecialAmmo, SpecialfirePos2.position, SpecialfirePos2.rotation);
            tempbullet.transform.Rotate(0, angel3 * i, 0);
            //tempbullet.transform.Translate(0, 0, 5f);
            tempbullet.name = "BossSpcialAttack";
            if (hp < -0)
            {
                Destroy(tempbullet);
            }
        }
    }


    public void BossSpcialAttack3()
    {
        for (int i = -BulletNum2 / 2; i < BulletNum2 / 2 + 1; i++)
        {
            GameObject tempbullet = Instantiate(SpecialAmmo, SpecialfirePos3.position, SpecialfirePos3.rotation);
            tempbullet.transform.Rotate(0, angel4 * i, 0);
            //tempbullet.transform.Translate(0, 0, 5f);
            tempbullet.name = "BossSpcialAttack";
            if (hp < -0)
            {
                Destroy(tempbullet);
            }
        }
    }

    public void Damage2(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            hp_bag.fillAmount = currentHealth / hp;
        }
        if (currentHealth <= 0)
        {
            //hp = 0;
            Instantiate(exp_enm, transform.position, transform.rotation);
            Destroy(gameObject);
            GameMaz.AddScore(scoreValue);
            GameMaz.BossDead();
            
        }
    }
  
}