﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public GameObject chooseLevelUI;
    public GameObject chooseSkinUI;
    // Use this for initialization
    void Start()
    {
        chooseLevelUI.SetActive(false);
        chooseSkinUI.SetActive(false);
    }

    public void Escape()
    {
        chooseLevelUI.SetActive(false);
        chooseSkinUI.SetActive(false);
    }

    public void StartGame()
    {
        chooseLevelUI.SetActive(true);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene("Level_" + index.ToString());

    }

    public void SelectSkin()
	{
        chooseSkinUI.SetActive(true);
	}
}
