using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreAlpha : MonoBehaviour {
	
	// α値の設定
	float fAlpha;
	// レンダラーの宣言
	new CanvasRenderer renderer;
	// 透明処理のフラグ
	bool bAlphaFlag = true;

	// Use this for initialization
	void Start () 
	{
		// レンダラーの取得
		renderer = GetComponent<CanvasRenderer> ();
		// 透明処理
		fAlpha = 1.0f;
	}

	void Update ()
	{
		if(bAlphaFlag == true && fAlpha <= 1.0f)
		{
			
			// Alpha値の更新
			fAlpha += 0.04f;
			renderer.SetAlpha(fAlpha);
		}
		if(bAlphaFlag == false && fAlpha > 0.0f)
		{

			// Alpha値の更新
			fAlpha -= 0.04f;
			renderer.SetAlpha(fAlpha);
		}
	}

	// Alpha値の設定
	public void SetAlpha(bool flag)
	{
		bAlphaFlag = flag;
	}

	// スコアのアルファ値初期化
	public void InitAlpha(float alpha)
	{
		// Alpha値の更新
		fAlpha = alpha;
		renderer.SetAlpha(fAlpha);
	}
}
