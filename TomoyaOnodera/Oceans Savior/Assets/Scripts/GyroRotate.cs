using UnityEngine;
using System.Collections;
public class GyroRotate : MonoBehaviour
{
	public float MaxSpeed;
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
		vec = new Vector3 (Mathf.Sin(vec.y*(Mathf.PI/180.0f))/100.0f*MaxSpeed, 0.0f,Mathf.Cos(vec.y*(Mathf.PI/180.0f))/100.0f*MaxSpeed);
		transform.position += vec;

		// 加速度をカメラに反映する
		yRotation += -Input.gyro.rotationRateUnbiased.y; 
		xRotation += -Input.gyro.rotationRateUnbiased.x;
		transform.eulerAngles = new Vector3(xRotation,yRotation, 0);

    }

	// スピードの増加
	void AddSpeed()
	{
		MaxSpeed++;
	}

	// あたり判定
	void OnCollisionEnter(Collision other)
	{
		// エクストラアイテムの判定
		if(other.gameObject.tag == "ExtraItem")
		{
			// プレイヤーのスピードアップ
			AddSpeed();

			// オブジェクトを削除
			Destroy(other.gameObject);
		}
	}
}
