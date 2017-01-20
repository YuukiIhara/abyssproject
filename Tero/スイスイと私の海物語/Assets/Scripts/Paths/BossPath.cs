 using UnityEngine;
using System.Collections;

public class BossPath : MonoBehaviour {
	public bool boss;
	public bool once;
	// Use this for initialization
	void Start () {
		once = false;
		boss = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Turtle").transform.position.z < -2634) {
			if (!once) {
				iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Boss Path"), "time", 25, "orienttopath", true, "easetype", iTween.EaseType.linear));
				once = true;
			}
		}
	}
}
