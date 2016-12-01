using UnityEngine;
using System.Collections;

public class Gyro : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		// ジェイロ機能を使用する
		Input.gyro.enabled = true;
	}

	// Update is called once per frame
	void Update () 
	{
		// ジェイロ機能をカメラに反映する
		transform.rotation = Quaternion.AngleAxis(90.0f,Vector3.right)*Input.gyro.attitude*Quaternion.AngleAxis(180.0f,Vector3.forward);
	}
}
