using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    public GameObject Bg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bg.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(Time.time / 0.5f, 0));
    }
}
