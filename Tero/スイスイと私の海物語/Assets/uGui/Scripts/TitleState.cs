using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleState : MonoBehaviour {

	// レンダラーの宣言
	new CanvasRenderer renderer;
	// 透明度
	float fAlpha = 1.0f;
	float fValue = -1.0f;

	// Use this for initialization
	void Start ()
	{
		// レンダラーの取得
		renderer = GetComponent<CanvasRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// 透明処理
		fAlpha += 0.01f*fValue;
		renderer.SetAlpha (fAlpha);

		// 符号の反転処理
		if (fAlpha < 0.2f || fAlpha >= 1.0f)
			fValue *= -1.0f;
	}
}
