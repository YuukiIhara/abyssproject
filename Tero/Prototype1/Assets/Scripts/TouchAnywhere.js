//blank style so screen button doesnt show up
var blankStyle : GUIStyle;
     
var buttonPressed = false;
var x = true;    
function OnGUI () {
    if (GUI.Button(Rect(0,0, 500, 500),"Test Button"))
    {
        buttonPressed = true;
    }
     
    //button is screen size and has a blank gui style
    //this \/ must be at the bottom so the other buttons can disable its use
    if (GUI.Button(Rect(0,0, Screen.width, Screen.height), "", blankStyle))
    {
        if(!buttonPressed)
        {
            //do stuff for touching screen
            if(x){
                transform.Translate(0,0,10);
                x=false;
            }
            else{
                transform.Translate(0,0,-10);
                x=true;
            }
            
        }else
        {
            buttonPressed = false;
        }
    }
}