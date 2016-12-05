//blank style so screen button doesnt show up
var blankStyle : GUIStyle;
static var WallExp : boolean = false;     
var buttonPressed = false;
var x = true;    
var tapcount : int=0;
var WallCheck = false;


function OnGUI () {
   //GUI.Label(new Rect(100,100,200,50), "Count: " + tapcount);
    
    //button is screen size and has a blank gui style
    //this \/ must be at the bottom so the other buttons can disable its use
    if (GUI.Button(Rect(0,0, Screen.width, Screen.height), "", blankStyle))
    {
 
        if(PlayerPos.Wall == true && tapcount<5)
        {

            Debug.Log("Wall2");

            if(!buttonPressed)
            {
                //do stuff for touching screen
                tapcount++;
                if(tapcount==5){
                    WallExp=true;
                }
            }else
            {
                buttonPressed = false;
            }
        }
    }

}