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
		yRotation += -Input.gyro.rotationRateUnbiased.y; 
		xRotation += -Input.gyro.rotationRateUnbiased.x;

		transform.eulerAngles = new Vector3(xRotation, yRotation, 0);
    }
}
