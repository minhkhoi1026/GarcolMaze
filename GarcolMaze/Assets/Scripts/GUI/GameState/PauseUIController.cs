using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUIController : MonoBehaviour
{
    public static bool isGamePause = false;
    public GameObject menuUI;

    private void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePause = true;
    }

    public void Resume()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePause = false;
    }

    public void ResetLevel()
    {
        Time.timeScale = 1f;
        GameManager.instance.resetGame();
        menuUI.SetActive(false);
        isGamePause = false;
    }

    public void LoadSetting()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Setting");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }
}
