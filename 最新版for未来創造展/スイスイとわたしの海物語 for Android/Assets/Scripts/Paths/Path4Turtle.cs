using UnityEngine;
using System.Collections;

public class Path4Turtle : MonoBehaviour {
	public int pathTime = 80;
	public bool once;
	public bool cave;
	private bool bgm = false;
	public GameObject Turtle;
	public GameObject SoundManager;
	// Use this for initialization
	void Start () {
		once = false;
		cave = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Turtle.transform.position.z < -1770) {
			cave = true;
		}
		if(Turtle.transform.position.z < -2100) {
			if (!bgm) {
				SoundManager.GetComponent<SoundManager> ().SetSound(3,true,1);
				bgm = true;
			}
		}
		if (cave) {
			if (!once) {
				iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Cave Path"), "time", pathTime, "orienttopath", true, "easetype", iTween.EaseType.linear));
				once = true;
			}
		}
	}
}
