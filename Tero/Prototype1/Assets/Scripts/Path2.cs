using UnityEngine;
using System.Collections;

public class Path2 : MonoBehaviour {
    private bool once = false;
    // Use this for initialization
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<TapCount>().tapped)
        {
            if (!once)
            {
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Path2"), "time", 5, "easetype", iTween.EaseType.linear));
                once = true;
            }
        }
    }
}
