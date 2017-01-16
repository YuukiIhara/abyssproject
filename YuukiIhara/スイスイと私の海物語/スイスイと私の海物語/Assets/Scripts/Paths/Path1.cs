using UnityEngine;
using System.Collections;

public class Path1 : MonoBehaviour
{

	// Use this for initialization

	void Start()
	{
		//iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Tutorial Path 1"), "time", 15, "easetype", iTween.EaseType.linear));
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Tutorial Path 1"), "time", 15, "orienttopath", true,"easetype", iTween.EaseType.linear,"delay",1));
	}
}
