using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class MenuMamager : MonoBehaviour {

	// ステートの設定
	public enum State {GAME, MENU,TITLE};
	// 現在のステートの初期化
	State nState = State.GAME;

	//オブジェクトの取得

	// Use this for initialization
	void Start ()
	{
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
			GameObject.Find("Fade").GetComponent<FadeManager>().SetFade(true);
			// タイトルへ遷移
			if(GameObject.Find("Fade").GetComponent<FadeManager>().GetFadeOutFlag())SceneManager.LoadScene("Title");
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
