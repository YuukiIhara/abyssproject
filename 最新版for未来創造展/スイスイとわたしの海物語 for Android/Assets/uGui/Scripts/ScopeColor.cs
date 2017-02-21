using UnityEngine;
using System.Collections;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class ScopeColor : MonoBehaviour {

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
	// レクトトランスフォームの宣言
	RectTransform  rectTransform;
	// イメージの宣言
	Image image;
	// アイテム取得時のフラグ
	bool bMoveFlag = false;
	// 拡縮に使う回転角
	float rot;
	// Meterの変数宣言
	GameObject Meter;

	void Start ()
	{
		// 変数の初期化
		cfAlpha = fAlpha;
		cnRed = nRed;
		cnGreen = nGreen;
		cnBlue = nBlue;
		rot = 0.0f;
		// レンダラーの取得
		renderer = GetComponent<CanvasRenderer> ();
		// レクトトランスフォームの取得
		rectTransform= GetComponent<RectTransform> ();
		// イメージのお取得
		image = GetComponent<Image> ();
		// 透明処理
		renderer.SetAlpha(fAlpha);
		// カラーの設定
		image.color = new Color(255,255,255);
		// Meterの初期化
		Meter = GameObject.Find ("Meter");
	}

	void Update () 
	{
		// 当たっていなかったらスコープのカラーを変更
		if (Meter.GetComponent<MeterController>().GetHit() == false && bMoveFlag == false) 
		{
			fAlpha = cfAlpha;
			nRed = 255;
			nGreen = 255;
			nBlue = 255;
			
			// 透明処理
			renderer.SetAlpha(fAlpha);
			// カラーの設定
			image.color = new Color(nRed,nGreen,nBlue);
		} 

		// スコープの拡縮処理
		if (bMoveFlag == true) 
		{
			// 拡縮処理
			rot += (Mathf.PI /28);
			Vector3 Addnum = new Vector2 (Mathf.Cos(rot)/25,Mathf.Cos(rot)/25);
			rectTransform.localScale += Addnum;
			// 透明処理
			fAlpha += -0.1f;
			// 処理の終了
			if(fAlpha <= -2.0f)
			{
				// スケールの初期化
				Addnum = new Vector2 (1,1);
				rectTransform.localScale = Addnum;
				// あたり判定を切る
				fAlpha = cfAlpha;
				// 回転角の初期化
				rot = 0.0f;
				// アイテム取得判定を消す
				bMoveFlag = false;
			}
		}
	}

	// カラーの設定
	public void SetColor()
	{
		// 透明処理
		fAlpha = 0.8f;
		renderer.SetAlpha(fAlpha);
		// カラーの設定
		image.color = new Color(cnRed,cnGreen,cnBlue);
	}

	// アイテム取得のフラグ設定
	public void SetMoveFlag()
	{
		bMoveFlag = true;
	}
	// アイテム取得のフラグ受け渡し
	public bool GetMoveFlag()
	{
		return bMoveFlag;
	}
}
