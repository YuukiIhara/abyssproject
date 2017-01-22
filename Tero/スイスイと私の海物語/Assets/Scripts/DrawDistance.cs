using UnityEngine;
using System.Collections;

public class DrawDistance : MonoBehaviour {
	Camera camTarget;
	public bool fieldOff = false;
	public GameObject Anemone1;
	public GameObject Anemone2;
	public GameObject Anemone3;
	public GameObject Anemone4;

	// Use this for initialization
	void Start () {
		camTarget = GameObject.Find ("Camera Player").GetComponent<Camera>();
	

	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find ("Turtle").transform.position.z > 12.0f){
			Anemone1.SetActive(false);
			Anemone2.SetActive(false);
			Anemone3.SetActive(false);
			Anemone4.SetActive(false);
		}
		if (GameObject.Find ("Turtle").transform.position.z < 12.0 && GameObject.Find ("Turtle").transform.position.z > -100) {
			camTarget.farClipPlane = 2000;
			Anemone1.SetActive(true);
			Anemone2.SetActive(true);
			Anemone3.SetActive(true);
			Anemone4.SetActive(true);
		}
		if (GameObject.Find ("Turtle").transform.position.z < -100.0 && GameObject.Find ("Turtle").transform.position.z > -1840) {
			camTarget.farClipPlane = 1000;
		}
		if (GameObject.Find ("Turtle").transform.position.z < -10.0) {
			Destroy (GameObject.FindWithTag ("Tutorial"));
		}
		if (GameObject.Find ("Turtle").transform.position.z < -1845 && GameObject.Find ("Turtle").transform.position.z > -2000) {
			camTarget.farClipPlane = 300;
			if (!fieldOff) {
				//GameObject.FindWithTag ("Field").SetActive (false);
				fieldOff = true;
			}
		}
		if (GameObject.Find ("Turtle").transform.position.z < -2000) {
			camTarget.farClipPlane = 600;
		}

	}
}
