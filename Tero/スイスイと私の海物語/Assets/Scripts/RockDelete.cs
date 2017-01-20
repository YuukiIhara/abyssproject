using UnityEngine;
using System.Collections;

public class RockDelete : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Turtle").transform.position.z < -3040) {
			Destroy(GameObject.FindWithTag("BossRock1"));
			Destroy(GameObject.FindWithTag("BossRock2"));
			Destroy(GameObject.FindWithTag("BossRock3"));
		}
		if (GameObject.Find ("Turtle").transform.position.z < -3500) {
			Destroy(GameObject.FindWithTag("BossRock4"));
		}
		if (GameObject.Find ("Turtle").transform.position.z < -3820) {
			Destroy(GameObject.FindWithTag("BossRock5"));
		}
	}
}
