using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Boss组件
    public GameObject BossPraf;
    public GameObject[] enemy;
    //等待时间
    public float spawnWait;
    public int waveCount;
    //UI显示
    private int scoreCount = 0;
    public Text lbScore;
    public Text Out1Score;
    public Text OutScore;
    public GameObject failCanvans;
    public GameObject WinCanvans;
    public AudioSource DamageMusicPlayer;
    //每一回合等待的时间
    public float waveWait;
    public float startWait;
    //各种组件医用
    private BossAI BossStart;
    private PlayerController PlayerHp;
    public Transform Boss_inComingPos;

    //Camera
    public Camera Camera_1;
    public Camera Camera_2;
    public float smoothTime = 0.01f;

    public bool bossAgain;
    public bool bossAgain1;

    //AttackShake
    public CameraShake cameraShake;
    //public Animation CameraShake_2;
    public bool isShake = false;
    public Animator camAnim;

    // Start is called before the first frame update
    void Start()
    {
        bossAgain = true;
        bossAgain1 = false;

        StartCoroutine(spawnWaves());
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        PlayerHp =go.GetComponent<PlayerController>();

        //Camera_1.active = true;
    }

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for(int i = 0; i < waveCount; i++)
            {
                int index = Random.Range(0, enemy.Length);
                GameObject go = enemy[index];
                Vector3 pos = new Vector3(Random.Range(-16.9f, 21.5f), -19.5f, 64.4f );
                Quaternion rot = Quaternion.identity;
                //Quaternion rot = Quaternion.identity;

                 Instantiate(go, pos,rot);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void AddScore(int value)
    {
        scoreCount += value;
        //Debug.Log("ScoreCount:" + scoreCount);
        lbScore.text = scoreCount.ToString();
        OutScore.text = scoreCount.ToString();
        Out1Score.text = scoreCount.ToString();
}

    private void CameraController()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Camera_1.gameObject.GetComponent<Camera>().enabled = true;
            Camera_2.gameObject.GetComponent<Camera>().enabled = false;

        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Camera_1.GetComponent<Camera>().enabled = false;
            Camera_2.GetComponent<Camera>().enabled = true;
        }
    }
    void Update()
    {
        
        //if (scoreCount >= 500)
        //{
        //    spawnWait = 2;

        //}
        //if (scoreCount >= 4000)
        //{
        //    spawnWait = 1;

        //}
        //if (scoreCount >= 8000)
        //{
        //    spawnWait = 0.5f;
        //}
       

        CameraController();
        if (scoreCount >=4000)
        {
            BossStartGo();
            waveCount = 9;
            //BossStart.isFlyStart();

        }
        // if (scoreCount >= 10000)
        //{
        //    BossStartGo1();
        //}
        if (isShake == true)
        {
            StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
            camAnim.SetTrigger("Shake");
            isShake = false;
        }
    }
    public void BossStartGo()
    {
        if (bossAgain == true)
        {
            BossStart = Instantiate(BossPraf, Boss_inComingPos.position, BossPraf.transform.rotation).GetComponent<BossAI>();//实例化BOSS
            StopAllCoroutines();
            bossAgain = false;
        }
           
    }

    //public void BossStartGo1()
    //{
    //    if (bossAgain1 == true)
    //    {
    //        BossStart = Instantiate(BossPraf, Boss_inComingPos.position, BossPraf.transform.rotation).GetComponent<BossAI>();
    //        StopAllCoroutines();
     
    //        bossAgain1 = false;
    //    }

    //}
    public void BossDead()
    {
        //StartCoroutine(spawnWaves());
        WinCanvans.SetActive(true);
        PlayerHp.LockHealthUp();
    }

    public void GameOver()
    {
        failCanvans.SetActive(true);
    }

    public void AttackShake()
    {
        isShake = true;
    }

    public void AttackShakeStop()
    {
        isShake = false;
    }
    public void DamagerPlayer()
    {
        DamageMusicPlayer.Play();
    }
}
