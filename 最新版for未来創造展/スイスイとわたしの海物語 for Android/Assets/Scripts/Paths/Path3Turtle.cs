using UnityEngine;
using System.Collections;

public class Path3Turtle : MonoBehaviour {
	public int pathTime = 60;
	public bool once;
	public bool edge;
	private bool bgm = false;
	public GameObject Scenario4;
	public GameObject Turtle;
	public GameObject SoundManager;
	// Use this for initialization
	void Start () {
		once = false;
		edge = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Turtle.transform.position.z < -8) {
			Scenario4.SetActive (true);
			if (!bgm) {
				SoundManager.GetComponent<SoundManager> ().SetSound(3,true,2);
				bgm = true;
			}
		}
		if (Scenario4.GetComponent<ScriptController> ().Flag){
			if (!once) {
				iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Field Path 1"), "time", pathTime, "orienttopath", true, "easetype", iTween.EaseType.linear));
				once = true;
			}
		}
	}
}
