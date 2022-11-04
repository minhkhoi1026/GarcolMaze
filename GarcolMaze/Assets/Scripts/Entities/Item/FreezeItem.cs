using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeItem : Collectable
{
	public float freezeTime = 3f;
	public override void Collect(PlayerController player)
	{
		GameManager.instance.enemyManager.FreezeAllMiniMonster(freezeTime);
		PlaySound("freezeItem");
	}

	public override void Use()
	{
		
	}
}
