using UnityEngine;
using System.Collections;

public class RockDelete : MonoBehaviour {
	public GameObject Turtle;
	public GameObject BossRock1;
	public GameObject BossRock2;
	public GameObject BossRock3;
	public GameObject BossRock4;
	public GameObject BossRock5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Turtle.transform.position.z < -3040) {
			Destroy(BossRock1);
			Destroy(BossRock2);
			Destroy(BossRock3);
		}
		if (Turtle.transform.position.z < -3500) {
			Destroy(BossRock4);
		}
		if (Turtle.transform.position.z < -3820) {
			Destroy(BossRock5);
		}
	}
}
