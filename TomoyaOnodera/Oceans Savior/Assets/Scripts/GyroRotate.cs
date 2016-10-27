using UnityEngine;
using System.Collections;
public class GyroRotate : MonoBehaviour
{
	public float Speed;
    float yRotation; float xRotation;
	Vector3 vec;

    void Start()
    {
		// ジェイロ機能を使用する
        Input.gyro.enabled = true;
		// 初期化
		vec = new Vector3(0.0f,0.0f,0.0f);
    }

    void Update()
    {
		//カメラの向いている方向に移動
		vec = transform.localEulerAngles;
		vec = new Vector3 (Mathf.Sin(vec.y*(Mathf.PI/180.0f))/Speed, 0.0f,Mathf.Cos(vec.y*(Mathf.PI/180.0f))/Speed);
		transform.position += vec;

		// 加速度をカメラに反映する
		yRotation += -Input.gyro.rotationRateUnbiased.y; 
		xRotation += -Input.gyro.rotationRateUnbiased.x;
		transform.eulerAngles = new Vector3(xRotation,yRotation, 0);

    }

}
