using UnityEngine;
using System.Collections;

public class TitlePathTurtle : MonoBehaviour
{
	public bool once = false;
	// Use this for initialization

	void Update()
	{
		if (!once) {
			iTween.MoveTo (gameObject, 
				iTween.Hash ("path", 
					iTweenPath.GetPath ("TitlePathTurtle"), 
					"time", 
					30, 
					"loopType", 
					"loop", 
					"orienttopath", 
					true, 
					"delay", 
					0, 
					"easetype", 
					iTween.EaseType.linear));
				once = true;
		}
	}
}
