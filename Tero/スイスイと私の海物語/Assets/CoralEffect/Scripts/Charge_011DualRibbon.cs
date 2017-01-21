using UnityEngine;
using System.Collections;

public class Charge_011DualRibbon : MonoBehaviour {


	// 到達点のオブジェクト取得
	public GameObject playerObj;

	#if UNITY_EDITOR
	// 到達するまでの時間
	int nFPSCnt = 50;
	int nDeleteTime = 80;
	#else
	// 到達するまでの時間
	int nFPSCnt = 25;
	int nDeleteTime = 40;
	#endif
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// 到達点までの距離を求める
		float fLenX = playerObj.transform.position.x - gameObject.transform.position.x;
		float fLenY = playerObj.transform.position.y - gameObject.transform.position.y;
		float fLenZ = playerObj.transform.position.z - gameObject.transform.position.z;
		//float fLength = ((fLenX * fLenX) + (fLenY * fLenY) + (fLenZ * fLenZ));

		// 自分自身からオブジェクトの方向ベクトルを求める
		//float VecX = fLenX/fLength;
		//float VecY = fLenX/fLength;
		//float VecZ = fLenX/fLength;

		// パーティクルの移動
		Vector3 Value = new Vector3(fLenX / nFPSCnt,fLenY / nFPSCnt,fLenZ / nFPSCnt);
		gameObject.transform.position += Value;

		// カウントを減らす
		nFPSCnt--;

		// パーティクルの破棄
		if(nFPSCnt == 0) nDeleteTime--;
		if(nDeleteTime == 0) Destroy(this.gameObject);

	}
}
