using UnityEngine;
using System.Collections;

public enum InteractionType{Examine, Grab, Door, Move, Stairs};

public class Interaction : MonoBehaviour {
	public bool interactable = true;
	public InteractionType type;

	private bool active;

	public void Activate(){
		if(interactable)
			active = true;
	}

	public void Deactivate(){
		active = false;
	}

	public bool isActive(){
		return active;
	}
}
