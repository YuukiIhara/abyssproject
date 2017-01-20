using UnityEngine;
using System.Collections;

public class FishPath1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Fish Path 1"), "time", 30, "loopType", "loop", "orientToPath", true, "delay", 0, "easetype", iTween.EaseType.linear));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
