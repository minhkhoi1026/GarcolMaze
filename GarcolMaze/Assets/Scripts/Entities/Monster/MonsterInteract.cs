using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterInteract : MonoBehaviour {
	void Start() {
	
	}

	void Update() {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.StartsWith("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            MonsterController monster = this.transform.parent.gameObject.GetComponent<MonsterController>();
            monster.InteractWhenHitPlayer(player);
        }
    }
}
