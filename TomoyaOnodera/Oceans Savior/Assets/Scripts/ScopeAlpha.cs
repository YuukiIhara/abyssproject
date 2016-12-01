using UnityEngine;
using System.Collections;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class ScopeAlpha : MonoBehaviour {
	
	// α値の設定
	[SerializeField][Range(0.000f, 1.0f)]
	float fAlpha = 0.5f;
	// レンダラーの宣言
	new CanvasRenderer renderer;

	void Start ()
	{
		// レンダラーの取得
		renderer = GetComponent<CanvasRenderer> ();
		// 透明処理
		renderer.SetAlpha(fAlpha);
	}

	void Update () 
	{
	
	}
}
