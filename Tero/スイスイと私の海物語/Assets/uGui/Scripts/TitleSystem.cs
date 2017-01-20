using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class TitleSystem : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// フェードインが終わったら処理開始
		if(GameObject.Find("Fade").GetComponent<FadeManager>().GetAlpha() <= 0.0000000000f)
		{
			if (Input.GetButtonDown ("Fire1"))
			{
				// フェードアウト処理
				GameObject.Find ("Fade").GetComponent<FadeManager> ().SetFade (true);

			}
		}
		// イントロダクションへ遷移
		if (GameObject.Find ("Fade").GetComponent<FadeManager> ().GetFadeOutFlag ()) 
		{
			SceneManager.LoadScene ("Introduction");
		}
	}
}
