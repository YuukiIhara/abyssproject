using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour {

	// レクトトランスフォームの宣言
	new Transform  transform;
	// 回転角
	float rot = Mathf.PI/2.0f;
	// 時間のカウント
	int TimeCnt = 0; 
	// 透明度
	float fAlpha = 0.0f;
	// レンダラーの宣言
	new CanvasRenderer renderer;

	// ScenarioSystemの変数宣言
	public GameObject ResultText;
	// Energyの変数宣言
	public GameObject Energy;
	// ScoreManagerの変数宣言
	public GameObject ScoreManager;

	// 表示判定
	public bool bAlphaFlag = false;

	// Use this for initialization
	void Start () 
	{
		// レクトトランスフォームの取得
		transform= GetComponent<Transform> ();

		// ResultTextの初期化
		//ResultText = GameObject.Find ("ResultText");
		// Energyの初期化
		//Energy = GameObject.Find ("Energy");
		// ScoreManagerの初期化
		//ScoreManager = GameObject.Find ("ScoreManager");
	}

	// Update is called once per frame
	void Update ()
	{
		// リザルト開始情報がtrueなら文字のフェードイン＆フェードアウト
		if(ResultText.GetComponent<ResultText> ().GetFlag() == true)
		{
			// 時間経過の測定
			TimeCnt++;

			// フェードイン
			if(TimeCnt == 1)
			{
				// 回転角の加算処理
				//rot += (Mathf.PI/2.0f)/30.0f;

				// 移動量の設定
				//Vector3 Addnum = new Vector3((Mathf.Sin (rot*(Mathf.PI/180))*1.0f ),0 ,0);
				//Vector3 Addnum = new Vector3(0 ,Mathf.Sin(rot)*-7.5f,0);
				//FIRE HD = *1.25f
				//transform.position += Addnum*1.25f;
				bAlphaFlag =true;
			}
			// エネルギの加算
			if(TimeCnt > 30 && Energy.GetComponent<Energy> ().GetEndFlag() == false)
			{
				ScoreManager.GetComponent<ScoreManager> ().ResultScore();
			}
		}
	}
}
