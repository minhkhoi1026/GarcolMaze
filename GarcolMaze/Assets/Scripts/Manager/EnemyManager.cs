using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour {
	public List<GameObject> enemyList;
	public Dictionary<string, GameObject> monsterPrefabDict;
	

	void Awake() {
		enemyList = new List<GameObject>();

		// init monster factory
        monsterPrefabDict = new Dictionary<string, GameObject>();
		monsterPrefabDict.Add("MiniMonster", 
			(GameObject)Resources.Load("Monster/Minimonster", typeof(GameObject)));
        monsterPrefabDict.Add("BossMonster",
            (GameObject)Resources.Load("Monster/Bossmonster", typeof(GameObject)));

    }

	// function to spawn new monster at given position
	public void SpawnMonster(Vector3 position, string monsterType)
	{
		GameObject newMonster;
		newMonster = Instantiate(monsterPrefabDict[monsterType], position, Quaternion.identity);
		enemyList.Add(newMonster);
	}

	public void FreezeAllMiniMonster(float freezeTime)
	{
		foreach (GameObject monster in enemyList)
		{
			// ignore dead monster
			if (!monster)
				continue;
			MonsterController controller = monster.GetComponent<MonsterController>();
			controller.Freeze(freezeTime);
		}
	}

	public string[] GetAllMonsterType()
	{
		return monsterPrefabDict.Keys.ToArray();
	}

	public void resetEnemy()
	{
		for (int i = 0; i < enemyList.Count; i++)
			if (enemyList[i] != null)
				Destroy(enemyList[i]);
		enemyList.Clear();
	}
}
