using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected int[] trashCountTotal = new int[] { 0, 0, 0 };
    protected int[] trashCountCurrent = new int[] { 0, 0, 0 };

    public void CollectTrashItem(TrashType trashType) {
        ++trashCountCurrent[(int)trashType];
        Debug.Log(trashType.ToString());    
    }

    protected void TakeOutTrash()
	{
        for (int i = 0; i < 3; ++i)
		{
            trashCountTotal[i] += trashCountCurrent[i];
            trashCountCurrent[i] = 0;
		}
	}
}
