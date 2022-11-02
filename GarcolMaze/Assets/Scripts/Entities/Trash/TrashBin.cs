using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : Interactable
{
	public TrashType trashType;
	public GameObject dialogPrefab;
	private int showTime = 2;
	private GameObject dialogShow = null;
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (showTime == 0) return;
		if (collision.gameObject.tag.StartsWith("Player"))
		{
			dialogShow = GameObject.Instantiate(dialogPrefab) as GameObject;
			RectTransform rectTransform = dialogShow.GetComponent<RectTransform>();
			rectTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position) + new Vector3(0, 48, 0);
			
			Canvas canvas = GameObject.FindObjectOfType<Canvas>();
			rectTransform.SetParent(canvas.transform);

			showTime -= 1;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (dialogShow != null)
		{
			Destroy(dialogShow);
			dialogShow = null;
		}
	}
	public override void Interact(PlayerController player)
	{
		player.TakeOutTrash(trashType);
	}
}
