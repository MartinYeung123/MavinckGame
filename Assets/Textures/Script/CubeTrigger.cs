using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Door")//检测碰到的是门
        {
            Vector3 characternewpos = GameObject.Find(other.name).GetComponent<DoorTrigger>().TransformPos;//获取传送位置-door为门脚本名称
            transform.position = characternewpos;//传送至位置
        }
    }
}
