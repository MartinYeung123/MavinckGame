using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class LaneController : MonoBehaviour
{
    RhythmGameController gameController;

    [Tooltip("此音轨使用的键盘按键")]
    public KeyCode keyboardButton;

    [Tooltip("此音轨对应事件的编号")]
    public int laneID;

    //对“目标”位置的键盘按下的视觉效果
    public Transform targetVisuals;

    //上下边界
    public Transform targetTopTrans;
    public Transform targetBottomTrans;

    //包含在此音轨中的所有事件列表
    List<KoreographyEvent> laneEvents = new List<KoreographyEvent>();

    //包含此音轨当前活动的所有音符对象的队列
    Queue<NoteObject> trackedNotes = new Queue<NoteObject>();

    //检测此音轨中的生成的下一个事件的索引
    int pendingEventIdx = 0;

    public GameObject downVisual;

    //音符移动的目标位置
    public Vector3 TargetPosition
    {
        get
        {
            return transform.position;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckSpawnNext();
    }
    //初始化
    public void Initialize(RhythmGameController controller)
    {
        gameController = controller;
    }

    //检测事件是否匹配当前编号的音轨
    public bool DoesMatch(int noteID)
    {
        return noteID == laneID;
    }

    //如果匹配，则把当前事件添加进音轨所持有的事件列表
    public void AddEventToLane(KoreographyEvent evt)
    {
        laneEvents.Add(evt);
    }

    //音符在音谱上产生的位置偏移量
    int GetSpawnSampleOffset()
    {
        //出生位置与目标点的位置
        float spawnDistToTarget = targetTopTrans.position.z - transform.position.z;

        //到达目标点的时间
        float spawnPosToTargetTime = spawnDistToTarget / gameController.noteSpeed;

        return (int)spawnPosToTargetTime * gameController.SampleRate;
    }

    //检测是否生成下一个新音符
    void CheckSpawnNext()
    {
        int samplesToTarget = GetSpawnSampleOffset();

        int currentTime = gameController.DelayedSampleTime;

        while (pendingEventIdx < laneEvents.Count
            && laneEvents[pendingEventIdx].StartSample < currentTime + samplesToTarget)
        {
            KoreographyEvent evt = laneEvents[pendingEventIdx];
            int noteNum = evt.GetIntValue();
            NoteObject newObj = gameController.GetFreshNoteObject();
            bool isLongNoteStart = false;
            bool isLongNoteEnd = false;
            if (noteNum > 6)
            {
                isLongNoteStart = true;
                noteNum = noteNum - 6;
                if (noteNum > 6)
                {
                    isLongNoteEnd = true;
                    isLongNoteStart = false;
                    noteNum = noteNum - 6;
                }
            }
            newObj.Initialize(evt, noteNum, this, gameController, isLongNoteStart, isLongNoteEnd);
            trackedNotes.Enqueue(newObj);
            pendingEventIdx++;
        }
    }
}
