using UnityEngine;
using System.Collections;

public class SharkCollision : MonoBehaviour {
	public Rigidbody rb;
	public MeshCollider mc;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		mc = GetComponent<MeshCollider> ();
		rb.AddForce(Physics.gravity * rb.mass);
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Shark") {
			rb.isKinematic = false;
			mc.isTrigger = false;

		}
	}
}
