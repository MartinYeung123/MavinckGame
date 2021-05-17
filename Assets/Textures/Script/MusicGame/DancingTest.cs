using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;
using UnityEngine.Rendering.PostProcessing;

public class DancingTest : MonoBehaviour
{
    private TesTest test;
    public string eventID;
    PostProcessVolume PostProcessVolume;
    Bloom m_Bloom;
    // Start is called before the first frame update
    void Start()
    {
        m_Bloom = ScriptableObject.CreateInstance<Bloom>();
        m_Bloom.enabled.Override(true);
        m_Bloom.intensity.Override(1f);
        PostProcessVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Bloom);
        test = GetComponent<TesTest>();
        Koreographer.Instance.RegisterForEvents(eventID, MusicalTest);
        StartCoroutine(ChangeBloom());

        float lerp = Mathf.PingPong(Time.time, 1.0f) / 1.0f;
    }

    //Update is called once per frame
    void Update()
    {

    }
    private void MusicalTest(KoreographyEvent koreographyEvent)
    {
        StartCoroutine(ChangeBloom());
    }
    IEnumerator ChangeBloom()
    {
        float lerp = Mathf.PingPong(Time.time, 1.0f) / 1.0f;
        yield return new WaitForSeconds(1.0f);
        m_Bloom.intensity.value = Mathf.Lerp(0, 10, lerp);

        yield return StartCoroutine(ChangeBloom());
    }

}
