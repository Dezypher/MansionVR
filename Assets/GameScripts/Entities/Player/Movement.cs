using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	public float speed;
	public float threshold;

	private Vector3 target;	
	private bool moving = false;
	private bool canMove = true;

	public void MoveTo(Vector3 target, bool stairs){
		if (canMove) {
			this.target = target;
			moving = true;

			if (stairs)
				canMove = false;
		}
	}

	void Update () {
		if (moving) {
			transform.position = Vector3.MoveTowards(transform.position, target, (speed * Time.deltaTime));

			float distance = Vector3.Distance (target, transform.position);
			if (distance <= threshold) {
				moving = false;
				canMove = true;
			}
		}
	}

	public bool isMoving(){
		return moving;
	}
}
