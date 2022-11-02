using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
	private static GameManager _instance = null;
	public EnemyManager enemyManager = null;
	public BoardManager boardManager = null;

    public float miniMonsterSpawnTime = 0f;
    public int nInitialMonster = 10;

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
		List<Vector3> monsterPositionList = boardManager.GenerateRandomPosition(nInitialMonster);
		for (int i = 0; i < monsterPositionList.Count; i++)
		{
			enemyManager.SpawnMonster(monsterPositionList[i], "MiniMonster");
		}
	}

	void Update() {
		
	}
}
