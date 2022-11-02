using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonFire : AutoTrigger
{
	public int burningDamage = 5;
	public float burningTime = 3f;
    private Animator animator;

	public override void applyEffect(Collider2D other)
	{
		if (other!.gameObject.tag.StartsWith("Player"))
		{
			PlayerController player = other.gameObject.GetComponent<PlayerController>();
			if (player != null)
				player.Damage(burningDamage, "Poisoned");
		}
	}

	public override void revertEffect(Collider2D other)
	{
		
	}

	// Start is called before the first frame update
	void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        animator.SetBool("IsBurning", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (burningTime > 0)
		{
            burningTime -= Time.deltaTime;
		} else if (animator.GetBool("IsBurning"))
		{
            animator.SetBool("IsBurning", false);
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
		}
    }
    

}
