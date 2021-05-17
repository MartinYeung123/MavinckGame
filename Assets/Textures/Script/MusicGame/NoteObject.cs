using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class NoteObject : MonoBehaviour
{
    public SpriteRenderer visuals;

    public Sprite[] noteSprites;

    KoreographyEvent trackedEvent;

    public bool isLongNote;

    public bool isLongNoteEnd;

    LaneController laneController;

    RhythmGameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }
    //初始化方法
    public void Initialize(KoreographyEvent evt, int noteNum, LaneController laneCont,
        RhythmGameController gameCont, bool isLongStart, bool isLongEnd)
    {
        trackedEvent = evt;
        laneController = laneCont;
        gameController = gameCont;
        isLongNote = isLongStart;
        isLongNoteEnd = isLongEnd;
        int spriteNum = noteNum;
        if (isLongNote)
        {
            spriteNum += 6;
        }
        else if (isLongNoteEnd)
        {
            spriteNum += 12;
        }
        visuals.sprite = noteSprites[spriteNum - 1];
    }
    private void ResetNote()
    {
        trackedEvent = null;
        laneController = null;
        gameController = null;

    }
    //返回对象池
    void ReturnToPool()
    {
        gameController.ReturnNoteObjectToPool(this);
        ResetNote();
    }
    //击中音符对象
    public void OnHit()
    {
        ReturnToPool();
    }
    //更新位子的方法
    void UpdatePosition()
    {
        Vector3 pos = laneController.TargetPosition;

        pos.z -= (gameController.DelayedSampleTime - trackedEvent.StartSample) / (float)gameController.SampleRate * gameController.noteSpeed;

        transform.position = pos;
    }
}
