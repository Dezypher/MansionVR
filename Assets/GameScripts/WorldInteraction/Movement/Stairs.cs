using UnityEngine;
using System.Collections;

public class Stairs : MonoBehaviour {

	public Transform target;

	private Movement playerMovement;
	private Interaction interaction;

	void Start () {
		interaction = GetComponent<Interaction> ();
		playerMovement = GameObject.Find ("Player")
						.GetComponent<Movement> ();
	}

	void Update () {
		if (interaction.isActive()) {
			playerMovement.MoveTo (target.position, true);
			interaction.Deactivate ();
		}
	}
}
