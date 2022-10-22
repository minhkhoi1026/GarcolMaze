using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TRASH_TYPE { Recyclable, NonRecyclable, Organic }


public class TrashItem : Collectable
{

	public TRASH_TYPE trashType;

	public override void Collect()
	{
		
	}

	public override void Use()
	{
		
	}
}
