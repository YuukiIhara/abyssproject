using UnityEngine;
using System.Collections;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class RateLavel : MonoBehaviour {

	// レクトトランスフォームの宣言
	RectTransform  rectTransform;
	// 回転角
	float rot = Mathf.PI/2.0f;
	// 時間のカウント
	int TimeCnt = 0; 

	// Energyの変数宣言
	public GameObject Energy;

	// Use this for initialization
	void Start ()
	{
		// レクトトランスフォームの取得
		rectTransform = GetComponent<RectTransform> ();
		// Energyの初期化
		//Energy = GameObject.Find ("Energy");
	}
	
	// Update is called once per frame
	void Update () 
	{
		// レートの表示処理
		if (Energy.GetComponent<Energy> ().GetEndFlag ())
		{
			if(TimeCnt <= 30)
			{
				// 時間経過の測定
				TimeCnt++;
				// 回転角の加算処理
				rot += (Mathf.PI/2.0f)/30.0f;
				// 縦のサイズを加算
				rectTransform.sizeDelta += new Vector2 (0.0f,Mathf.Sin(rot)*4.0f);
			}
		}
	}
}
