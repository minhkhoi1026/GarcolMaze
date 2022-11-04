using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
	protected void PlaySound(string sound)
	{
		SoundManager.PlaySound(sound);
	}
	public abstract void Collect(PlayerController player);
	public abstract void Use();
}
