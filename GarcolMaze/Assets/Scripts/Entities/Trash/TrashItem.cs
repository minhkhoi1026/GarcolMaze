using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrashType { Recyclable, NonRecyclable, Organic }


public class TrashItem : Collectable
{

	public TrashType trashType;

	public override void Collect(PlayerController player)
	{
		player.CollectTrashItem(trashType);
	}

	public override void Use()
	{
		
	}
}
