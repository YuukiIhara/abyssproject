using UnityEngine;
using System.Collections;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class MeterColor : MonoBehaviour {
	
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
	int rot = 0;

	// MeterのS変数宣言
	GameObject Meter;

	void Start ()
	{
		// 変数の初期化
		cfAlpha = fAlpha;
		cnRed = nRed;
		cnGreen = nGreen;
		cnBlue = nBlue;
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
		// メーターがはじけ飛ぶ処理
		if (bMoveFlag == true) 
		{
			// 移動量の設定
			Vector3 Addnum = new Vector3((Mathf.Sin (rot*(Mathf.PI/180))*1.0f ),Mathf.Cos ((rot*(Mathf.PI/180)))*1.0f,0); 
			rectTransform.position += Addnum;
			// 透明処理
			fAlpha += -0.1f;
			renderer.SetAlpha(fAlpha);
			// 処理の終了
			if(fAlpha <= -2.0f)
			{
				// あたり判定を切る
				fAlpha = cfAlpha;
				bMoveFlag = false;
				// 透明処理
				renderer.SetAlpha(cfAlpha);
				// ポジションの初期化
				Addnum = Meter.GetComponent<MeterController>().SetMeterPosition(rot/10);
				rectTransform.position = Addnum;
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
	public void SetMoveFlag(int Rot)
	{
		bMoveFlag = true;
		rot = Rot*10;
	}
}
