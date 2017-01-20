using UnityEngine;
using System.Collections;

public class BossPathPlayer : MonoBehaviour {
	public bool once;
	public bool boss;

	// Use this for initialization
	void Start () {
		once = false;
		boss = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Boss").transform.position.z < -2300) {
			boss = true;
		}
		if (boss) {
			if (!once) {
				iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Boss Path Player"), "time", 20, "orienttopath", true, "easetype", iTween.EaseType.linear));
				once = true;
			}
		
		}
	}
}
