using UnityEngine;
using System.Collections;
public class GyroRotate : MonoBehaviour
{
	float yRotation;

	public bool turn;
	public GameObject Turtle;
	public GameObject Cam;

	void Start()
	{
		Input.gyro.enabled = true;
		turn = false;
	}

	void Update()
	{
#if UNITY_EDITOR

#else
		yRotation += -Input.gyro.rotationRateUnbiased.y*2; 

		var rotation = Quaternion.AngleAxis (90.0f, Vector3.right) * Input.gyro.attitude * Quaternion.AngleAxis (180.0f, Vector3.forward);

		if (Turtle.transform.position.z < -2635 && !turn) {
			Turn ();
		}

		transform.localEulerAngles = new Vector3 (rotation.eulerAngles.x, yRotation, 0);
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
