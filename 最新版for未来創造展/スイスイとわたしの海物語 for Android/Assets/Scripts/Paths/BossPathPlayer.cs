using UnityEngine;
using System.Collections;

public class BossPathPlayer : MonoBehaviour {
	public int pathTime = 20;
	public bool once;
	public bool boss;
	public bool resume;
	public GameObject Scenario5;
	public GameObject Boss;
	public GameObject SoundManager;
	public GameObject Turtle;
	public GameObject Fade;

	// Use this for initialization
	void Start () {
		once = false;
		boss = false;
		resume = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Boss.transform.position.z < -2300 && !resume) {
			SoundManager.GetComponent<SoundManager> ().SetSound(0,true,2);
			Scenario5.SetActive (true);
			iTween.Pause (Boss);
		}
		if (Scenario5.GetComponent<ScriptController> ().Flag){
			if (!once) {
				resume = true;
				iTween.Resume (Boss);
				iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Boss Path Player"), "time", pathTime, "orienttopath", true, "easetype", iTween.EaseType.linear));
				once = true;
			}
		
		}
		if (Turtle.transform.position.z < -3990) {
			Fade.GetComponent<FadeManager> ().SetFade(true);
		}

	}
}
