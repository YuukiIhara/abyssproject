using UnityEngine;
using System.Collections;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class FadeManager : MonoBehaviour {
	
	// レンダラーの宣言
	new CanvasRenderer renderer;
	// イメージの宣言
	Image image;
	// フラグ
	public bool bFadeFlag;
	bool bFlag = false;
	// フェードアウト終了のフラグ
	bool FadeOutFlag = false;
	// 透明度
	float fAlpha;
	// 色の設定
	public int nColor; 

	// ScenarioSystemの変数宣言
	GameObject ScenarioSystem;

	// Use this for initialization
	void Start () 
	{
		// レンダラーの取得
		renderer = GetComponent<CanvasRenderer> ();
		// イメージのお取得
		image = GetComponent<Image> ();
		// 透明処理
		if (bFadeFlag == true) 
		{
			// 透明処理
			fAlpha = 0.000000f;
			renderer.SetAlpha (fAlpha);
		}
		else
		{
			// 不透明処理
			fAlpha = 1.000000f;
			renderer.SetAlpha(fAlpha);
		}
		// カラーの設定
		image.color = new Color(nColor,nColor,nColor);

		// ScenarioSystemの初期化
		ScenarioSystem = GameObject.Find ("ScenarioSystem");
	}
	
	// Update is called once per frame
	void Update () 
	{	
		// テスト
		if (Input.GetKey (KeyCode.V)) 
		{
			bFadeFlag = true;
		}
		if (Input.GetKey (KeyCode.B)) 
		{
			bFadeFlag = false;
		}

		// フェードアウト処理
		if (bFadeFlag == true && fAlpha < 1.0f) 
		{
			// 不透明処理
			fAlpha += 0.02f;
			renderer.SetAlpha (fAlpha);
			if(fAlpha >= 1.0f)
			{
				// フェードアウトフラグの設定
				FadeOutFlag = true;
				bFlag = false;
				ScenarioSystem.GetComponent<ScenarioSystem> ().SetScenarioFlag (false);
			}
		}
		// フェードイン処理
		else if (bFadeFlag == false && fAlpha > 0.000000f)
		{
			// 透明処理
			fAlpha -= 0.02f;
			renderer.SetAlpha (fAlpha);
			// ゲーム中のフラグ
			ScenarioSystem.GetComponent<ScenarioSystem>().SetScenarioFlag(false);
			// フェードアウトフラグの設定
			FadeOutFlag = false;
			if(fAlpha <= 0.000000f)
			{
				bFlag = false;
			}
		} 
		else if(bFlag == false )
		{
			// ゲーム中のフラグ
			ScenarioSystem.GetComponent<ScenarioSystem>().SetScenarioFlag(true);
			bFlag = true;
		}
	}

	// ゲーム中のフラグ
	public void SetFade(bool flag)
	{
		bFadeFlag = flag;
	}

	// フェードウトが終わったフラグ受け渡し
	public bool GetFadeOutFlag()
	{
		return FadeOutFlag;
	}

	// アルファ値のフラグ受け渡し
	public float GetAlpha()
	{
		return fAlpha;
	}
}
