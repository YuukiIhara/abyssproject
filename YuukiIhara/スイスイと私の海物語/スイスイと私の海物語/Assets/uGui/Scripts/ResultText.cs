using UnityEngine;
using System.Collections;

public class ResultText : MonoBehaviour {

	// レクトトランスフォームの宣言
	RectTransform  rectTransform;
	// 回転角
	float rot = Mathf.PI/2.0f;
	// 時間のカウント
	int TimeCnt = 0; 
	// リザルト開始のフラグ
	bool bFlag = false;

	// Use this for initialization
	void Start () 
	{
		// レクトトランスフォームの取得
		rectTransform= GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// リザルト開始情報がtrueなら文字のフェードイン＆フェードアウト
		if(GameObject.Find ("ResultSystem").GetComponent<ResultManager> ().GetFlag() == true)
		{
			// 時間経過の測定
			TimeCnt++;

			// フェードイン
			if(TimeCnt > 0 && 60 >= TimeCnt)
			{
				// 回転角の加算処理
				rot += (Mathf.PI/2.0f)/60.0f;

				// 移動量の設定
				//Vector3 Addnum = new Vector3((Mathf.Sin (rot*(Mathf.PI/180))*1.0f ),0 ,0);
				Vector3 Addnum = new Vector3(Mathf.Sin(rot)*27.8f,0 ,0);
				rectTransform.position += Addnum;
			}

			// フェードアウト
			if(TimeCnt > 120 && 180 >= TimeCnt)
			{
				// 回転角の加算処理
				rot += (Mathf.PI/2.0f)/60.0f;

				// 移動量の設定
				//Vector3 Addnum = new Vector3((Mathf.Sin (rot*(Mathf.PI/180))*1.0f ),0 ,0);
				Vector3 Addnum = new Vector3(Mathf.Sin(rot)*-27.8f,0 ,0);
				rectTransform.position += Addnum;
			}

			// リザルトUIのフラグを立てる
			if (TimeCnt == 181)
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
