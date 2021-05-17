﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cbe : MonoBehaviour
{
    public float speed = 12;
    public int band;
    public float startScale, scaleMultiplier;

    Material material;
    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed*Time.deltaTime, 0, 0);
        transform.localScale = new Vector3(transform.localScale.x, (AudioVisable._audioBandBuffer[band]) * scaleMultiplier + startScale, transform.localScale.z);
        //Color color = new Color(AudioVisable._audioBandBuffer[band], AudioVisable._audioBandBuffer[band], AudioVisable._audioBandBuffer[band]);
        //material.SetColor("_EmissionColor", color);
    }

}