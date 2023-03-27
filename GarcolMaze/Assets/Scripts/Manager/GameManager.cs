using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public EnemyManager enemyManager = null;
    public BoardManager boardManager = null;
    public PlayerManager playerManager = null;
    public EndGamePopupController popupController = null;

    public float miniMonsterSpawnTime = 0f;
    public int nInitialMonster = 10;
    public int nInitialTrash = 10;
    public int nInitialItem = 5;

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

    void Awake()
    {
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

        spawnMonster();
        spawnRandomTrash(nInitialTrash);
        spawnRandomItem(nInitialItem);
    }

    private void spawnMonster()
	{
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        List<Vector3> monsterPositionList = boardManager.GenerateRandomPosition(nInitialMonster,
            new Vector3[] { players[0].transform.position, players[1].transform.position },
            6f);
        // spawn Boss
        if (SceneManager.GetActiveScene().name.Substring(6) != "1")
		    enemyManager.SpawnMonster(monsterPositionList[0], "BossMonster");
        // spawn Miniboss
        for (int i = 1; i < monsterPositionList.Count; i++)
        {
            enemyManager.SpawnMonster(monsterPositionList[i], "MiniMonster");
        }
    }

    private void spawnRandomTrash(int n)
    {

        //string[] trashDir = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Prefabs/Trash" });
        // note: not .prefab!
        string[] trashDir = new string[] { "Prefabs/Trash/screen 1", "Prefabs/Trash/trash_organic_46", "Prefabs/Trash/trash_recyclable_12" };

        for (int i = 0; i < trashDir.Length; i++)
        {
            if (n <= 0) return;
            int num = UnityEngine.Random.Range(0, n + 1);
            if (i == trashDir.Length - 1) num = n;
            n -= num;

            //string path = AssetDatabase.GUIDToAssetPath(trashDir[i]);
            string path = trashDir[i];
            boardManager.GenerateItem(Resources.Load(path) as GameObject, num, true);

        }

        remainingTrash = nInitialMonster;
    }

    public void spawnRandomItem(int num)
    {
        // string[] itemDir = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Prefabs/Item/GoodItem" });
        // note: not .prefab!
        string[] itemDir = new string[] { "Prefabs/Item/GoodItem/FreezeItem", "Prefabs/Item/GoodItem/SpeedItem" };

        for (int i = 0; i < num; ++i)
        {
            int idx = UnityEngine.Random.Range(0, itemDir.Length);
            // string path = AssetDatabase.GUIDToAssetPath(itemDir[idx]);
            string path = itemDir[idx];
            boardManager.GenerateItem(Resources.Load(path) as GameObject, 1);
        }
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
        }
        else
        {
            playerManager.playerB = null;
        }
        if (playerManager.playerA == null && playerManager.playerB == null)
            gameOverState();
        Destroy(player);
    }

    private void winGameState()
    {
        SoundManager.PlaySound("win");
        popupController.ShowPopup(true);
    }

    private void gameOverState()
    {
        SoundManager.PlaySound("lose");
        popupController.ShowPopup(false);
    }

    public void resetGame()
    {
        playerManager.resetPlayerState();
        enemyManager.resetEnemy();
        boardManager.resetItem();
        InitGame();
    }
}
