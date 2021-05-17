using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //X轴抖动
    public float X_VaxMax;
    public float X_VaxMin;

    //Y轴抖动
    public float VaxMax;
    public float VaxMin;

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float x = Random.Range(X_VaxMin, X_VaxMax) * magnitude;
            float y = Random.Range(VaxMin, VaxMax) * magnitude;
            transform.position = new Vector3(x, y, -43);
            elapsed += Time.deltaTime;
            yield return transform.position;
        }
        transform.position = orignalPosition;
    }
}
