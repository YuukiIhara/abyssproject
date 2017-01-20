using UnityEngine;
using System.Collections;

public class TurnAround : MonoBehaviour {
	public bool turn;
	private int scalingFactor;



	// Use this for initialization
	void Start () {
		turn = false;
		scalingFactor = 70;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (GameObject.Find ("Turtle").transform.position.z < -2635 && !turn) {
		//if (GameObject.Find ("Turtle").transform.position.z < 50 && !turn) {
			Turn ();
		}

	}
	void Turn(){
		if (!turn) {
			Input.gyro.enabled = false;
			transform.Rotate(Vector3.up * scalingFactor * Time.deltaTime, Space.World);
				if(GameObject.Find ("Cam").transform.localEulerAngles.y >179){
				Input.gyro.enabled = true;
				turn = true;
	
			}
		}
	}
}
