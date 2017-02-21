using UnityEngine;
using System.Collections;

public class MoveBreaker : MonoBehaviour {
	public bool ByRock = false;
	public bool MoveRock = false;
	public bool tapped = false;
	public GameObject Scenario3;
	public GameObject Turtle;
	public GameObject BreakableRock;
	public GameObject TapManager;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Turtle.transform.position.z < 23.5) {
			Scenario3.SetActive (true);
		}
		if (Scenario3.GetComponent<ScriptController> ().Flag){
			//ByRock = true;

			if(!tapped)TapManager.GetComponent<TapManager> ().SetTapFlag(true);

			if (Input.touchCount > 0 || Input.GetMouseButton(0)) {
				MoveRock = true;
				TapManager.GetComponent<TapManager> ().SetTapFlag(false);
				tapped = true;
			}
			if(MoveRock){
				Vector3 position = this.transform.position;
				position.z-=0.5f;
				this.transform.position = position;
				if (this.transform.position.z < 10) {
					BreakableRock.GetComponent<BreakRock> ().PathClear = true;
					Object.Destroy (this.gameObject);
					MoveRock = false;
				}
			}
		}

	}
}
