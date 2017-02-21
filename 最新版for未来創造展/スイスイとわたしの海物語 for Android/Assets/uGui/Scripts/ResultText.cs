using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultText : MonoBehaviour {

	// レクトトランスフォームの宣言
	RectTransform  rectTransform;
	// 回転角
	float rot = Mathf.PI/2.0f;
	// 時間のカウント
	int TimeCnt = 0; 
	// リザルト開始のフラグ
	bool bFlag = false;
	// 透明度
	float fAlpha = 0.0f;
	// レンダラーの宣言
	new CanvasRenderer renderer;

	// ResultSystemの変数宣言
	public GameObject ResultSystem;

	// Use this for initialization
	void Start () 
	{
		// レクトトランスフォームの取得
		rectTransform= GetComponent<RectTransform> ();
		// レンダラーの取得
		renderer = GetComponent<CanvasRenderer> ();

		// ResultSystemの初期化
		//ResultSystem = GameObject.Find ("ResultSystem");
	}
	
	// Update is called once per frame
	void Update ()
	{
		// リザルト開始情報がtrueなら文字のフェードイン＆フェードアウト
		if(ResultSystem.GetComponent<ResultManager> ().GetFlag() == true)
		{
			// 時間経過の測定
			TimeCnt++;

			// フェードイン
			if(TimeCnt > 0 && 19 >= TimeCnt)
			{
				// 回転角の加算処理
				//rot += (Mathf.PI/2.0f)/30.0f;

				// 移動量の設定
				//Vector3 Addnum = new Vector3((Mathf.Sin (rot*(Mathf.PI/180))*1.0f ),0 ,0);
				//Vector3 Addnum = new Vector3(Mathf.Sin(rot)*27.8f,0 ,0);
				//FIRE HD = *1.25f
				//rectTransform.position += Addnum*1.25f;
				fAlpha += 0.05f;
				renderer.SetAlpha(fAlpha);
			}

			// フェードアウト
			if(TimeCnt > 60 && 80 >= TimeCnt)
			{
				// 回転角の加算処理
				//rot += (Mathf.PI/2.0f)/30.0f;

				// 移動量の設定
				//Vector3 Addnum = new Vector3((Mathf.Sin (rot*(Mathf.PI/180))*1.0f ),0 ,0);
				//Vector3 Addnum = new Vector3(Mathf.Sin(rot)*-27.8f,0 ,0);
				//FIRE HD = *1.25f
				//rectTransform.position += Addnum*1.25f;
				fAlpha -= 0.05f;
				renderer.SetAlpha(fAlpha);
			}

			// リザルトUIのフラグを立てる
			if (TimeCnt == 81)
			{
				bFlag = true;
			}

		}
	}

	// フラグの受け渡し
	public bool GetFlag()
	{
		return bFlag;
	}
}
