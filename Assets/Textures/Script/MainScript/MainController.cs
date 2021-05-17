using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public GameObject musicPlane;
    public GameObject startMain;
    public GameObject startButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        Screen.SetResolution(1024, 768, false);
       
    }
    

    // Update is called once per frame
    void Update()
    {
        //if (Input.anyKeyDown)
        //{
        //    startMain.SetActive(false);
        //    startButton.SetActive(true);
        //}
    }
    public void StartMain()
    {
                startMain.SetActive(false);
                startButton.SetActive(true); 
    }

    public void startGame()
    {
        //SceneManager.LoadScene(1);
        //Globe.nextScenceName = "SampleScene";//目标场景名称
        SceneManager.LoadScene("LoadingMainGame");//加载进度条场景
    }
    public void startPlane()
    {
        Debug.Log("Press");
        musicPlane.SetActive(true);
        startButton.SetActive(false);
        
    }
    public void RhythmMode()
    {

        SceneManager.LoadScene("RhythmLoading");//加载进度条场景
        //musicPlane.SetActive(true);
        startButton.SetActive(false);
    }

        public void Exit()
    {
        Application.Quit();
    }
}
