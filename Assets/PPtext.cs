using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PPtext : MonoBehaviour
{
    public string name;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Text>().text = PlayerPrefs.GetInt(name) + "";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
