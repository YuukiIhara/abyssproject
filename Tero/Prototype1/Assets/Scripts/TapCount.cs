using UnityEngine;
using System.Collections;

public class TapCount : MonoBehaviour {
    public int tap = 0;
    public bool tapped = false;
	public bool now = false;
    // Update is called once per frame
    void OnGUI()
    {
        //GUILayout.Label("Tap = " + tap);
    }
    void Update () {
        
        if (gameObject.transform.position.z > 89)
        {
			if (Input.touchCount > 0 && tap<5) {

				if(Input.GetTouch(0).phase == TouchPhase.Began){

					tap++;
				}
			}

            if (tap == 5)
            {
                tapped = true;
            }
        }
    }
}
