using UnityEngine;
using System.Collections;

public class Examine : MonoBehaviour {

	public string text;
	public float time;
	public bool working = false;

	private Transform playerCanvas;
	private GameObject examineRef;
	private Interaction interaction;

	void Start () {
		playerCanvas = GameObject.Find ("PlayerCanvas").transform;
		examineRef = (Resources.Load ("Prefabs/Examine") as GameObject);
		interaction = GetComponent<Interaction> ();
	}

	void Update () {
		if (interaction.isActive() && !working) {
			interaction.Deactivate ();
			interaction.interactable = false;

			GameObject examineObject = Instantiate (examineRef);

			examineObject.transform.position = playerCanvas.position;
			examineObject.transform.rotation = playerCanvas.rotation;

			examineObject.GetComponent<ExamineUI> ().examineText = text;
			examineObject.GetComponent<ExamineUI> ().time = time;
			StartCoroutine (StartWorking());
			StartCoroutine (examineObject.GetComponent<ExamineUI> ().startExamine());
		}
	}

	IEnumerator StartWorking () {
		working = true;
		yield return new WaitForSeconds (time);
		yield return new WaitForSeconds (2);
		working = false;
		interaction.interactable = true;
	}
}
