using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : Collectable
{
	public float SPEED_INCREASED = 4f;
	public int BOOSTED_TIME = 3; // SECOND
	public override void Collect(PlayerController player)
	{
		player.boostSpeed(SPEED_INCREASED, BOOSTED_TIME);
		PlaySound("speedItem");

	}

	public override void Use()
	{

	}
}
