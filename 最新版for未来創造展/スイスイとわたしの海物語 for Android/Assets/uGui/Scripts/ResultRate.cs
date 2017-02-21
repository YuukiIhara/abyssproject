using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultRate : MonoBehaviour {

	// トランスフォームの宣言
	new Transform  transform;
	// 回転角
	float rot = Mathf.PI/2.0f;
	// 時間のカウント
	int TimeCnt = 0; 
	// 終了のフラグ
	bool bEndFlag = false;

	// RateTxtManagerの変数宣言
	public GameObject RateTxtManager;

	// Use this for initialization
	void Start () 
	{
		// トランスフォームの取得
		transform = GetComponent<Transform> ();

		// RateTxtManagerの初期化
		//RateTxtManager = GameObject.Find ("RateTxtManager");
	}
	
	// Update is called once per frame
	void Update () 
	{
		// リザルトレートの縮小＆移動
		if(RateTxtManager.GetComponent<RateTxtManager> ().GetEndFlag())
		{
			// 時間経過の測定
			TimeCnt++;

			if(TimeCnt <= 30)
			{
				// 回転角の加算処理
				//rot += (Mathf.PI/2.0f)/30.0f;
				// 縦のサイズを加算
				//Vector3 Addnum = new Vector2 (Mathf.Sin(rot)*0.012f,Mathf.Sin(rot)*0.012f);
				//transform.localScale -= Addnum;

				// ポジションの移動
				//transform.position += new Vector3 ((-Mathf.Sin(rot)*4.5f)*1.25f,(Mathf.Sin(rot)*6.5f)*1.25f,0.0f);
			}
			if(TimeCnt == 30)
			{
				bEndFlag = true;
			}
		}
	}

	// 終了フラグの受け渡し
	public bool GetEndFlag()
	{
		return bEndFlag;
	}
}
