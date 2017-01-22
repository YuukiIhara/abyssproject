using UnityEngine;
using System.Collections;

public class ResultTurtle : MonoBehaviour {
	public bool moved = false;
	public bool once = false;
	private bool bgm = false;
	public GameObject Scenario6;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Turtle").transform.position.z < -3730) {

			if (!bgm) {
				GameObject.Find ("SoundManager").GetComponent<SoundManager>().SetSound(0,true,1);
				bgm = true;
			}
		}
		if (GameObject.Find ("Fade").GetComponent<FadeManager> ().GetFadeOutFlag ()) {
			GameObject.Find ("SoundManager").GetComponent<SoundManager> ().SetSound(4,true,2);
			GameObject.Find ("Fade").GetComponent<FadeManager> ().SetFade(false);
			GameObject.Find ("Turtle").transform.position = new Vector3 (-220,-322,-633);
			moved = true;
			GameObject.FindWithTag ("Field").SetActive(true);
			Scenario6.SetActive (true);
		}
		if (moved) {
			if (!once) {
				iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Fish Path 1"), "time", 30, "loopType", "loop", "orientToPath", true, "delay", 0, "easetype", iTween.EaseType.linear));
				once = true;
			}
		}
	}
}
