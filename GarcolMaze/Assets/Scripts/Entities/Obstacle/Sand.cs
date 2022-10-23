using System.Collections;
using UnityEngine;


public class Sand : Obstacle
{
    public override void applyEffect(Collider2D other)
    {
        if (other!.attachedRigidbody != null)
        {
            other.attachedRigidbody.drag = 100;
        }
    }

    public override void revertEffect(Collider2D other)
    {
        if (other!.attachedRigidbody != null)
        {
            other.attachedRigidbody.drag = 0;
        }
    }

    // Use this for initialization
    void Start(){}

    // Update is called once per frame
    void Update(){}
}
