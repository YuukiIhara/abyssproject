using UnityEngine;
using System.Collections;

public class ResultState : MonoBehaviour {

	// リザルトシステムの取得
	public GameObject ResultSystem;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// リザルトのスタート
		if(GameObject.Find ("Scenario3_00").GetComponent<ScriptController> ().GetFlag())
		{
			ResultSystem.SetActive(true);
		}
	}
}
