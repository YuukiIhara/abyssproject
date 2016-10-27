using UnityEngine;
using System.Collections;

public class Path1 : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Path1"), "time", 15,"easetype",iTween.EaseType.linear));
	}
	

}
