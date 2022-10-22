using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBController : PlayerController
{
    public const float PICKUP_RANGE = 0.5f;

    public float moveSpeed = 5f;
    Rigidbody2D rigidbody;
    Collider2D collider;
    Animator animator;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("P2_Horizontal");
        movement.y = Input.GetAxisRaw("P2_Vertical");
        movement.Normalize();
        if (movement.sqrMagnitude > 0)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            collectItems();
        }
    }

    private void FixedUpdate()
    {
        if (movement != null)
        {
            rigidbody.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
        }
    }

    private void collectItems()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(collider.bounds.center, PICKUP_RANGE);
        foreach (Collider2D c in colliders)
        {
            Collectable item = c.GetComponent<Collectable>();
            if (item != null)
            {
                item.Collect(this);
                Destroy(item.gameObject);
            }
        }
    }
}
