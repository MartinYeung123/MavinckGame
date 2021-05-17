using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float speed;
    public float till;
    private Rigidbody rbd;

    public Boundary bound;

    //public KeyCode key;
    //public KeyCode key_1;
    //public KeyCode key_2;
    //public AudioSource hitSound;
    //GameObject note;
    //bool active = false;
    private void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(key) && active)
        //{
        //    Destroy(note);
        //    active = false;
        //}
    }
    private void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        Vector3 vel = new Vector3(h*2, 0, 0);
        rbd.velocity = vel * speed;

        rbd.rotation = Quaternion.Euler(-rbd.velocity.x * (1) * till, -90, -90);
        float posX = Mathf.Clamp(rbd.position.x, bound.xMin, bound.xMax);
        float posZ = Mathf.Clamp(rbd.position.z, bound.zMin, bound.zMax);
        transform.position = new Vector3(posX, 0.3f,posZ);

    }

    //private void OnTriggerEnter(Collider col)
    //{
    //    active = true;
    //    if (col.gameObject.tag == "Note")
    //    {
    //        col.gameObject.SetActive(false);
    //        note = col.gameObject;
    //        hitSound.Play();
    //    }
    //}
    //private void OnTriggerExit(Collider col)
    //{
    //    active = false;
    //}
}
