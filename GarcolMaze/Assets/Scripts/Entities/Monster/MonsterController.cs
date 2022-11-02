using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MonsterController : MonoBehaviour {
	public int damagePoint = 5;
	protected bool isFreezed;

	void Start() {
		isFreezed = false;
    }

	void Update() {
		
	}

	public abstract void Freeze(float freezeTime);


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.StartsWith("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            InteractWhenHitPlayer(player);
        }
    }

    protected abstract void InteractWhenHitPlayer(PlayerController player);
}
