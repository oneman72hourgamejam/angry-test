using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]

public class CameraOrtho : MonoBehaviour {

	private Camera Cam = null;
	public float PixelsToWorldUnits = 200f;

	// Use this for initialization
	void Awake () {
		Cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Cam.orthographicSize = Screen.height / 2f / PixelsToWorldUnits;
	}
}
