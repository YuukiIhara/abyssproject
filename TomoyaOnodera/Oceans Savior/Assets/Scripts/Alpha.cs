using UnityEngine;
using System.Collections;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class Alpha : MonoBehaviour {

	// 減算するα値の設定
	float dAlpha;
	// レンダラーの宣言
	CanvasRenderer renderer;

	// Use this for initialization
	void Start () 
	{
		// レンダラーの取得
		renderer = GetComponent<CanvasRenderer> ();
		// 透明処理
		dAlpha = 0.0f;
		renderer.SetAlpha(dAlpha);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(dAlpha < 1.0f)
		{
			dAlpha += 0.02f;
			renderer.SetAlpha(dAlpha);
		}
	}
}
