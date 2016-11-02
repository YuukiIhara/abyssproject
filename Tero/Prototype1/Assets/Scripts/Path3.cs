using UnityEngine;
using System.Collections;

public class Path3 : MonoBehaviour {
	private bool once = false;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.z>=105)
		{
			if (!once)
			{
				iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Path3"), "time", 10, "easetype", iTween.EaseType.linear));
				once = true;
			}
		}
	}
}
