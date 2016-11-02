using UnityEngine;
using System.Collections;

public class RayTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Rayを作成
		Ray ray = new Ray (transform.position, transform.forward);
		// Rayと衝突したオブジェクトを格納する変数
		RaycastHit hit;
		// Rayの届く距離
		float maxRayDistance = 20.0f;
		// Rayの半径
		float rayRadius = 0.5f;
		// 球状のRayを飛ばす
		if (Physics.SphereCast (ray, rayRadius, out hit, maxRayDistance)) {
			// 当たったオブジェクトのカラーを変更
			hit.collider.GetComponent<MeshRenderer> ().material.color = Color.red;
			// Rayを可視化
			Debug.DrawRay(ray.origin, ray.direction * maxRayDistance, Color.red, 0.0f);
		} else {
			// Rayを可視化
			Debug.DrawRay(ray.origin, ray.direction * maxRayDistance, Color.blue, 0.0f);
		}


	}
}
