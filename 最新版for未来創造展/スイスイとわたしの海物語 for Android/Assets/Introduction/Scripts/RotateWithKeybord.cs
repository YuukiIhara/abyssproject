using UnityEngine;
using System.Collections;

public class RotateWithKeybord : MonoBehaviour {
	public bool turn;
	public GameObject Turtle;
	public GameObject Cam;

	float yRotation;
	float xRotation;
	// Use this for initialization
	void Start () {
		turn = false;
	}
	
	// Update is called once per frame
	void Update () {
		// カメラ回転
		//if (Input.GetKey (KeyCode.A)) {
		//	Camera.main.transform.Rotate (0f, -2.0f, 0, Space.World);
		//}
		//if (Input.GetKey (KeyCode.D)) {
		//	Camera.main.transform.Rotate (0f, 2.0f, 0, Space.World);
		//}
		//if (Input.GetKey (KeyCode.W)) {
		//	Camera.main.transform.Rotate (-2.0f, 0f, 0);
		//}
		//if (Input.GetKey (KeyCode.S)) {
		//	Camera.main.transform.Rotate (2.0f, 0f, 0);
		//}
#if UNITY_EDITOR

		if (Input.GetKey (KeyCode.A)) {
			yRotation += -4.0f; 
		}
		if (Input.GetKey (KeyCode.D)) {
			yRotation += 4.0f; 
		}
		if (Input.GetKey (KeyCode.W)) {
			xRotation += -4.0f;
		}
		if (Input.GetKey (KeyCode.S)) {
			xRotation += 4.0f;
		}

		if (Input.GetMouseButton (1)) {
			xRotation += -Input.GetAxisRaw ("Mouse Y") * 6;
			yRotation += Input.GetAxisRaw ("Mouse X") * 6;
		}

		if (Turtle.transform.position.z < -2635 && !turn) {
			Turn ();
		}

		transform.localEulerAngles = new Vector3 (xRotation, yRotation, 0);
#endif
	}

	void Turn(){
		if (!turn) {
			Input.gyro.enabled = false;
			yRotation += 4.0f;
			if (yRotation > 179.0f) {
				Input.gyro.enabled = true;
				turn = true;
			}
		}
	}
}
