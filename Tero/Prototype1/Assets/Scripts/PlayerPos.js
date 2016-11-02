#pragma strict
static var Wall : boolean = false;

function Start () {
    Debug.Log("NotWall");
}

function Update () {
    if (transform.position.z > 89.0f)
    {
        Wall = true;

    }
    if (Wall)
    {
        //Debug.Log("Wall");
    }
}