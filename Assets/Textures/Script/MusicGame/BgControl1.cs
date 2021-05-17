using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl1 : MonoBehaviour
{
    public GameObject Bg;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bg.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, Time.time / -Speed));
    }
}
