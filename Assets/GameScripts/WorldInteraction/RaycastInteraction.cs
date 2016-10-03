using UnityEngine;
using System.Collections;

public class RaycastInteraction : MonoBehaviour {
	public Transform cursor;
	public UnityEngine.UI.Image cursorSprite;
	public CursorReference cursorReference;
	public float interactionRange;

	private Movement movement;
	private GameObject pointer;
	private GameObject currPointer;

	void Start () {
		movement = GameObject.Find("Player")
						.GetComponent<Movement> ();
		pointer = Resources.Load ("Prefabs/Pointer") as GameObject;
	}

	void Update () {
		RaycastHit hit;
		Ray ray = new Ray (transform.position, cursor.position - transform.position);

		//Debug.DrawRay (transform.position, cursor.position - transform.position);

		if (Input.touchCount > 0 || Input.GetMouseButtonDown(0)) {
			if (Physics.Raycast (ray, out hit)) {
				GameObject objectHit = hit.transform.gameObject;
				if (objectHit.tag == "Interactable") {
					int type = (int)objectHit.GetComponent<Interaction> ()
						.type;
					if (type == 3) {
						movement.MoveTo (hit.point, false);

						Destroy (currPointer);

						currPointer = Instantiate (pointer);
						currPointer.transform.position = hit.point;
					} else {
						float dist = Vector3.Distance (transform.position, hit.point);

						if (dist <= interactionRange) {
							objectHit.GetComponent<Interaction> ()
								.Activate ();
						}
					}
				}
			}
		}

		bool defaultIcon = false;

		if (Physics.Raycast (ray, out hit)) {
			GameObject objectHit = hit.transform.gameObject;
			if (objectHit.tag == "Interactable") {
				int type = (int)objectHit.GetComponent<Interaction> ()
					.type;
				bool interactable = (bool)objectHit.GetComponent<Interaction> ()
					.interactable;
				float dist = Vector3.Distance (transform.position, hit.point);
				if ((type == 3 || (dist <= interactionRange)) && interactable) {
					int size = cursorReference.size [type + 1];
					cursorSprite.sprite = cursorReference.icons [type + 1];
					cursorSprite.rectTransform.sizeDelta = new Vector3 (size, size, 0);
				} else defaultIcon = true;
			} else defaultIcon = true;
		} else defaultIcon = true;

		if (defaultIcon) {
			int size = cursorReference.size [0];
			cursorSprite.sprite = cursorReference.icons [0];
			cursorSprite.rectTransform.sizeDelta = new Vector3 (size, size, 0);
		}

		if (!movement.isMoving ()) {
			DestroyPointer ();
		}
	}

	public void DestroyPointer(){
		if (currPointer != null)
			Destroy (currPointer);
	}
}
