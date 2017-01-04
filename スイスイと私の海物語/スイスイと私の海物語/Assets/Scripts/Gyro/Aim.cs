using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {
	private float distance = 100.0f;
	public bool FirstCoral = false;
	// Update is called once per frame

		void Update(){
		Ray ray =  Camera.main.ScreenPointToRay (new Vector3(Screen.width/2, Screen.height/2, 0));
			RaycastHit hit;
			if (Physics.Raycast (ray,out hit,distance))
			{
				if (hit.collider.tag == "FirstCoral") {
					FirstCoral = true;
					Destroy (hit.transform.gameObject);
				}
				if (FirstCoral && hit.collider.tag == "Coral") {
				
					Destroy (hit.transform.gameObject);
				}
			}
		}
	}

