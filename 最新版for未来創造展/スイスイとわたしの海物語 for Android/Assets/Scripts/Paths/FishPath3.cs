using UnityEngine;
using System.Collections;

public class FishPath3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Fish Path 3"), "time", 10, "loopType", "loop", "orientToPath", true, "delay", 0, "easetype", iTween.EaseType.linear));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
