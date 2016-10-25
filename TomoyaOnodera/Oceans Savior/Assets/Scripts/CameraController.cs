

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	private GUIStyle labelStyle;
	Quaternion start_gyro;
	Quaternion gyro;
	void Start()
	{
		this.labelStyle = new GUIStyle();
		this.labelStyle.fontSize = Screen.height / 22;
		this.labelStyle.normal.textColor = Color.white;
	}


	void Update ()
	{
		Input.gyro.enabled = true;
		if (Input.gyro.enabled)
		{
			gyro = Input.gyro.attitude;
			gyro = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyro.x,-gyro.y, gyro.z, gyro.w));
			this.transform.localRotation = gyro;
			//最初に見ていた向きとゲームの進行方向を合わせる
			//this.transform.localRotation = Quaternion.Euler(0, -start_gyro.y, 0);
		}
	}
}

