using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    public bool isGamePause;
    //public GameObject capsuleGo;
    public RhythmGameManager rhythmGameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        //rhythmGameManager = GetComponent<RhythmGameManager>();
        StartGame();
        //capsuleGo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
        }
        if (Input.GetKey(KeyCode.E))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        isGamePause = false;
        Time.timeScale = 1;
        rhythmGameManager.ThisMusic.UnPause();
        rhythmGameManager.isPlaying = true;
        //capsuleGo.SetActive(false);
    }
    public void PauseGame()
    {
        isGamePause = true;
        rhythmGameManager.isPlaying = false;
        Time.timeScale = 0;
        rhythmGameManager.ThisMusic.Pause();
        rhythmGameManager.resultsScreen.SetActive(false);
        //capsuleGo.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(3);
    }

    public void GobackSelectMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
