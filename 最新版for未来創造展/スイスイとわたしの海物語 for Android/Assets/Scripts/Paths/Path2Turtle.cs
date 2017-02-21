using UnityEngine;
using System.Collections;

public class Path2Turtle : MonoBehaviour
{
	public int pathTime = 15;
	public bool once = false;
	public bool Rock = false;
	public GameObject BreakableRock;
	// Use this for initialization
	void Start()
	{ 

	}
	void Update()
	{
		if (BreakableRock.GetComponent<BreakRock> ().PathClear) {
			Rock = true;
		}
		if (Rock) {
			if (!once) {
				iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Tutorial Path 2"), "time", pathTime, "orienttopath", true, "easetype", iTween.EaseType.linear));
				once = true;
			}
		}
	}

}
