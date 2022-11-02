using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonFire : MonoBehaviour
{
    public float burningTime = 3f;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
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
