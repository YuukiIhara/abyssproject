using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rating : MonoBehaviour {

	// レクトトランスフォームの宣言
	new Transform  transform;
	// 回転角
	float rot = Mathf.PI/2.0f;
	// 時間のカウント
	int TimeCnt = 0; 
	// 終了のフラグ
	bool bEndFlag = false;

	// ResultRateの変数宣言
	public GameObject ResultRate;

	// Use this for initialization
	void Start ()
	{
		// トランスフォームの取得
		transform = GetComponent<Transform> ();
		// ResultRateの初期化
		//ResultRate = GameObject.Find ("ResultRate");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(ResultRate.GetComponent<ResultRate> ().GetEndFlag() == true)
		{
			// 時間経過の測定
			TimeCnt++;
			
			if (TimeCnt <= 20) 
			{
				// 回転角の加算処理
				rot += (Mathf.PI / 2.0f) / 20.0f;
				// 縦のサイズを加算
				Vector3 Addnum = new Vector2 (Mathf.Sin (rot) * 0.57f, Mathf.Sin (rot) * 0.57f);
				transform.localScale -= Addnum;
			
				// ポジションの移動
				//transform.position += new Vector3 (-Mathf.Sin(rot)*4.5f,Mathf.Sin(rot)*6.5f,0.0f);
			}
			if(TimeCnt == 50)
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
