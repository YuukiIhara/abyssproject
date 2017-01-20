using UnityEngine;
using System.Collections;
public class GyroRotate : MonoBehaviour
{
	float yRotation; float xRotation;
	void Start()
	{
		Input.gyro.enabled = true;
	}

	void Update()
	{
			yRotation += -Input.gyro.rotationRateUnbiased.y*2; 
			xRotation += -Input.gyro.rotationRateUnbiased.x*2;

			//transform.eulerAngles = new Vector3(xRotation, yRotation, 0);
			transform.localEulerAngles = new Vector3 (xRotation, yRotation, 0);
	}
}
