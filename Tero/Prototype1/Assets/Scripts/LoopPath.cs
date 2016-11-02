using UnityEngine;
using System.Collections;

public class LoopPath : MonoBehaviour {

	// Use this for initialization
	void Start () {

		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Loop"), "time", 5, "loopType", "loop", "orientToPath", true, "delay", 0, "easetype", iTween.EaseType.linear));


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
