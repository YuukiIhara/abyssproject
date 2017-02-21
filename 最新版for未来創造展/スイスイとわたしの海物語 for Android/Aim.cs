using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {
	private float distance = 200.0f;
	public bool FirstCoral = false;
	// Update is called once per frame
	public GameObject Effect;
	public GameObject Scenario1;
	public GameObject Scenario2;
	public GameObject ResultTurtle;

	// Meterの変数宣言
	GameObject Meter;
	// Scenario1_00の変数宣言
	GameObject Scenario1_00;
	// ScoreManagerの変数宣言
	GameObject ScoreManager;
	// SoundManagerの変数宣言
	GameObject SoundManager;

	void Start ()
	{
		// Meterの初期化
		Meter = GameObject.Find ("Meter");
		// Scenario1_00の初期化
		Scenario1_00 = GameObject.Find ("Scenario1_00");
		// ScoreManagerの初期化
		ScoreManager = GameObject.Find ("ScoreManager");
		// SoundManagerの初期化
		SoundManager = GameObject.Find ("SoundManager");
	}

	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
		RaycastHit hit;
		if (Scenario1_00.GetComponent<ScriptController> ().Flag)
		{
			if (Physics.Raycast (ray, out hit, distance))
			{
				//if (Meter.GetComponent<MeterController> ().SetHit (hit.collider.tag == "FirstCoral"))
				{
					if (hit.collider.tag == "FirstCoral")
					{
						
						Scenario2.SetActive (true);
						if (hit.transform.gameObject.tag == "FirstCoral")
						{
							Instantiate (Effect, hit.transform.position, Quaternion.identity);
							Destroy (hit.transform.gameObject);
							ScoreManager.GetComponent<ScoreManager> ().AddScore (150);

							// サンゴ採集ESの再生
							SoundManager.GetComponent<SoundManager>().SetSound(9,true,0);
							//SoundManager.GetComponent<SoundManager>().SetSound(8,true,0);
						}
					}
				}

				//if (FirstCoral && Meter.GetComponent<MeterController> ().SetHit (hit.collider.tag == "Coral"))
				{
					if (FirstCoral && !ResultTurtle.GetComponent<ResultTurtle>().once) 
					{
						if (hit.transform.gameObject.tag == "Coral")
						{
							Instantiate (Effect, hit.transform.position, Quaternion.identity);
				
							Destroy (hit.transform.gameObject);
							ScoreManager.GetComponent<ScoreManager> ().AddScore (150);

							// サンゴ採集ESの再生
							SoundManager.GetComponent<SoundManager>().SetSound(9,true,0);
						}
					}
				}
			}
		}
	}
}

