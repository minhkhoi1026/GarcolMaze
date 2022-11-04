using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour {
	private static GameManager _instance = null;
	public EnemyManager enemyManager = null;
	public BoardManager boardManager = null;
	public PlayerManager playerManager = null;

    public float miniMonsterSpawnTime = 0f;
    public int nInitialMonster = 10;
	public int nInitialTrash = 10;

	private int remainingTrash;

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
		
		playerManager = GetComponent<PlayerManager>();
		enemyManager = GetComponent<EnemyManager>();
		boardManager = GetComponent<BoardManager>();

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

	private void InitGame()
	{
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

		List<Vector3> monsterPositionList = boardManager.GenerateRandomPosition(nInitialMonster, 
			new Vector3[] {players[0].transform.position, players[1].transform.position},
			6f);
		for (int i = 0; i < monsterPositionList.Count; i++)
		{
			enemyManager.SpawnMonster(monsterPositionList[i], "MiniMonster");
		}

		spawnRandomTrash();
	}

	private void spawnRandomTrash()
	{

		string[] trashDir = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Prefabs/Trash" });
		Debug.Log(trashDir.Length);
		int n = nInitialTrash;
		for (int i = 0; i < trashDir.Length; i++)
		{
			if (n <= 0) return;
			int num = UnityEngine.Random.Range(0, n + 1);
			if (i == trashDir.Length - 1) num = n;
			n -= num;

			string path = AssetDatabase.GUIDToAssetPath(trashDir[i]);
			boardManager.GenerateItem(AssetDatabase.LoadAssetAtPath(path, typeof(GameObject)) as GameObject , num);

		}

		remainingTrash = nInitialMonster;
	}

	public void removeTrash(int cnt)
	{
		remainingTrash -= cnt;
		if (remainingTrash <= 0)
		{
			winGameState();
		}
	}

	public void removeCharacter(GameObject player)
	{
		if (playerManager.playerA == player)
		{
			playerManager.playerA = null;
		} else
		{
			playerManager.playerB = null;
		}
		if (playerManager.playerA == null && playerManager.playerB == null)
			gameOverState();
		Destroy(player);
	}

	private void winGameState()
	{

	}

	private void gameOverState()
	{

	}

	void Update() {
		
	}
}
