using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RatingTxtManager : MonoBehaviour {

	// α値の設定
	float fAlpha;
	// レンダラーの宣言
	new CanvasRenderer renderer;

	// Use this for initialization
	void Start ()
	{
		// レンダラーの取得
		renderer = GetComponent<CanvasRenderer> ();
		// 透明処理
		fAlpha = 0.0f;
		renderer.SetAlpha(fAlpha);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// アルファ値の設定
		if(fAlpha <= 1.0f && GameObject.Find ("ResultRate").GetComponent<ResultRate> ().GetEndFlag() == true)
		{
			// Alpha値の更新
			fAlpha += 0.04f;
			renderer.SetAlpha(fAlpha);
		}
	}
}
