using UnityEngine;
using System.Collections;

public class Path3Turtle : MonoBehaviour {
	public bool once;
	public bool edge;
	// Use this for initialization
	void Start () {
		once = false;
		edge = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Turtle").transform.position.z < -8) {
			edge = true;
		}
		if (edge) {
			if (!once) {
				iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Field Path 1"), "time", 40, "orienttopath", true, "easetype", iTween.EaseType.linear));
				once = true;
			}
		}
	}
}
