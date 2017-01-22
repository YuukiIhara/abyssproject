using UnityEngine;
using System.Collections;

public class Path3Turtle : MonoBehaviour {
	public bool once;
	public bool edge;
	private bool bgm = false;
	public GameObject Scenario4;
	// Use this for initialization
	void Start () {
		once = false;
		edge = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Turtle").transform.position.z < -8) {
			Scenario4.SetActive (true);
			if (!bgm) {
				GameObject.Find ("SoundManager").GetComponent<SoundManager> ().SetSound(3,true,2);
				bgm = true;
			}
		}
		if (GameObject.Find ("Scenario1_04").GetComponent<ScriptController> ().Flag){
			if (!once) {
				iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Field Path 1"), "time", 60, "orienttopath", true, "easetype", iTween.EaseType.linear));
				once = true;
			}
		}
	}
}
