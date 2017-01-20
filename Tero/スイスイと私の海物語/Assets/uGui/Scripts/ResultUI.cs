using UnityEngine;
using System.Collections;

public class ResultUI : MonoBehaviour {

	// レクトトランスフォームの宣言
	new Transform  transform;
	// 回転角
	float rot = Mathf.PI/2.0f;
	// 時間のカウント
	int TimeCnt = 0; 

	// Use this for initialization
	void Start () 
	{
		// レクトトランスフォームの取得
		transform= GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update ()
	{
		// リザルト開始情報がtrueなら文字のフェードイン＆フェードアウト
		if(GameObject.Find ("ResultText").GetComponent<ResultText> ().GetFlag() == true)
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
				Vector3 Addnum = new Vector3(0 ,Mathf.Sin(rot)*-7.5f,0);
				transform.position += Addnum;
			}
			// エネルギの加算
			if(TimeCnt > 60 && GameObject.Find ("Energy").GetComponent<Energy> ().GetEndFlag() == false)
			{
				GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ().ResultScore();
			}
		}
	}
}
