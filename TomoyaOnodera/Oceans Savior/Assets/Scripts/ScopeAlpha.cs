using UnityEngine;
using System.Collections;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class ScopeAlpha : MonoBehaviour {
	
	// α値の設定
	[SerializeField][Range(0.000f, 1.0f)]
	float fAlpha = 0.5f;
	float cfAlpha = 0;
	[SerializeField][Range(0, 255)]
	int nRed = 0;
	int cnRed = 0;
	[SerializeField][Range(0, 255)]
	int nGreen = 0;
	int cnGreen = 0;
	[SerializeField][Range(0, 255)]
	int nBlue = 0;
	int cnBlue = 0;
	// レンダラーの宣言
	new CanvasRenderer renderer;
	// イメージの宣言
	Image image;
	// 対象物に当たっているのか判定
	public bool bHit = false; 

	void Start ()
	{
		// 変数の初期化
		cfAlpha = fAlpha;
		cnRed = nRed;
		cnGreen = nGreen;
		cnBlue = nBlue;
		// レンダラーの取得
		renderer = GetComponent<CanvasRenderer> ();
		// イメージのお取得
		image = GetComponent<Image> ();
		// 透明処理
		renderer.SetAlpha(fAlpha);
		// カラーの設定
		image.color = new Color(255,255,255);
	}

	void Update () 
	{
		// デバック用当たり判定
		if (Input.GetKey (KeyCode.Return)) {
			bHit = true;
		} else {
			bHit = false;
		}

		// 当たっていたらスコープのカラーを変える
		if (bHit == true) 
		{
			fAlpha = 0.6f;
			nRed = cnRed;
			nGreen = cnGreen;
			nBlue = cnBlue;
		} 
		else 
		{
			fAlpha = cfAlpha;
			nRed = 255;
			nGreen = 255;
			nBlue = 255;
		}
		// 透明処理
		renderer.SetAlpha(fAlpha);
		// カラーの設定
		image.color = new Color(nRed,nGreen,nBlue);
	}
}
