using UnityEngine;
using System.Collections;

public class Path4 : MonoBehaviour {
	private bool once = false;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.z>=311)
		{
			if (!once)
			{
				iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Path4"), "time", 25, "easetype", iTween.EaseType.linear));
				once = true;
			}
		}
	}
}
