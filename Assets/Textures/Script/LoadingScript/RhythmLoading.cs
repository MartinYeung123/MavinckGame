using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//public class Globe
//{
//    public static string nextScenceName;
//}

public class RhythmLoading : MonoBehaviour
{
    public Text loadingText;

    private int curProgressValue = 0;

    private AsyncOperation operation;

    public string NextScenceLoading;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "RhythmLoading")
        {
            StartCoroutine(AsyncLoading());
        }
    }
    IEnumerator AsyncLoading()
    {
        operation = SceneManager.LoadSceneAsync(NextScenceLoading);
        operation.allowSceneActivation = false;
        yield return operation;
    }

    // Update is called once per frame
    void Update()
    {
        int progressValue = 100;
        if (curProgressValue < progressValue)
        {
            curProgressValue++;
        }
        loadingText.text = "加载中:" + curProgressValue + "%";
        if (curProgressValue == 100)
        {
            operation.allowSceneActivation = true;
            loadingText.text = "加载完成";
        }
    }
}
