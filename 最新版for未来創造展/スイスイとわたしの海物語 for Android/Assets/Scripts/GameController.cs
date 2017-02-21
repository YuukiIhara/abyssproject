using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0; // VSyncをOFFにする
		Application.targetFrameRate = 30; // ターゲットフレームレートを60に設定
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
