using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;
using SonicBloom.Koreo.Players;


public class RhythmGameController : MonoBehaviour
{
    [Tooltip("用于目标生成的轨道的事件对应ID")]
    [EventID]
    public string eventID;
    //音符速度
    public float noteSpeed = 1;
    //击打范围
    [Tooltip("音符击打范围")]
    [Range(8f,300f)]
    public float hitWindowRangeInMS;

    public float WindowSizeInUnits
    {
        get
        {
            return noteSpeed + (hitWindowRangeInMS * 0.001f);
        }
    }
    //在音乐样本中的命中窗口
    private int hitWindowRangeInSamples;

    public int HitWindowSampleWidth
    {
        get
        {
            return hitWindowRangeInSamples;
        }
    }
    public int SampleRate
    {
        get
        {
            return playingKoreo.SampleRate;
        }
    }
    Stack<NoteObject> noteObjectPool = new Stack<NoteObject>();
    

    //预制体资源
    public NoteObject noteObject;
    //按下
    public GameObject downEffectGo;
    //击中
    public GameObject hitEffectGo;
    //击中长音符
    public GameObject hitLongNoteEffectGo;
    //引用
    Koreography playingKoreo;

    public AudioSource audioCom;

    public List<LaneController> noteLines = new List<LaneController>();
    //其他
    [Tooltip("开始播放音频之前提供的时间量/s")]
    public float leadInTime;
    //音频播放之前的剩余时间量
    float leadInTimeLeft;
    //音乐开始之前的倒计时器
    float TimeLeftToPlay;
    //当前的采样时间，包括任何必要的延迟
    public int DelayedSampleTime
    {
        get
        {
            return playingKoreo.GetLatestSampleTime()-SampleRate*(int)leadInTimeLeft;
        }

    }


    void Start()
    {
        InitializeLeadIn();
        for (int i = 0; i < noteLines.Count; i++)
        {
            noteLines[i].Initialize(this);//音轨初始化
        }
        //获取到koreography对象
        playingKoreo = Koreographer.Instance.GetKoreographyAtIndex(0);
        KoreographyTrack rhythmTrack = playingKoreo.GetTrackByID(eventID);
        //获取事件
        List<KoreographyEvent> rawEvents = rhythmTrack.GetAllEvents();
        for (int i = 0; i < rawEvents.Count; i++)
        {
            KoreographyEvent evt = rawEvents[i];
            int noteID = evt.GetIntValue();
            //遍历所有音轨
            for (int j = 0; j < noteLines.Count; j++)
            {
                LaneController lane = noteLines[j];
                if (noteID>6)
                {
                    noteID = noteID - 6;
                    if (noteID>6)
                    {
                        noteID = noteID - 6;
                    }
                }
                if (lane.DoesMatch(noteID))
                {
                    lane.AddEventToLane(evt);
                    break;
                }
            }
        }
        hitWindowRangeInSamples = (int)(SampleRate * hitWindowRangeInMS * 0.0001f);
    }
    

    void Update()
    {
        if (TimeLeftToPlay > 0)
        {
            TimeLeftToPlay -= Time.unscaledDeltaTime;
            if (TimeLeftToPlay <= 0)
            {
                audioCom.Play();
                TimeLeftToPlay = 0;
            }
        }
        //倒数我们的遇到时间
        if (leadInTime > 0)
        {
            leadInTimeLeft =Mathf.Max(leadInTimeLeft - Time.unscaledDeltaTime,0);
        }
    }
    /// <summary>
    /// 初始化引导时间
    /// </summary>
    void InitializeLeadIn()
    {
        if (leadInTime>0)
        {
            leadInTimeLeft = leadInTime;
            TimeLeftToPlay = leadInTime;
        }
        else
        {
            audioCom.Play();
        }
    }
    //从池中取对象的方法
    public NoteObject GetFreshNoteObject()
    {
        NoteObject retObj;
        if (noteObjectPool.Count > 0)
        {
            retObj = noteObjectPool.Pop();
        }
        else
        {
            //资源母体
            retObj = Instantiate(noteObject);
            //retObj = Instantiate(noteObject);
        }
        retObj.gameObject.SetActive(true);
        retObj.enabled = true;

        return retObj;
    }
    //将音符对象放回对象池
    public void ReturnNoteObjectToPool(NoteObject obj)
    {
        if (obj != null)
        {
            obj.enabled = false;
            obj.gameObject.SetActive(false);
            noteObjectPool.Push(obj);
        }
    }
}
