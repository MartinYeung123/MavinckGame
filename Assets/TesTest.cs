using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class TesTest : MonoBehaviour
{
     PostProcessVolume PostProcessVolume;
     Bloom m_Bloom;
    public float colorNum;
    PostProcessResources resources;

    private void Start()
    {
        //var postProcessLayer = gameObject.AddComponent<PostProcessLayer>();
        //postProcessLayer.Init(resources);

        m_Bloom = ScriptableObject.CreateInstance<Bloom>();
        m_Bloom.enabled.Override(true);
        m_Bloom.intensity.Override(1f);
        PostProcessVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Bloom);
        //m_Bloom.intensity.value = 5;
    }
    private void Update()
    {
        //m_Bloom.intensity.value = colorNum;
        //TestDancing();
    }

    public void TestDancing()
    {
        //m_Bloom.intensity.value = 18;
    }

}
