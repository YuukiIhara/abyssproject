using UnityEngine;
using System.Collections;

public class RotateWithGyro : MonoBehaviour {

#if UNITY_EDITOR
	// カメラリセット用変数
	Vector3 	defaultPosition; 	// デフォルト座標保存用
	Quaternion 	defaultRotation; 	// デフォルト角度保存用
	float 		defaultZoom; 		// デフォルトズーム保存用
#endif
	float yRotation;
	float xRotation;

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
		}
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
#endif
	}
}
