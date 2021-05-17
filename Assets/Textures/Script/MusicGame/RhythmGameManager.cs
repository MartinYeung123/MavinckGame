using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmGameManager : MonoBehaviour
{
    public bool startPlaying;

    public static RhythmGameManager instance;
    public int ScorePerNote=6;
    public int scorePerGoodNote = 8;
    public int scorePerPerfectNote = 10;
    public int currenScore;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text Score_text;
    public Text multiText;

    public float totalNotes;
    public float noramlHits;
    public float PerfectlHits;
    public float goodHits;
    public float missedHits;

    public GameObject resultsScreen;
    public Text PerHitText, noramlHitText, GoodHitText, missedText, rankTest, finalScoreText;

    public AudioSource ThisMusic;

    public bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentMultiplier = 1;
        totalNotes = FindObjectsOfType<Note>().Length;
        isPlaying = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (!ThisMusic.isPlaying && !resultsScreen.activeInHierarchy)
        {
                resultsScreen.SetActive(true);
                noramlHitText.text = "" + noramlHits;
                GoodHitText.text = goodHits.ToString();
                PerHitText.text = PerfectlHits.ToString();
                missedText.text = "" + missedHits;

                float totalHit = noramlHits + goodHits + PerfectlHits;
                float percentHit = (totalHit / totalNotes) * 100f;
                Debug.Log(percentHit);


                string rankVal = "F";
                if (percentHit > 40)
                {
                    rankVal = "D";
                    if (percentHit > 55)
                    {
                        rankVal = "C";
                        if (percentHit > 70)
                        {
                            rankVal = "B";
                            if (percentHit > 85)
                            {
                                rankVal = "A";
                                if (percentHit > 90)
                                {
                                    rankVal = "S";
                                    if (percentHit > 95)
                                    {
                                        rankVal = "SS";
                                    }
                                }
                            }
                        }
                    }
                }
                rankTest.text = rankVal;

                finalScoreText.text = currenScore.ToString();

        }
        else
        {
            if (ThisMusic.isPlaying && resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(false);

            }
        }
        
    }
    
    public void NoteHit()
    {
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        multiText.text ="x"+currentMultiplier.ToString();
        currenScore += ScorePerNote*currentMultiplier;
        Score_text.text = currenScore.ToString();
        //Debug.Log(currenScore);

    }

    public void NormalHit()
    {
        currenScore += ScorePerNote * currentMultiplier;
        NoteHit();
        noramlHits++;
    }
    public void GoodHit()
    {
        currenScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
        goodHits++;
    }
    public void PerfectHit()
    {
        currenScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
        PerfectlHits++;
    }

    public void NoteMissed()
    {
       
        Debug.Log("Miss Note");
        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "x" + currentMultiplier.ToString();
        missedHits++;
    }
    
  
}
