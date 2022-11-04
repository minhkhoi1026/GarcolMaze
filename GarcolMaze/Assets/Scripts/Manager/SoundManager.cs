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

		audioSource = GetComponent<AudioSource>();
	}

	public static void PlaySound(string clip)
	{
		if (sounds.ContainsKey(clip))
			audioSource.PlayOneShot(sounds[clip]);
	}
}
