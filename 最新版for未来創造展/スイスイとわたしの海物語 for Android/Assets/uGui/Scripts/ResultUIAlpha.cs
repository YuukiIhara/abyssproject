using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultUIAlpha : MonoBehaviour {


	// 透明度
	float fAlpha = 0.0f;
	// レンダラーの宣言
	new CanvasRenderer renderer;

	// 表示判定
	//bool bAlphaFlag = false;

	public GameObject ResultUI;

	// Use this for initialization
	void Start ()
	{
		// レンダラーの取得
		renderer = GetComponent<CanvasRenderer> ();
		// スタート時は透明
		renderer.SetAlpha(fAlpha);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// 表示処理
		if(ResultUI.GetComponent<ResultUI>().bAlphaFlag && fAlpha < 1.0f)
		{
			// 徐々に加算
			fAlpha += 0.05f;
			renderer.SetAlpha(fAlpha);
		}
	
	}

}
