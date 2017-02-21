using UnityEngine;
using System.Collections;

public class TurnAround : MonoBehaviour {
	public bool turn;
	private int scalingFactor;
	public GameObject Turtle;
	public GameObject Cam;
	private bool turnRightFlag;

	// Use this for initialization
	void Start () {
		turn = false;
		scalingFactor = 70;
		turnRightFlag = true;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Turtle.transform.position.z < -2635 && !turn) {
			Turn ();
		}

	}
	void Turn(){
		if (!turn) {
			//if (Cam.transform.eulerAngles >= 180) {
			//	turnRightFlag = false;
			//}
			Input.gyro.enabled = false;
			transform.Rotate (Vector3.up * scalingFactor * Time.deltaTime);//, Space.World);
			if (Cam.transform.localEulerAngles.y > 179) {
				Input.gyro.enabled = true;
				turn = true;
			}
		}
	}
}
