using UnityEngine;
using System.Collections;

public class MoveBreaker : MonoBehaviour {
	public bool ByRock = false;
	public GameObject Scenario3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Turtle").transform.position.z < 23.5) {
			Scenario3.SetActive (true);
		}
		if (GameObject.Find ("Scenario1_02").GetComponent<ScriptController> ().Flag){
			//ByRock = true;
			GameObject.Find ("Tap").GetComponent<TapManager> ().SetTapFlag(true);

		}
		if (ByRock) {
			Vector3 position = this.transform.position;
			position.z-=0.5f;
			this.transform.position = position;
			if (this.transform.position.z < 10) {
				GameObject.Find ("BreakableRock").GetComponent<BreakRock> ().PathClear = true;
				Object.Destroy (this.gameObject);
			}
		}
	}
}
