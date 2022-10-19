using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBController : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody2D rigidbody;
    Animator animator;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

        // update animation
    }

    private void FixedUpdate()
    {
        if (movement != null)
        {
            if (movement.SqrMagnitude() > 0)
            {
                Debug.Log(movement);

            }
            rigidbody.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
        }
    }
}
