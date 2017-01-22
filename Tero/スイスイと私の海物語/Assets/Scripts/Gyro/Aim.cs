﻿using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {
	private float distance = 200.0f;
	public bool FirstCoral = false;
	// Update is called once per frame
	public GameObject Effect;
	public GameObject Scenario1;
	public GameObject Scenario2;

		void Update(){
		Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
		RaycastHit hit;
		if (GameObject.Find ("Scenario1_00").GetComponent<ScriptController> ().Flag) {
			
			if (Physics.Raycast (ray, out hit, distance)) {
				if (GameObject.Find ("Meter").GetComponent<MeterController> ().SetHit (hit.collider.tag == "FirstCoral")) {
					FirstCoral = true;
					Scenario2.SetActive (true);
					if (hit.transform.gameObject.tag == "FirstCoral") {
						Instantiate (Effect, hit.transform.position, Quaternion.identity);
						Destroy (hit.transform.gameObject);
						GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ().AddScore(150);
					}
				}
				//if (FirstCoral && GameObject.Find ("Meter").GetComponent<MeterController> ().SetHit (hit.collider.tag == "Coral")) {
				if (FirstCoral) {
					if (hit.transform.gameObject.tag == "Coral") {
						Instantiate (Effect, hit.transform.position, Quaternion.identity);
				
						Destroy (hit.transform.gameObject);
						GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ().AddScore(150);
					}
				}
			}
		}
	}
	}

