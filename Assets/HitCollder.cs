using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitCollder : MonoBehaviour
{
    private Rigidbody rbd;
    public KeyCode key;
    public AudioSource hitSound;
    public GameObject HitOver;
    GameObject note,gm;
    bool active = false;
    public Text PerWord;

    public float timer = 1.0f;
    //ComBo
    public Text Combo_Text;
    public int Combo = 0;

    //public Text Score_Text;
    //int Score=0;
    // Start is called before the first frame update
    void Start()
    {
        PerWord.text = " ";
        //Score = 100;
        rbd = GetComponent<Rigidbody>();
        gm = GameObject.Find("RhythmGameManager");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(key) && active)
        {
            note.SetActive(false);
            hitSound.Play();
            timer = 1.0f;
            Combo++;
            Combo_Text.text = Combo.ToString();
            Instantiate(HitOver, transform.position, Quaternion.identity);
            //RhythmGameManager.instance.NoteHit();

            if (note.transform.position.z > 3.5f)
            {
                RhythmGameManager.instance.PerfectHit();

                PerWord.text = "完美";
                //Debug.Log("Perfect");
            }
            else if (note.transform.position.z > 3.1f)
            {
                RhythmGameManager.instance.GoodHit();
                PerWord.text = "漂亮";
                Debug.Log("Good");
            }
            else
            {
                RhythmGameManager.instance.NormalHit();
                PerWord.text = "很好";
                Debug.Log("Nomral");

            }
            active = false;
            //if(active == false)
            //{
            //    //PerWord.text = " ";
            //}
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            PerWord.text = " ";
            timer = 1.0f;
        }
        
    }
    private void OnTriggerEnter(Collider col)
    {
        active = true;
        if (col.gameObject.tag == "Note")
        {

            note = col.gameObject;
            //timer = 1.0f;
            //Combo++;
            //Combo_Text.text = Combo.ToString();
            //hitSound.Play();
            //Destroy(note);
            //Instantiate(HitOver, transform.position, Quaternion.identity);
            //AddScore();
            //    if (note.transform.position.z > 3.5f)
            //    {
            //        RhythmGameManager.instance.PerfectHit();

            //        PerWord.text = "完美";
            //        //Debug.Log("Perfect");
            //    }
            //    else if (note.transform.position.z > 3.1f)
            //    {
            //        RhythmGameManager.instance.GoodHit();
            //        PerWord.text = "漂亮";
            //        Debug.Log("Good");
            //    }
            //    else
            //    {
            //        RhythmGameManager.instance.NormalHit();
            //        PerWord.text = "很好";
            //        Debug.Log("Nomral");

            //    }
            //    active = false;
        }

    }
    private void OnTriggerExit(Collider col)
    {
        RhythmGameManager.instance.NoteMissed();
        PerWord.text = " ";
        Combo = 0;
        Combo_Text.text = Combo.ToString();
        active = false;
    }

   public void AddScore()
    {
        //PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gm.GetComponent<RhythmGameManager>().GetScore());
    }
}
