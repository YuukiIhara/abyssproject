using UnityEngine;
using System.Collections;

public class RotateWithGyro : MonoBehaviour {
#if UNITY_EDITOR
	// カメラリセット用変数
	Vector3 	defaultPosition; 	// デフォルト座標保存用
	Quaternion 	defaultRotation; 	// デフォルト角度保存用
	float 		defaultZoom; 		// デフォルトズーム保存用
	Vector3		cameraForward;
#else
	Vector3		cameraForward;
	float yRotation = -180;
	float xRotation = 0;
#endif
	// Use this for initialization
	void Start () {
#if UNITY_EDITOR
		//　デフォルト位置を保存
		defaultPosition = Camera.main.transform.position;
		defaultRotation = Camera.main.transform.rotation;
		defaultZoom = Camera.main.fieldOfView; 	
#else
		Input.gyro.enabled = true;
#endif
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
		// カメラ移動
		if (Input.GetMouseButton (0)) {
			cameraForward = Camera.main.transform.forward;
			Camera.main.transform.Translate(cameraForward, Space.World);
		}
		if (Input.GetMouseButton (1)) {
			cameraForward = Camera.main.transform.forward;
			Camera.main.transform.Translate(5*cameraForward, Space.World);
		}
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
		/*
		if (Input.GetMouseButton (0)) {
			Camera.main.transform.Translate (
				Input.GetAxisRaw ("Mouse X") * 10,
				Input.GetAxisRaw ("Mouse Y") * 10,
				0
			);
		}
		// カメラ回転
		if (Input.GetMouseButton (1)) {
			Camera.main.transform.Rotate (
				Input.GetAxisRaw ("Mouse Y") * 10,
				Input.GetAxisRaw ("Mouse X") * 10,
				0
			);
		}*/
		// ズームイン・ズームアウト
		Camera.main.fieldOfView += ( 20 * Input.GetAxis("Mouse ScrollWheel") );
		if (Camera.main.fieldOfView < 10) {
			Camera.main.fieldOfView = 10;
		} else if (Camera.main.fieldOfView > 100) {
			Camera.main.fieldOfView = 100;
		}
		// カメラ位置リセット
		if (Input.GetMouseButton (2)) {
			Camera.main.transform.position = defaultPosition;
			Camera.main.transform.rotation = defaultRotation;
			Camera.main.fieldOfView = defaultZoom;
		}
#else
		yRotation += -Input.gyro.rotationRateUnbiased.y;
		xRotation += -Input.gyro.rotationRateUnbiased.x;

		transform.eulerAngles = new Vector3(xRotation, yRotation, 0);

		if(Input.touchCount > 0)
		{
			foreach(Touch t in Input.touches)
			{
				if (t.phase == TouchPhase.Stationary)
				{
					cameraForward = Camera.main.transform.forward;
					Camera.main.transform.Translate(5*cameraForward, Space.World);
				}
			}
		}
#endif
	}
}


