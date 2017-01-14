using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class EnergyTank : MonoBehaviour {

	// リジッドボディ2Dの宣言
	new Rigidbody2D rigidbody2D;

	// AddForceを加える間隔
	public int nInterval;
	int i = 0;
	// Use this for initialization
	void Start () 
	{
		rigidbody2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(i % nInterval == 0)
		{
			rigidbody2D.AddForce(Vector2.right * Random.Range (-4.0f, 3.0f));
		}
	}
}
