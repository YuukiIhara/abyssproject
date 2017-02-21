using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	public Rigidbody rb;
	private bool bgm = false;
	public GameObject Turtle;
	public GameObject SoundManager;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		if (Turtle.transform.position.z < 12.0) {
			rb.isKinematic = false;
			if (!bgm) {
				SoundManager.GetComponent<SoundManager> ().SetSound(6,true,1);
				bgm = true;
			}
		}
	}
}
