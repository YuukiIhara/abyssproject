using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
 
    void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward*3000);
       // GetComponent<Rigidbody>().useGravity=true;
    }

}
