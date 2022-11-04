using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Animator animator;

    public float moveSpeed = 3f;
    private HealthSystem healthSystem;

    protected int[] trashCountTotal = new int[] { 0, 0, 0 };
    protected int[] trashCountCurrent = new int[] { 0, 0, 0 };

    public CollectableStats collectableStats;
    public HealthBar healthBar;
    public GameObject textGUI;

    protected Vector2 movement;
	private void Awake()
	{
		healthSystem = new HealthSystem(this);
        healthSystem.InitHP(20);
        animator = GetComponent<Animator>();

    }

    public void CollectTrashItem(TrashType trashType)
    {
        ++trashCountCurrent[(int)trashType];
    }

    public void TakeOutTrash(TrashType trashType)
    {
        int cnt = trashCountCurrent[(int)trashType];
        if (cnt == 0)
            return;
        
        trashCountTotal[(int)trashType] += cnt;
        trashCountCurrent[(int)trashType] = 0;

        GameManager.instance.removeTrash(cnt);
        if (collectableStats != null)
        {
            int recycleableCnt = trashCountTotal[(int)TrashType.Recyclable];
            int nonRecycleableCnt = trashCountTotal[(int)TrashType.NonRecyclable];
            int organicCnt = trashCountTotal[(int)TrashType.Organic];
            collectableStats.UpdateStats(recycleableCnt, nonRecycleableCnt, organicCnt);
        }
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
            }
            else
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

    public void Damage(int point, string animationType = "Hit")
	{
        animator.SetTrigger(animationType);
        TextShow.showTextAbove(gameObject, textGUI, "-" + point);
        healthSystem.ChangeHP(-point);
	}

    public void Heal(int point)
	{
        healthSystem.ChangeHP(point);
	}

    public void Die()
	{
        GameManager.instance.removeCharacter(gameObject);
	}
}
