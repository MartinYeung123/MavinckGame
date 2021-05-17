using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteCreator : MonoBehaviour
{
    public KeyCode key;
    bool active = false;
    GameObject note;
    public bool createMode;
    public GameObject n;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(key) && active)
        //{

           
        //}
        if (createMode && Input.GetKeyDown(key))
        {
            if (Input.GetKeyDown(key))
            {
                Instantiate(n, transform.position, Quaternion.identity);
            }
        }
    }
}
