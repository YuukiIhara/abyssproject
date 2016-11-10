#pragma strict
 
// ONLY ANDROID NOT PC NOT IOS
// Attach this script to the Main Camera
// It raycasts from camera and destroies objects if you will touch them
 
var speed : float = 4;
var hit = new RaycastHit();
 
function Update () {
 
    // se c'è un tocco Input.touchCount AND la fase del tocco è quella iniziale TouchPhase.Began
   // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
        // traccia i raggi dalla Camera dal punto del tocco
       // var ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
        var ray = Camera.main.ScreenPointToRay (new Vector3(Screen.width/2, Screen.height/2, 0));
        // se raycast colpisce l'oggetto
        if (Physics.Raycast (ray, hit)) {
            
            if (hit.collider.tag == "Destroy"){
                // Destroy Object
                //Destroy(hit.transform.gameObject);
            
                //Change Color
                hit.transform.gameObject.GetComponent.<Renderer>().material.color = Color.red;
            }
        }
 
   // }
}