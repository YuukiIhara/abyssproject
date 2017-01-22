using UnityEngine;
using System.Collections;

public class BossPathPlayer : MonoBehaviour {
	public bool once;
	public bool boss;
	public bool resume;
	public GameObject Scenario5;

	// Use this for initialization
	void Start () {
		once = false;
		boss = false;
		resume = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Boss").transform.position.z < -2300 && !resume) {
			GameObject.Find ("SoundManager").GetComponent<SoundManager> ().SetSound (0, true, 2);
			Scenario5.SetActive (true);
			iTween.Pause (GameObject.Find("Boss"));
		}
		if (GameObject.Find ("Scenario2_01").GetComponent<ScriptController> ().Flag){
			if (!once) {
				resume = true;
				iTween.Resume (GameObject.Find("Boss"));
				iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Boss Path Player"), "time", 20, "orienttopath", true, "easetype", iTween.EaseType.linear));
				once = true;
			}
		
		}
		if (GameObject.Find ("Turtle").transform.position.z < -3990) {
			GameObject.Find ("Fade").GetComponent<FadeManager> ().SetFade(true);
		}

	}
}
