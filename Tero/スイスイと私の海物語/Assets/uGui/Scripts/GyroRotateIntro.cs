using UnityEngine;
using System.Collections;
public class GyroRotateIntro : MonoBehaviour
{
    float yRotation; float xRotation;

	// ドライブの補正
	float fValue = 0.0f;
	//bool i = true;
    void Start()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
		//if (i == true && Input.GetButtonDown("Fire1"))
		{
			//i = false;

			/*
			Quaternion gattitude = Input.gyro.attitude;
			gattitude.x *= -1;
			gattitude.y *= -1;
			var localRotation = 
				Quaternion.Euler(90, 0, 0) * gattitude;*/
			//Debug.Log(xRotation);
		} 
		//else if(i == false)
		{
			// 傾いた分の移動量を加算
			yRotation += -Input.gyro.rotationRateUnbiased.y;
			xRotation += -Input.gyro.rotationRateUnbiased.x;
			//var rotation = Quaternion.AngleAxis (90.0f, Vector3.right) * Input.gyro.attitude * Quaternion.AngleAxis (180.0f, Vector3.forward);
			////Debug.Log (rotation.eulerAngles.x);
			//if(xRotation >= 360.0f)
			//{
			//	xRotation -= 360.0f;
			//}
			//if(xRotation <= -360.0f)
			//{
			//	xRotation += 360.0f;
			//}
			//
			//// 実際の傾きと今の傾きの差を比べ、あまりにも差が出ていた場合は補正する。
			//if ((Mathf.Abs (rotation.eulerAngles.x - xRotation)) > 5.0f)
			//{
			//	//&& fValue < 1.0f
			//	//fValue += 0.01f;
			//	//xRotation += (rotation.eulerAngles.x - xRotation) * fValue;
			//	xRotation = rotation.eulerAngles.x;
			//} 
			//else 
			//{
			//	fValue = 0.0f;
			//}

			// カメラの視点設定
			transform.eulerAngles = new Vector3 (xRotation, yRotation, 0);
		}
    }
}
