using UnityEngine;
using System.Collections;

public class Path4Turtle : MonoBehaviour {
	public bool once;
	public bool cave;
	private bool bgm = false;
	// Use this for initialization
	void Start () {
		once = false;
		cave = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Turtle").transform.position.z < -1770) {
			cave = true;
		}
		if(GameObject.Find ("Turtle").transform.position.z < -2100) {
			if (!bgm) {
				GameObject.Find ("SoundManager").GetComponent<SoundManager> ().SetSound (3, true, 1);
				bgm = true;
			}
		}
		if (cave) {
			if (!once) {
				iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Cave Path"), "time", 70, "orienttopath", true, "easetype", iTween.EaseType.linear));
				once = true;
			}
		}
	}
}
