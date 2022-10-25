using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;

    protected int[] trashCountTotal = new int[] { 0, 0, 0 };
    protected int[] trashCountCurrent = new int[] { 0, 0, 0 };


    public void CollectTrashItem(TrashType trashType) {
        ++trashCountCurrent[(int)trashType];
        Debug.Log(trashType.ToString());
    }

    public void TakeOutTrash(TrashType trashType)
	{
        trashCountTotal[(int)trashType] += trashCountCurrent[(int)trashType];
        trashCountCurrent[(int)trashType] = 0;
	}

    protected void collectItems(Vector2 position, float pickupRange)
	{
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, pickupRange);
        foreach (Collider2D c in colliders)
        {
            Collectable item = c.GetComponent<Collectable>();
            if (item != null)
            {
                item.Collect(this);
                Destroy(item.gameObject);
            } else
			{
                Interactable interactableObj = c.GetComponent<Interactable>();
                if (interactableObj != null)
				{
                    interactableObj.Interact(this);
				}
			}
        }
    }

    // functionality

    public void boostSpeed(float effectSpeed, int boostedTime)
	{
        moveSpeed += effectSpeed;
        StartCoroutine(speedTime());
        IEnumerator speedTime()
		{
            yield return new WaitForSeconds(boostedTime);
            moveSpeed -= effectSpeed;
		}
	}
}
