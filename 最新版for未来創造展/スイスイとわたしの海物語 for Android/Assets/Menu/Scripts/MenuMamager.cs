using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class MenuMamager : MonoBehaviour {

	// ステートの設定
	public enum State {GAME, MENU,TITLE};
	// 現在のステートの初期化
	State nState = State.GAME;

	// Fadeの変数宣言
	GameObject Fade;

	// Use this for initialization
	void Start ()
	{
		// Fadeの初期化
		Fade = GameObject.Find ("Fade");
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (nState)
		{
		// ゲーム画面時の処理
		case State.GAME:
			
			break;

		// メニュー画面時の処理
		case State.MENU:
			
			break;
		
		// タイトル遷移時の処理
		case State.TITLE:
			// フェードアウト処理
			Fade.GetComponent<FadeManager>().SetFade(true);
			// タイトルへ遷移
			if(Fade.GetComponent<FadeManager>().GetFadeOutFlag())SceneManager.LoadScene("Title");
			break;
		}
	}

	// 状態のセット
	public void SetState(State state)
	{
		nState = state;
	}
	// 状態の取得
	public State GetState()
	{
		return nState;
	}
}
