using UnityEngine;
using System.Collections;

public class Path1Turtle : MonoBehaviour
{
	public bool resume = false;
	public bool CoralGet = false;
	public bool once = false;
	// Use this for initialization
	void Start()
	{
		GameObject.Find ("SoundManager").GetComponent<SoundManager>().SetSound(6,true,2);
	}

	void Update()
	{
		//if (GameObject.Find ("Camera Player").GetComponent<Aim> ().FirstCoral) {
		if (GameObject.Find ("Scenario1_01").GetComponent<ScriptController> ().Flag) {
			CoralGet = true;
	
		}
		if (CoralGet) {
			
			if (!once) {
				iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Tutorial Path 1"), "time", 15, "orienttopath", true, "easetype", iTween.EaseType.linear));
				once = true;
			}
		}

	}
}
