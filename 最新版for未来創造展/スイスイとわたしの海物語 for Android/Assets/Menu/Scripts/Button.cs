using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	// オブジェクトの取得
	public GameObject menu;
	public GameObject menuFrame;
	public GameObject menuTitle;
	public GameObject menuGame;

	// MenuSystemの変数宣言
	GameObject MenuSystem;

	// Use this for initialization
	void Start ()
	{
		// MenuSystemの初期化
		MenuSystem = GameObject.Find ("MenuSystem");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	// Menuの処理
	public void OnClick1() 
	{
		if(MenuSystem.GetComponent<MenuMamager>().GetState() == MenuMamager.State.GAME)
		{
			// 非表示にする
			//gameObject.SetActive(false);
			// 状態の変更
			MenuSystem.GetComponent<MenuMamager>().SetState(MenuMamager.State.MENU);
			// メニューの表示
			//GameObject flame = GameObject.Find("MenuFrame");
			menuFrame.SetActive(true);
			//GameObject title = GameObject.Find("MenuTitle");
			menuTitle.SetActive (true);
			//GameObject game = GameObject.Find("MenuGame");
			menuGame.SetActive (true);
		}
	}

	// MenuTitleの処理
	public void OnClick2() 
	{
		if (MenuSystem.GetComponent<MenuMamager> ().GetState () == MenuMamager.State.MENU)
		{
			// 非表示にする
			//gameObject.SetActive(false);
			// 状態の変更
			//GameObject.Find("MenuSystem").GetComponent<MenuMamager>().SetState(MenuMamager.State.MENU);
			// 状態の変更
			MenuSystem.GetComponent<MenuMamager> ().SetState (MenuMamager.State.TITLE);

			menu.SetActive (false);
			menuTitle.SetActive (false);
			menuGame.SetActive (false);
		}
	}

	// MenuGameの処理
	public void OnClick3() 
	{
		if (MenuSystem.GetComponent<MenuMamager> ().GetState() == MenuMamager.State.MENU)
		{
			// 状態の変更
			MenuSystem.GetComponent<MenuMamager> ().SetState (MenuMamager.State.GAME);
			// 非表示にする
			//gameObject.SetActive(false);
			// 状態の変更
			//GameObject.Find("MenuSystem").GetComponent<MenuMamager>().SetState(MenuMamager.State.MENU);
			menuFrame.SetActive (false);
			//GameObject title = GameObject.Find("MenuTitle");
			menuTitle.SetActive (false);
			//GameObject game = GameObject.Find("MenuGame");
			menuGame.SetActive (false);
		}
	}
}
