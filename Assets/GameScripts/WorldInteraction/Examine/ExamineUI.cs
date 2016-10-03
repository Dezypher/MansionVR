using UnityEngine;
using System.Collections;

public class ExamineUI : MonoBehaviour {

	public float time;
	public UnityEngine.UI.Text textui;
	public string examineText;

	public IEnumerator startExamine(){
		textui.text = examineText;

		Color color = textui.color;
		color.a = 0;
		textui.color = color;

		StartCoroutine(fadeIn ());
		yield return new WaitForSeconds (time);
		StartCoroutine(fadeOut ());
		yield return new WaitForSeconds (2);
		Destroy (this.gameObject);
	}

	IEnumerator fadeIn(){
		float alpha = 0.0f;

		while (alpha <= 1) {
			alpha += 0.01f;
			Color color = textui.color;
			color.a = alpha;
			textui.color = color;
			yield return new WaitForSeconds(0.01f);
		}
	}

	IEnumerator fadeOut(){
		float alpha = 1.0f;

		while (alpha > 0) {
			alpha -= 0.01f;
			Color color = textui.color;
			color.a = alpha;
			textui.color = color;
			yield return new WaitForSeconds(0.01f);
		}
	}
}
