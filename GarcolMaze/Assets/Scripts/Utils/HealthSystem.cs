using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    public int maxHP;
    private int HP;
	private PlayerController playerController;
    HealthSystem()
	{
		HP = 0;
	}

	public HealthSystem(PlayerController player)
	{
		playerController = player;
		HP = 0;
	}

    public void InitHP(int point)
	{
		if (playerController == null)
			return;
        maxHP = HP = point;
		playerController.healthBar?.setMaxHealth(maxHP);
	}

    public void ChangeHP(int point)
	{
		if (playerController == null)
			return;
		HP += point;
		if (HP > maxHP) {
			point = 0;
			HP = maxHP; 
		}
		playerController.healthBar?.setHealth(HP < 0 ? 0 : HP);
        if (HP <= 0)
		{
			playerController.Die();
		}
	}
}
