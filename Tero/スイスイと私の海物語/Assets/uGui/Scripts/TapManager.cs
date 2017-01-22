using UnityEngine;
using System.Collections;

public class TapManager : MonoBehaviour {

	private bool tutorial = false;
	// レクトトランスフォームの宣言
	RectTransform  rectTransform;
	// レンダラーの宣言
	new CanvasRenderer renderer;

	// テキストオブジェクト取得
	public GameObject txt;
	// 回転角
	float rot = 0.0f;
	// 透明度
	float fAlpha = 0.0f;
	// 使用判定
	public bool bTapFlag;

	// Use this for initialization
	void Start ()
	{
		// レクトトランスフォームの取得
		rectTransform= GetComponent<RectTransform> ();
		// レンダラーの取得
		renderer = GetComponent<CanvasRenderer> ();
		// アルファ値の初期化
		renderer.SetAlpha (fAlpha);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// チュートリアルの表示処理
		if(txt != null)
		{
			if(txt.GetComponent<ScriptController>().GetLine() == 3)
			{
				bTapFlag = true;
			}
			if(txt.GetComponent<ScriptController>().GetLine() == 4 && !tutorial)
			{
				bTapFlag = false;
				tutorial = true;
			}
		}


		// スコープの拡縮処理
		//if (bMoveFlag == true)
		{
			// 拡縮処理
			rot += 0.04f;
			Vector3 Addnum = new Vector2 (Mathf.Cos(rot)/170,Mathf.Cos(rot)/170);
			rectTransform.localScale += Addnum;
		}

		// 実行処理
		if (bTapFlag == true)
		{
			if (fAlpha < 1.0f)
			{
				// 透明処理
				fAlpha += 0.1f;
				renderer.SetAlpha (fAlpha);
			}
			// 拡縮処理
			rot += 0.04f;
			Vector3 Addnum = new Vector2 (Mathf.Cos (rot) / 170, Mathf.Cos (rot) / 170);
			rectTransform.localScale += Addnum;
		} 
		else if (bTapFlag == false && fAlpha == 0.0f) 
		{
			
		}
		else if (bTapFlag == false)
		{
			if(fAlpha > 0.0f)
			{
				// 透明処理
				fAlpha -= 0.1f;
				renderer.SetAlpha (fAlpha);
			}
			// 拡縮処理
			rot += 0.04f;
			Vector3 Addnum = new Vector2 (Mathf.Cos(rot)/170,Mathf.Cos(rot)/170);
			rectTransform.localScale += Addnum;
		} 
	}

	public void SetTapFlag(bool bFlag)
	{
		bTapFlag = bFlag;
	}
}
