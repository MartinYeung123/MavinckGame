using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class ButtonControl : MonoBehaviour
{

    public float pressDurationTime = 1;
    public bool responseOnceBypress = false;
    public float doubleClickIntervalTime = 0.5f;

    public UnityEvent onDoubleClick;
    public UnityEvent onPress;
    public UnityEvent onClick;

    private bool isDown = false;
    private bool isPress = false;
    private float downTime = 0;

    private float clickIntervalTime = 0;
    private int ClickTimes = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDown)
        {
            if (responseOnceBypress && isPress)
            {
                return;
            }
            downTime += Time.deltaTime;
            if (downTime > pressDurationTime)
            {
                isPress = true;
                onPress.Invoke();
            }
        }
        if (ClickTimes >= 1)
        {
            clickIntervalTime += Time.deltaTime;
            if (clickIntervalTime >= doubleClickIntervalTime)
            {
                if (ClickTimes >= 2)
                {
                    onDoubleClick.Invoke();
                }
                else
                {
                    onClick.Invoke();
                }
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
        downTime = 0;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isDown = false;
        isPress = false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isPress)
        {
            ClickTimes += 1;
        }
        else
        {
            isPress = false;
        }
    }
    [DllImport("user32.dll", EntryPoint = "keybd_event")]
    public static extern void keybd_event(
        byte bVk,
        byte bScan,
        int dwFlags,//0为按下 1为按住 2为释放
        int dwExtraInfo

        );

    public void InputButtonA()
    {
        //keybd_event(65, 0, 0, 0);
        keybd_event(65, 0, 1, 0);
        //keybd_event(65, 0, 2, 0);
    }
}
