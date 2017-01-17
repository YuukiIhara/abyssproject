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
	// 透明度
	float fAlpha;
	// 色の設定
	public int nColor; 

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
			fAlpha = 0.0f;
			renderer.SetAlpha (fAlpha);
		}
		else
		{
			// 透明処理
			fAlpha = 1.0f;
			renderer.SetAlpha(fAlpha);
		}
		// カラーの設定
		image.color = new Color(nColor,nColor,nColor);
	}
	
	// Update is called once per frame
	void Update () 
	{	

		// フェードアウト処理
		if (bFadeFlag == true && fAlpha < 1.0f) {
			// 透明処理
			fAlpha += 0.01f;
			renderer.SetAlpha (fAlpha);
			// ゲーム中のフラグ
			GameObject.Find("ScenarioSystem").GetComponent<ScenarioSystem>().SetScenarioFlag(false);
			bFlag = false;
		}
		// フェードイン処理
		else if (bFadeFlag == false && fAlpha > 0.0f) {
			// 透明処理
			fAlpha -= 0.01f;
			renderer.SetAlpha (fAlpha);
			// ゲーム中のフラグ
			GameObject.Find("ScenarioSystem").GetComponent<ScenarioSystem>().SetScenarioFlag(false);
			bFlag = false;
		} 
		else if(bFlag == false )
		{
			// ゲーム中のフラグ
			GameObject.Find("ScenarioSystem").GetComponent<ScenarioSystem>().SetScenarioFlag(true);
			bFlag = true;
		}
	}

	public void SetFade(bool flag)
	{
		bFadeFlag = flag;
	}
}
