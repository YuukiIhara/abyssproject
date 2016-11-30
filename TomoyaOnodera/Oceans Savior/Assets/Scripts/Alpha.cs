using UnityEngine;
using System.Collections;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class Alpha : MonoBehaviour {

	// 減算するα値の設定
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
		// シナリオのフラグがtrueならスプライトを表示
		if(GameObject.Find("ScenarioScene").GetComponent<ScenarioScene>().GetScenarioFlag() == true)
		{
			if(fAlpha < 1.0f)
			{
				fAlpha += 0.02f;
				renderer.SetAlpha(fAlpha);
			}
		}
		// シナリオのフラグがfalseならスプライトを非表示
		if(GameObject.Find("ScenarioScene").GetComponent<ScenarioScene>().GetScenarioFlag() == false)
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
}
