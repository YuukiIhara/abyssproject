using UnityEngine;
using System.Collections;



public class Crosshair : MonoBehaviour {
	public Texture cross;
	float width = 50;
	float height =50;
	void OnGUI(){
		GUI.DrawTexture(new Rect((Screen.width/2) - (width/2),(Screen.height/2) - (height/2), width,height), cross);
	}


	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {

	}
}
