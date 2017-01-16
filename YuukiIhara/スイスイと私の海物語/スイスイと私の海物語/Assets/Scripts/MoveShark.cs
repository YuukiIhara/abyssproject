using UnityEngine;
using System.Collections;

public class MoveShark : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Turtle").transform.position.z < 12.0) {
			transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y,transform.position.z);

		}
		if (transform.position.x > 15) {
			Object.Destroy (this.gameObject);
		}

	}
}
