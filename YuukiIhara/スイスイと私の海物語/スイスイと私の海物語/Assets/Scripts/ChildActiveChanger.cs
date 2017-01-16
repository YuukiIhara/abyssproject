using UnityEngine;
using System.Collections;

public class ChildActiveChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeActive(bool flag)
	{
		transform.GetChild(1).gameObject.SetActive (flag);
//		foreach (Transform child in transform)
//		{
//			child.gameObject.SetActive (flag);
//		}
	}
}
