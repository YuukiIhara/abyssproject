using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Turtle").transform.position.z < 12.0) {
			rb.isKinematic = false;
		}
	}
}
