using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiControel : MonoBehaviour
{
    public GameObject PauseMenu;


    private void Start()
    {
        PauseMenu.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(true);
        }
    }




    public void Goback()
    {
        SceneManager.LoadScene(0);
    }

    public void reStart()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GoOnGame()
    {
        PauseMenu.SetActive(false);
    }
}
