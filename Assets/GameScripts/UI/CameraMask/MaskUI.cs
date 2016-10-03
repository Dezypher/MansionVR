using UnityEngine;
using System.Collections;

public class MaskUI : MonoBehaviour {

	private Camera cam;

	void Start () {
		cam = GetComponent<Camera> ();
	}

	void Update () {
		cam.cullingMask = 1 << 5;
		cam.depth = 1;
		cam.clearFlags = CameraClearFlags.Depth;
	}
}
