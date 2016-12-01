using UnityEngine;
using System.Collections;

public class Darkness : MonoBehaviour {
	public bool cave = false;
	void OnTriggerEnter( Collider other) {
		if(other.gameObject.tag == "Player") {
			//Do stuff here
			cave = true;
			GameObject.Find("Main Camera").GetComponent<UnderwaterFog>().cave = true;
		}
	}
}
