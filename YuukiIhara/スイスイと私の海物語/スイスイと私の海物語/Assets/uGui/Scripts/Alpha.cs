using UnityEngine;
using System.Collections;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class Alpha : MonoBehaviour {

	// α値の設定
	public float fAlpha;
	// レンダラーの宣言
	new CanvasRenderer renderer;
	// イメージの宣言
	Image image;

	// Use this for initialization
	void Start () 
	{
		// イメージのお取得
		image = GetComponent<Image> ();
		// レンダラーの取得
		renderer = GetComponent<CanvasRenderer> ();
		// 透明処理
		fAlpha = 0.0f;
		renderer.SetAlpha(fAlpha);
	}
	
	// Update is called once per frame
	void Update ()
	{
		// シナリオのフラグがtrueならスプライトを表示
		if(GameObject.Find("ScenarioSystem").GetComponent<ScenarioSystem>().GetScenarioFlag() == true)
		{
			if(fAlpha < 1.0f)
			{
				fAlpha += 0.02f;
				renderer.SetAlpha(fAlpha);
			}
		}
		// シナリオのフラグがfalseならスプライトを非表示
		if(GameObject.Find("ScenarioSystem").GetComponent<ScenarioSystem>().GetScenarioFlag() == false)
		{
			if(fAlpha > 0.0f)
			{
				fAlpha -= 0.02f;
				renderer.SetAlpha(fAlpha);
			}
		}
	}

	// α値の受け渡し
	public float GetAlpha()
	{
		return fAlpha;
	}

	// 色の切り替え255
	public void RGB255()
	{
		// カラーの設定
		image.color = new Color(1,1,1);
	}
	// 色の切り替え255
	public void RGB100()
	{
		// カラーの設定
		image.color = new Color(0.5f,0.5f,0.5f);
	}
}
