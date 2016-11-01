using UnityEngine;
using System.Collections;
public class GyroRotate : MonoBehaviour
{
	public GameObject EffectPrefab;
	public Vector3 EffectRotation;


	public float MaxSpeed;
    float yRotation; float xRotation;
	Vector3 vec;

	float Speed_Y = 0.0f;
	bool flag = false;

	public GameObject mainCamera;
	public GameObject subCamera;

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
		if(flag == false)
		{
			vec = transform.localEulerAngles;
			vec = new Vector3 (Mathf.Sin(vec.y*(Mathf.PI/180.0f))/100.0f*MaxSpeed,Speed_Y,Mathf.Cos(vec.y*(Mathf.PI/180.0f))/100.0f*MaxSpeed);
		}
		transform.position += vec;

		// 加速度をカメラに反映する
		yRotation += -Input.gyro.rotationRateUnbiased.y; 
		xRotation += -Input.gyro.rotationRateUnbiased.x;
		transform.eulerAngles = new Vector3(xRotation,yRotation, 0);

    }

	// スピードの増加
	void AddSpeed()
	{
		MaxSpeed += 1.3f;
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

			if(EffectPrefab != null)
			{
				// Candyのポジションにエフェクトを表示
				// インスタンシェイト
				EffectRotation = transform.localEulerAngles;
				Instantiate (
					EffectPrefab,
					other.transform.position,
					Quaternion.Euler (EffectRotation));
			}
		}

		// ゴールの判定
		if(other.gameObject.tag == "Goal")
		{
			// Rigitbodyの削除
			Destroy (this.gameObject.GetComponent<Rigidbody>());

			// 上軸に移動量を加える
			Speed_Y = 0.15f;
			MaxSpeed += 25.0f;
			vec = transform.localEulerAngles;
			vec = new Vector3 (Mathf.Sin(vec.y*(Mathf.PI/180.0f))/100.0f*MaxSpeed,Speed_Y,Mathf.Cos(vec.y*(Mathf.PI/180.0f))/100.0f*MaxSpeed);
			flag = true;

			// カメラの切り替え
			mainCamera.SetActive(false);
			subCamera.SetActive (true);
		}
	}
}
