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

    }

	// function to spawn new monster at given position
	public void SpawnMonster(Vector3 position, string monsterType)
	{
		GameObject newMonster;
		newMonster = Instantiate(monsterPrefabDict[monsterType], position, Quaternion.identity);
		enemyList.Add(newMonster);
	}

	public void FreezeAllMiniMonster()
	{
		foreach (GameObject monster in enemyList)
		{
			MonsterController controller = monster.GetComponent<MonsterController>();
			controller.Freeze();
		}
	}

	public string[] GetAllMonsterType()
	{
		return monsterPrefabDict.Keys.ToArray();
	}
}
