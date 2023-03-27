using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static Dictionary<string, AudioClip> sounds;
	static AudioSource audioSource;

	private void Start()
	{
		sounds = new Dictionary<string, AudioClip>();

		sounds["collectItem"] = Resources.Load<AudioClip>("Audio/Sounds/collectItem");
		sounds["collectTrash"] = Resources.Load<AudioClip>("Audio/Sounds/collectTrash");
		sounds["speedItem"] = Resources.Load<AudioClip>("Audio/Sounds/speedItem");
		sounds["freezeItem"] = Resources.Load<AudioClip>("Audio/Sounds/freezeItem");
		
		sounds["hitMonster"] = Resources.Load<AudioClip>("Audio/Sounds/hitMonster");
		sounds["damaged"] = Resources.Load<AudioClip>("Audio/Sounds/damaged");
		sounds["die"] = Resources.Load<AudioClip>("Audio/Sounds/die");

		sounds["button"] = Resources.Load<AudioClip>("Audio/Sounds/button");
		sounds["throwTrash"] = Resources.Load<AudioClip>("Audio/Sounds/throwTrash");
		sounds["switch"] = Resources.Load<AudioClip>("Audio/Sounds/switch");

		sounds["win"] = Resources.Load<AudioClip>("Audio/Sounds/win");
		sounds["lose"] = Resources.Load<AudioClip>("Audio/Sounds/lose");



		audioSource = GetComponent<AudioSource>();
	}

	public static void PlaySound(string clip)
	{
		if (sounds.ContainsKey(clip))
			audioSource.PlayOneShot(sounds[clip]);
	}
}
