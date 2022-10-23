using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public virtual void Interact(PlayerController player) {}

	public virtual string GetInteractableType() { return "Interactable"; }
}
