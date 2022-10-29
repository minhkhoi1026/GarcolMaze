using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
	private static GameManager _instance = null;
	public EnemyManager enemyManager = null;
	public BoardManager boardManager = null;

	public static GameManager instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("Game Manager is not initialized!");
			return _instance;
		}
	}

	void Awake() {
		// make game manager singleton
		if (_instance == null)
		{
			_instance = this;
		}
		else if (_instance != this)
		{
			Destroy(gameObject);
		}

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

		enemyManager = GetComponent<EnemyManager>();
		boardManager = GetComponent<BoardManager>();

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

	private void InitGame()
	{
		// TODO: EnemyManager should contain a list of enemy, this load is slow
		boardManager.GenerateItem(enemyManager.enemyList[0], 10);
	}

	void Update() {
		
	}
}
