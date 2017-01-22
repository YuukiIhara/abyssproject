using UnityEngine;
using System.Collections;

public class RotateWithKeybord : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// カメラ回転
		if (Input.GetKey (KeyCode.A)) {
			Camera.main.transform.Rotate (0f, -1.0f, 0, Space.World);
		}
		if (Input.GetKey (KeyCode.D)) {
			Camera.main.transform.Rotate (0f, 1.0f, 0, Space.World);
		}
		if (Input.GetKey (KeyCode.W)) {
			Camera.main.transform.Rotate (-1.0f, 0f, 0);
		}
		if (Input.GetKey (KeyCode.S)) {
			Camera.main.transform.Rotate (1.0f, 0f, 0);
		}
	}
}
