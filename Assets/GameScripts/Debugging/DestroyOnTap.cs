using UnityEngine;
using System.Collections;

public class DestroyOnTap : MonoBehaviour {
	private Interaction interaction;

	void Start () {
		interaction = GetComponent<Interaction> ();
	}

	void Update () {
		if (interaction.isActive()) {
			Destroy(this.gameObject);
		}
	}
}
