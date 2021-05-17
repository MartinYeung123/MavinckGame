using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float dodgeMinSpeed;
    public float dodgeMaxSpeed;

    public float waitMin;
    public float waitMax;

    public float dodgeMinTime;
    public float dodgeMaxTime;

    public float accelerSpeed;
    public float till;
    public Boundary bound;

    private float dodgeTargetSpeed;
    private Rigidbody rbd;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        StartCoroutine(CalcDodgeSpeed());
    }
    IEnumerator CalcDodgeSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(waitMin, waitMax));
            dodgeTargetSpeed = Random.Range(dodgeMinSpeed, dodgeMaxSpeed);
            if (transform.position.z > 0)
            {
                dodgeTargetSpeed = -dodgeTargetSpeed;
            }
            yield return new WaitForSeconds(Random.Range(dodgeMinTime, dodgeMaxTime));
            dodgeTargetSpeed = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float dodgeVal = Mathf.MoveTowards(Time.deltaTime * accelerSpeed, rbd.velocity.x, dodgeTargetSpeed);
        rbd.velocity = new Vector3(rbd.velocity.x, 0,dodgeVal);

        rbd.rotation = Quaternion.Euler(0, 0, rbd.velocity.z * (1) * till);
        float posX = Mathf.Clamp(rbd.position.x, bound.xMin, bound.xMax);
        float posZ = Mathf.Clamp(rbd.position.z, bound.zMin, bound.zMax);
        transform.position = new Vector3(posX, 0, posZ);
    }
}
