#pragma strict

var radius = 5.0;
var power = 10.0;
function Update () {
    if(BreakWall.WallExp == true)
    {
    // Applies an explosion force to all nearby rigidbodies
    var explosionPos : Vector3 = transform.position;
    var colliders : Collider[] = Physics.OverlapSphere (explosionPos, radius);
    
    for (var hit : Collider in colliders) {
        if (!hit)
            continue;
        
        if (hit.GetComponent.<Rigidbody>())
            hit.GetComponent.<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0);
    }
}
}