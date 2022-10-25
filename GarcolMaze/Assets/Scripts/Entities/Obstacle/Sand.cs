using System.Collections;
using UnityEngine;


public class Sand : AutoTrigger
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
}
