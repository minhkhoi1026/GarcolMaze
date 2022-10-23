using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : Interactable
{
	public TrashType trashType;
	public override void Interact(PlayerController player)
	{
		player.TakeOutTrash(trashType);
	}
}
