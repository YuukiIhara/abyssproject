using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class IntroPlayer : MonoBehaviour {

	// プレイヤーのオブジェクト設定
	Transform Player;
	// プレイヤーの移動開始フラグ
	bool bPlayerFlag = false;
	Vector3 PlayerMove;
	float PlayerRot = 0.0f;
	float PlayerRotY = Mathf.PI / 2;
	int PlayerMoveCount = 0;
	//スイスイのオブジェクト取得
	public GameObject suisui;
	// シナリオブジェクト取得
	public GameObject txt;
	// スイスイの回転角
	float rotY;
	float rotZ;
	//Sound
	public GameObject SoundManager;
	// Use this for initialization
	void Start () 
	{
		// プレイヤーのオブジェクト設定
		Player = gameObject.GetComponent<Transform>();

		// プレイヤーのスイスイ迄の移動量を設定
		PlayerMove = new Vector3(suisui.transform.position.x - gameObject.GetComponent<Transform>().position.x,0,suisui.transform.position.z-1.45f - gameObject.GetComponent<Transform>().position.z);
		float fLengse = Mathf.Sqrt (PlayerMove.x*PlayerMove.x + PlayerMove.z*PlayerMove.z);
		PlayerMove = new Vector3 (PlayerMove.x/fLengse/120,0,PlayerMove.z/fLengse/120);

		rotY = 110.0f;
		rotZ = 26.0f;

		suisui.transform.rotation = Quaternion.Euler(0,rotY,rotZ);
		//Sound
		SoundManager.GetComponent<SoundManager> ().SetSound (2, true, 2);
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(txt != null)
		{
			if(txt.GetComponent<ScriptController>().Flag == true)
			{
				bPlayerFlag = true;
			}
		}

		// プレイヤーの移動開始
		if(bPlayerFlag == true)
		{
			PlayerMoveCount++;
			//Vector3 ani = new Vector3 (0.0f,10.0f,0.0f);
			//suisui.transform.rotation(ani.x,ani.y,ani.z);

			//var rot = suisui.transform.rotation;
			//rot.y += 0.2f;
			//suisui.transform.rotation = rot;

			// スイスイの回転開始
			if(PlayerMoveCount > 0 && PlayerMoveCount <= 120)
			{
				rotY += 1.35f;
				rotZ -= rotZ / 120;
				suisui.transform.rotation = Quaternion.Euler(0,rotY,rotZ);
			}

			// スイスイまで近づく処理
			if(PlayerMoveCount < 380)
			{
				Player.position += new Vector3 (PlayerMove.x,0,PlayerMove.z);
			}
			// スイスイに飛び乗る処理
			if(PlayerMoveCount > 420 && PlayerMoveCount <= 450)
			{
				PlayerRot += Mathf.PI*2 / 30;
				// プレイヤーのスイスイ迄の移動量を設定
				PlayerMove = new Vector3(suisui.transform.position.x - gameObject.GetComponent<Transform>().position.x,Mathf.Sin(PlayerRot)/20.0f,suisui.transform.position.z - gameObject.GetComponent<Transform>().position.z);
				Player.position += new Vector3 (PlayerMove.x*0.05f,PlayerMove.y,PlayerMove.z*0.1f);
			}
			if (PlayerMoveCount == 450) 
			{
				// プレイヤーオブジェクトの親をスイスイに設定
				gameObject.GetComponent<Transform> ().parent = suisui.transform;
				PlayerRot = 0.0f;
			}
			if (PlayerMoveCount > 480) 
			{
				if(PlayerMoveCount == 481) SoundManager.GetComponent<SoundManager> ().SetSound (2, true, 1);
				if (PlayerRot < 1.0f) 
				{
					PlayerRot += 0.002f; 
				}
				// スイスイの移動処理
				suisui.GetComponent<Transform>().position += new Vector3 (0,0,0.03f*PlayerRot);
				if(PlayerMoveCount > 480 && PlayerMoveCount <= 560)
				{
					PlayerRotY += Mathf.PI/2 / 140f;
					suisui.GetComponent<Transform>().position += new Vector3 (0,-Mathf.Sin(PlayerRotY)/45,0);
				}
			}

			if (PlayerMoveCount == 700)
			{
				// フェードアウトのフラグを立てる
				GameObject.Find ("Fade").GetComponent<FadeManager> ().SetFade(true);
			}
			if (PlayerMoveCount == 750)
			{
				// ゲーム画面に繊維
				SceneManager.LoadScene("main");
			}
		}
	}

	// プレイヤーの移動フラグ設定
	public void SetPlayerFlag()
	{
		bPlayerFlag = true;
	}

	// プレイヤーの移動フラグ受け渡し
	public bool GetPlayerFlag()
	{
		return bPlayerFlag;
	}
}
