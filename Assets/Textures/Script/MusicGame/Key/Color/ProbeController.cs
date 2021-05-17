using UnityEngine;
using System.Collections;

public class ProbeController : MonoBehaviour
{

    ReflectionProbe probe;

    void Start()
    {
        this.probe = GetComponent<ReflectionProbe>();
    }

    void FixedUpdate()
    {
        this.probe.transform.position = new Vector3(
            Camera.main.transform.position.x,
            Camera.main.transform.position.y * -1,
            Camera.main.transform.position.z
        );

        probe.RenderProbe();
    }
}