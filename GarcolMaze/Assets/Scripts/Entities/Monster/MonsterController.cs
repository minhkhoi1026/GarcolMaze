using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MonsterController : MonoBehaviour {
	public int damagePoint = 5;
	void Start() {
	
	}

	void Update() {
		
	}

	public abstract void Freeze(float freezeTime);

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag.StartsWith("Player"))
		{
			PlayerController player = collision.gameObject.GetComponent<PlayerController>();
			if (player != null)
				player.Damage(damagePoint);
		}
	}
}
