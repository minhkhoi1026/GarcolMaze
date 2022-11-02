using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBController : PlayerController
{
    public const float PICKUP_RANGE = 0.5f;

    Rigidbody2D rigidbody;
    Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
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
            collectItems(collider.bounds.center, PICKUP_RANGE);
        }
    }

    private void FixedUpdate()
    {
        if (movement != null)
        {
            rigidbody.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
        }
    }
}
