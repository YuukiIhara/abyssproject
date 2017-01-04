using UnityEngine;
using System.Collections;

public class Path2Turtle : MonoBehaviour
{
	public bool once = false;
	public bool Rock = false;

	// Use this for initialization
	void Start()
	{ 

	}
	void Update()
	{
		if (GameObject.Find ("BreakableRock").GetComponent<BreakRock> ().PathClear) {
			Rock = true;
		}
		if (Rock) {
			if (!once) {
				iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Tutorial Path 2"), "time", 15, "orienttopath", true, "easetype", iTween.EaseType.linear));
				once = true;
			}
		}
	}

}
