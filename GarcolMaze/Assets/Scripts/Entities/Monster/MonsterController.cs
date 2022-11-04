using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterController : MonoBehaviour {
	public int damagePoint = 5;
	protected bool isFreezed;

    private void Start()
    {
        isFreezed = false;
    }

	void Update() {
		
	}

	public abstract void Freeze(float freezeTime);


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.StartsWith("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            InteractWhenHitPlayer(player);
        }
    }

    protected abstract void InteractWhenHitPlayer(PlayerController player);
}
